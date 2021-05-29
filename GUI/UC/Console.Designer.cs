namespace BotTemplate.GUI.UC
{
    partial class Console
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._tbConsole = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // _tbConsole
            // 
            this._tbConsole.BackColor = System.Drawing.Color.Black;
            this._tbConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tbConsole.ForeColor = System.Drawing.Color.Lime;
            this._tbConsole.Location = new System.Drawing.Point(0, 0);
            this._tbConsole.Name = "_tbConsole";
            this._tbConsole.ReadOnly = true;
            this._tbConsole.Size = new System.Drawing.Size(111, 129);
            this._tbConsole.TabIndex = 0;
            this._tbConsole.Text = "";
            // 
            // Console
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._tbConsole);
            this.Name = "Console";
            this.Size = new System.Drawing.Size(111, 129);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox _tbConsole;



    }
}
