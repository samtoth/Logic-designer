using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsTest.component;

namespace WindowsFormsTest.Gates
{
    public class NotGate : LogicComponentBase
    {

        
        public override System.Drawing.Image ToolboxIcon
        {
            get { return Properties.Resources.NOT_16x16; }
        }

        public override System.Drawing.Image DesignerImage
        {
            get { return Properties.Resources.NOT; }
        }

        public NotGate()
        {
            Nodes.Add(new Controls.ConnectionNode(new System.Drawing.Point(0, 15), "Input A", true));
            Nodes.Add(new Controls.ConnectionNode(new System.Drawing.Point(80, 13), "Output B", false));
        }
    }


}
