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
            this.components = new System.ComponentModel.Container();
            this.visualStudio2012DarkTheme1 = new Telerik.WinControls.Themes.VisualStudio2012DarkTheme();
            this.drawingSurface = new Telerik.WinControls.UI.RadPanel();
            this.trashcan = new System.Windows.Forms.PictureBox();
            this.MoveTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.drawingSurface)).BeginInit();
            this.drawingSurface.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trashcan)).BeginInit();
            this.SuspendLayout();
            // 
            // drawingSurface
            // 
            this.drawingSurface.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.drawingSurface.Controls.Add(this.trashcan);
            this.drawingSurface.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawingSurface.Location = new System.Drawing.Point(0, 0);
            this.drawingSurface.Margin = new System.Windows.Forms.Padding(6);
            this.drawingSurface.Name = "drawingSurface";
            this.drawingSurface.Size = new System.Drawing.Size(780, 808);
            this.drawingSurface.TabIndex = 0;
            this.drawingSurface.ThemeName = "VisualStudio2012Dark";
            this.drawingSurface.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.MainLogicDesigner_ControlAdded);
            this.drawingSurface.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.MainLogicDesigner_ControlRemoved);
            this.drawingSurface.Paint += new System.Windows.Forms.PaintEventHandler(this.drawingSurface_Paint);
            this.drawingSurface.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawingSurface_MouseDown);
            // 
            // trashcan
            // 
            this.trashcan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.trashcan.BackgroundImage = global::WindowsFormsTest.Properties.Resources.trash_recyclebin_empty_closed;
            this.trashcan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.trashcan.Location = new System.Drawing.Point(640, 665);
            this.trashcan.Margin = new System.Windows.Forms.Padding(0);
            this.trashcan.Name = "trashcan";
            this.trashcan.Size = new System.Drawing.Size(140, 142);
            this.trashcan.TabIndex = 1;
            this.trashcan.TabStop = false;
            // 
            // MoveTimer
            // 
            this.MoveTimer.Interval = 50;
            this.MoveTimer.Tick += new System.EventHandler(this.MoveTimer_Tick);
            // 
            // MainLogicDesigner
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.drawingSurface);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "MainLogicDesigner";
            this.Size = new System.Drawing.Size(780, 808);
            this.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.MainLogicDesigner_ControlAdded);
            this.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.MainLogicDesigner_ControlRemoved);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainLogicDesigner_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainLogicDesigner_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.drawingSurface)).EndInit();
            this.drawingSurface.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trashcan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.VisualStudio2012DarkTheme visualStudio2012DarkTheme1;
        private Telerik.WinControls.UI.RadPanel drawingSurface;
        private System.Windows.Forms.PictureBox trashcan;
        private System.Windows.Forms.Timer MoveTimer;
    }
}
