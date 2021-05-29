using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotTemplate.BO
{
    [Serializable]
    public class SettingsObj
    {
        #region Constructors

        public SettingsObj()
        {
            GlobalFramelock = false;
            AntiAfk = true;
            LogLevel = 3;
            MsPulseSleep = 34;
            UsedPlugins = new List<string>();
        }

        public SettingsObj(SettingsObj settings)
        {
            GlobalFramelock = settings.GlobalFramelock;
            AntiAfk = settings.AntiAfk;
            LogLevel = settings.LogLevel;
            MsPulseSleep = settings.MsPulseSleep;
            UsedPlugins = settings.UsedPlugins;
        }

        #endregion

        #region Props

        public bool GlobalFramelock
        {
            get;
            set;
        }

        public bool AntiAfk
        {
            get;
            set;
        }

        public int LogLevel
        {
            get;
            set;
        }

        public int MsPulseSleep
        {
            get;
            set;
        }

        public List<string> UsedPlugins
        {
            get;
            set;
        } 

        #endregion
    }
}
