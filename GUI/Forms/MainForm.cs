using BotTemplate.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BotTemplate.GUI.Forms
{
    public partial class MainForm : Form
    {
        #region Constructors

        public MainForm()
        {
            InitializeComponent();
            LoadWidgets();
        }

        #endregion

        #region private Methods

        private void LoadWidgets()
        {
            Bot.LoadSettings();

            _cbGlobalFramelock.Checked = Bot.Settings.GlobalFramelock;
            _nudMsPulseSleep.Value = Bot.Settings.MsPulseSleep;
            var logLevel = Bot.Settings.LogLevel;
            _cbLogLevel.DataSource = Enum.GetValues(typeof(Enums.LogLevel));
            _cbLogLevel.SelectedIndex = logLevel;
            checkBox_AntiAfk.Checked = Bot.Settings.AntiAfk;

            pluginControl2.Refresh();
        }
           
        #endregion

        #region Event Handlers

        private void _btStartStop_Click(object sender, EventArgs e)
        {
            if (Bot.PulseEnabled)
            {
                Bot.PulseEnabled = false;
                _btStartStop.Text = "Start";
                Bot.SaveSettings();
            }
            else
            {
                Bot.LoadSettings();
                LoadWidgets();
                Bot.PulseEnabled = true;
                _btStartStop.Text = "Stop";
            }
        }

        private void _cbGlobalFramelock_CheckedChanged(object sender, EventArgs e)
        {
            Bot.Settings.GlobalFramelock = _cbGlobalFramelock.Checked;
            Bot.SaveSettings();
        }

        private void _nudMsPulseSleep_ValueChanged(object sender, EventArgs e)
        {
            Bot.Settings.MsPulseSleep = (int)_nudMsPulseSleep.Value;
            Bot.SaveSettings();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            Bot.WriteLogMessage("test...");
        }

        private void _cbLogLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bot.Settings.LogLevel = _cbLogLevel.SelectedIndex;
            Bot.SaveSettings();
        }

        private void checkBox_AntiAfk_CheckedChanged(object sender, EventArgs e)
        {
            Bot.Settings.AntiAfk = checkBox_AntiAfk.Checked;
            Bot.SaveSettings();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadWidgets();
        }

        #endregion
    }
}
