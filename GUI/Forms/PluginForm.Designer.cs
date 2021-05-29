namespace BotTemplate.GUI.Forms
{
    partial class PluginForm
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
            this.pluginControl1 = new BotTemplate.GUI.UC.PluginControl();
            this.SuspendLayout();
            // 
            // pluginControl1
            // 
            this.pluginControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pluginControl1.Location = new System.Drawing.Point(0, 0);
            this.pluginControl1.Name = "pluginControl1";
            this.pluginControl1.Size = new System.Drawing.Size(424, 461);
            this.pluginControl1.TabIndex = 0;
            // 
            // PluginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 461);
            this.Controls.Add(this.pluginControl1);
            this.MinimumSize = new System.Drawing.Size(440, 500);
            this.Name = "PluginForm";
            this.Text = "PluginForm";
            this.ResumeLayout(false);

        }

        #endregion

        private UC.PluginControl pluginControl1;
    }
}