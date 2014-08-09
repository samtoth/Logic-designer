using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsTest.Controls
{
    public partial class Settings : UserControl
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void WireColor_ValueChanged(object sender, EventArgs e)
        {
            DesignerSettings.WireColor = WireColor.Value;
            Globals.MainForm.Refresh();
        }

        private void Settings_Load(object sender, EventArgs e)
        {            
            WireColor.Value = DesignerSettings.WireColor;
        }

        private void WireColor_ValueChanging(object sender, Telerik.WinControls.UI.ValueChangingEventArgs e)
        {
            WireColor_ValueChanged(sender, e);
        }
    }
}
