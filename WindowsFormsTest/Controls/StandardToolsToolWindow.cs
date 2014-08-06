using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsTest.Controls
{
    class StandardToolsToolWindow : Telerik.WinControls.UI.Docking.ToolWindow
    {
        public StandardToolsToolWindow()
        {
            StandardTools StandardTools = new StandardTools();
            StandardTools.Dock = System.Windows.Forms.DockStyle.Fill;

            this.Controls.Add(StandardTools);
        }
    }
}
