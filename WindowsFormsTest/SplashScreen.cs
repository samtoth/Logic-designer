using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsTest
{
    public partial class SplashScreen : Telerik.WinControls.UI.ShapedForm
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            timer1.Interval = 10;
                        
            timer1.Tick += timer1_Tick;

            timer1.Start();

            
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            RadRibbonForm1 mainForm = new RadRibbonForm1();
            mainForm.Show();

            this.Hide();
            timer1.Stop();
        }
    }
}
