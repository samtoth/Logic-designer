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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.WireColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WireColorLabel)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // WireColor
            // 
            this.WireColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WireColor.Location = new System.Drawing.Point(68, 3);
            this.WireColor.Name = "WireColor";
            this.WireColor.Size = new System.Drawing.Size(151, 20);
            this.WireColor.TabIndex = 0;
            this.WireColor.Text = "radColorBox1";
            this.WireColor.Value = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.WireColor.ValueChanged += new System.EventHandler(this.WireColor_ValueChanged);
            // 
            // WireColorLabel
            // 
            this.WireColorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WireColorLabel.Location = new System.Drawing.Point(3, 3);
            this.WireColorLabel.Name = "WireColorLabel";
            this.WireColorLabel.Size = new System.Drawing.Size(56, 18);
            this.WireColorLabel.TabIndex = 1;
            this.WireColorLabel.Text = "WireColor";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.27928F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.72072F));
            this.tableLayoutPanel1.Controls.Add(this.WireColor, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.WireColorLabel, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(222, 357);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Settings";
            this.Size = new System.Drawing.Size(222, 357);
            ((System.ComponentModel.ISupportInitialize)(this.WireColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WireColorLabel)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadColorBox WireColor;
        private Telerik.WinControls.UI.RadLabel WireColorLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
