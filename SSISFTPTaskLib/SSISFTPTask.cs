
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.SqlServer.Dts.Runtime;
using Rebex.Net;

// ReSharper disable MissingXmlDoc
// ReSharper disable PublicMembersMustHaveComments
// ReSharper disable InconsistentNaming

namespace SSISFTPTaskLib
{
    [DtsTask(
    DisplayName = "SSIS FTP Task",
    TaskType = "SSISFTPTask",
    TaskContact = "SSIS FTP Task",
        //IconResource = "SSISJoost.myTask.ico",
    UITypeName = "SSISFTPTaskLib.SSISFTPTaskUI, SSISFTPTaskLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=95a88e7ace5c2b71",
    RequiredProductLevel = DTSProductLevel.None)]
    public class SSISFTPTask : Task
    {
        public string SourceFileNamePattern { get; set; }
        public FtpType FtpType { get; set; }
        public SftpTransferType TransferType { get; set; }
        public string HostName { get; set; }
        public int ServerPort { get; set; }
        public string InBoundFolderPath { get; set; }
        public string OutBoundFolderPath { get; set; }
        public string LocalPath { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
        public bool DeleteSourceFileOnSuccess { get; set; }
        public bool ReWriteFileToASCII { get; set; }
        public string DownloadedFileNames { get; set; }
        
        public override void InitializeTask(Connections connections, VariableDispenser variableDispenser, IDTSInfoEvents events, IDTSLogging log,
            EventInfos eventInfos, LogEntryInfos logEntryInfos, ObjectReferenceTracker refTracker)
        {
            //DownloadedFileNames=new List<string>();
            base.InitializeTask(connections, variableDispenser, events, log, eventInfos, logEntryInfos, refTracker);
        }

        public override DTSExecResult Validate(Connections connections, VariableDispenser variableDispenser, IDTSComponentEvents componentEvents,
            IDTSLogging log)
        {

            //return base.Validate(connections, variableDispenser, componentEvents, log);
            return DTSExecResult.Success;
        }

        public override DTSExecResult Execute(Connections connections, VariableDispenser variableDispenser, IDTSComponentEvents componentEvents,
            IDTSLogging log, object transaction)
        {
            try
            {
                using (var sftp = new Rebex.Net.Sftp())
                {
                    // connect to a server
                    sftp.Connect(HostName, ServerPort);
                    // authenticate
                    sftp.Login(LoginId, Password);

                    //sftp.Encoding = Encoding.ASCII;//.BigEndianUnicode;//.ASCII;//.Unicode;
                    sftp.TransferType = TransferType;

                    if (FtpType == FtpType.Download) //read from MFT
                    {
                        var filesToRead = sftp.GetList(InBoundFolderPath)
                            .Where(fl => fl.Name.StartsWith(SourceFileNamePattern, StringComparison.OrdinalIgnoreCase))
                            .Select(s => new
                            {
                                FileName = s.Name,
                                FullFilePath = InBoundFolderPath + "/" + s.Name
                            }).ToArray();

                        if (filesToRead.Any())
                        {
                            var _downloadedFileNames = new List<string>();

                            //download the file into local folder
                            foreach (var file in filesToRead)
                            {
                                sftp.GetFiles(file.FullFilePath, LocalPath,
                                    SftpBatchTransferOptions.Default, SftpActionOnExistingFiles.OverwriteAll);
                                _downloadedFileNames.Add(file.FileName);

                                if (ReWriteFileToASCII)
                                {
                                    string from = Path.Combine(LocalPath, file.FileName);
                                    string to = Path.Combine(LocalPath, file.FileName +"_temp");
                                    using (StreamReader reader = new StreamReader(from, System.Text.Encoding.UTF8, true, 10))
                                    using (StreamWriter writer = new StreamWriter(to, false, System.Text.Encoding.ASCII, 10))
                                    {
                                        while (reader.Peek() >= 0)
                                            writer.WriteLine(reader.ReadLine());
                                    }
                                    //delete old file and rename *_temp file to old file
                                    File.Delete(from);
                                    File.Move(Path.Combine(LocalPath, file.FileName + "_temp"), Path.Combine(LocalPath, file.FileName));
                                }

                                //delete the file, after download
                                if (DeleteSourceFileOnSuccess)
                                    sftp.DeleteFile(file.FullFilePath);
                            }
                            DownloadedFileNames = string.Join(",", _downloadedFileNames);
                        }
                        else
                        {
                            throw new Exception(string.Format("No file with name pattern:'{0}' found inside folder :'{1}' to download.", SourceFileNamePattern, InBoundFolderPath));
                        }
                    }
                    else //outbound -> write to MFT
                    {
                        //get file from application path
                        var filesToWrite = Directory.GetFiles(LocalPath, SourceFileNamePattern + "*");

                        if (filesToWrite.Any())
                        {
                            //upload file
                            foreach (var file in filesToWrite)
                            {
                                sftp.PutFiles(file, OutBoundFolderPath, SftpBatchTransferOptions.Default);

                                //delete the file, after upload
                                if (DeleteSourceFileOnSuccess)
                                    File.Delete(file);
                            }
                        }
                        else
                        {
                            throw new Exception(string.Format("No file with name pattern:'{0}' found inside folder :'{1}' to upload.", SourceFileNamePattern, LocalPath));
                        }
                    }
                    sftp.Disconnect();
                }
                return DTSExecResult.Success;
            }
            catch (System.Exception e)
            {
                componentEvents.FireError(0, null, string.Format("Error using Rebex Sftp: {0}", e), null, 0);

                return DTSExecResult.Failure;
            }
        }
    }
}