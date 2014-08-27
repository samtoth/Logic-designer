using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsTest.Controls.SettingsControls
{
    public partial class Appearance : UserControl
    {
        public Appearance()
        {
            InitializeComponent();
        }

        public string getThemeName()
        {
            if (ThemeDropDownBox.SelectedText == "Dark")
            {
                return "VisualStudio2012Dark";
            }
            if (ThemeDropDownBox.SelectedText == "Light")
            {
                return "VisualStudio2012Light";
            }
            if (ThemeDropDownBox.SelectedText == "silver")
            {
                return "Office2007Silver";
            }
            if (ThemeDropDownBox.SelectedText == "Blue")
            {
                return "Office2010Blue";
            }
            if (ThemeDropDownBox.SelectedText == String.Empty)
            {
                return "Windows8";
            }
            return ThemeDropDownBox.SelectedText;
        }
    }
}
