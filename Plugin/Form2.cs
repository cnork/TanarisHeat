using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using BotTemplate.Interface;

namespace BotTemplate
{
    public partial class Form2 : Form
    {
        private bool Pulse = false;
        public Form2()
        {
            InitializeComponent();
            InitializePlugin();
            Thread puls = new Thread(new ThreadStart(MainPulse));
            puls.Start();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text =
Environment.OSVersion.Version.Major.ToString();

            label2.Text =
Environment.OSVersion.Version.Minor.ToString();

            label3.Text =
Environment.OSVersion.Version.MajorRevision.ToString();

            label4.Text =
Environment.OSVersion.Version.MinorRevision.ToString();

        }
        void InitializePlugin()
        {
            string executeablePath = AppDomain.CurrentDomain.BaseDirectory;   //Path.GetDirectoryName(Application.StartupPath);
            _wrapper = new ApiWrapper();
            _pluginManager = new PluginManager(executeablePath, _wrapper);
        }
   
        ApiWrapper _wrapper;
        PluginManager _pluginManager;
        void MainPulse()
        {
            while (true)
            {
                if (Pulse)
                {
                    if (_pluginManager.Plugins.Count > 0)
                        _pluginManager.Plugins[0].Pulse();

                   //Thread.Sleep(30);
                }
            }
        }
       

        void Initialize()
        {
            string executeablePath = Path.GetDirectoryName(Application.ExecutablePath);
            _wrapper = new ApiWrapper();
            _pluginManager = new PluginManager(executeablePath, _wrapper);
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
               // MessageBox.Show(openFileDialog1.FileName);
                 _pluginManager.LoadPlugin(openFileDialog1.FileName);                
            }

        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            Pulse = true;
            //if (_pluginManager.Plugins.Count > 0)
            //    _pluginManager.Plugins[0].Pulse();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Pulse = false;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }



    }
}
