namespace WindowsFormsTest.Controls
{
    partial class ConstantControl
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
            this.MainImage = new System.Windows.Forms.PictureBox();
            this.MoveTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.MainImage)).BeginInit();
            this.SuspendLayout();
            // 
            // MainImage
            // 
            this.MainImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainImage.Image = global::WindowsFormsTest.Properties.Resources.High;
            this.MainImage.Location = new System.Drawing.Point(0, 0);
            this.MainImage.Name = "MainImage";
            this.MainImage.Size = new System.Drawing.Size(16, 16);
            this.MainImage.TabIndex = 0;
            this.MainImage.TabStop = false;
            this.MainImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainImage_click);
            // 
            // MoveTimer
            // 
            this.MoveTimer.Interval = 50;
            this.MoveTimer.Tick += new System.EventHandler(this.MoveTimer_Tick);
            // 
            // ConstantControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MainImage);
            this.Name = "ConstantControl";
            this.Size = new System.Drawing.Size(16, 16);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.MainImage_DragOver);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ConstantControl_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.MainImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox MainImage;
        private System.Windows.Forms.Timer MoveTimer;
    }
}
