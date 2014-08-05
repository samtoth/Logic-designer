using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsTest.component;

namespace WindowsFormsTest.Gates
{
    public class AndGate : LogicComponentBase
    {

        
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
            Nodes.Add(new Controls.ConnectionNode(new System.Drawing.Point(0, 5), "Input A", true));
            Nodes.Add(new Controls.ConnectionNode(new System.Drawing.Point(0, 25), "Input B", true));
            Nodes.Add(new Controls.ConnectionNode(new System.Drawing.Point(80, 13), "Output C", false));
        }
    }


}
