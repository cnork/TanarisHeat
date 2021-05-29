namespace BotTemplate.GUI.Forms
{
    partial class ProcessSelectionForm
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
            this._cbProcessses = new System.Windows.Forms.ComboBox();
            this._btSelect = new System.Windows.Forms.Button();
            this._btAttach = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _cbProcessses
            // 
            this._cbProcessses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbProcessses.FormattingEnabled = true;
            this._cbProcessses.Location = new System.Drawing.Point(12, 12);
            this._cbProcessses.Name = "_cbProcessses";
            this._cbProcessses.Size = new System.Drawing.Size(156, 21);
            this._cbProcessses.TabIndex = 0;
            this._cbProcessses.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // _btSelect
            // 
            this._btSelect.Location = new System.Drawing.Point(12, 39);
            this._btSelect.Name = "_btSelect";
            this._btSelect.Size = new System.Drawing.Size(75, 23);
            this._btSelect.TabIndex = 1;
            this._btSelect.Text = "Select";
            this._btSelect.UseVisualStyleBackColor = true;
            this._btSelect.Click += new System.EventHandler(this._btSelect_Click);
            // 
            // _btAttach
            // 
            this._btAttach.Location = new System.Drawing.Point(93, 39);
            this._btAttach.Name = "_btAttach";
            this._btAttach.Size = new System.Drawing.Size(75, 23);
            this._btAttach.TabIndex = 2;
            this._btAttach.Text = "Attach";
            this._btAttach.UseVisualStyleBackColor = true;
            this._btAttach.Click += new System.EventHandler(this._btAttach_Click);
            // 
            // ProcessSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(179, 76);
            this.Controls.Add(this._btAttach);
            this.Controls.Add(this._btSelect);
            this.Controls.Add(this._cbProcessses);
            this.Name = "ProcessSelectionForm";
            this.Text = "ProcessSelectionForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox _cbProcessses;
        private System.Windows.Forms.Button _btSelect;
        private System.Windows.Forms.Button _btAttach;
    }
}