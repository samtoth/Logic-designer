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
                DesignerSettings.Theme = "VisualStudio2012Dark";
            }
            else if (ThemeDropDownBox.SelectedText == "Light")
            {
                DesignerSettings.Theme = "VisualStudio2012Light";
            }
            else if(ThemeDropDownBox.SelectedText == "silver"){
                DesignerSettings.Theme = "Office2007Silver";
            }
            else if (ThemeDropDownBox.SelectedText == "Blue")
            {
                DesignerSettings.Theme = "Office2010Blue";
            }
            else if(ThemeDropDownBox.SelectedText == String.Empty)
            {
                DesignerSettings.Theme = "Windows8";
            }
            else
            {
                DesignerSettings.Theme = ThemeDropDownBox.SelectedText;
            }


            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
