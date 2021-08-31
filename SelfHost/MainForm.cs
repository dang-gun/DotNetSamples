using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SelfHost
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnChrome_Click(object sender, EventArgs e)
        {
            //https://stackoverflow.com/questions/58846709/process-start-in-core-3-0-does-not-open-a-folder-just-by-its-name
            var psi = new ProcessStartInfo
            {
                FileName = "chrome.exe",
                Arguments = this.txtUrl.Text,
                UseShellExecute = true
            };
            Process.Start(psi);
        }

        private void btnMsEdge_Click(object sender, EventArgs e)
        {
            //https://stackoverflow.com/questions/58846709/process-start-in-core-3-0-does-not-open-a-folder-just-by-its-name
            var psi = new ProcessStartInfo
            {
                FileName = "msedge.exe",
                Arguments = this.txtUrl.Text,
                UseShellExecute = true
            };
            Process.Start(psi);
        }
    }
}
