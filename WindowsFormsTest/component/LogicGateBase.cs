using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsTest.Controls;

namespace WindowsFormsTest.component
{
    public class LogicGateBase : ILogicGate
    {

        private readonly List<Controls.ConnectionNode> _inputNodes = new List<Controls.ConnectionNode>();
        private ConnectionNode _outputNode;

        public virtual void UpdateOutputState(){}

        public List<Controls.ConnectionNode> InputNodes
        {
            get { return _inputNodes; }
        }

        public ConnectionNode OutputNode
        {
            get { return _outputNode; }
            set { _outputNode = value; }
        }

        public virtual System.Drawing.Image ToolboxIcon
        {
            get { return null; }
        }

        public virtual System.Drawing.Image DesignerImage
        {
            get { return null; }
        }
    }
}
