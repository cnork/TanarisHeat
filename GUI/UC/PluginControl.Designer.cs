namespace BotTemplate.GUI.UC
{
    partial class PluginControl
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this._btnSettings = new System.Windows.Forms.Button();
            this._btnReload = new System.Windows.Forms.Button();
            this._tbDescription = new System.Windows.Forms.RichTextBox();
            this._lwPlugins = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this._cbCartegories = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this._tbDescription, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this._lwPlugins, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(417, 414);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this._btnSettings);
            this.flowLayoutPanel1.Controls.Add(this._btnReload);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 381);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(411, 30);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // _btnSettings
            // 
            this._btnSettings.Location = new System.Drawing.Point(310, 3);
            this._btnSettings.Name = "_btnSettings";
            this._btnSettings.Size = new System.Drawing.Size(98, 23);
            this._btnSettings.TabIndex = 0;
            this._btnSettings.Text = "Plugin settings";
            this._btnSettings.UseVisualStyleBackColor = true;
            this._btnSettings.Click += new System.EventHandler(this._btnSettings_Click);
            // 
            // _btnReload
            // 
            this._btnReload.Location = new System.Drawing.Point(206, 3);
            this._btnReload.Name = "_btnReload";
            this._btnReload.Size = new System.Drawing.Size(98, 23);
            this._btnReload.TabIndex = 1;
            this._btnReload.Text = "Reload plugins";
            this._btnReload.UseVisualStyleBackColor = true;
            this._btnReload.Click += new System.EventHandler(this._btnReload_Click);
            // 
            // _tbDescription
            // 
            this._tbDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tbDescription.Location = new System.Drawing.Point(3, 278);
            this._tbDescription.Name = "_tbDescription";
            this._tbDescription.ReadOnly = true;
            this._tbDescription.Size = new System.Drawing.Size(411, 97);
            this._tbDescription.TabIndex = 2;
            this._tbDescription.Text = "";
            // 
            // _lwPlugins
            // 
            this._lwPlugins.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lwPlugins.Location = new System.Drawing.Point(3, 38);
            this._lwPlugins.Name = "_lwPlugins";
            this._lwPlugins.Size = new System.Drawing.Size(411, 234);
            this._lwPlugins.TabIndex = 1;
            this._lwPlugins.UseCompatibleStateImageBehavior = false;
            this._lwPlugins.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this._lwPlugins_ItemCheck);
            this._lwPlugins.SelectedIndexChanged += new System.EventHandler(this._lwPlugins_SelectedIndexChanged);
            this._lwPlugins.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._lwPlugins_KeyPress);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this._cbCartegories);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(411, 29);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(218, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cartegory:";
            // 
            // _cbCartegories
            // 
            this._cbCartegories.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._cbCartegories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbCartegories.FormattingEnabled = true;
            this._cbCartegories.Location = new System.Drawing.Point(287, 5);
            this._cbCartegories.Name = "_cbCartegories";
            this._cbCartegories.Size = new System.Drawing.Size(121, 21);
            this._cbCartegories.TabIndex = 0;
            this._cbCartegories.SelectedIndexChanged += new System.EventHandler(this._cbCartegories_SelectedIndexChanged);
            // 
            // PluginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "PluginControl";
            this.Size = new System.Drawing.Size(417, 414);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button _btnSettings;
        private System.Windows.Forms.Button _btnReload;
        private System.Windows.Forms.ListView _lwPlugins;
        private System.Windows.Forms.RichTextBox _tbDescription;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox _cbCartegories;
        private System.Windows.Forms.Label label1;

    }
}
