using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace AutoInstallWindowsServiceTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo(Application.StartupPath);
            var allExecuteFiles = dir.GetFiles("*.exe");
            foreach(var file in allExecuteFiles)
            {
                listBox1.Items.Add(file.Name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var selectedFile = GetSelectedFilePath();
            if (!string.IsNullOrEmpty(selectedFile))
            {
                var process = new Process();
                process.StartInfo.FileName = InstallUtil;
                process.StartInfo.Arguments = $"\"{selectedFile}\"";
                process.EnableRaisingEvents = true;
                process.Exited += Process_Exited;
                process.Start();
            }
        }

        private void Process_Exited(object sender, EventArgs e)
        {
            var selectedFile = (sender as Process).StartInfo.Arguments.Trim('\"');
            var winsvc = WinService.GetWinServiceByPathName(selectedFile);
            if (winsvc != null)
            {
                winsvc.Start();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process process = null;
            var selectedFile = GetSelectedFilePath();
            if (!string.IsNullOrEmpty(selectedFile))
            {
                process = Process.Start(InstallUtil, $"/u \"{selectedFile}\"");
            }
        }

        private string NetFrameworkPath
        {
            get
            {
                return Environment.GetEnvironmentVariable("windir") + @"\Microsoft.NET\Framework\v4.0.30319";
            }
        }

        private string InstallUtil
        {
            get
            {
                return Path.Combine(NetFrameworkPath, "InstallUtil.exe");
            }
        }

        private string GetSelectedFilePath()
        {
            string fileName = listBox1.SelectedItem as string;
            if (string.IsNullOrEmpty(fileName))
            {
                return string.Empty;
            }

            return Path.Combine(Application.StartupPath, fileName);
        }

        private void itmeServiceRun_Click(object sender, EventArgs e)
        {
            var service = WinService.GetWinServiceByPathName(GetSelectedFilePath());
            if (service != null && service.State == "Stopped")
            {
                service.Start();
            }
        }

        private void itemServiceStop_Click(object sender, EventArgs e)
        {
            var service = WinService.GetWinServiceByPathName(GetSelectedFilePath());
            if (service != null && service.State == "Running")
            {
                service.ServiceStoped += Service_ServiceStoped;
                service.Stop();
            }
        }

        private void Service_ServiceStoped(object sender, EventArgs e)
        {
            MessageBox.Show("服务已经停止。");
        }

        private void itemOPenNotepad_Click(object sender, EventArgs e)
        {
            Process.Start("Notepad.exe");
        }

        private void itemBackupAll_Click(object sender, EventArgs e)
        {
            string directoryName = new DirectoryInfo(Application.StartupPath).Name;
            directoryName += DateTime.Now.ToString("_yyyyMMdd_backup");
            DirectoryInfo dirInfo = new DirectoryInfo(directoryName);
            if (dirInfo.Exists == false)
            {
                dirInfo.Create();
            }

            var currentDir = new DirectoryInfo(Application.StartupPath);
            foreach (var file in currentDir.GetFiles())
            {
                file.CopyTo(Path.Combine(dirInfo.FullName, file.Name), true);
            }
        }

        private void itemLocateFile_Click(object sender, EventArgs e)
        {
            var file = GetSelectedFilePath();
            if (string.IsNullOrEmpty(file))
            {
                file = Environment.GetCommandLineArgs()[0];
            }
            Process.Start("explorer.exe", $"/SELECT,\"{file}\"");
        }
    }
}
