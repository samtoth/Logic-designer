using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsTest.component;
using Telerik.WinControls.UI.RadColorPicker;

namespace WindowsFormsTest.Controls
{
    public partial class ConstantControl : LogicControl
    {

        public bool High = true;

        ConnectionNode _outputNode = new ConnectionNode(new Point(22, 1), "Output", false);

        public override ConnectionNode OutputNode
        {
            get { return _outputNode; }
        }

        public ConstantControl(bool pHigh)
        {
            InitializeComponent();
            this.Width = 32;
            this.Height = 12;
            High = pHigh;
            _outputNode.IsOn = High;
        }

        private void ConstantControl_Load(object sender, EventArgs e)
        {
            MainImage.BackColor = High ? Color.Red : Color.Blue;//TODO: get from designer properties
            _outputNode.ParentLogicControl = this;
            MainImage.Controls.Add(_outputNode);
        }
    }    
}
