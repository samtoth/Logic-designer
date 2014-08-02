using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI.Docking;
using WindowsFormsTest.Controls;

namespace WindowsFormsTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Globals.MainForm = this;
        }


        private void radTitleBar1_Click(object sender, EventArgs e)
        {

        }

        private void radButtonElement1_Click(object sender, EventArgs e)
        {
            //partDesigner pd = new partDesigner();
            //pd.Text = "bollox";
            //radDock1.DockControl(pd, DockPosition.Left);

            newPartMessageBox messageBox = new newPartMessageBox();

            messageBox.Show();

            
        }

        public void addDocumentWindow(DocumentWindow pDocWindow)
        {
            radDock1.AddDocument(pDocWindow);
        }


    }
}
