namespace SigFoxGui
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.btSearch = new System.Windows.Forms.Button();
            this.btScan = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbDevices = new System.Windows.Forms.ComboBox();
            this.tbCommand = new System.Windows.Forms.TextBox();
            this.btSendCommand = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Property = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btClearLog = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btSearch
            // 
            this.btSearch.Location = new System.Drawing.Point(245, 32);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(73, 24);
            this.btSearch.TabIndex = 0;
            this.btSearch.Text = "Search";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // btScan
            // 
            this.btScan.Location = new System.Drawing.Point(324, 32);
            this.btScan.Name = "btScan";
            this.btScan.Size = new System.Drawing.Size(96, 23);
            this.btScan.TabIndex = 1;
            this.btScan.Text = "Scan Device";
            this.btScan.UseVisualStyleBackColor = true;
            this.btScan.Click += new System.EventHandler(this.btScan_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Serial Links:";
            // 
            // cbDevices
            // 
            this.cbDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDevices.FormattingEnabled = true;
            this.cbDevices.Location = new System.Drawing.Point(82, 35);
            this.cbDevices.Name = "cbDevices";
            this.cbDevices.Size = new System.Drawing.Size(157, 21);
            this.cbDevices.TabIndex = 3;
            // 
            // tbCommand
            // 
            this.tbCommand.Location = new System.Drawing.Point(15, 64);
            this.tbCommand.Name = "tbCommand";
            this.tbCommand.Size = new System.Drawing.Size(303, 20);
            this.tbCommand.TabIndex = 4;
            this.tbCommand.Text = "AT";
            // 
            // btSendCommand
            // 
            this.btSendCommand.Location = new System.Drawing.Point(324, 61);
            this.btSendCommand.Name = "btSendCommand";
            this.btSendCommand.Size = new System.Drawing.Size(96, 23);
            this.btSendCommand.TabIndex = 5;
            this.btSendCommand.Text = "Send Command";
            this.btSendCommand.UseVisualStyleBackColor = true;
            this.btSendCommand.Click += new System.EventHandler(this.btSendCommand_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(16, 102);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(403, 303);
            this.listBox1.TabIndex = 6;
            this.listBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox1_KeyDown);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Property,
            this.Value});
            this.dataGridView1.Location = new System.Drawing.Point(451, 32);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(464, 373);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Property
            // 
            this.Property.HeaderText = "Property";
            this.Property.Name = "Property";
            this.Property.ReadOnly = true;
            this.Property.Width = 200;
            // 
            // Value
            // 
            this.Value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            // 
            // btClearLog
            // 
            this.btClearLog.Location = new System.Drawing.Point(344, 418);
            this.btClearLog.Name = "btClearLog";
            this.btClearLog.Size = new System.Drawing.Size(75, 23);
            this.btClearLog.TabIndex = 8;
            this.btClearLog.Text = "Clear Log";
            this.btClearLog.UseVisualStyleBackColor = true;
            this.btClearLog.Click += new System.EventHandler(this.btClearLog_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 453);
            this.Controls.Add(this.btClearLog);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btSendCommand);
            this.Controls.Add(this.tbCommand);
            this.Controls.Add(this.cbDevices);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btScan);
            this.Controls.Add(this.btSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "SigFox Tester";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.Button btScan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbDevices;
        private System.Windows.Forms.TextBox tbCommand;
        private System.Windows.Forms.Button btSendCommand;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Property;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.Button btClearLog;
    }
}

