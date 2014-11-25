namespace WindowsFormsTest.Controls.SettingsControls
{
    partial class Appearance
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.WinControls.UI.RadListDataItem radListDataItem1 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem2 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem3 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem4 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem5 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem6 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem7 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem8 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem9 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem10 = new Telerik.WinControls.UI.RadListDataItem();
            this.ThemeDropDownBox = new Telerik.WinControls.UI.RadDropDownList();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.Theme = new Telerik.WinControls.UI.RadLabel();
            this.WireTypeDropDownBox = new Telerik.WinControls.UI.RadDropDownList();
            this.wireType = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.ThemeDropDownBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Theme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WireTypeDropDownBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wireType)).BeginInit();
            this.SuspendLayout();
            // 
            // ThemeDropDownBox
            // 
            this.ThemeDropDownBox.AllowShowFocusCues = false;
            this.ThemeDropDownBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ThemeDropDownBox.AutoCompleteDisplayMember = null;
            this.ThemeDropDownBox.AutoCompleteValueMember = null;
            this.ThemeDropDownBox.DropDownAnimationEasing = Telerik.WinControls.RadEasingType.InOutCubic;
            radListDataItem1.Text = "Aqua";
            radListDataItem1.TextWrap = true;
            radListDataItem2.Text = "Breeze";
            radListDataItem2.TextWrap = true;
            radListDataItem3.Text = "Desert";
            radListDataItem3.TextWrap = true;
            radListDataItem4.Text = "Dark";
            radListDataItem4.TextWrap = true;
            radListDataItem5.Text = "Light";
            radListDataItem5.TextWrap = true;
            radListDataItem6.Text = "silver";
            radListDataItem6.TextWrap = true;
            radListDataItem7.Text = "Blue";
            radListDataItem7.TextWrap = true;
            this.ThemeDropDownBox.Items.Add(radListDataItem1);
            this.ThemeDropDownBox.Items.Add(radListDataItem2);
            this.ThemeDropDownBox.Items.Add(radListDataItem3);
            this.ThemeDropDownBox.Items.Add(radListDataItem4);
            this.ThemeDropDownBox.Items.Add(radListDataItem5);
            this.ThemeDropDownBox.Items.Add(radListDataItem6);
            this.ThemeDropDownBox.Items.Add(radListDataItem7);
            this.ThemeDropDownBox.Location = new System.Drawing.Point(210, 78);
            this.ThemeDropDownBox.Margin = new System.Windows.Forms.Padding(6);
            this.ThemeDropDownBox.Name = "ThemeDropDownBox";
            this.ThemeDropDownBox.Size = new System.Drawing.Size(325, 35);
            this.ThemeDropDownBox.TabIndex = 2;
            this.ThemeDropDownBox.ThemeName = "ControlDefault";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.WireTypeDropDownBox);
            this.radGroupBox1.Controls.Add(this.wireType);
            this.radGroupBox1.Controls.Add(this.ThemeDropDownBox);
            this.radGroupBox1.Controls.Add(this.Theme);
            this.radGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGroupBox1.HeaderText = "Appearance";
            this.radGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(607, 652);
            this.radGroupBox1.TabIndex = 4;
            this.radGroupBox1.Text = "Appearance";
            // 
            // Theme
            // 
            this.Theme.Location = new System.Drawing.Point(77, 77);
            this.Theme.Name = "Theme";
            this.Theme.Size = new System.Drawing.Size(78, 34);
            this.Theme.TabIndex = 3;
            this.Theme.Text = "Theme";
            // 
            // WireTypeDropDownBox
            // 
            this.WireTypeDropDownBox.AllowShowFocusCues = false;
            this.WireTypeDropDownBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WireTypeDropDownBox.AutoCompleteDisplayMember = null;
            this.WireTypeDropDownBox.AutoCompleteValueMember = null;
            this.WireTypeDropDownBox.DropDownAnimationEasing = Telerik.WinControls.RadEasingType.InOutCubic;
            radListDataItem8.Text = "Square";
            radListDataItem8.TextWrap = true;
            radListDataItem9.Text = "Curved";
            radListDataItem9.TextWrap = true;
            radListDataItem10.Text = "Direct";
            radListDataItem10.TextWrap = true;
            this.WireTypeDropDownBox.Items.Add(radListDataItem8);
            this.WireTypeDropDownBox.Items.Add(radListDataItem9);
            this.WireTypeDropDownBox.Items.Add(radListDataItem10);
            this.WireTypeDropDownBox.Location = new System.Drawing.Point(210, 156);
            this.WireTypeDropDownBox.Margin = new System.Windows.Forms.Padding(6);
            this.WireTypeDropDownBox.Name = "WireTypeDropDownBox";
            this.WireTypeDropDownBox.Size = new System.Drawing.Size(325, 35);
            this.WireTypeDropDownBox.TabIndex = 4;
            this.WireTypeDropDownBox.ThemeName = "ControlDefault";
            // 
            // wireType
            // 
            this.wireType.Location = new System.Drawing.Point(77, 155);
            this.wireType.Name = "wireType";
            this.wireType.Size = new System.Drawing.Size(108, 34);
            this.wireType.TabIndex = 5;
            this.wireType.Text = "Wire style";
            // 
            // Appearance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radGroupBox1);
            this.Name = "Appearance";
            this.Size = new System.Drawing.Size(607, 652);
            ((System.ComponentModel.ISupportInitialize)(this.ThemeDropDownBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Theme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WireTypeDropDownBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wireType)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadDropDownList ThemeDropDownBox;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadLabel Theme;
        private Telerik.WinControls.UI.RadDropDownList WireTypeDropDownBox;
        private Telerik.WinControls.UI.RadLabel wireType;
    }
}
