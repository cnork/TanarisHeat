namespace TeleportPlugin
{
    partial class TeleForm
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this._btnDelete = new System.Windows.Forms.Button();
            this._btnAdd = new System.Windows.Forms.Button();
            this._btnCurrentLocation = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this._nupZ = new System.Windows.Forms.NumericUpDown();
            this._nupY = new System.Windows.Forms.NumericUpDown();
            this._nupX = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._tbName = new System.Windows.Forms.TextBox();
            this._btnTeleport = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._lwLocations = new System.Windows.Forms.ListView();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nupZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._nupY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._nupX)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this._btnDelete, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this._btnAdd, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this._btnCurrentLocation, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 292);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(384, 27);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // _btnDelete
            // 
            this._btnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this._btnDelete.Location = new System.Drawing.Point(259, 3);
            this._btnDelete.Name = "_btnDelete";
            this._btnDelete.Size = new System.Drawing.Size(122, 21);
            this._btnDelete.TabIndex = 2;
            this._btnDelete.Text = "Delete";
            this._btnDelete.UseVisualStyleBackColor = true;
            this._btnDelete.Click += new System.EventHandler(this._btnDelete_Click);
            // 
            // _btnAdd
            // 
            this._btnAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this._btnAdd.Location = new System.Drawing.Point(131, 3);
            this._btnAdd.Name = "_btnAdd";
            this._btnAdd.Size = new System.Drawing.Size(122, 21);
            this._btnAdd.TabIndex = 0;
            this._btnAdd.Text = "Add";
            this._btnAdd.UseVisualStyleBackColor = true;
            this._btnAdd.Click += new System.EventHandler(this._btnAdd_Click);
            // 
            // _btnCurrentLocation
            // 
            this._btnCurrentLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this._btnCurrentLocation.Location = new System.Drawing.Point(3, 3);
            this._btnCurrentLocation.Name = "_btnCurrentLocation";
            this._btnCurrentLocation.Size = new System.Drawing.Size(122, 21);
            this._btnCurrentLocation.TabIndex = 3;
            this._btnCurrentLocation.Text = "Set to my Location";
            this._btnCurrentLocation.UseVisualStyleBackColor = true;
            this._btnCurrentLocation.Click += new System.EventHandler(this._btnCurrentLocation_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._nupZ);
            this.panel1.Controls.Add(this._nupY);
            this.panel1.Controls.Add(this._nupX);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this._tbName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 180);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(384, 106);
            this.panel1.TabIndex = 1;
            // 
            // _nupZ
            // 
            this._nupZ.DecimalPlaces = 5;
            this._nupZ.Location = new System.Drawing.Point(125, 82);
            this._nupZ.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this._nupZ.Minimum = new decimal(new int[] {
            50000,
            0,
            0,
            -2147483648});
            this._nupZ.Name = "_nupZ";
            this._nupZ.Size = new System.Drawing.Size(250, 20);
            this._nupZ.TabIndex = 10;
            // 
            // _nupY
            // 
            this._nupY.DecimalPlaces = 5;
            this._nupY.Location = new System.Drawing.Point(125, 56);
            this._nupY.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this._nupY.Minimum = new decimal(new int[] {
            50000,
            0,
            0,
            -2147483648});
            this._nupY.Name = "_nupY";
            this._nupY.Size = new System.Drawing.Size(250, 20);
            this._nupY.TabIndex = 9;
            // 
            // _nupX
            // 
            this._nupX.DecimalPlaces = 5;
            this._nupX.Location = new System.Drawing.Point(125, 30);
            this._nupX.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this._nupX.Minimum = new decimal(new int[] {
            50000,
            0,
            0,
            -2147483648});
            this._nupX.Name = "_nupX";
            this._nupX.Size = new System.Drawing.Size(250, 20);
            this._nupX.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "z";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "y";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "x";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "name";
            // 
            // _tbName
            // 
            this._tbName.Location = new System.Drawing.Point(125, 3);
            this._tbName.Name = "_tbName";
            this._tbName.Size = new System.Drawing.Size(250, 20);
            this._tbName.TabIndex = 2;
            // 
            // _btnTeleport
            // 
            this._btnTeleport.Dock = System.Windows.Forms.DockStyle.Fill;
            this._btnTeleport.Location = new System.Drawing.Point(3, 325);
            this._btnTeleport.Name = "_btnTeleport";
            this._btnTeleport.Size = new System.Drawing.Size(384, 27);
            this._btnTeleport.TabIndex = 1;
            this._btnTeleport.Text = "Teleport";
            this._btnTeleport.UseVisualStyleBackColor = true;
            this._btnTeleport.Click += new System.EventHandler(this._btnTeleport_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this._btnTeleport, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this._lwLocations, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(390, 355);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // _lwLocations
            // 
            this._lwLocations.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lwLocations.Location = new System.Drawing.Point(3, 3);
            this._lwLocations.Name = "_lwLocations";
            this._lwLocations.Size = new System.Drawing.Size(384, 171);
            this._lwLocations.TabIndex = 3;
            this._lwLocations.UseCompatibleStateImageBehavior = false;
            this._lwLocations.SelectedIndexChanged += new System.EventHandler(this._lwLocations_SelectedIndexChanged);
            // 
            // TeleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 355);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TeleForm";
            this.Text = "TeleForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TeleForm_FormClosing);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nupZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._nupY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._nupX)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button _btnDelete;
        private System.Windows.Forms.Button _btnAdd;
        private System.Windows.Forms.Button _btnCurrentLocation;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown _nupZ;
        private System.Windows.Forms.NumericUpDown _nupY;
        private System.Windows.Forms.NumericUpDown _nupX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _tbName;
        private System.Windows.Forms.Button _btnTeleport;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListView _lwLocations;
    }
}