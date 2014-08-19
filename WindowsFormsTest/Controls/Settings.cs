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
        private void Settings_Load(object sender, EventArgs e)
        {
        }

        public void SetSettingsTarget(MainLogicDesigner.DesignerProperties designerProperties)
        {
            radPropertyGrid1.SelectedObject = designerProperties;
        }

    }
}
