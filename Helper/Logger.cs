using BotTemplate.BO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace BotTemplate.Helper
{
    internal class Logger : Control
    {
        #region Fields

        private List<string> _logMesssages = new List<string>();
        private string _logDirPath = AppDomain.CurrentDomain.BaseDirectory + @"Logs\";
        private string _logFileName;
        private bool _newMessages;
        private object _lock = new object();

        #endregion

        #region Singleton Stuff

        private static volatile Logger _inctance;
        private static object _syncRoot = new object();

        private Logger()
        {
            Initialize();
        }

        internal static Logger Instance
        {
            get
            {
                if (_inctance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_inctance == null)
                            _inctance = new Logger();
                    }
                }

                return _inctance;
            }
        }
   
        #endregion

        #region Delegates n Events

        private WriteToConsoleHandler fireLogMessageDelegate;
        internal event WriteToConsoleHandler WriteToConsoleEvent;
        internal delegate void WriteToConsoleHandler(string message);

        #endregion

        #region Public Methods

        internal void WriteLogMessage(string message, UserApi.Enums.LogLevel level)
        {
            lock (_lock)
            {
                if (level != UserApi.Enums.LogLevel.Off && (int)level <= Bot.Settings.LogLevel)
                {
                    _newMessages = true;

                    message = string.Format("[{0}] {1}", DateTime.Now.ToShortTimeString(), message);
                    _logMesssages.Insert(0, message);
                    WriteMessageToFile(message);

                    while (_logMesssages.Count > 200)
                    {
                        _logMesssages.RemoveAt(_logMesssages.Count - 1);
                    }
                }
            }
        }

        internal void ClearLogMessages()
        {
            lock (_lock)
            {
                _newMessages = true;
                _logMesssages.Clear();
            }
        }

        internal void SendMessagesToConsoleControls()
        {
            lock (_lock)
            {
                if (_newMessages)
                {
                    var textToWrite = string.Empty;
                    foreach (string s in _logMesssages)
                    {
                        textToWrite += s + Environment.NewLine;
                    }

                    this.Invoke(this.fireLogMessageDelegate, textToWrite);

                    _newMessages = false;
                }
            }
        }

        #endregion

        #region Private Methods

        private void WriteMessageToFile(string message)
        {
            File.AppendAllText(_logFileName, (message + Environment.NewLine));
        }

        private void Initialize()
        {
            _newMessages = false;

            if (!Directory.Exists(_logDirPath))
                Directory.CreateDirectory(_logDirPath);

            _logFileName = string.Format("{0}Log{1}.txt", _logDirPath, DateTime.Now.ToString("yyyy.MM.dd HH-mm-ss"));
            File.WriteAllText(_logFileName, string.Empty);

            this.CreateControl();

            fireLogMessageDelegate = SendToConsoleHandler;
        }

        #endregion

        #region Event Handlers

        private void SendToConsoleHandler(string message)
        {
            if (WriteToConsoleEvent != null)
                WriteToConsoleEvent(message);
        }

        #endregion

    }
}
