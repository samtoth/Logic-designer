using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsTest.Forms
{
    public partial class SplashScreenLogicDesigner : Form
    {
        public SplashScreenLogicDesigner()
        {
            InitializeComponent();
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            timer1.Interval = 20;
            timer1.Start();
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            RadRibbonForm1 mainForm = new RadRibbonForm1();
            mainForm.Show();
            this.Hide();
        }
    }
}
