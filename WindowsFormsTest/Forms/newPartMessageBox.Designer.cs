namespace WindowsFormsTest
{
    partial class SaveAsMessageBox
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
            this.windows8Theme1 = new Telerik.WinControls.Themes.Windows8Theme();
            this.okButton = new Telerik.WinControls.UI.RadButton();
            this.radButton2 = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.okButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(31, 243);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(110, 24);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "Ok";
            this.okButton.ThemeName = "VisualStudio2012Dark";
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // radButton2
            // 
            this.radButton2.Location = new System.Drawing.Point(147, 243);
            this.radButton2.Name = "radButton2";
            this.radButton2.Size = new System.Drawing.Size(110, 24);
            this.radButton2.TabIndex = 0;
            this.radButton2.Text = "Cancel";
            this.radButton2.ThemeName = "VisualStudio2012Dark";
            this.radButton2.Click += new System.EventHandler(this.radButton2_Click);
            // 
            // SaveAsMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 279);
            this.Controls.Add(this.radButton2);
            this.Controls.Add(this.okButton);
            this.Name = "SaveAsMessageBox";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Save As";
            this.ThemeName = "VisualStudio2012Dark";
            ((System.ComponentModel.ISupportInitialize)(this.okButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.Windows8Theme windows8Theme1;
        private Telerik.WinControls.UI.RadButton okButton;
        private Telerik.WinControls.UI.RadButton radButton2;
    }
}
