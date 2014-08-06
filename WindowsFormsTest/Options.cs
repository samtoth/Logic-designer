using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace WindowsFormsTest
{
    public partial class Options : Telerik.WinControls.UI.ShapedForm
    {
        public Options()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (ThemeDropDownBox.SelectedText == "Dark")
            {
                ThemeResolutionService.ApplicationThemeName = "VisualStudio2012Dark";
            }
            else if (ThemeDropDownBox.SelectedText == "Light")
            {
                ThemeResolutionService.ApplicationThemeName = "VisualStudio2012Light";
            }
            else if(ThemeDropDownBox.SelectedText == "silver"){
                ThemeResolutionService.ApplicationThemeName = "Office2007Silver";
            }
            else if (ThemeDropDownBox.SelectedText == "Blue")
            {
                ThemeResolutionService.ApplicationThemeName = "Office2010Blue";
            }
            else
            {
                ThemeResolutionService.ApplicationThemeName = ThemeDropDownBox.SelectedText;
            }


            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
