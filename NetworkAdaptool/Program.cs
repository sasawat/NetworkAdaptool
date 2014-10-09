using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace NetworkAdaptool
{
    static class Program
    {

        public static Dictionary<string, IPV4Settings> dicProfiles;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        static void loadProfiles()
        {
            if(File.Exists("profilelibrary"))
            {

            }
            else
            {
                dicProfiles = new Dictionary<string, IPV4Settings>();
                
            }
        }
    }
}
