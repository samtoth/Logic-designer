using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsTest.Controls
{
    public partial class InputControl : LogicControl
    {

        public bool IsOn
        {
            get { return OutputNode.IsOn; }
            set
            {
                MainImage.Image = value ? Properties.Resources.On_Switch : Properties.Resources.Off_Switch;
                OutputNode.IsOn = value;
            }
        }


        ConnectionNode _outputNode = new ConnectionNode(new Point(11, 11), "Output", false);

        public override ConnectionNode OutputNode
        {
            get { return _outputNode; }
        }

        public InputControl()
        {
            InitializeComponent();
            IsOn = false;
            MainImage.MouseDown += MainImage_MouseClick;
            Size = new Size(32, 32);
            _outputNode.ParentLogicControl = this;
            MainImage.Controls.Add(_outputNode);
        }

        void MainImage_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && ModifierKeys == Keys.Control)
            {
                IsOn = !IsOn;
            }
        }
        
    }
}
