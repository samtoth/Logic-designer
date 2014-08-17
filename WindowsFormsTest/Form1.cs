using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            if (!DesignMode)
            {
               // Globals.MainForm = this;
            }
        }


        private void radTitleBar1_Click(object sender, EventArgs e)
        {

        }

        private void radButtonElement1_Click(object sender, EventArgs e)
        {
            //partDesigner pd = new partDesigner();
            //pd.Text = "bollox";
            //radDock1.DockControl(pd, DockPosition.Left);

            SaveAsMessageBox messageBox = new SaveAsMessageBox();

            messageBox.Show();

            
        }

        public void addDocumentWindow(DocumentWindow pDocWindow)
        {
            radDock1.AddDocument(pDocWindow);
        }

        private void radMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void Load_Click(object sender, EventArgs e)
        {
            //mainLogicDesigner1.OpenFile(@"C:\Users\Sam\Documents\test.bollocks");
            OpenFile();
        }

        private void OpenFile()
        {
            using(OpenFileDialog fileDialog = new OpenFileDialog()){
                fileDialog.Filter = String.Format("{0} (*{1})|*{1}", MainLogicDesigner.FileTypeName, MainLogicDesigner.FileExtension);
                fileDialog.DefaultExt = ".sch";

                if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    DocumentWindow newWindow = new DocumentWindow(System.IO.Path.GetFileNameWithoutExtension(fileDialog.FileName));
                    documentTabStrip1.Controls.Add(newWindow.Parent);

                    MainLogicDesigner mainLogicDesigner = new MainLogicDesigner();

                    newWindow.Controls.Add(mainLogicDesigner);

                    mainLogicDesigner.Dock = DockStyle.Fill;

                    mainLogicDesigner.OpenFile(fileDialog.FileName);
                    
                }  
            }

        }

        private void SaveAs_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog()){                
                saveFileDialog.Filter = String.Format("{0} (*{1})|*{1}", MainLogicDesigner.FileTypeName, MainLogicDesigner.FileExtension);
                saveFileDialog.DefaultExt = ".sch";

                if (((MainLogicDesigner)documentTabStrip1.ActiveWindow.Controls[0]).FilePath != null){
                    saveFileDialog.FileName = ((MainLogicDesigner)documentTabStrip1.ActiveWindow.Controls[0]).FilePath;
                }

                if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                    SaveFile(saveFileDialog.FileName);
                }                
            }
        }

        private void SaveFile(string p)
        {
            var currentDesigner = (MainLogicDesigner)documentTabStrip1.ActiveWindow.Controls[0];
            if (currentDesigner != null)
            {
                
                // Compose a string that consists of three lines.
                string lines = currentDesigner.getSaveData();

                // Write the string to a file.
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(p))
                {
                    file.WriteLine(lines);

                    file.Close();
                }

                documentTabStrip1.ActiveWindow.Text = Path.GetFileNameWithoutExtension(p);
                currentDesigner.FilePath = p;
            }
        }

        private void NewBlankDocument_Click(object sender, EventArgs e)
        {
            DocumentWindow newWindow = new DocumentWindow();
            MainLogicDesigner mainLogicDesigner = new MainLogicDesigner();
            newWindow.Controls.Add(mainLogicDesigner);
            mainLogicDesigner.Dock = DockStyle.Fill;
            radDock1.AddDocument(newWindow);
            newWindow.Text = newWindow.Text.Replace("documentWindow", "Schematic ");
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (((MainLogicDesigner)documentTabStrip1.ActiveWindow.Controls[0]).FilePath != null){
                SaveFile(((MainLogicDesigner)documentTabStrip1.ActiveWindow.Controls[0]).FilePath);
            }
            else
            {
                SaveAs_Click(sender, e);
            }
        }

        private void playButton_MouseDown(object sender, MouseEventArgs e)
        {
           // playButton.BackgroundImage = Properties.Resources.playButton_pressed;
        }

        private void playButton_MouseUp(object sender, MouseEventArgs e)
        {
           // playButton.BackgroundImage = Properties.Resources.playButton;
        }

        private void mainLogicDesigner1_Load(object sender, EventArgs e)
        {

        }


    }
}
