using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace CRXDownloader
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            char[] delimiter = new char[] { '/' };
            char[] delimiter2 = new char[] { '?' };
            string szPath = txtURL.Text;
            string[] tokens = szPath.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
            int iLen = tokens.Length;
            string[] szExtensionID = tokens[tokens.Length - 1].Split(delimiter2, StringSplitOptions.None);
            string szDownloadPath = "https://clients2.google.com/service/update2/crx?response=redirect&x=id%3D" + szExtensionID[0] + "%26uc";
            WebClient webClient = new WebClient();
            string szFile = tokens[tokens.Length-2] + ".crx";
            webClient.DownloadFile(szDownloadPath, szFile);
            MessageBox.Show("Download Completed.");
        }
    }
}
