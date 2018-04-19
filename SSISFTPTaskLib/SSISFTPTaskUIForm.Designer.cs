namespace SSISFTPTaskLib
{
    partial class SSISFTPTaskUIForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.fileNamePattern = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cboFtpType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.serverName = new System.Windows.Forms.TextBox();
            this.port = new System.Windows.Forms.NumericUpDown();
            this.txtInBoundFolderPath = new System.Windows.Forms.TextBox();
            this.lblInBoundFolderPath = new System.Windows.Forms.Label();
            this.localPath = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pwd = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.loginId = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtOutBoundFolderPath = new System.Windows.Forms.TextBox();
            this.lblOutBoundFolderPath = new System.Windows.Forms.Label();
            this.chkDeleteSourceFileOnSuccess = new System.Windows.Forms.CheckBox();
            this.cboTransferType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkReWriteFileToASCII = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.port)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 343);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "File Name Start With";
            // 
            // fileNamePattern
            // 
            this.fileNamePattern.Location = new System.Drawing.Point(190, 343);
            this.fileNamePattern.MaxLength = 50;
            this.fileNamePattern.Name = "fileNamePattern";
            this.fileNamePattern.Size = new System.Drawing.Size(354, 22);
            this.fileNamePattern.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(469, 381);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 32);
            this.button1.TabIndex = 8;
            this.button1.Text = "Done";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "FTP Type";
            // 
            // cboFtpType
            // 
            this.cboFtpType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFtpType.FormattingEnabled = true;
            this.cboFtpType.Location = new System.Drawing.Point(190, 173);
            this.cboFtpType.Name = "cboFtpType";
            this.cboFtpType.Size = new System.Drawing.Size(121, 24);
            this.cboFtpType.TabIndex = 7;
            this.cboFtpType.SelectedIndexChanged += new System.EventHandler(this.cboFtpType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "MFT Server Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "MFT Server Port";
            // 
            // serverName
            // 
            this.serverName.Location = new System.Drawing.Point(190, 12);
            this.serverName.MaxLength = 50;
            this.serverName.Name = "serverName";
            this.serverName.Size = new System.Drawing.Size(354, 22);
            this.serverName.TabIndex = 0;
            this.serverName.Text = "mft.domain.com";
            // 
            // port
            // 
            this.port.Location = new System.Drawing.Point(190, 51);
            this.port.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(120, 22);
            this.port.TabIndex = 1;
            this.port.Value = new decimal(new int[] {
            2222,
            0,
            0,
            0});
            // 
            // txtInBoundFolderPath
            // 
            this.txtInBoundFolderPath.Location = new System.Drawing.Point(190, 215);
            this.txtInBoundFolderPath.MaxLength = 50;
            this.txtInBoundFolderPath.Name = "txtInBoundFolderPath";
            this.txtInBoundFolderPath.Size = new System.Drawing.Size(354, 22);
            this.txtInBoundFolderPath.TabIndex = 4;
            this.txtInBoundFolderPath.Text = "/Parts_Host-DEV/inbound/";
            // 
            // lblInBoundFolderPath
            // 
            this.lblInBoundFolderPath.AutoSize = true;
            this.lblInBoundFolderPath.Location = new System.Drawing.Point(35, 218);
            this.lblInBoundFolderPath.Name = "lblInBoundFolderPath";
            this.lblInBoundFolderPath.Size = new System.Drawing.Size(137, 17);
            this.lblInBoundFolderPath.TabIndex = 10;
            this.lblInBoundFolderPath.Text = "InBound Folder Path";
            // 
            // localPath
            // 
            this.localPath.Location = new System.Drawing.Point(190, 301);
            this.localPath.MaxLength = 50;
            this.localPath.Name = "localPath";
            this.localPath.Size = new System.Drawing.Size(354, 22);
            this.localPath.TabIndex = 5;
            this.localPath.Text = "c:\\path";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(35, 301);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Local Path";
            // 
            // pwd
            // 
            this.pwd.Location = new System.Drawing.Point(190, 130);
            this.pwd.MaxLength = 50;
            this.pwd.Name = "pwd";
            this.pwd.PasswordChar = '*';
            this.pwd.Size = new System.Drawing.Size(354, 22);
            this.pwd.TabIndex = 3;
            this.pwd.Text = "sorry";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 17);
            this.label7.TabIndex = 16;
            this.label7.Text = "Password";
            // 
            // loginId
            // 
            this.loginId.Location = new System.Drawing.Point(190, 89);
            this.loginId.MaxLength = 50;
            this.loginId.Name = "loginId";
            this.loginId.Size = new System.Drawing.Size(354, 22);
            this.loginId.TabIndex = 2;
            this.loginId.Text = "mft_win_qa";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(35, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 17);
            this.label8.TabIndex = 14;
            this.label8.Text = "Login ID";
            // 
            // txtOutBoundFolderPath
            // 
            this.txtOutBoundFolderPath.Location = new System.Drawing.Point(190, 259);
            this.txtOutBoundFolderPath.MaxLength = 50;
            this.txtOutBoundFolderPath.Name = "txtOutBoundFolderPath";
            this.txtOutBoundFolderPath.Size = new System.Drawing.Size(354, 22);
            this.txtOutBoundFolderPath.TabIndex = 17;
            this.txtOutBoundFolderPath.Text = "/Parts_Host-DEV/outbound/";
            // 
            // lblOutBoundFolderPath
            // 
            this.lblOutBoundFolderPath.AutoSize = true;
            this.lblOutBoundFolderPath.Location = new System.Drawing.Point(35, 262);
            this.lblOutBoundFolderPath.Name = "lblOutBoundFolderPath";
            this.lblOutBoundFolderPath.Size = new System.Drawing.Size(149, 17);
            this.lblOutBoundFolderPath.TabIndex = 18;
            this.lblOutBoundFolderPath.Text = "OutBound Folder Path";
            // 
            // chkDeleteSourceFileOnSuccess
            // 
            this.chkDeleteSourceFileOnSuccess.AutoSize = true;
            this.chkDeleteSourceFileOnSuccess.Location = new System.Drawing.Point(38, 381);
            this.chkDeleteSourceFileOnSuccess.Name = "chkDeleteSourceFileOnSuccess";
            this.chkDeleteSourceFileOnSuccess.Size = new System.Drawing.Size(226, 21);
            this.chkDeleteSourceFileOnSuccess.TabIndex = 19;
            this.chkDeleteSourceFileOnSuccess.Text = "Delete Source File On Success";
            this.chkDeleteSourceFileOnSuccess.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkDeleteSourceFileOnSuccess.UseVisualStyleBackColor = true;
            // 
            // cboTransferType
            // 
            this.cboTransferType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTransferType.FormattingEnabled = true;
            this.cboTransferType.Location = new System.Drawing.Point(423, 173);
            this.cboTransferType.Name = "cboTransferType";
            this.cboTransferType.Size = new System.Drawing.Size(121, 24);
            this.cboTransferType.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(326, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 17);
            this.label5.TabIndex = 20;
            this.label5.Text = "Transfer Type";
            // 
            // chkReWriteFileToASCII
            // 
            this.chkReWriteFileToASCII.AutoSize = true;
            this.chkReWriteFileToASCII.Location = new System.Drawing.Point(270, 381);
            this.chkReWriteFileToASCII.Name = "chkReWriteFileToASCII";
            this.chkReWriteFileToASCII.Size = new System.Drawing.Size(160, 21);
            this.chkReWriteFileToASCII.TabIndex = 22;
            this.chkReWriteFileToASCII.Text = "ReWrite File to ASCII";
            this.chkReWriteFileToASCII.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkReWriteFileToASCII.UseVisualStyleBackColor = true;
            this.chkReWriteFileToASCII.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // SSISFTPTaskUIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 434);
            this.Controls.Add(this.chkReWriteFileToASCII);
            this.Controls.Add(this.cboTransferType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chkDeleteSourceFileOnSuccess);
            this.Controls.Add(this.txtOutBoundFolderPath);
            this.Controls.Add(this.lblOutBoundFolderPath);
            this.Controls.Add(this.pwd);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.loginId);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.localPath);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtInBoundFolderPath);
            this.Controls.Add(this.lblInBoundFolderPath);
            this.Controls.Add(this.port);
            this.Controls.Add(this.serverName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboFtpType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.fileNamePattern);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SSISFTPTaskUIForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SSIS FTP Task";
            this.Load += new System.EventHandler(this.SSISFTPTaskUIForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.port)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox fileNamePattern;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboFtpType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox serverName;
        private System.Windows.Forms.NumericUpDown port;
        private System.Windows.Forms.TextBox txtInBoundFolderPath;
        private System.Windows.Forms.Label lblInBoundFolderPath;
        private System.Windows.Forms.TextBox localPath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox pwd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox loginId;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtOutBoundFolderPath;
        private System.Windows.Forms.Label lblOutBoundFolderPath;
        private System.Windows.Forms.CheckBox chkDeleteSourceFileOnSuccess;
        private System.Windows.Forms.ComboBox cboTransferType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkReWriteFileToASCII;
    }
}