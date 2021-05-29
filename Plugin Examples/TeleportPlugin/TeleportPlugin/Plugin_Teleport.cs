using System;
using UserApi;
using UserApi.Interfaces;

namespace TeleportPlugin
{
    public class Plugin_Teleport : IPlugin
    {
        private TeleForm _form;

        public string Description
        {
            get
            {
                return "Lets you teleport around.";
            }
        }

        public string Name
        {
            get
            {
                return "Teleporter";
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
            _form.Close();
        }

        public void OpenForm()
        {
            if (_form == null || _form.IsDisposed)
                _form = new TeleForm();

            _form.Show();
        }

        public void Pulse()
        {
            // nope
        }
    }
}
