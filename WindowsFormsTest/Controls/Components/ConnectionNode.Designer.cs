namespace WindowsFormsTest.Controls
{
    partial class ConnectionNode
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
            this.ConnectionNodeImage = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.ConnectionNodeImage)).BeginInit();
            this.SuspendLayout();
            // 
            // ConnectionNodeImage
            // 
            this.ConnectionNodeImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConnectionNodeImage.Image = global::WindowsFormsTest.Properties.Resources.connectionPoint;
            this.ConnectionNodeImage.Location = new System.Drawing.Point(0, 0);
            this.ConnectionNodeImage.Margin = new System.Windows.Forms.Padding(6);
            this.ConnectionNodeImage.Name = "ConnectionNodeImage";
            this.ConnectionNodeImage.Size = new System.Drawing.Size(20, 20);
            this.ConnectionNodeImage.TabIndex = 0;
            this.ConnectionNodeImage.TabStop = false;
            this.ConnectionNodeImage.DragDrop += new System.Windows.Forms.DragEventHandler(this.panel1_DragOver);
            this.ConnectionNodeImage.DragOver += new System.Windows.Forms.DragEventHandler(this.panel1_DragOver);
            this.ConnectionNodeImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.ConnectionNodeImage.MouseHover += new System.EventHandler(this.pictureBox1_MouseHover);
            // 
            // ConnectionNode
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ConnectionNodeImage);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "ConnectionNode";
            this.Size = new System.Drawing.Size(20, 20);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.panel1_DragDrop);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.panel1_DragOver);
            ((System.ComponentModel.ISupportInitialize)(this.ConnectionNodeImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ConnectionNodeImage;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;


    }
}
