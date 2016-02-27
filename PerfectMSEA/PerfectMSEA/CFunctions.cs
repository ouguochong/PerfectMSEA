using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PerfectMSEA
{
    class CFunctions
    {
        WebClient wc;

        public CFunctions()
        {
            wc = new WebClient();
        }

        public bool CheckGHStatus()
        {
            if (wc.DownloadString("https://raw.githubusercontent.com/tdeyi1996/tdeyi1996.github.io/master/status.txt").Contains("1"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void DownloadOriginalPCOM(string mapleDir)
        {
            string fileURL = wc.DownloadString("https://raw.githubusercontent.com/tdeyi1996/tdeyi1996.github.io/master/pcom.proxy.txt");
            wc.DownloadFile(fileURL, mapleDir + "\\PCOM.proxy");
        }

        public void DownloadHackedPCOM(string mapleDir)
        {
            string fileURL = wc.DownloadString("https://raw.githubusercontent.com/tdeyi1996/tdeyi1996.github.io/master/pcom.dll.txt");
            wc.DownloadFile(fileURL, mapleDir + "\\PCOM.dll");
        }
    }
}
