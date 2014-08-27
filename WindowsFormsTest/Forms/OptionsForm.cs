using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsTest.Forms
{
    public partial class OptionsForm : Telerik.WinControls.UI.ShapedForm
    {
        public SettingData getSettingsData()
        {
            SettingData result = new SettingData();

            result.Theme = (radPageViewPage1.Controls[0] as Controls.SettingsControls.Appearance).getThemeName();
            result.RecentFilesCount = (SavingAndLoadingTab.Controls[0] as Controls.SettingsControls.SavingAndLoading).getData();

            return result;
        }

        public OptionsForm()
        {
            InitializeComponent();
        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public class SettingData
        {
            public int RecentFilesCount;
            public string Theme;
        }

        private void Ok_btn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            
        }
    }
}
