using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsTest.component;

namespace WindowsFormsTest.Gates
{
    public class AndGate : LogicGateBase
    {
        public override void UpdateOutputState()
        {
            //andGate so all inputs must be on
            OutputNode.IsOn =  InputNodes.All(node => node.IsOn);
        }

        public override System.Drawing.Image ToolboxIcon
        {
            get { return Properties.Resources.AND_16x16; }
        }

        public override System.Drawing.Image DesignerImage
        {
            get { return Properties.Resources.AND; }
        }

        public AndGate()
        {
            InputNodes.Add(new Controls.ConnectionNode(new System.Drawing.Point(0, 5), "Input A", true));
            InputNodes.Add(new Controls.ConnectionNode(new System.Drawing.Point(0, 25), "Input B", true));
            OutputNode = new Controls.ConnectionNode(new System.Drawing.Point(80, 13), "Output C", false);
        }
    }


}
