using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsTest.component;

namespace WindowsFormsTest.Gates
{
    public class XorGate : LogicComponentBase
    {

        public XorGate()
        {
            Nodes.Add(new Controls.ConnectionNode(new System.Drawing.Point(0, 5), "Input 1"));
            Nodes.Add(new Controls.ConnectionNode(new System.Drawing.Point(0, 25), "Input 2")); 
        }

        public override System.Drawing.Image ToolboxIcon
        {
            get { return Properties.Resources.XOR_16x16; }
        }

        public override System.Drawing.Image DesignerImage
        {
            get { return Properties.Resources.XOR; }
        }

    }


}
