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
            loadProfiles();
            Application.Run(new Form1());
        }

        /// <summary>
        /// Loads profiles from the default profile library file
        /// </summary>
        static void loadProfiles()
        {
            if(File.Exists("profilelibrary"))
            {
                FileStream fsProfiles = File.OpenRead("profilelibrary");
                dicProfiles = IPV4Settings.readLibrary(fsProfiles);
                fsProfiles.Close();
            }
            else
            {
                dicProfiles = new Dictionary<string, IPV4Settings>();
                dicProfiles.Add("Dynamic", new IPV4Settings(null, null, null, null, null, "Dynamic", true, true));
                FileStream fsProfiles = File.Create("profilelibrary");
                IPV4Settings.writeLibrary(fsProfiles, dicProfiles);
                fsProfiles.Close();
            }
        }

        /// <summary>
        /// Saves profiles to the default profile library file
        /// </summary>
        static void saveProfiles()
        {
            FileStream fsProfiles = File.Create("profilelibrary");
            IPV4Settings.writeLibrary(fsProfiles, dicProfiles);
            fsProfiles.Close();
        }
    }
}
