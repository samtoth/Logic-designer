namespace WindowsFormsTest
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.visualStudio2012DarkTheme1 = new Telerik.WinControls.Themes.VisualStudio2012DarkTheme();
            this.radDock1 = new Telerik.WinControls.UI.Docking.RadDock();
            this.toolWindow2 = new Telerik.WinControls.UI.Docking.ToolWindow();
            this.settings1 = new WindowsFormsTest.Controls.Settings();
            this.toolsWindow = new Telerik.WinControls.UI.Docking.ToolTabStrip();
            this.toolWindow1 = new Telerik.WinControls.UI.Docking.ToolWindow();
            this.standardTools1 = new WindowsFormsTest.Controls.StandardTools();
            this.documentContainer1 = new Telerik.WinControls.UI.Docking.DocumentContainer();
            this.toolTabStrip3 = new Telerik.WinControls.UI.Docking.ToolTabStrip();
            this.documentTabStrip1 = new Telerik.WinControls.UI.Docking.DocumentTabStrip();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.object_53829f1b_b5cc_4ca1_b874_80bb15bbbfb7 = new Telerik.WinControls.RootRadElement();
            this.radStatusStrip1 = new Telerik.WinControls.UI.RadStatusStrip();
            this.performanceCounter1 = new System.Diagnostics.PerformanceCounter();
            this.radRibbonBar1 = new Telerik.WinControls.UI.RadRibbonBar();
            this.ribbonTab1 = new Telerik.WinControls.UI.RibbonTab();
            this.radRibbonBarGroup1 = new Telerik.WinControls.UI.RadRibbonBarGroup();
            this.newPart = new Telerik.WinControls.UI.RadButtonElement();
            this.SavedParts = new Telerik.WinControls.UI.RadButtonElement();
            this.radRibbonBarGroup2 = new Telerik.WinControls.UI.RadRibbonBarGroup();
            this.SaveLayout = new Telerik.WinControls.UI.RadButtonElement();
            this.LoadLayout = new Telerik.WinControls.UI.RadButtonElement();
            this.New = new Telerik.WinControls.UI.RadMenuItem();
            this.NewBlankDocument = new Telerik.WinControls.UI.RadMenuButtonItem();
            this.Save = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuButtonItem1 = new Telerik.WinControls.UI.RadMenuButtonItem();
            this.SaveAs = new Telerik.WinControls.UI.RadMenuButtonItem();
            this.Load = new Telerik.WinControls.UI.RadMenuItem();
            this.LoadFile = new Telerik.WinControls.UI.RadMenuButtonItem();
            this.LoadTemplate = new Telerik.WinControls.UI.RadMenuButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.radDock1)).BeginInit();
            this.radDock1.SuspendLayout();
            this.toolWindow2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toolsWindow)).BeginInit();
            this.toolsWindow.SuspendLayout();
            this.toolWindow1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolTabStrip3)).BeginInit();
            this.toolTabStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentTabStrip1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radStatusStrip1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.performanceCounter1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRibbonBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // radDock1
            // 
            this.radDock1.ActiveWindow = this.toolWindow1;
            this.radDock1.BackColor = System.Drawing.Color.Gray;
            this.radDock1.CausesValidation = false;
            this.radDock1.Controls.Add(this.toolsWindow);
            this.radDock1.Controls.Add(this.documentContainer1);
            this.radDock1.Controls.Add(this.toolTabStrip3);
            this.radDock1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radDock1.ForeColor = System.Drawing.Color.White;
            this.radDock1.IsCleanUpTarget = true;
            this.radDock1.Location = new System.Drawing.Point(0, 161);
            this.radDock1.MainDocumentContainer = this.documentContainer1;
            this.radDock1.Name = "radDock1";
            this.radDock1.Padding = new System.Windows.Forms.Padding(0);
            // 
            // 
            // 
            this.radDock1.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.radDock1.Size = new System.Drawing.Size(1002, 476);
            this.radDock1.SplitterWidth = 2;
            this.radDock1.TabIndex = 1;
            this.radDock1.TabStop = false;
            this.radDock1.Text = "radDock1";
            this.radDock1.ThemeName = "VisualStudio2012Dark";
            // 
            // toolWindow2
            // 
            this.toolWindow2.Caption = null;
            this.toolWindow2.Controls.Add(this.settings1);
            this.toolWindow2.Location = new System.Drawing.Point(4, 24);
            this.toolWindow2.Name = "toolWindow2";
            this.toolWindow2.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.Docked;
            this.toolWindow2.Size = new System.Drawing.Size(251, 448);
            this.toolWindow2.Text = "Settings";
            // 
            // settings1
            // 
            this.settings1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.settings1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settings1.Location = new System.Drawing.Point(0, 0);
            this.settings1.Name = "settings1";
            this.settings1.Size = new System.Drawing.Size(251, 448);
            this.settings1.TabIndex = 0;
            // 
            // toolsWindow
            // 
            this.toolsWindow.CanUpdateChildIndex = true;
            this.toolsWindow.CausesValidation = false;
            this.toolsWindow.Controls.Add(this.toolWindow1);
            this.toolsWindow.Location = new System.Drawing.Point(0, 0);
            this.toolsWindow.Name = "toolsWindow";
            // 
            // 
            // 
            this.toolsWindow.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.toolsWindow.SelectedIndex = 0;
            this.toolsWindow.Size = new System.Drawing.Size(200, 476);
            this.toolsWindow.TabIndex = 1;
            this.toolsWindow.TabStop = false;
            this.toolsWindow.Text = "Tools";
            this.toolsWindow.ThemeName = "VisualStudio2012Dark";
            // 
            // toolWindow1
            // 
            this.toolWindow1.Caption = null;
            this.toolWindow1.Controls.Add(this.standardTools1);
            this.toolWindow1.Location = new System.Drawing.Point(4, 24);
            this.toolWindow1.Name = "toolWindow1";
            this.toolWindow1.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.Docked;
            this.toolWindow1.Size = new System.Drawing.Size(192, 448);
            this.toolWindow1.Text = "Standard Tools";
            // 
            // standardTools1
            // 
            this.standardTools1.AutoSize = true;
            this.standardTools1.BackColor = System.Drawing.SystemColors.GrayText;
            this.standardTools1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.standardTools1.Location = new System.Drawing.Point(0, 0);
            this.standardTools1.Name = "standardTools1";
            this.standardTools1.Size = new System.Drawing.Size(192, 448);
            this.standardTools1.TabIndex = 0;
            // 
            // documentContainer1
            // 
            this.documentContainer1.CausesValidation = false;
            this.documentContainer1.Name = "documentContainer1";
            // 
            // 
            // 
            this.documentContainer1.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.documentContainer1.SizeInfo.AbsoluteSize = new System.Drawing.Size(539, 200);
            this.documentContainer1.SizeInfo.SizeMode = Telerik.WinControls.UI.Docking.SplitPanelSizeMode.Fill;
            this.documentContainer1.SizeInfo.SplitterCorrection = new System.Drawing.Size(-59, 0);
            this.documentContainer1.SplitterWidth = 2;
            this.documentContainer1.TabIndex = 2;
            this.documentContainer1.ThemeName = "VisualStudio2012Dark";
            // 
            // toolTabStrip3
            // 
            this.toolTabStrip3.CanUpdateChildIndex = true;
            this.toolTabStrip3.CausesValidation = false;
            this.toolTabStrip3.Controls.Add(this.toolWindow2);
            this.toolTabStrip3.Location = new System.Drawing.Point(743, 0);
            this.toolTabStrip3.Name = "toolTabStrip3";
            // 
            // 
            // 
            this.toolTabStrip3.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.toolTabStrip3.SelectedIndex = 0;
            this.toolTabStrip3.Size = new System.Drawing.Size(259, 476);
            this.toolTabStrip3.SizeInfo.AbsoluteSize = new System.Drawing.Size(259, 200);
            this.toolTabStrip3.SizeInfo.SplitterCorrection = new System.Drawing.Size(59, 0);
            this.toolTabStrip3.TabIndex = 3;
            this.toolTabStrip3.TabStop = false;
            this.toolTabStrip3.ThemeName = "VisualStudio2012Dark";
            // 
            // documentTabStrip1
            // 
            this.documentTabStrip1.CanUpdateChildIndex = true;
            this.documentTabStrip1.CausesValidation = false;
            this.documentTabStrip1.Location = new System.Drawing.Point(0, 0);
            this.documentTabStrip1.Name = "documentTabStrip1";
            // 
            // 
            // 
            this.documentTabStrip1.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.documentTabStrip1.Size = new System.Drawing.Size(487, 476);
            this.documentTabStrip1.TabIndex = 0;
            this.documentTabStrip1.TabStop = false;
            this.documentTabStrip1.ThemeName = "VisualStudio2012Dark";
            // 
            // object_53829f1b_b5cc_4ca1_b874_80bb15bbbfb7
            // 
            this.object_53829f1b_b5cc_4ca1_b874_80bb15bbbfb7.MinSize = new System.Drawing.Size(0, 0);
            this.object_53829f1b_b5cc_4ca1_b874_80bb15bbbfb7.Name = "object_53829f1b_b5cc_4ca1_b874_80bb15bbbfb7";
            this.object_53829f1b_b5cc_4ca1_b874_80bb15bbbfb7.StretchHorizontally = true;
            this.object_53829f1b_b5cc_4ca1_b874_80bb15bbbfb7.StretchVertically = true;
            this.object_53829f1b_b5cc_4ca1_b874_80bb15bbbfb7.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // radStatusStrip1
            // 
            this.radStatusStrip1.Location = new System.Drawing.Point(0, 613);
            this.radStatusStrip1.Name = "radStatusStrip1";
            this.radStatusStrip1.Size = new System.Drawing.Size(1002, 26);
            this.radStatusStrip1.TabIndex = 1;
            this.radStatusStrip1.Text = "radStatusStrip1";
            this.radStatusStrip1.ThemeName = "VisualStudio2012Dark";
            // 
            // radRibbonBar1
            // 
            this.radRibbonBar1.CommandTabs.AddRange(new Telerik.WinControls.RadItem[] {
            this.ribbonTab1});
            this.radRibbonBar1.Location = new System.Drawing.Point(0, 0);
            this.radRibbonBar1.Name = "radRibbonBar1";
            this.radRibbonBar1.Size = new System.Drawing.Size(1002, 161);
            this.radRibbonBar1.StartButtonImage = ((System.Drawing.Image)(resources.GetObject("radRibbonBar1.StartButtonImage")));
            this.radRibbonBar1.StartMenuItems.AddRange(new Telerik.WinControls.RadItem[] {
            this.New,
            this.Save,
            this.Load});
            this.radRibbonBar1.TabIndex = 0;
            this.radRibbonBar1.ThemeName = "VisualStudio2012Dark";
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.AccessibleDescription = "Create";
            this.ribbonTab1.AccessibleName = "Create";
            this.ribbonTab1.IsSelected = true;
            this.ribbonTab1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radRibbonBarGroup1,
            this.radRibbonBarGroup2});
            this.ribbonTab1.Name = "ribbonTab1";
            this.ribbonTab1.Text = "Layout";
            this.ribbonTab1.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // radRibbonBarGroup1
            // 
            this.radRibbonBarGroup1.AccessibleDescription = "parts";
            this.radRibbonBarGroup1.AccessibleName = "parts";
            this.radRibbonBarGroup1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.newPart,
            this.SavedParts});
            this.radRibbonBarGroup1.Margin = new System.Windows.Forms.Padding(0);
            this.radRibbonBarGroup1.MaxSize = new System.Drawing.Size(0, 0);
            this.radRibbonBarGroup1.MinSize = new System.Drawing.Size(0, 0);
            this.radRibbonBarGroup1.Name = "radRibbonBarGroup1";
            this.radRibbonBarGroup1.Text = "parts";
            this.radRibbonBarGroup1.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // newPart
            // 
            this.newPart.AccessibleDescription = "newPart";
            this.newPart.AccessibleName = "newPart";
            this.newPart.Name = "newPart";
            this.newPart.Text = "newPart";
            this.newPart.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.newPart.Click += new System.EventHandler(this.radButtonElement1_Click);
            // 
            // SavedParts
            // 
            this.SavedParts.AccessibleDescription = "savedParts";
            this.SavedParts.AccessibleName = "savedParts";
            this.SavedParts.Name = "SavedParts";
            this.SavedParts.Text = "savedParts";
            this.SavedParts.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // radRibbonBarGroup2
            // 
            this.radRibbonBarGroup2.AccessibleDescription = "Save and Load Layouts";
            this.radRibbonBarGroup2.AccessibleName = "Save and Load Layouts";
            this.radRibbonBarGroup2.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.SaveLayout,
            this.LoadLayout});
            this.radRibbonBarGroup2.Name = "radRibbonBarGroup2";
            this.radRibbonBarGroup2.Text = "Save and Load Layouts";
            this.radRibbonBarGroup2.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // SaveLayout
            // 
            this.SaveLayout.AccessibleDescription = "Save layout";
            this.SaveLayout.AccessibleName = "Save layout";
            this.SaveLayout.Name = "SaveLayout";
            this.SaveLayout.Text = "Save layout";
            this.SaveLayout.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // LoadLayout
            // 
            this.LoadLayout.AccessibleDescription = "Load Layout";
            this.LoadLayout.AccessibleName = "Load Layout";
            this.LoadLayout.Name = "LoadLayout";
            this.LoadLayout.Text = "Load Layout";
            this.LoadLayout.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // New
            // 
            this.New.AccessibleDescription = "New";
            this.New.AccessibleName = "New";
            this.New.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.NewBlankDocument});
            this.New.Name = "New";
            this.New.Text = "New";
            this.New.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // NewBlankDocument
            // 
            this.NewBlankDocument.AccessibleDescription = "Blank Document";
            this.NewBlankDocument.AccessibleName = "Blank Document";
            // 
            // 
            // 
            this.NewBlankDocument.ButtonElement.AccessibleDescription = "Blank Document";
            this.NewBlankDocument.ButtonElement.AccessibleName = "Blank Document";
            this.NewBlankDocument.Name = "NewBlankDocument";
            this.NewBlankDocument.Text = "Blank Document";
            this.NewBlankDocument.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.NewBlankDocument.Click += new System.EventHandler(this.NewBlankDocument_Click);
            // 
            // Save
            // 
            this.Save.AccessibleDescription = "Save";
            this.Save.AccessibleName = "Save";
            this.Save.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radMenuButtonItem1,
            this.SaveAs});
            this.Save.Name = "Save";
            this.Save.Text = "Save";
            this.Save.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.Save.Click += new System.EventHandler(this.radMenuItem1_Click);
            // 
            // radMenuButtonItem1
            // 
            this.radMenuButtonItem1.AccessibleDescription = "Save";
            this.radMenuButtonItem1.AccessibleName = "Save";
            // 
            // 
            // 
            this.radMenuButtonItem1.ButtonElement.AccessibleDescription = "Save";
            this.radMenuButtonItem1.ButtonElement.AccessibleName = "Save";
            this.radMenuButtonItem1.Name = "radMenuButtonItem1";
            this.radMenuButtonItem1.Text = "Save";
            this.radMenuButtonItem1.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.radMenuButtonItem1.Click += new System.EventHandler(this.Save_Click);
            // 
            // SaveAs
            // 
            this.SaveAs.AccessibleDescription = "Save As";
            this.SaveAs.AccessibleName = "Save As";
            // 
            // 
            // 
            this.SaveAs.ButtonElement.AccessibleDescription = "Save As";
            this.SaveAs.ButtonElement.AccessibleName = "Save As";
            this.SaveAs.Name = "SaveAs";
            this.SaveAs.Text = "Save As";
            this.SaveAs.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.SaveAs.Click += new System.EventHandler(this.SaveAs_Click);
            // 
            // Load
            // 
            this.Load.AccessibleDescription = "Load";
            this.Load.AccessibleName = "Load";
            this.Load.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.LoadFile,
            this.LoadTemplate});
            this.Load.Name = "Load";
            this.Load.Text = "Load";
            this.Load.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // LoadFile
            // 
            this.LoadFile.AccessibleDescription = "From File";
            this.LoadFile.AccessibleName = "From File";
            // 
            // 
            // 
            this.LoadFile.ButtonElement.AccessibleDescription = "From File";
            this.LoadFile.ButtonElement.AccessibleName = "From File";
            this.LoadFile.Name = "LoadFile";
            this.LoadFile.Text = "From File";
            this.LoadFile.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.LoadFile.Click += new System.EventHandler(this.Load_Click);
            // 
            // LoadTemplate
            // 
            this.LoadTemplate.AccessibleDescription = "Example Template";
            this.LoadTemplate.AccessibleName = "Example Template";
            // 
            // 
            // 
            this.LoadTemplate.ButtonElement.AccessibleDescription = "Example Template";
            this.LoadTemplate.ButtonElement.AccessibleName = "Example Template";
            this.LoadTemplate.Name = "LoadTemplate";
            this.LoadTemplate.Text = "Example Template";
            this.LoadTemplate.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1002, 637);
            this.ControlBox = false;
            this.Controls.Add(this.radStatusStrip1);
            this.Controls.Add(this.radDock1);
            this.Controls.Add(this.radRibbonBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.radDock1)).EndInit();
            this.radDock1.ResumeLayout(false);
            this.toolWindow2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.toolsWindow)).EndInit();
            this.toolsWindow.ResumeLayout(false);
            this.toolWindow1.ResumeLayout(false);
            this.toolWindow1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolTabStrip3)).EndInit();
            this.toolTabStrip3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.documentTabStrip1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radStatusStrip1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.performanceCounter1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRibbonBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.VisualStudio2012DarkTheme visualStudio2012DarkTheme1;
        private Telerik.WinControls.UI.RadRibbonBar radRibbonBar1;
        private Telerik.WinControls.UI.RibbonTab ribbonTab1;
        private Telerik.WinControls.UI.Docking.RadDock radDock1;
        private Telerik.WinControls.UI.Docking.DocumentContainer documentContainer1;
        private Telerik.WinControls.UI.Docking.ToolWindow toolWindow1;
        private Telerik.WinControls.UI.Docking.ToolTabStrip toolTabStrip1;
        private Telerik.WinControls.UI.RadSplitContainer radSplitContainer1;
        private Telerik.WinControls.UI.Docking.ToolTabStrip toolsWindow;
        private Telerik.WinControls.UI.RadRibbonBarGroup radRibbonBarGroup1;
        private Telerik.WinControls.UI.RadButtonElement newPart;
        private Telerik.WinControls.UI.RadButtonElement SavedParts;
        private Controls.StandardTools standardTools1;
        private Telerik.WinControls.UI.RadMenuItem Save;
        private Telerik.WinControls.UI.RadMenuButtonItem radMenuButtonItem1;
        private Telerik.WinControls.UI.RadMenuButtonItem SaveAs;
        private Telerik.WinControls.UI.RadMenuItem Load;
        private Telerik.WinControls.UI.RadMenuButtonItem LoadFile;
        private Telerik.WinControls.UI.RadMenuButtonItem LoadTemplate;
        private Telerik.WinControls.UI.RadMenuItem New;
        private Telerik.WinControls.UI.RadMenuButtonItem NewBlankDocument;
        private Telerik.WinControls.UI.Docking.ToolTabStrip toolTabStrip3;
        private Telerik.WinControls.UI.Docking.ToolWindow toolWindow2;
        private Telerik.WinControls.UI.RadRibbonBarGroup radRibbonBarGroup2;
        private Telerik.WinControls.UI.RadButtonElement SaveLayout;
        private Telerik.WinControls.UI.RadButtonElement LoadLayout;
        private Telerik.WinControls.UI.Docking.DocumentTabStrip documentTabStrip1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private Telerik.WinControls.RootRadElement object_53829f1b_b5cc_4ca1_b874_80bb15bbbfb7;
        private Controls.Settings settings1;
        private Telerik.WinControls.UI.RadStatusStrip radStatusStrip1;
        private System.Diagnostics.PerformanceCounter performanceCounter1;


    }
}

