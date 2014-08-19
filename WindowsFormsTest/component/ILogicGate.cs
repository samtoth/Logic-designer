using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsTest.Controls;

namespace WindowsFormsTest.component
{
    public enum ComponentType
    {
        Wire, Or, Xor, Nand, And
    }



    public interface ILogicGate
    {
        void UpdateOutputState();
        List<ConnectionNode> InputNodes { get;}
        ConnectionNode OutputNode { get; }
        Image ToolboxIcon { get; }
        Image DesignerImage { get; }


    }

}
