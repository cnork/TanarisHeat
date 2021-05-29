using BotTemplate.BO;
using BotTemplate.Helper;
using BotTemplate.Helper.Xml;
using BotTemplate.Hooks;
using BotTemplate.Managers;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Utilities;

namespace BotTemplate
{
    internal static class Bot
    {
        #region DllImports

        [DllImport("kernel32.dll")]
        internal static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        internal static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        internal static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        internal static extern IntPtr VirtualAllocEx(IntPtr hProcess,
            IntPtr lpAddress,
            uint dwSize,
            uint flAllocationType,
            uint flProtect);

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool WriteProcessMemory(IntPtr hProcess,
            IntPtr lpBaseAddress,
            byte[] lpBuffer,
            uint nSize,
            out UIntPtr lpNumberOfBytesWritten);

        [DllImport("kernel32.dll")]
        internal static extern IntPtr CreateRemoteThread(IntPtr hProcess,
            IntPtr lpThreadAttributes,
            uint dwStackSize,
            IntPtr lpStartAddress,
            IntPtr lpParameter,
            uint dwCreationFlags,
            IntPtr lpThreadId);


        [DllImport("kernel32", SetLastError = true, ExactSpelling = true)]
        internal static extern Int32 WaitForSingleObject(
            IntPtr handle,
            Int32 milliseconds
            );

        #endregion

        #region Fields

        // privileges
        const int PROCESS_CREATE_THREAD = 0x0002;
        const int PROCESS_QUERY_INFORMATION = 0x0400;
        const int PROCESS_VM_OPERATION = 0x0008;
        const int PROCESS_VM_WRITE = 0x0020;
        const int PROCESS_VM_READ = 0x0010;

        // used for memory allocation
        const uint MEM_COMMIT = 0x00001000;
        const uint MEM_RESERVE = 0x00002000;
        const uint PAGE_READWRITE = 4;

        // other stuff
        private static Thread _pulseThread;
        private static bool _pulseThreadShouldStop;

        // Setting Directory Path
        private static string _settingDirectory = AppDomain.CurrentDomain.BaseDirectory + @"Settings\";
        private static string _defaultSettingsDirectory = _settingDirectory + @"Default\";

        #endregion

        #region Singleton

        //private static Bot _instance;
        //private static object _syncRoot = new object();

        //private Bot()
        //{
        //    StartExceptionLogger();
        //    InitWardenProtection();
        //    StartPulseThread();
        //}

        //internal static Bot Instance
        //{
        //    get
        //    {
        //        if (_instance == null)
        //        {
        //            lock (_syncRoot)
        //            {
        //                if (_instance == null)
        //                    _instance = new Bot();
        //            }
        //        }

        //        return _instance;
        //    }
        //}

        #endregion

        #region Constructor

        static Bot()
        {
            StartExceptionLogger();
            InitWardenProtection();
            StartPulseThread();
            LoadSettings();
            PluginManager.LoadPlugins();
        }

        #endregion

        #region Properties

        internal static SettingsObj Settings
        {
            get;
            set;
        }

        internal static bool PulseEnabled
        {
            get;
            set;
        }

        #endregion

        #region Public Methods

        internal static void SaveSettings()
        {
           string settingsFileName;

            if (WoW.Online)
                settingsFileName = CreateSettingsPath();
            else
            {
                if (!Directory.Exists(_defaultSettingsDirectory))
                    Directory.CreateDirectory(_defaultSettingsDirectory);

                settingsFileName = _defaultSettingsDirectory + "Settings.xml";
            }

            XmlSave.SaveData(Settings, settingsFileName);
        }

        internal static void LoadSettings()
        {
            string settingsFileName;

            if (WoW.Online)
                settingsFileName = CreateSettingsPath();
            else
                settingsFileName = _defaultSettingsDirectory;

            if (File.Exists(settingsFileName))
            {
                XmlLoad<SettingsObj> loader = new XmlLoad<SettingsObj>();
                Settings = loader.LoadData(settingsFileName);
            }
            else
            {
                Settings = new SettingsObj();
                SaveSettings();
            }
        }

        internal static void WriteLogMessage(string message, UserApi.Enums.LogLevel logLevel = UserApi.Enums.LogLevel.Information)
        {
            Logger.Instance.WriteLogMessage(message, logLevel);
        }

