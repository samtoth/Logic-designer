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
using Newtonsoft.Json;

namespace WindowsFormsTest
{
    public partial class RadRibbonForm1 : Telerik.WinControls.UI.RadRibbonForm
    {
        public RadRibbonForm1()
        {
            if (!DesignMode)
            {
                Globals.MainForm = this;
                if (File.Exists(Globals.UserDataFilename))
                {
                    PreferenceDataSerializer data = PreferenceDataSerializer.LoadFromFile(Globals.UserDataFilename);
                    if (data != null)
                    {
                        DesignerSettings.LayoutPath = data.LayoutPath;
                        DesignerSettings.WireColor = data.Color;
                        DesignerSettings.Theme = data.Theme;
                    }
                }

                this.FormClosing += RadRibbonForm1_FormClosing;
                
            }

            InitializeComponent();
        
        }

        public void addDocumentWindow(DocumentWindow pDocWindow)
        {
            radDock2.AddDocument(pDocWindow);
        }

        private void Load_Click(object sender, EventArgs e)
        {
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

        private void radDock2_Initialized(object sender, EventArgs e)
        {
            LoadDefaultLayout();

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

                    DesignerSettings.LayoutPath = openFileDialog.FileName;
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

        void RadRibbonForm1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var pd = new PreferenceDataSerializer(ThemeResolutionService.ApplicationThemeName, DesignerSettings.WireColor, DesignerSettings.LayoutPath);
            pd.SaveToFile(Globals.UserDataFilename);
        }

        

        class PreferenceDataSerializer
        {
            public String Theme = String.Empty;
            public Color Color = Color.Empty;
            public String LayoutPath = String.Empty;

            public PreferenceDataSerializer(String pTheme, Color wireColor, String pLayoutPath)
            {
                Theme = pTheme;
                Color = wireColor;
                LayoutPath = pLayoutPath;
            }

            public static PreferenceDataSerializer LoadFromFile(string filename)
            {
                return JsonConvert.DeserializeObject<PreferenceDataSerializer>(File.ReadAllText(filename));
            }
            public void SaveToFile(string filename)
            {
                String prefData = JsonConvert.SerializeObject(this);
                Directory.CreateDirectory(Path.GetDirectoryName(filename)); //Ensure it exists
                File.WriteAllText(filename, prefData);
            }
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

        private void LoadDefaultLayout_Click(object sender, EventArgs e)
        {
            LoadDefaultLayout();
        }

        private void LoadDefaultLayout()
        {
            using (Stream s = Utilities.GenerateStreamFromString(Properties.Resources.Default))
            {
                radDock2.LoadFromXml(s);
            }
            
        }
        


    }
}