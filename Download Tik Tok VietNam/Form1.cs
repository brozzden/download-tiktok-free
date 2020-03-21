using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Download_Tik_Tok_VietNam
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void ExecuteCommand(string name)
        {
            string commandText = @"/c tiktok-dl " + name;
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo
                (Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\" + @"cmd.exe", commandText);
            //startInfo.WorkingDirectory = Application.StartupPath;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();
        }

        private void KillProcess()
        {
            Process[] processes = Process.GetProcessesByName("cmd");
            foreach(Process p in processes)
            {
                p.Kill();
                p.Dispose();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            string UserName = txtUserName.Text;
            if(UserName != null)
                ExecuteCommand(UserName);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            KillProcess();
        }
    }
}
