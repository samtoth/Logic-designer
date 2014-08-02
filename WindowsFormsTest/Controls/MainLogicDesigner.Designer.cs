namespace WindowsFormsTest.Controls
{
    partial class MainLogicDesigner
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
            this.visualStudio2012DarkTheme1 = new Telerik.WinControls.Themes.VisualStudio2012DarkTheme();
            this.drawingSurface = new Telerik.WinControls.UI.RadPanel();
            ((System.ComponentModel.ISupportInitialize)(this.drawingSurface)).BeginInit();
            this.SuspendLayout();
            // 
            // drawingSurface
            // 
            this.drawingSurface.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.drawingSurface.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawingSurface.Location = new System.Drawing.Point(0, 0);
            this.drawingSurface.Name = "drawingSurface";
            this.drawingSurface.Size = new System.Drawing.Size(390, 420);
            this.drawingSurface.TabIndex = 0;
            this.drawingSurface.ThemeName = "VisualStudio2012Dark";
            this.drawingSurface.Paint += new System.Windows.Forms.PaintEventHandler(this.drawingSurface_Paint);
            // 
            // MainLogicDesigner
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Controls.Add(this.drawingSurface);
            this.Name = "MainLogicDesigner";
            this.Size = new System.Drawing.Size(390, 420);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainLogicDesigner_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainLogicDesigner_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.drawingSurface)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.VisualStudio2012DarkTheme visualStudio2012DarkTheme1;
        private Telerik.WinControls.UI.RadPanel drawingSurface;
    }
}
