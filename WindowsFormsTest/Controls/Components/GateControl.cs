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

namespace WindowsFormsTest.Controls
{
    public partial class GateControl : ProcessingControl
    {
        [ReadOnly(true)]
        [DefaultValue(2)]
        [Category("Logic Gate")]
        [Description("Not implemented yet!")]
        public int NumberOfInputNodes { get; set; }

        [Browsable(false)]
        public ILogicGate LogicGate { get { return _logicGate; } }

        public override ConnectionNode OutputNode
        {
            get { return _logicGate.OutputNode; }
        }

        ILogicGate _logicGate;
        
        public GateControl(ILogicGate logicGate, Guid pGuid)
        {
            Guid = pGuid;
            _logicGate = logicGate;
            InitializeComponent();
            Name = LogicGate.GetType().Name + " : " + Guid.ToString();
        }

        public override void UpdateOutputState()
        {
            LogicGate.UpdateOutputState();
        }

        private void Gate_Load(object sender, EventArgs e)
        {
            MainImage.Image = _logicGate.DesignerImage;
            foreach (var node in _logicGate.InputNodes)
            {
                MainImage.Controls.Add(node);
                node.ParentLogicControl = this;
                node.ConnectionMade += node_ConnectionMade;
            }

            MainImage.Controls.Add(_logicGate.OutputNode);
            _logicGate.OutputNode.ParentLogicControl = this;
            _logicGate.OutputNode.ConnectionMade += node_ConnectionMade;
        }
        public override LogicSaveData GetSaveData()
        {
            var result = base.GetSaveData();

            result.Type = this.LogicGate.GetType();

            return result;
        }
    }
}
