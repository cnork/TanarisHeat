using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApi;
using UserApi.Interfaces;
using UserApi.Managers;

namespace FishingPlugin
{
    public class Plugin : IPlugin
    {
        private Fisher _fisher = new Fisher();

        public string Description
        {
            get
            {
                return "just dumbly tries to fish";
            }
        }

        public string Name
        {
            get
            {
                return "Fisher";
            }
        }

        public Enums.PluginType PluginType
        {
            get
            {
                return Enums.PluginType.Utility;
            }
        }

        public string Version
        {
            get
            {
                return "1";
            }
        }

        public void Close()
        {
            //
        }

        public void OpenForm()
        {
            //
        }

        public void Pulse()
        {
            _fisher.Pulse();   
        }


    }
}
