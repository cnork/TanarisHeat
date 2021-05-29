using BotTemplate.Hooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core = BotTemplate;

namespace UserApi
{
    public static class Bot
    {

        #region Props

        public static bool GlobalFramelock
        {
            get
            {
                return Bot.GlobalFramelock;
            }
            set
            {
                Bot.GlobalFramelock = value;
            }
        }

        public static bool PulseEnabled
        {
            get
            {
                return Bot.PulseEnabled;
            }
            set
            {
                Bot.PulseEnabled = value;
            }
        }
        #endregion

        #region Methods

        public static void WriteLogMessage(string message, Enums.LogLevel level = Enums.LogLevel.Information)
        {
            Core.Bot.WriteLogMessage(message, level);
        }

        public static void WriteToConsole(string message)
        {
            Core.Bot.WriteToConsole(message);
        }

        public static void ClearConsole()
        {
            Core.Bot.ClearConsole();
        }

        public static void EnableFramelock()
        {
            D3DHook.EnableFramelock();
        }

        public static void DisableFramelock()
        {
            D3DHook.DisableFramelock();
        }

        public static void Close()
        {
            Core.Bot.Close();
        }

        #endregion

    }
}
