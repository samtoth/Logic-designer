using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsTest.component;

namespace WindowsFormsTest.Gates
{
    public class NorGate : ILogicComponent
    {

        
        public System.Drawing.Image ToolboxIcon
        {
            get { return Properties.Resources.NOR_16x16; }
        }

        public System.Drawing.Image DesignerImage
        {
            get { return Properties.Resources.NOR; }
        }

        public List<Controls.ConnectionNode> Nodes
        {
            get { throw new NotImplementedException(); }
        }
    }


}
