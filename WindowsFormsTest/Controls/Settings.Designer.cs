namespace WindowsFormsTest.Controls
{
    partial class Settings
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
            this.WireColor = new Telerik.WinControls.UI.RadColorBox();
            this.WireColorLabel = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.WireColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WireColorLabel)).BeginInit();
            this.SuspendLayout();
            // 
            // WireColor
            // 
            this.WireColor.Location = new System.Drawing.Point(65, 3);
            this.WireColor.Name = "WireColor";
            this.WireColor.Size = new System.Drawing.Size(154, 21);
            this.WireColor.TabIndex = 0;
            this.WireColor.Text = "radColorBox1";
            this.WireColor.ThemeName = "VisualStudio2012Dark";
            this.WireColor.Value = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.WireColor.ValueChanged += new System.EventHandler(this.WireColor_ValueChanged);
            // 
            // WireColorLabel
            // 
            this.WireColorLabel.Location = new System.Drawing.Point(4, 4);
            this.WireColorLabel.Name = "WireColorLabel";
            this.WireColorLabel.Size = new System.Drawing.Size(56, 18);
            this.WireColorLabel.TabIndex = 1;
            this.WireColorLabel.Text = "WireColor";
            this.WireColorLabel.ThemeName = "VisualStudio2012Dark";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Controls.Add(this.WireColorLabel);
            this.Controls.Add(this.WireColor);
            this.Name = "Settings";
            this.Size = new System.Drawing.Size(252, 357);
            ((System.ComponentModel.ISupportInitialize)(this.WireColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WireColorLabel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadColorBox WireColor;
        private Telerik.WinControls.UI.RadLabel WireColorLabel;
    }
}
