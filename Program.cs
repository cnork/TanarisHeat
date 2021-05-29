using System;
using System.Windows.Forms;
using BotTemplate.GUI.Forms;
using System.Runtime.InteropServices;
using Utilities;
using BotTemplate.Helper;
using BotTemplate.Hooks;
using BotTemplate.Managers;
using System.Net;
using Magic;

namespace BotTemplate
{
    static class Program
    {
        #region DLL Imports

        [DllImport("kernel32.dll")]
        private static extern bool SetConsoleCtrlHandler(EventHandler handler, bool add);

        #endregion

        #region Fields

        private delegate bool EventHandler(CtrlType sig);
        static EventHandler _handler;
        static MainForm _testForm;

        #endregion

        #region ControlType

        enum CtrlType
        {
            CTRL_C_EVENT = 0,
            CTRL_BREAK_EVENT = 1,
            CTRL_CLOSE_EVENT = 2,
            CTRL_LOGOFF_EVENT = 5,
            CTRL_SHUTDOWN_EVENT = 6
        }

        #endregion

        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //CheckAccess();
         
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Bot.Initialize();
            
            // show main form
            _testForm = new MainForm();
            Application.Run(_testForm);

            // Cleanup and Close
            Console.WriteLine("Press any key to close...");
            //Console.ReadKey();
            Bot.Close();
            Environment.Exit(0);
        }

        private static void CheckAccess()
        {
            WebClient c = new WebClient();
            c.Proxy = null;
            if (c.DownloadString("http://109.73.237.163/morpheus/BT.html") != "true") Environment.Exit(0);
            _handler += new EventHandler(Handler);
            SetConsoleCtrlHandler(_handler, true);
        }

        #region Event Handlers

        private static bool Handler(CtrlType sig)
        {
            switch (sig)
            {
                case CtrlType.CTRL_C_EVENT:
                case CtrlType.CTRL_LOGOFF_EVENT:
                    break;
                case CtrlType.CTRL_SHUTDOWN_EVENT:
                case CtrlType.CTRL_CLOSE_EVENT:
                    Bot.Close();
                    break;
                default:
                    return false;
            }

            return true;
        }

        #endregion
    }
}
