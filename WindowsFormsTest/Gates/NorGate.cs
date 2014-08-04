using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsTest.component;

namespace WindowsFormsTest.Gates
{
    public class NorGate : LogicComponentBase
    {

        
        public override System.Drawing.Image ToolboxIcon
        {
            get { return Properties.Resources.NOR_16x16; }
        }

        public override System.Drawing.Image DesignerImage
        {
            get { return Properties.Resources.NOR; }
        }

        public NorGate()
        {
            Nodes.Add(new Controls.ConnectionNode(new System.Drawing.Point(6, 5), "Input A", true));
            Nodes.Add(new Controls.ConnectionNode(new System.Drawing.Point(80, 10), "Input B", true));  
        }
    }


}
