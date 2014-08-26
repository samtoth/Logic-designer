namespace WindowsFormsTest.Forms
{
    partial class ListPicker
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
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.ListControl = new Telerik.WinControls.UI.RadListView();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.Cancel_btn = new Telerik.WinControls.UI.RadButton();
            this.Ok_btn = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListControl)).BeginInit();
            this.ListControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Cancel_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ok_btn)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.AutoSize = false;
            this.radLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radLabel1.Location = new System.Drawing.Point(0, 0);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(529, 103);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "radLabel1";
            // 
            // ListControl
            // 
            this.ListControl.Controls.Add(this.radPanel1);
            this.ListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListControl.Location = new System.Drawing.Point(0, 103);
            this.ListControl.Name = "ListControl";
            this.ListControl.Size = new System.Drawing.Size(529, 535);
            this.ListControl.TabIndex = 1;
            this.ListControl.Text = "radListView1";
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.Cancel_btn);
            this.radPanel1.Controls.Add(this.Ok_btn);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radPanel1.Location = new System.Drawing.Point(0, 418);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(529, 117);
            this.radPanel1.TabIndex = 0;
            // 
            // Cancel_btn
            // 
            this.Cancel_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_btn.Location = new System.Drawing.Point(287, 38);
            this.Cancel_btn.Name = "Cancel_btn";
            this.Cancel_btn.Size = new System.Drawing.Size(220, 48);
            this.Cancel_btn.TabIndex = 1;
            this.Cancel_btn.Text = "Cancel";
            // 
            // Ok_btn
            // 
            this.Ok_btn.Location = new System.Drawing.Point(26, 38);
            this.Ok_btn.Name = "Ok_btn";
            this.Ok_btn.Size = new System.Drawing.Size(220, 48);
            this.Ok_btn.TabIndex = 0;
            this.Ok_btn.Text = "Ok";
            this.Ok_btn.Click += new System.EventHandler(this.Ok_btn_Click);
            // 
            // ListPicker
            // 
            this.AcceptButton = this.Ok_btn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel_btn;
            this.ClientSize = new System.Drawing.Size(529, 638);
            this.Controls.Add(this.ListControl);
            this.Controls.Add(this.radLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ListPicker";
            this.Text = "ListPicker";
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListControl)).EndInit();
            this.ListControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Cancel_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ok_btn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadButton Cancel_btn;
        private Telerik.WinControls.UI.RadButton Ok_btn;
        internal Telerik.WinControls.UI.RadListView ListControl;
    }
}