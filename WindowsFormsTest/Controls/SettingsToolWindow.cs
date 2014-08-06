using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsTest.Controls
{
    class SettingsToolWindow : Telerik.WinControls.UI.Docking.ToolWindow
    {
        public SettingsToolWindow()
        {
            Settings settingsControl = new Settings();
            settingsControl.Dock = System.Windows.Forms.DockStyle.Fill;

            this.Controls.Add(settingsControl);
        }
    }
}
