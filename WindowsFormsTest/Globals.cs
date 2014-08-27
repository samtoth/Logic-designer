using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls;
using WindowsFormsTest.Controls;

//TODO Make Recent layout work

namespace WindowsFormsTest
{
    internal static class Globals
    {
        internal static RadRibbonForm1 MainForm { get; set; }
        internal static string UserDataFilename
        {
            get
            {
                return Path.Combine(UserDataPath, "UserPrefs.json");
            }
        }
        internal static string UserDataPath
        {
            get
            {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "LogicDesigner");
            }
        }

        public static void EnsureUserDataPathExists()
        {
            if (!Directory.Exists(UserDataPath))
            {
                Directory.CreateDirectory(UserDataPath);
            }
        }
    }

    internal static class DesignerSettings
    {
        
        internal static String LayoutPath { get; set; }

        internal static String Theme { get { return ThemeResolutionService.ApplicationThemeName; } set { ThemeResolutionService.ApplicationThemeName = value; } }

        internal static List<String> RecentFilePaths { get; set; } 

        internal static  int RecentFileCount { get; set; }

        static DesignerSettings()
        {
            //Set default Value
            RecentFileCount = 10;
            Theme = "Windows8";
            RecentFilePaths = new List<string>();
        }
    }

    internal static class Utilities
    {
        public static Stream GenerateStreamFromString(string s)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

    }
}
