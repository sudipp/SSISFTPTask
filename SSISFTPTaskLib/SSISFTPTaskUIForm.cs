using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.SqlServer.Dts.Runtime;
using Rebex.Net;

// ReSharper disable MissingXmlDoc
// ReSharper disable PublicMembersMustHaveComments
// ReSharper disable InconsistentNaming
// ReSharper disable PrivateMembersMustHaveComments

namespace SSISFTPTaskLib
{
    public partial class SSISFTPTaskUIForm : Form
    {
        private TaskHost taskHostValue;

        public SSISFTPTaskUIForm(TaskHost taskHostValue)
        {
            try
            {
                InitializeComponent();

                this.taskHostValue = taskHostValue;

                var lstFtpType = new List<KeyValuePair<FtpType, FtpType>>();
                lstFtpType.Add(new KeyValuePair<FtpType, FtpType>(FtpType.Download, FtpType.Download));
                lstFtpType.Add(new KeyValuePair<FtpType, FtpType>(FtpType.Upload, FtpType.Upload));
                this.cboFtpType.DataSource = lstFtpType;
                this.cboFtpType.ValueMember = "Key";

                var lstTransferType = new List<KeyValuePair<SftpTransferType, SftpTransferType>>();
                lstTransferType.Add(new KeyValuePair<SftpTransferType, SftpTransferType>(SftpTransferType.Binary, SftpTransferType.Binary));
                lstTransferType.Add(new KeyValuePair<SftpTransferType, SftpTransferType>(SftpTransferType.Ascii, SftpTransferType.Ascii));
                this.cboTransferType.DataSource = lstTransferType;
                this.cboTransferType.ValueMember = "Key";

                //MessageBox.Show(taskHostValue.Properties.Contains("SourceFileNamePattern").ToString());
                object _SourceFileNamePattern = taskHostValue.Properties["SourceFileNamePattern"].GetValue(this.taskHostValue);
                    this.fileNamePattern.Text = (_SourceFileNamePattern != null) ? _SourceFileNamePattern.ToString() : string.Empty;
                object _HostName = taskHostValue.Properties["HostName"].GetValue(this.taskHostValue);
                    this.serverName.Text = (_HostName != null) ? _HostName.ToString() : string.Empty;
                
                object _ServerPort = taskHostValue.Properties["ServerPort"].GetValue(this.taskHostValue);
                int i=2222; 
                int.TryParse((_ServerPort != null) ? _ServerPort.ToString() : String.Empty, out i);
                this.port.Text = i.ToString();

                object _InBoundFolderPath = taskHostValue.Properties["InBoundFolderPath"].GetValue(this.taskHostValue);
                this.txtInBoundFolderPath.Text = (_InBoundFolderPath != null) ? _InBoundFolderPath.ToString() : string.Empty;
                object _OutBoundFolderPath = taskHostValue.Properties["OutBoundFolderPath"].GetValue(this.taskHostValue);
                this.txtOutBoundFolderPath.Text = (_OutBoundFolderPath != null) ? _OutBoundFolderPath.ToString() : string.Empty;
                object _LocalPath = taskHostValue.Properties["LocalPath"].GetValue(this.taskHostValue);
                this.localPath.Text = (_LocalPath != null) ? _LocalPath.ToString() : string.Empty;

                object _LoginId = taskHostValue.Properties["LoginId"].GetValue(this.taskHostValue);
                this.loginId.Text = (_LoginId != null) ? _LoginId.ToString() : string.Empty;

                object _Password = taskHostValue.Properties["Password"].GetValue(this.taskHostValue);
                this.pwd.Text = (_Password != null) ? _Password.ToString() : string.Empty;

                bool b;
                object _DeleteSourceFileOnSuccess = taskHostValue.Properties["DeleteSourceFileOnSuccess"].GetValue(this.taskHostValue);
                bool.TryParse((_DeleteSourceFileOnSuccess != null)?_DeleteSourceFileOnSuccess.ToString():string.Empty, out b);
                this.chkDeleteSourceFileOnSuccess.Checked = b;

                object _ReWriteFileToASCII = taskHostValue.Properties["ReWriteFileToASCII"].GetValue(this.taskHostValue);
                bool.TryParse((_ReWriteFileToASCII != null) ? _ReWriteFileToASCII.ToString() : string.Empty, out b);
                this.chkReWriteFileToASCII.Checked = b;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SSISFTPTaskUIForm()");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int _port = 0;
                if (!int.TryParse(this.port.Text, out _port))
                    _port = 0;

                this.taskHostValue.Properties["SourceFileNamePattern"].SetValue(this.taskHostValue,
                    this.fileNamePattern.Text);
                this.taskHostValue.Properties["HostName"].SetValue(this.taskHostValue, this.serverName.Text);
                this.taskHostValue.Properties["ServerPort"].SetValue(this.taskHostValue, _port);//int.Parse(this.port.Text));
                this.taskHostValue.Properties["LocalPath"].SetValue(this.taskHostValue, this.localPath.Text);
                this.taskHostValue.Properties["LoginId"].SetValue(this.taskHostValue, this.loginId.Text);
                this.taskHostValue.Properties["Password"].SetValue(this.taskHostValue, this.pwd.Text);
                this.taskHostValue.Properties["DeleteSourceFileOnSuccess"].SetValue(this.taskHostValue, this.chkDeleteSourceFileOnSuccess.Checked);
                this.taskHostValue.Properties["ReWriteFileToASCII"].SetValue(this.taskHostValue, this.chkReWriteFileToASCII.Checked);

                this.taskHostValue.Properties["FtpType"].SetValue(this.taskHostValue, this.cboFtpType.SelectedValue);
                this.taskHostValue.Properties["TransferType"].SetValue(this.taskHostValue, this.cboTransferType.SelectedValue);

                if ((int)cboFtpType.SelectedValue == (int)FtpType.Upload)
                {
                    this.taskHostValue.Properties["InBoundFolderPath"].SetValue(this.taskHostValue,
                        string.Empty);
                    this.taskHostValue.Properties["OutBoundFolderPath"].SetValue(this.taskHostValue,
                        this.txtOutBoundFolderPath.Text);
                }
                else
                {
                    this.taskHostValue.Properties["InBoundFolderPath"].SetValue(this.taskHostValue,
                        this.txtInBoundFolderPath.Text);
                    this.taskHostValue.Properties["OutBoundFolderPath"].SetValue(this.taskHostValue,
                        string.Empty);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SSISFTPTaskLib - button1_Click()");
            }
        }

        private void SSISFTPTaskUIForm_Load(object sender, EventArgs e)
        {
            try
            {
                FtpType _ftptype=FtpType.Download;
                if (taskHostValue.Properties.Contains("FtpType"))
                    _ftptype = (FtpType)Enum.Parse(typeof(FtpType), taskHostValue.Properties["FtpType"].GetValue(this.taskHostValue).ToString());

                SftpTransferType _transferType = SftpTransferType.Ascii;
                if (taskHostValue.Properties.Contains("TransferType"))
                    _transferType = (SftpTransferType)Enum.Parse(typeof(SftpTransferType), taskHostValue.Properties["TransferType"].GetValue(this.taskHostValue).ToString());
                
                this.cboFtpType.SelectedValue = _ftptype;//(FtpType)taskHostValue.Properties["FtpType"].GetValue(this.taskHostValue);
                cboFtpType_SelectedIndexChanged(cboFtpType, EventArgs.Empty);

                this.cboTransferType.SelectedValue = _transferType;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SSISFTPTaskUIForm_Load()");
            }
        }

        private void cboFtpType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((int)cboFtpType.SelectedValue == (int)FtpType.Upload)
            {
                txtOutBoundFolderPath.Enabled = true;
                lblOutBoundFolderPath.Enabled = true;

                //txtInBoundFolderPath.Text = string.Empty;
                txtInBoundFolderPath.Enabled = false;
                lblInBoundFolderPath.Enabled = false;
            }
            else
            {
                txtOutBoundFolderPath.Enabled = false;
                lblOutBoundFolderPath.Enabled = false;
                //txtOutBoundFolderPath.Text = string.Empty;

                txtInBoundFolderPath.Enabled = true;
                lblInBoundFolderPath.Enabled = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
