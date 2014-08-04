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
            this.toolTabStrip2 = new Telerik.WinControls.UI.Docking.ToolTabStrip();
            this.documentContainer1 = new Telerik.WinControls.UI.Docking.DocumentContainer();
            this.documentTabStrip1 = new Telerik.WinControls.UI.Docking.DocumentTabStrip();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.playButton = new System.Windows.Forms.PictureBox();
            this.radRibbonBar1 = new Telerik.WinControls.UI.RadRibbonBar();
            this.ribbonTab1 = new Telerik.WinControls.UI.RibbonTab();
            this.radRibbonBarGroup1 = new Telerik.WinControls.UI.RadRibbonBarGroup();
            this.newPart = new Telerik.WinControls.UI.RadButtonElement();
            this.SavedParts = new Telerik.WinControls.UI.RadButtonElement();
            this.New = new Telerik.WinControls.UI.RadMenuItem();
            this.NewBlankDocument = new Telerik.WinControls.UI.RadMenuButtonItem();
            this.Save = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuButtonItem1 = new Telerik.WinControls.UI.RadMenuButtonItem();
            this.SaveAs = new Telerik.WinControls.UI.RadMenuButtonItem();
            this.Load = new Telerik.WinControls.UI.RadMenuItem();
            this.LoadFile = new Telerik.WinControls.UI.RadMenuButtonItem();
            this.LoadTemplate = new Telerik.WinControls.UI.RadMenuButtonItem();
            this.documentWindow1 = new Telerik.WinControls.UI.Docking.DocumentWindow();
            this.mainLogicDesigner1 = new WindowsFormsTest.Controls.MainLogicDesigner();
            this.toolWindow1 = new Telerik.WinControls.UI.Docking.ToolWindow();
            this.standardTools1 = new WindowsFormsTest.Controls.StandardTools();
            ((System.ComponentModel.ISupportInitialize)(this.radDock1)).BeginInit();
            this.radDock1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toolTabStrip2)).BeginInit();
            this.toolTabStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer1)).BeginInit();
            this.documentContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentTabStrip1)).BeginInit();
            this.documentTabStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.playButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRibbonBar1)).BeginInit();
            this.documentWindow1.SuspendLayout();
            this.toolWindow1.SuspendLayout();
            this.SuspendLayout();
            // 
            // radDock1
            // 
            this.radDock1.ActiveWindow = this.documentWindow1;
            this.radDock1.BackColor = System.Drawing.Color.Gray;
            this.radDock1.CausesValidation = false;
            this.radDock1.Controls.Add(this.toolTabStrip2);
            this.radDock1.Controls.Add(this.documentContainer1);
            this.radDock1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radDock1.ForeColor = System.Drawing.Color.White;
            this.radDock1.IsCleanUpTarget = true;
            this.radDock1.Location = new System.Drawing.Point(0, 235);
            this.radDock1.MainDocumentContainer = this.documentContainer1;
            this.radDock1.Name = "radDock1";
            this.radDock1.Padding = new System.Windows.Forms.Padding(0);
            // 
            // 
            // 
            this.radDock1.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.radDock1.Size = new System.Drawing.Size(921, 397);
            this.radDock1.SplitterWidth = 2;
            this.radDock1.TabIndex = 1;
            this.radDock1.TabStop = false;
            this.radDock1.Text = "radDock1";
            this.radDock1.ThemeName = "VisualStudio2012Dark";
            // 
            // toolTabStrip2
            // 
            this.toolTabStrip2.CanUpdateChildIndex = true;
            this.toolTabStrip2.CausesValidation = false;
            this.toolTabStrip2.Controls.Add(this.toolWindow1);
            this.toolTabStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolTabStrip2.Name = "toolTabStrip2";
            // 
            // 
            // 
            this.toolTabStrip2.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.toolTabStrip2.SelectedIndex = 0;
            this.toolTabStrip2.Size = new System.Drawing.Size(200, 397);
            this.toolTabStrip2.TabIndex = 1;
            this.toolTabStrip2.TabStop = false;
            this.toolTabStrip2.ThemeName = "VisualStudio2012Dark";
            // 
            // documentContainer1
            // 
            this.documentContainer1.CausesValidation = false;
            this.documentContainer1.Controls.Add(this.documentTabStrip1);
            this.documentContainer1.Name = "documentContainer1";
            // 
            // 
            // 
            this.documentContainer1.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.documentContainer1.SizeInfo.SizeMode = Telerik.WinControls.UI.Docking.SplitPanelSizeMode.Fill;
            this.documentContainer1.SplitterWidth = 2;
            this.documentContainer1.TabIndex = 2;
            this.documentContainer1.ThemeName = "VisualStudio2012Dark";
            // 
            // documentTabStrip1
            // 
            this.documentTabStrip1.CanUpdateChildIndex = true;
            this.documentTabStrip1.CausesValidation = false;
            this.documentTabStrip1.Controls.Add(this.documentWindow1);
            this.documentTabStrip1.Location = new System.Drawing.Point(0, 0);
            this.documentTabStrip1.Name = "documentTabStrip1";
            // 
            // 
            // 
            this.documentTabStrip1.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.documentTabStrip1.SelectedIndex = 0;
            this.documentTabStrip1.Size = new System.Drawing.Size(719, 397);
            this.documentTabStrip1.TabIndex = 0;
            this.documentTabStrip1.TabStop = false;
            this.documentTabStrip1.ThemeName = "VisualStudio2012Dark";
            // 
            // radPanel1
            // 
            this.radPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.radPanel1.Controls.Add(this.playButton);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel1.Location = new System.Drawing.Point(0, 148);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(921, 87);
            this.radPanel1.TabIndex = 2;
            this.radPanel1.ThemeName = "VisualStudio2012Dark";
            // 
            // playButton
            // 
            this.playButton.BackgroundImage = global::WindowsFormsTest.Properties.Resources.playButton;
            this.playButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.playButton.Location = new System.Drawing.Point(396, 21);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(32, 31);
            this.playButton.TabIndex = 0;
            this.playButton.TabStop = false;
            this.playButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.playButton_MouseDown);
            this.playButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.playButton_MouseUp);
            // 
            // radRibbonBar1
            // 
            this.radRibbonBar1.CommandTabs.AddRange(new Telerik.WinControls.RadItem[] {
            this.ribbonTab1});
            this.radRibbonBar1.Location = new System.Drawing.Point(0, 0);
            this.radRibbonBar1.Name = "radRibbonBar1";
            this.radRibbonBar1.Size = new System.Drawing.Size(921, 148);
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
            this.radRibbonBarGroup1});
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
            // documentWindow1
            // 
            this.documentWindow1.Controls.Add(this.mainLogicDesigner1);
            this.documentWindow1.Location = new System.Drawing.Point(4, 29);
            this.documentWindow1.Name = "documentWindow1";
            this.documentWindow1.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.TabbedDocument;
            this.documentWindow1.Size = new System.Drawing.Size(711, 364);
            this.documentWindow1.Text = "Document 1";
            // 
            // mainLogicDesigner1
            // 
            this.mainLogicDesigner1.AllowDrop = true;
            this.mainLogicDesigner1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.mainLogicDesigner1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLogicDesigner1.Location = new System.Drawing.Point(0, 0);
            this.mainLogicDesigner1.Name = "mainLogicDesigner1";
            this.mainLogicDesigner1.Size = new System.Drawing.Size(711, 364);
            this.mainLogicDesigner1.TabIndex = 0;
            // 
            // toolWindow1
            // 
            this.toolWindow1.Caption = null;
            this.toolWindow1.Controls.Add(this.standardTools1);
            this.toolWindow1.Location = new System.Drawing.Point(4, 24);
            this.toolWindow1.Name = "toolWindow1";
            this.toolWindow1.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.Docked;
            this.toolWindow1.Size = new System.Drawing.Size(192, 369);
            this.toolWindow1.Text = "toolWindow1";
            // 
            // standardTools1
            // 
            this.standardTools1.AutoSize = true;
            this.standardTools1.BackColor = System.Drawing.SystemColors.GrayText;
            this.standardTools1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.standardTools1.Location = new System.Drawing.Point(0, 0);
            this.standardTools1.Name = "standardTools1";
            this.standardTools1.Size = new System.Drawing.Size(192, 369);
            this.standardTools1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(921, 632);
            this.Controls.Add(this.radPanel1);
            this.Controls.Add(this.radDock1);
            this.Controls.Add(this.radRibbonBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.radDock1)).EndInit();
            this.radDock1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.toolTabStrip2)).EndInit();
            this.toolTabStrip2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer1)).EndInit();
            this.documentContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.documentTabStrip1)).EndInit();
            this.documentTabStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.playButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRibbonBar1)).EndInit();
            this.documentWindow1.ResumeLayout(false);
            this.toolWindow1.ResumeLayout(false);
            this.toolWindow1.PerformLayout();
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
        private Telerik.WinControls.UI.Docking.ToolTabStrip toolTabStrip2;
        private Telerik.WinControls.UI.RadRibbonBarGroup radRibbonBarGroup1;
        private Telerik.WinControls.UI.RadButtonElement newPart;
        private Telerik.WinControls.UI.Docking.DocumentTabStrip documentTabStrip1;
        private Telerik.WinControls.UI.Docking.DocumentWindow documentWindow1;
        private Telerik.WinControls.UI.RadButtonElement SavedParts;
        private Controls.StandardTools standardTools1;
        private Controls.MainLogicDesigner mainLogicDesigner1;
        private Telerik.WinControls.UI.RadMenuItem Save;
        private Telerik.WinControls.UI.RadMenuButtonItem radMenuButtonItem1;
        private Telerik.WinControls.UI.RadMenuButtonItem SaveAs;
        private Telerik.WinControls.UI.RadMenuItem Load;
        private Telerik.WinControls.UI.RadMenuButtonItem LoadFile;
        private Telerik.WinControls.UI.RadMenuButtonItem LoadTemplate;
        private Telerik.WinControls.UI.RadMenuItem New;
        private Telerik.WinControls.UI.RadMenuButtonItem NewBlankDocument;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private System.Windows.Forms.PictureBox playButton;


    }
}

