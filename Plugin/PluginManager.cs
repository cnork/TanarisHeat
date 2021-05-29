using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using BotTemplate.Interface;
//using System.Threading.Tasks;

namespace BotTemplate.Interface
{
    class PluginManager
    {
        string _appExecutablePath;
        IApiWrapper _apiWrapper;

        public PluginManager(string appExecutablePath, IApiWrapper apiWrapper)
        {
            _appExecutablePath = appExecutablePath;
            _apiWrapper = apiWrapper;
            Plugins = new List<IPlugin>();
        }

        public List<IPlugin> Plugins{ get; set; }

        public void LoadPlugin(string filePath)
        {
            CompilerResults result = CompilePlugin(filePath);

            if (result.Errors.HasErrors)
            {
                StringBuilder errors = new StringBuilder();
                string filename = Path.GetFileName(filePath);
                foreach (CompilerError err in result.Errors)
                {
                    errors.Append(string.Format("\r\n{0}({1},{2}): {3}: {4}",
                                filename, err.Line, err.Column,
                                err.ErrorNumber, err.ErrorText));
                }
                string str = "Error loading script\r\n" + errors.ToString();
                throw new ApplicationException(str);
            }

            GetPlugins(result.CompiledAssembly);
        }

        private CompilerResults CompilePlugin(string filepath)
        {
            string language = CSharpCodeProvider.GetLanguageFromExtension(
                                      Path.GetExtension(filepath));
            CodeDomProvider codeDomProvider =
                              CSharpCodeProvider.CreateProvider(language);
            CompilerParameters compilerParams = new CompilerParameters();
            compilerParams.GenerateExecutable = false;
            compilerParams.GenerateInMemory = true;
            compilerParams.IncludeDebugInformation = true;
            
            string extAssembly = Path.Combine(
                         Path.GetDirectoryName(_appExecutablePath),
                          "BotTemplate.exe");
            compilerParams.ReferencedAssemblies.Add(extAssembly);
            compilerParams.ReferencedAssemblies.Add("System.dll");
            compilerParams.ReferencedAssemblies.Add("System.Linq.dll");
            compilerParams.ReferencedAssemblies.Add("System.Drawing.dll");
            compilerParams.ReferencedAssemblies.Add("System.Windows.Forms.dll");
            return codeDomProvider.CompileAssemblyFromFile(compilerParams,
                                                           filepath);
        }

        private void GetPlugins(Assembly assembly)
        {
            foreach (Type type in assembly.GetTypes())
            {
                if (!type.IsClass || type.IsNotPublic) continue;
                Type[] interfaces = type.GetInterfaces();
                if (((IList<Type>)interfaces).Contains(typeof(IPlugin)))
                {
                    IPlugin plugin = (IPlugin)Activator.CreateInstance(type);
                    plugin.Initialize(_apiWrapper);

                    Plugins.Add(plugin);
                }
            }
        }
    }
}
