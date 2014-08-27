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
            this.radPropertyGrid1 = new Telerik.WinControls.UI.RadPropertyGrid();
            ((System.ComponentModel.ISupportInitialize)(this.radPropertyGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // radPropertyGrid1
            // 
            this.radPropertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPropertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.radPropertyGrid1.Name = "radPropertyGrid1";
            this.radPropertyGrid1.SelectedObject = this;
            this.radPropertyGrid1.Size = new System.Drawing.Size(444, 687);
            this.radPropertyGrid1.SortOrder = System.Windows.Forms.SortOrder.Ascending;
            this.radPropertyGrid1.TabIndex = 0;
            this.radPropertyGrid1.Text = "radPropertyGrid1";
            this.radPropertyGrid1.ToolbarVisible = true;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.radPropertyGrid1);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Settings";
            this.Size = new System.Drawing.Size(444, 687);
            this.Load += new System.EventHandler(this.Settings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radPropertyGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPropertyGrid radPropertyGrid1;

    }
}
