using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using UserApi.Interfaces;

namespace BotTemplate.Managers
{
    internal static class PluginManager
    {

        #region Fields

        private static List<IPlugin> _plugins = new List<IPlugin>();
        private static List<IPlugin> _enabledPlugins = new List<IPlugin>();
        private static string _pluginDirectory = AppDomain.CurrentDomain.BaseDirectory + @"Plugins\";
        private static object _lock = new object();

        #endregion

        #region Properties

        public static List<IPlugin> Plugins
        {
            get
            {
                if (_plugins == null)
                    _plugins = new List<IPlugin>();

                return _plugins;
            }
            set
            {
                _plugins = value;
            }
        }

        #endregion

        #region Public Methods
        
        public static void EnablePlugin(IPlugin plugin)
        {
            lock (_lock)
            {
                if (!_enabledPlugins.Contains(plugin))
                    _enabledPlugins.Add(plugin);
            }
        }

        public static void DisablePlugin(IPlugin plugin)
        {
            lock (_lock)
            {
                if (_enabledPlugins.Contains(plugin))
                    _enabledPlugins.Remove(plugin);
            }
        }

        public static string LoadPlugins()
        {
            string returnString = string.Empty;

            lock (_lock)
            {
                _plugins.Clear();
                _enabledPlugins.Clear();

                Directory.CreateDirectory(_pluginDirectory);
                var subdirs = GetAllSubdirsOfDir(_pluginDirectory);
                foreach (string s in subdirs)
                {
                    var dlls = Directory.GetFiles(s, "*.dll");
                    if (dlls.Count() > 0)
                       LoadPluginFromDll(dlls.First());
                    else
                    {
                        var csFiles = GetAllCSFilesOfDirAndAllSubdirs(s).ToArray<string>();
                        if (csFiles.Count() > 0)
                            returnString += LoadPluginFromCs(csFiles);
                    }
                }

                return string.Empty;
            }
        }

        public static void PulseEnabledPlugins()
        {
            lock (_lock)
            {
                foreach (IPlugin p in _enabledPlugins)
                    p.Pulse();
            }
        }

        #endregion

        #region Private Methods

        private static string LoadPluginFromCs(string[] filenames)
        {
            var returnString = string.Empty;
            CompilerResults result = CompilePluginAssembly(filenames);

            if (result.Errors.HasErrors)
            {
                StringBuilder errors = new StringBuilder();

                foreach (CompilerError err in result.Errors)
                    errors.Append(string.Format("\r\n{0}({1},{2}): {3}: {4}", err.FileName, err.Line, err.Column, err.ErrorNumber, err.ErrorText));

                var exceptionString = "Error loading plugin:\r\n" + errors.ToString();
                Console.WriteLine(exceptionString);
                returnString = exceptionString;
            }
            else
                ValidateAndAddPlugin(result.CompiledAssembly);

            return returnString;
        }

        private static void LoadPluginFromDll(string filePath)
        {
            var dll = Assembly.LoadFile(filePath);
            ValidateAndAddPlugin(dll);
        }

        private static CompilerResults CompilePluginAssembly(string[] filenames)
        {
            CodeDomProvider codeDomProvider = CSharpCodeProvider.CreateProvider("CSharp");
            CompilerParameters compilerParams = new CompilerParameters();
            compilerParams.IncludeDebugInformation = true;
            compilerParams.GenerateExecutable = false;
            compilerParams.GenerateInMemory = true;

            var extAssembly = Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory),"BotTemplate.exe");
            compilerParams.ReferencedAssemblies.Add(extAssembly);
            compilerParams.ReferencedAssemblies.Add("System.dll");
            compilerParams.ReferencedAssemblies.Add("System.Xml.dll");
            compilerParams.ReferencedAssemblies.Add("System.Core.dll");
            compilerParams.ReferencedAssemblies.Add("System.Linq.dll");
            compilerParams.ReferencedAssemblies.Add("System.Data.dll");
            compilerParams.ReferencedAssemblies.Add("System.Drawing.dll");
            compilerParams.ReferencedAssemblies.Add("System.Windows.Forms.dll");

            return codeDomProvider.CompileAssemblyFromFile(compilerParams, filenames);
        }

        private static void ValidateAndAddPlugin(Assembly assembly)
        {
            try
            {
                foreach (Type type in assembly.GetTypes())
                {
                    if (!type.IsClass || type.IsNotPublic) continue;
                    Type[] interfaces = type.GetInterfaces();
                    if (((IList<Type>)interfaces).Contains(typeof(IPlugin)))
                    {
                        IPlugin plugin = (IPlugin)Activator.CreateInstance(type);
                        Plugins.Add(plugin);
                    }
                }
            }
            catch(Exception)
            {
                Console.WriteLine("The Plugin-Dll (" + assembly.FullName + ") seems to be outdated.");
            }
        }

        private static IEnumerable<string> GetAllCSFilesOfDirAndAllSubdirs(string dir)
        {
            List<string> files = new List<string>();
            files.AddRange(Directory.GetFiles(dir, "*.cs"));

            var subdirs = GetAllSubdirsOfDir(dir);
            foreach(string s in subdirs)
                files.AddRange(GetAllCSFilesOfDirAndAllSubdirs(s));

            return files;
        }

        private static IEnumerable<string> GetAllSubdirsOfDir(string dir)
        {
            List<string> subdirs = new List<string>();

            DirectoryInfo dInfo = new DirectoryInfo(dir);
            DirectoryInfo[] subdirsDirectoryInfos = dInfo.GetDirectories();

            foreach(DirectoryInfo di in subdirsDirectoryInfos)
                subdirs.Add(di.FullName);

            return subdirs;
        }

        #endregion
    }
}
