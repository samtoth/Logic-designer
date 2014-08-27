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
    public partial class ConstantControl : ProcessingControl
    {


        ConnectionNode _outputNode = new ConnectionNode(new Point(22, 1), "Output", false);

        public override ConnectionNode OutputNode
        {
            get { return _outputNode; }
        }

        public Color ControlColor { get { return MainImage.BackColor; } set { MainImage.BackColor = value; } }

        protected ConstantControl()
        {
            InitializeComponent();
            this.Width = 32;
            this.Height = 12;
        }
        private void ConstantControl_Load(object sender, EventArgs e)
        {
            
            _outputNode.ParentLogicControl = this;
            MainImage.Controls.Add(_outputNode);
        }
    }
    
    public class ConstantControlHigh : ConstantControl
    {
        public ConstantControlHigh()
        {
            OutputNode.IsOn = true;
            MainImage.BackColor = Color.Red;
        }
    }
    public class ConstantControlLow : ConstantControl
    {
        public ConstantControlLow()
        {
            OutputNode.IsOn = false;
            MainImage.BackColor = Color.Blue;
        }
    }
}
