namespace WindowsFormsTest.Forms
{
    partial class OptionsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            this.radTitleBar1 = new Telerik.WinControls.UI.RadTitleBar();
            this.roundRectShapeTitle = new Telerik.WinControls.RoundRectShape(this.components);
            this.Ok_btn = new Telerik.WinControls.UI.RadButton();
            this.Cancel_btn = new Telerik.WinControls.UI.RadButton();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.TabView = new Telerik.WinControls.UI.RadPageView();
            this.radPageViewPage1 = new Telerik.WinControls.UI.RadPageViewPage();
            this.appearance1 = new WindowsFormsTest.Controls.SettingsControls.Appearance();
            this.SavingAndLoadingTab = new Telerik.WinControls.UI.RadPageViewPage();
            this.savingAndLoading1 = new WindowsFormsTest.Controls.SettingsControls.SavingAndLoading();
            ((System.ComponentModel.ISupportInitialize)(this.radTitleBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ok_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cancel_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TabView)).BeginInit();
            this.TabView.SuspendLayout();
            this.radPageViewPage1.SuspendLayout();
            this.SavingAndLoadingTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // radTitleBar1
            // 
            this.radTitleBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radTitleBar1.Location = new System.Drawing.Point(0, 0);
            this.radTitleBar1.Margin = new System.Windows.Forms.Padding(6);
            this.radTitleBar1.Name = "radTitleBar1";
            // 
            // 
            // 
            this.radTitleBar1.RootElement.ApplyShapeToControl = true;
            this.radTitleBar1.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.radTitleBar1.RootElement.Shape = this.roundRectShapeTitle;
            this.radTitleBar1.Size = new System.Drawing.Size(1045, 44);
            this.radTitleBar1.TabIndex = 0;
            this.radTitleBar1.TabStop = false;
            this.radTitleBar1.Text = "OptionsForm";
            // 
            // roundRectShapeTitle
            // 
            this.roundRectShapeTitle.BottomLeftRounded = false;
            this.roundRectShapeTitle.BottomRightRounded = false;
            // 
            // Ok_btn
            // 
            this.Ok_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Ok_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Ok_btn.Location = new System.Drawing.Point(12, 40);
            this.Ok_btn.Name = "Ok_btn";
            this.Ok_btn.Size = new System.Drawing.Size(479, 71);
            this.Ok_btn.TabIndex = 1;
            this.Ok_btn.Text = "Ok";
            this.Ok_btn.Click += new System.EventHandler(this.Ok_btn_Click);
            // 
            // Cancel_btn
            // 
            this.Cancel_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel_btn.Location = new System.Drawing.Point(544, 40);
            this.Cancel_btn.Name = "Cancel_btn";
            this.Cancel_btn.Size = new System.Drawing.Size(489, 71);
            this.Cancel_btn.TabIndex = 2;
            this.Cancel_btn.Text = "Cancel";
            this.Cancel_btn.Click += new System.EventHandler(this.Cancel_btn_Click);
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.Ok_btn);
            this.radPanel1.Controls.Add(this.Cancel_btn);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radPanel1.Location = new System.Drawing.Point(0, 735);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(1045, 123);
            this.radPanel1.TabIndex = 0;
            // 
            // TabView
            // 
            this.TabView.Controls.Add(this.radPageViewPage1);
            this.TabView.Controls.Add(this.SavingAndLoadingTab);
            this.TabView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabView.Location = new System.Drawing.Point(0, 44);
            this.TabView.Name = "TabView";
            this.TabView.SelectedPage = this.radPageViewPage1;
            this.TabView.Size = new System.Drawing.Size(1045, 691);
            this.TabView.TabIndex = 1;
            this.TabView.Text = "Saving and loading";
            this.TabView.ViewMode = Telerik.WinControls.UI.PageViewMode.Backstage;
            // 
            // radPageViewPage1
            // 
            this.radPageViewPage1.Controls.Add(this.appearance1);
            this.radPageViewPage1.ItemSize = new System.Drawing.SizeF(252F, 48F);
            this.radPageViewPage1.Location = new System.Drawing.Point(262, 5);
            this.radPageViewPage1.Name = "radPageViewPage1";
            this.radPageViewPage1.Size = new System.Drawing.Size(778, 681);
            this.radPageViewPage1.Text = "Appearence";
            // 
            // appearance1
            // 
            this.appearance1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.appearance1.Location = new System.Drawing.Point(0, 0);
            this.appearance1.Name = "appearance1";
            this.appearance1.Size = new System.Drawing.Size(778, 681);
            this.appearance1.TabIndex = 0;
            // 
            // SavingAndLoadingTab
            // 
            this.SavingAndLoadingTab.Controls.Add(this.savingAndLoading1);
            this.SavingAndLoadingTab.ItemSize = new System.Drawing.SizeF(252F, 48F);
            this.SavingAndLoadingTab.Location = new System.Drawing.Point(262, 5);
            this.SavingAndLoadingTab.Name = "SavingAndLoadingTab";
            this.SavingAndLoadingTab.Size = new System.Drawing.Size(778, 681);
            this.SavingAndLoadingTab.Text = "Saving and Loading";
            // 
            // savingAndLoading1
            // 
            this.savingAndLoading1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.savingAndLoading1.Location = new System.Drawing.Point(0, 0);
            this.savingAndLoading1.Name = "savingAndLoading1";
            this.savingAndLoading1.Size = new System.Drawing.Size(778, 681);
            this.savingAndLoading1.TabIndex = 0;
            // 
            // OptionsForm
            // 
            this.AcceptButton = this.Ok_btn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Ok_btn;
            this.ClientSize = new System.Drawing.Size(1045, 858);
            this.Controls.Add(this.TabView);
            this.Controls.Add(this.radPanel1);
            this.Controls.Add(this.radTitleBar1);
            this.Margin = new System.Windows.Forms.Padding(12);
            this.MinimumSize = new System.Drawing.Size(1000, 0);
            this.Name = "OptionsForm";
            this.Text = "OptionsForm";
            ((System.ComponentModel.ISupportInitialize)(this.radTitleBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ok_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cancel_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TabView)).EndInit();
            this.TabView.ResumeLayout(false);
            this.radPageViewPage1.ResumeLayout(false);
            this.SavingAndLoadingTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadTitleBar radTitleBar1;
        private Telerik.WinControls.RoundRectShape roundRectShapeTitle;
        private Telerik.WinControls.UI.RadButton Ok_btn;
        private Telerik.WinControls.UI.RadButton Cancel_btn;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadPageView TabView;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage1;
        private Telerik.WinControls.UI.RadPageViewPage SavingAndLoadingTab;
        private Controls.SettingsControls.Appearance appearance1;
        private Controls.SettingsControls.SavingAndLoading savingAndLoading1;
    }
}
