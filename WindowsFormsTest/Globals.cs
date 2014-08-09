using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls;
using WindowsFormsTest.Controls;

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

        internal static Color WireColor { get; set; }

        internal static String LayoutPath { get; set; }

        internal static String Theme { get { return ThemeResolutionService.ApplicationThemeName; } set { ThemeResolutionService.ApplicationThemeName = value; } }

        static DesignerSettings()
        {
            //Set default Value
            WireColor = Color.FromArgb(0, 122, 204);
            
            Theme = "Windows8";
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
