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
    public partial class SavingAndLoading : UserControl
    {
        public SavingAndLoading()
        {
            InitializeComponent();
            numericUpDown1.Value = DesignerSettings.RecentFileCount;
        }

        private void radTextBox1_TextChanging(object sender, Telerik.WinControls.TextChangingEventArgs e)
        {
            if (!Char.IsDigit(e.NewValue.Last()))
            {
                e.Cancel = true;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        public int getData()
        {
            return (int)numericUpDown1.Value;
        }
    }
}
