using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsTest.component
{
    public class LogicComponentBase : ILogicComponent
    {

        private List<Controls.ConnectionNode> _nodes = new List<Controls.ConnectionNode>();

        public List<Controls.ConnectionNode> Nodes
        {
            get { return _nodes; }
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
