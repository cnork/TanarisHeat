using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BotTemplate.GUI.Forms
{
    public partial class ProcessSelectionForm : Form
    {
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        #region Constructor

        public ProcessSelectionForm(Process[] processes)
        {
            InitializeComponent();
            LoadWidgets(processes);
        }

        #endregion

        #region Properties

        public Process SelectedProcess
        {
            get;
            set;
        }

        #endregion

        #region Private Methods

        private void LoadWidgets(Process[] processes)
        {
            _cbProcessses.DataSource = processes;
            _cbProcessses.DisplayMember = "Id";
        }

        #endregion

        #region Event Handlerss

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedProcess = (Process)_cbProcessses.SelectedItem;
        }
        
        #endregion

        private void _btAttach_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void _btSelect_Click(object sender, EventArgs e)
        {
            var process = (Process)_cbProcessses.SelectedItem;
            SetForegroundWindow(process.MainWindowHandle);
        }
        
    }
}
