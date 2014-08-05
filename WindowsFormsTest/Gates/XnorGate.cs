using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsTest.component;

namespace WindowsFormsTest.Gates
{
    public class XnorGate : LogicComponentBase
    {

        public XnorGate()
        {
            Nodes.Add(new Controls.ConnectionNode(new System.Drawing.Point(0, 5), "Input A", true));
            Nodes.Add(new Controls.ConnectionNode(new System.Drawing.Point(0, 25), "Input B", true));
            Nodes.Add(new Controls.ConnectionNode(new System.Drawing.Point(80, 13), "Output C", false));        
        }

        public override System.Drawing.Image ToolboxIcon
        {
            get { return Properties.Resources.XNOR_16x16; }
        }

        public override System.Drawing.Image DesignerImage
        {
            get { return Properties.Resources.XNOR; }
        }

    }


}
