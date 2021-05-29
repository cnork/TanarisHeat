namespace BotTemplate.GUI.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.console2 = new BotTemplate.GUI.UC.Console();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pluginControl2 = new BotTemplate.GUI.UC.PluginControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.checkBox_AntiAfk = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._nudMsPulseSleep = new System.Windows.Forms.NumericUpDown();
            this._cbLogLevel = new System.Windows.Forms.ComboBox();
            this._cbGlobalFramelock = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this._btStartStop = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudMsPulseSleep)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(757, 452);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(751, 411);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.console2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(743, 385);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Info";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // console2
            // 
            this.console2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.console2.Location = new System.Drawing.Point(3, 3);
            this.console2.Name = "console2";
            this.console2.Size = new System.Drawing.Size(737, 379);
            this.console2.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pluginControl2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(743, 385);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Plugins";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pluginControl2
            // 
            this.pluginControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pluginControl2.Location = new System.Drawing.Point(3, 3);
            this.pluginControl2.Name = "pluginControl2";
            this.pluginControl2.Size = new System.Drawing.Size(737, 379);
            this.pluginControl2.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.checkBox_AntiAfk);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this._nudMsPulseSleep);
            this.tabPage3.Controls.Add(this._cbLogLevel);
            this.tabPage3.Controls.Add(this._cbGlobalFramelock);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(743, 385);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Settings";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // checkBox_AntiAfk
            // 
            this.checkBox_AntiAfk.AutoSize = true;
            this.checkBox_AntiAfk.Location = new System.Drawing.Point(152, 6);
            this.checkBox_AntiAfk.Name = "checkBox_AntiAfk";
            this.checkBox_AntiAfk.Size = new System.Drawing.Size(63, 17);
            this.checkBox_AntiAfk.TabIndex = 7;
            this.checkBox_AntiAfk.Text = "Anti Afk";
            this.checkBox_AntiAfk.UseVisualStyleBackColor = true;
            this.checkBox_AntiAfk.CheckedChanged += new System.EventHandler(this.checkBox_AntiAfk_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Logging-Level:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "ms sleep between pulses:";
            // 
            // _nudMsPulseSleep
            // 
            this._nudMsPulseSleep.Location = new System.Drawing.Point(5, 42);
            this._nudMsPulseSleep.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this._nudMsPulseSleep.Name = "_nudMsPulseSleep";
            this._nudMsPulseSleep.Size = new System.Drawing.Size(122, 20);
            this._nudMsPulseSleep.TabIndex = 4;
            this._nudMsPulseSleep.Value = new decimal(new int[] {
            34,
            0,
            0,
            0});
            this._nudMsPulseSleep.ValueChanged += new System.EventHandler(this._nudMsPulseSleep_ValueChanged);
            // 
            // _cbLogLevel
            // 
            this._cbLogLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbLogLevel.FormattingEnabled = true;
            this._cbLogLevel.Location = new System.Drawing.Point(6, 81);
            this._cbLogLevel.Name = "_cbLogLevel";
            this._cbLogLevel.Size = new System.Drawing.Size(121, 21);
            this._cbLogLevel.TabIndex = 3;
            this._cbLogLevel.SelectedIndexChanged += new System.EventHandler(this._cbLogLevel_SelectedIndexChanged);
            // 
            // _cbGlobalFramelock
            // 
            this._cbGlobalFramelock.AutoSize = true;
            this._cbGlobalFramelock.Location = new System.Drawing.Point(6, 6);
            this._cbGlobalFramelock.Name = "_cbGlobalFramelock";
            this._cbGlobalFramelock.Size = new System.Drawing.Size(108, 17);
            this._cbGlobalFramelock.TabIndex = 2;
            this._cbGlobalFramelock.Text = "Global Framelock";
            this._cbGlobalFramelock.UseVisualStyleBackColor = true;
            this._cbGlobalFramelock.CheckedChanged += new System.EventHandler(this._cbGlobalFramelock_CheckedChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this._btStartStop);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 420);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(751, 29);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // _btStartStop
            // 
            this._btStartStop.Location = new System.Drawing.Point(638, 3);
            this._btStartStop.Name = "_btStartStop";
            this._btStartStop.Size = new System.Drawing.Size(110, 23);
            this._btStartStop.TabIndex = 0;
            this._btStartStop.Text = "Start";
            this._btStartStop.UseVisualStyleBackColor = true;
            this._btStartStop.Click += new System.EventHandler(this._btStartStop_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 452);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainForm";
            this.Text = "Tanaris Heat";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudMsPulseSleep)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox _cbGlobalFramelock;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private UC.Console console1;
        private System.Windows.Forms.TabPage tabPage2;
        private UC.PluginControl pluginControl1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button _btStartStop;
        private UC.Console console2;
        private UC.PluginControl pluginControl2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown _nudMsPulseSleep;
        private System.Windows.Forms.ComboBox _cbLogLevel;
        private System.Windows.Forms.CheckBox checkBox_AntiAfk;
    }
}