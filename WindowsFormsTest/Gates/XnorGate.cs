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
            Nodes.Add(new Controls.ConnectionNode(new System.Drawing.Point(0, 5), "bollocks", true));            
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
