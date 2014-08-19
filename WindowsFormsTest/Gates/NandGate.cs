using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsTest.component;

namespace WindowsFormsTest.Gates
{
    class NandGate : LogicGateBase
    {
        public override void UpdateOutputState()
        {
            //Nand gate so output when nnot all on
            OutputNode.IsOn = !InputNodes.All(node => node.IsOn);
        }

        public override System.Drawing.Image ToolboxIcon
        {
            get { return Properties.Resources.NAND_16x16; }
        }

        public override System.Drawing.Image DesignerImage
        {
            get { return Properties.Resources.NAND; }
        }

        public NandGate()
        {
            InputNodes.Add(new Controls.ConnectionNode(new System.Drawing.Point(0, 5), "Input A", true));
            InputNodes.Add(new Controls.ConnectionNode(new System.Drawing.Point(0, 25), "Input B", true));
            OutputNode = new Controls.ConnectionNode(new System.Drawing.Point(80, 13), "Output C", false);
        }

    }
}