        internal static void WriteToConsole(string message)
        {
            Logger.Instance.WriteLogMessage(message, UserApi.Enums.LogLevel.Information);
        }

        internal static void ClearConsole()
        {
            Logger.Instance.ClearLogMessages();
        }

        internal static void Close()
        {
            _pulseThreadShouldStop = true;

            while (_pulseThread.ThreadState != System.Threading.ThreadState.Stopped)
            {
                // wait for thread to be done
            }

            D3DHook.DisposeEndsceneHook();
            MemoryManager.DisposeMemory();

            Environment.Exit(0);
        }

        internal static void Initialize()
        {
            // empty method to assure an instance is active
        }
        
        #endregion

        #region Private Methods

        private static string CreateSettingsPath()
        {
            string directory = _settingDirectory + WoW.RealmName + "\\";
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            return string.Format("{0}Settings_{1}.xml", directory, WoW.LocalPlayer.Name);
        }

        private static void StartExceptionLogger()
        {
            ExceptionLogger logger = new ExceptionLogger();
            logger.AddLogger(new TextFileLogger());
        }

        private static void StartPulseThread()
        {
            _pulseThread = new Thread(new ThreadStart(MainPulse));
            _pulseThread.Start();
            _pulseThreadShouldStop = false;
            PulseEnabled = false;
        }

        private static void MainPulse()
        {
            while (!_pulseThreadShouldStop)
            {
                if (PulseEnabled)
                {
                    if (Settings.GlobalFramelock)
                        D3DHook.EnableFramelock();

                    try
                    {
                        PluginManager.PulseEnabledPlugins();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error: " +e.Message+ Environment.NewLine + e.StackTrace);
                    }
                    finally
                    {
                        if (Settings.GlobalFramelock)
                            D3DHook.DisableFramelock();
                    }
                }

                Logger.Instance.SendMessagesToConsoleControls();

                if (Settings.AntiAfk)
                    MemoryManager.BlackMagic.WriteUInt(0x00B499A4, MemoryManager.BlackMagic.ReadUInt(0x00B1D618));

                Thread.Sleep(Settings.MsPulseSleep);
            }

            Console.WriteLine("Pulse thread closed.");
        }

        #region Warden Protection

        private static void InitWardenProtection()
        {
            Process p = Process.GetProcessById(MemoryManager.BlackMagic.ProcessId);
            if (!checkDLL())
            {
                Console.WriteLine("Protect");
                inject(p);
                if (!checkDLL())
                    Environment.Exit(0);
            }

            Console.WriteLine("Protection done");
        }

        private static bool checkDLL()
        {
            //            Process[] process = Process.GetProcessesByName("WoW");
            Process process = Process.GetProcessById(MemoryManager.BlackMagic.ProcessId);
            Console.WriteLine("Checking Protection");

            foreach (ProcessModule module in process.Modules)
            {
                //Console.WriteLine(module.FileName);
                if (module.FileName.Contains("WardenProtection.dll"))
                    return true;
            }

            return false;
        }

        private static int inject(Process tProcess)
        {
            Process targetProcess = tProcess;
            string dllName = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\WardenProtection.dll";
            if (!File.Exists(dllName))
            {
                Console.WriteLine("Dll Missing");
                Console.ReadKey();
                Environment.Exit(0);
            }

            IntPtr procHandle = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ, false, targetProcess.Id);
            IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            IntPtr allocMemAddress = VirtualAllocEx(procHandle, IntPtr.Zero, (uint)((dllName.Length + 1) * Marshal.SizeOf(typeof(char))), MEM_COMMIT | MEM_RESERVE, PAGE_READWRITE);
            UIntPtr bytesWritten;
            WriteProcessMemory(procHandle, allocMemAddress, Encoding.Default.GetBytes(dllName), (uint)((dllName.Length + 1) * Marshal.SizeOf(typeof(char))), out bytesWritten);
            CreateRemoteThread(procHandle, IntPtr.Zero, 0, loadLibraryAddr, allocMemAddress, 0, IntPtr.Zero);
            Thread.Sleep(200);
            return 0;
        } 

        #endregion

        #endregion
    }
}
