using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI.Docking;

namespace WindowsFormsTest
{
    public partial class SaveAsMessageBox : Telerik.WinControls.UI.RadForm
    {
        public SaveAsMessageBox()
        {
            InitializeComponent();
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            partDesignerControl designerWindow = new partDesignerControl();
            DocumentWindow newDock = new DocumentWindow();

            newDock.Controls.Add(designerWindow);
            designerWindow.Dock = DockStyle.Fill;

            Globals.MainForm.AddDocumentWindow(newDock);

            
        }

    }
}
