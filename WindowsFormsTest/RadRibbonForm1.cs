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
using Telerik.WinControls;

namespace WindowsFormsTest
{
    public partial class RadRibbonForm1 : Telerik.WinControls.UI.RadRibbonForm
    {
        public RadRibbonForm1()
        {
            if (!DesignMode)
            {
                Globals.MainForm = this;                
            }
            InitializeComponent();
            ThemeResolutionService.ApplicationThemeName = "VisualStudio2012Dark";
        }
            
    

        public void addDocumentWindow(DocumentWindow pDocWindow)
        {
            radDock2.AddDocument(pDocWindow);
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
                    newWindow.Parent = documentTabStrip1;

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

                if (((MainLogicDesigner)documentTabStrip1.ActiveWindow.Controls[0]).filePath != null){
                    saveFileDialog.FileName = ((MainLogicDesigner)documentTabStrip1.ActiveWindow.Controls[0]).filePath;
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
                currentDesigner.filePath = p;
            }
        }

        private void NewBlankDocument_Click(object sender, EventArgs e)
        {
            DocumentWindow newWindow = new DocumentWindow();
            MainLogicDesigner mainLogicDesigner = new MainLogicDesigner();
            newWindow.Controls.Add(mainLogicDesigner);
            mainLogicDesigner.Dock = DockStyle.Fill;
            radDock2.AddDocument(newWindow);
            newWindow.Text = newWindow.Text.Replace("documentWindow", "Schematic ");
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (((MainLogicDesigner)documentTabStrip1.ActiveWindow.Controls[0]).filePath != null){
                SaveFile(((MainLogicDesigner)documentTabStrip1.ActiveWindow.Controls[0]).filePath);
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

        private void radDock2_Initialized(object sender, EventArgs e)
        {
            radDock2.LoadFromXml(@"E:\Development\LogicDesigner\WindowsFormsTest\Resources\Deafult.xml");

            //SettingsToolWindow toolWindow = new SettingsToolWindow();

            //radDock2.AddDocument(toolWindow);

            /*Settings SettingsControl = new Settings();

            SettingsControl.Dock = DockStyle.Fill;

            foreach(ToolWindow window in Globals.MainForm.Controls.Find("ColorSetting", true)){
                window.Controls.Add(SettingsControl);
            }

            StandardTools StandardToolsControl = new StandardTools();

            StandardToolsControl.Dock = DockStyle.Fill;

            foreach(ToolWindow window in Globals.MainForm.Controls.Find("StandardTools", true)){
                window.Controls.Add(StandardToolsControl);
            }*/
        }

        private void LoadLayout_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = String.Format("{0} (*{1})|*{1}", "Xml files", ".xml");
                openFileDialog.DefaultExt = ".xml";
                
                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    radDock2.LoadFromXml(openFileDialog.FileName);
                }
            }
        }

        private void SaveLayout_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = String.Format("{0} (*{1})|*{1}", "Xml files", ".xml");
                saveFileDialog.DefaultExt = ".xml";
                
                if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    radDock2.SaveToXml(saveFileDialog.FileName);
                }
            }
        }

        private void NewStandardToolsButton_Click(object sender, EventArgs e)
        {
            StandardToolsToolWindow standardToolsWindow = new StandardToolsToolWindow();
            standardToolsWindow.DockState = DockState.Floating;

            radDock2.DockWindow(standardToolsWindow, DockPosition.Left);
        }

        private void ColorSettings_Click(object sender, EventArgs e)
        {
            SettingsToolWindow settingsToolWindow = new SettingsToolWindow();
            settingsToolWindow.DockState = DockState.Floating;

            radDock2.DockWindow(settingsToolWindow, DockPosition.Right);
        }

        private void RadRibbonForm1_Load(object sender, EventArgs e)
        {
            ThemeResolutionService.ApplicationThemeName = "VisualStudio2012Light";
        }

        private void radContextMenu1_DropDownOpened(object sender, EventArgs e)
        {
            radContextMenu1.Items[1].Click += Options_Click;
        }

        private void Options_Click(object sender, EventArgs e)
        {
            Options optionForm = new Options();
            optionForm.Show();
        }

        private void radContextMenu1_DropDownClosed(object sender, EventArgs e)
        {
            radContextMenu1.Items[1].Click -= Options_Click;
        }

        private void SaveContainer_Click(object sender, EventArgs e)
        {

        }

        private void LoadDeafultLayout_Click(object sender, EventArgs e)
        {
            radDock2.LoadFromXml(@"E:\Development\LogicDesigner\WindowsFormsTest\Resources\Deafult.xml");
        }


    }
}