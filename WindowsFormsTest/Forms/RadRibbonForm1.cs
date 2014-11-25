using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsTest.Forms;
using Telerik.WinControls.Enumerations;
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
                        DesignerSettings.Theme = data.Theme;
                        DesignerSettings.RecentFilePaths.AddRange(data.RecentFilePaths);
                        DesignerSettings.RecentFileCount = data.RecentFilesCount;
                    }
                }

                this.FormClosing += RadRibbonForm1_FormClosing;

            }

            InitializeComponent();

        }
        
        private MainLogicDesigner _activeDesigner;

        public void AddDocumentWindow(DocumentWindow pDocWindow)
        {
            radDock2.AddDocument(pDocWindow);
        }

        private void Load_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void OpenFile()
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Filter = String.Format("{0} (*{1})|*{1}", MainLogicDesigner.FileTypeName,
                    MainLogicDesigner.FileExtension);
                fileDialog.DefaultExt = ".sch";

                if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    DocumentWindow newWindow =
                        new DocumentWindow(System.IO.Path.GetFileNameWithoutExtension(fileDialog.FileName));
                    radDock2.AddDocument(newWindow);
                   
                    MainLogicDesigner mainLogicDesigner = new MainLogicDesigner();

                    mainLogicDesigner.FilePath = fileDialog.FileName;

                    newWindow.Controls.Add(mainLogicDesigner);

                    mainLogicDesigner.Dock = DockStyle.Fill;
                    try
                    {
                        mainLogicDesigner.OpenFile(fileDialog.FileName);
                    }
                    catch (Exception ex)
                    {
                        
                        MessageBox.Show(ex.Message);
                    }

                }
            }

        }

        private void SaveAs_Click(object sender, EventArgs e)
        {
            var activeDewsigner = GetActiveDesigner();
            if (activeDewsigner == null)
            {
                return;
            }
            string filePath = GetSaveFilePath(activeDewsigner.FilePath);
            if (!string.IsNullOrEmpty(filePath))
            {
                SaveAs(filePath, activeDewsigner);
            }

        }

        private string GetSaveFilePath(string defaultPath)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = String.Format("{0} (*{1})|*{1}", MainLogicDesigner.FileTypeName,
                    MainLogicDesigner.FileExtension);
                saveFileDialog.DefaultExt = ".sch";

                if (!String.IsNullOrEmpty(defaultPath))
                {
                    saveFileDialog.FileName = defaultPath;
                }

                return saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK ? saveFileDialog.FileName : null;
            }
        }

        private bool SaveAs(string path, MainLogicDesigner designer)
        {
            bool result = false;

            // Compose a string that consists of three lines.
            string lines = designer.GetSaveData();

            // Write the string to a file.
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(path))
            {
                file.WriteLine(lines);

                file.Close();
            }

            designer.Parent.Text = Path.GetFileNameWithoutExtension(path);
            designer.FilePath = path;

            designer.ChangedFlag = false;

            result = true;

            return result;
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
            var activeDewsigner = GetActiveDesigner();
            if (activeDewsigner == null)
            {
                return;
            }
            Save(activeDewsigner);
        }

        MainLogicDesigner GetActiveDesigner()
        {
            if (radDock2.DocumentManager.ActiveDocument == null)
            {
                return null;
            }
            
            return radDock2.DocumentManager.ActiveDocument.Controls[0] as MainLogicDesigner;
        }

        bool Save(MainLogicDesigner designer)
        {
            if (!string.IsNullOrEmpty(designer.FilePath))
            {
                return SaveAs(designer.FilePath, designer);
            }
            else
            {
                string saveFilePath = GetSaveFilePath("");
                if (!string.IsNullOrEmpty(saveFilePath))
                {
                    return SaveAs(saveFilePath, designer);
                }
            }
            return false;
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

        private void RadRibbonForm1_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var documentWindow in radDock2.DockWindows)
            {
                if(documentWindow is DocumentWindow)
                e.Cancel = !SaveIfRequired(documentWindow as DocumentWindow);
                if (e.Cancel)
                {
                    break;
                }
            }

            //SAve settings
            if (!e.Cancel)
            {

                var pd = new PreferenceDataSerializer(ThemeResolutionService.ApplicationThemeName, DesignerSettings.LayoutPath, DesignerSettings.RecentFilePaths, DesignerSettings.RecentFileCount);
                pd.SaveToFile(Globals.UserDataFilename);
            }
        }
        
        private class PreferenceDataSerializer
        {
            public String Theme = String.Empty;
            public String LayoutPath = String.Empty;
            public List<String> RecentFilePaths = new List<string>();
            public int RecentFilesCount = 0;

            public PreferenceDataSerializer(String pTheme, String pLayoutPath, List<String> filePaths, int recentFileCount)
            {
                Theme = pTheme;
                LayoutPath = pLayoutPath;
                RecentFilePaths = filePaths;
                RecentFilesCount = recentFileCount;
            }

            public static PreferenceDataSerializer LoadFromFile(string filename)
            {
                return JsonConvert.DeserializeObject<PreferenceDataSerializer>(System.IO.File.ReadAllText(filename));
            }

            public void SaveToFile(string filename)
            {
                String prefData = JsonConvert.SerializeObject(this);//TODO Change to indented formatting
                Directory.CreateDirectory(Path.GetDirectoryName(filename)); //Ensure it exists
                File.WriteAllText(filename, prefData);
            }
        }


        private void Options_Click(object sender, EventArgs e)
        {
            OptionsForm optionForm = new OptionsForm();
            optionForm.Show();
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
                Settings settings = FindSettingsWindow();
                if (settings != null)
                {
                    var designer = GetActiveDesigner();
                    if (designer != null)
                    {
                        settings.SetSettingsTarget(designer.Properties);
                    }
                }
            }
        }

        public Settings FindSettingsWindow()
        {
            foreach (var toolWindow in radDock2.DockWindows.ToolWindows.Where(toolWindow => toolWindow is SettingsToolWindow && (toolWindow as SettingsToolWindow).Controls[0] != null && ((toolWindow as SettingsToolWindow).Controls[0] as Settings) != null))
            {
                    return (toolWindow.Controls[0] as Settings);
            }
            return null;
        }

        private void RadRibbonForm1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void radDock2_DockWindowClosing(object sender, DockWindowCancelEventArgs e)
        {
            if (e.NewWindow is DocumentWindow)
            {
                e.Cancel = !SaveIfRequired(e.NewWindow as DocumentWindow);
            }
            if (e.NewWindow is DocumentWindow)
            {
                var designer = e.NewWindow.Controls[0] as MainLogicDesigner;
                if (designer != null && !String.IsNullOrEmpty(designer.FilePath))
                {
                    RecentListAdd(designer.FilePath);
                }
            }
        }

        public bool SaveIfRequired(DocumentWindow designerWindow)
        {
            bool result = false;
            var designer = ((MainLogicDesigner) designerWindow.Controls[0]);

            if (designer.ChangedFlag)
            {
                var dr = MessageBox.Show("Do you want to save " + designerWindow.Text, "Confirm",
                    MessageBoxButtons.YesNoCancel);
                switch (dr)
                {
                    case DialogResult.Yes:
                        result = Save(designer);
                        break;
                    case DialogResult.No:
                        result = true;
                        break;
                }
            }
            else
            {
                result = true;
            }
            return result;
        }

        private void Run_Btn_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            var activeDewsigner = GetActiveDesigner();
            if (activeDewsigner == null)
            {
                
                return;
            }
            activeDewsigner.Running = Run_Btn.ToggleState == ToggleState.On;
        }

        private void Run_Btn_Click(object sender, EventArgs e)
        {

        }

        private void step_btn_Click(object sender, EventArgs e)
        {
            var activeDewsigner = GetActiveDesigner();
            if (activeDewsigner == null)
            {
                return;
            }
            activeDewsigner.UpdateLogicAsync();
        }

        private void Run_Btn_ToggleStateChanging(object sender, Telerik.WinControls.UI.StateChangingEventArgs args)
        {
            if (GetActiveDesigner() == null)
            {
                args.Cancel = true;
                System.Media.SystemSounds.Exclamation.Play();
            }
        }

        private void radDock2_ActiveWindowChanged(object sender, DockWindowEventArgs e)
        {
            if (e.DockWindow is DocumentWindow)
            {
                _activeDesigner = GetActiveDesigner();
                var settings = FindSettingsWindow();
                if (settings != null)
                {
                    settings.SetSettingsTarget(_activeDesigner.Properties);
                }
            }
        }

        private void ribbonTab3_Click(object sender, EventArgs e)
        {

        }

        private void Recent_btn_Click(object sender, EventArgs e)
        {
            ListPicker frm = new ListPicker("Recent", "Choose from your recent files from below");
            frm.ListControl.DataSource = DesignerSettings.RecentFilePaths;
            System.Windows.Forms.DialogResult result = frm.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (frm.ListControl.SelectedItem != null)
                {
                    DocumentWindow newWindow = new DocumentWindow(System.IO.Path.GetFileNameWithoutExtension(frm.ListControl.SelectedItem.Text));
                    radDock2.AddDocument(newWindow);

                    MainLogicDesigner mainLogicDesigner = new MainLogicDesigner();

                    mainLogicDesigner.FilePath = frm.ListControl.SelectedItem.Text;

                    newWindow.Controls.Add(mainLogicDesigner);

                    mainLogicDesigner.Dock = DockStyle.Fill;

                    mainLogicDesigner.OpenFile(frm.ListControl.SelectedItem.Text);
                }
                
            }
        }
        internal void RecentListAdd(string fileName)
        {
            #region garbage
            //while(DesignerSettings.RecentFilePaths.Count > 10)//10 is tempory will be changed to a user setting
            //{
            //    DesignerSettings.RecentFilePaths.Remove(DesignerSettings.RecentFilePaths[DesignerSettings.RecentFilePaths.Count - 1]);
            //}
            //DesignerSettings.RecentFilePaths.Add(fileName);

            //foreach (var s in DesignerSettings.RecentFilePaths.Where())
            //{
                
            //}
            #endregion

            //If its allready on the take it out
            //if (DesignerSettings.RecentFilePaths.Contains(fileName))
            {
                DesignerSettings.RecentFilePaths.Remove(fileName);
            }

            //Insert it at the the beggining
            DesignerSettings.RecentFilePaths.Insert(0, fileName);

            //Remove any excess from the bottem
            while (DesignerSettings.RecentFilePaths.Count > DesignerSettings.RecentFileCount && DesignerSettings.RecentFileCount >= 0)
            {
                DesignerSettings.RecentFilePaths.Remove(DesignerSettings.RecentFilePaths[DesignerSettings.RecentFilePaths.Count - 1]);
            }
        }

        private void radDock2_DockWindowClosed(object sender, DockWindowEventArgs e)
        {
            
        }

        private void Options_btn_Click(object sender, EventArgs e)
        {
            using (OptionsForm frm = new OptionsForm())
            {
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    OptionsForm.SettingData dat = frm.getSettingsData();

                    DesignerSettings.RecentFileCount = dat.RecentFilesCount;
                    DesignerSettings.Theme = dat.Theme;
                    DesignerSettings.wireType = dat.wireType;
                }
            }
        }
    }
}