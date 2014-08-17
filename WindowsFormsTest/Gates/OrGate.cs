using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsTest.component;

namespace WindowsFormsTest.Gates
{
    public class OrGate : LogicComponentBase
    {
        public override void UpdateOutputState()
        {
            //Or gate so if any are on output
            OutputNode.IsOn = InputNodes.Any(node => node.IsOn);
        }

        public override System.Drawing.Image ToolboxIcon
        {
            get { return Properties.Resources.OR_16x16; }
        }

        public override System.Drawing.Image DesignerImage
        {
            get { return Properties.Resources.OR; }
        }

        public OrGate()
        {
            InputNodes.Add(new Controls.ConnectionNode(new System.Drawing.Point(0, 5), "Input A", true));
            InputNodes.Add(new Controls.ConnectionNode(new System.Drawing.Point(0, 25), "Input B", true));
            OutputNode = new Controls.ConnectionNode(new System.Drawing.Point(80, 13), "Output C", false); 
        }
    }
}
