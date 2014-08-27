using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsTest.Controls
{
    public partial class DisplayControl : LogicControl
    {
        public DisplayControl()
        {
            InitializeComponent();
            InputNodes = new List<ConnectionNode>();

            Load += DisplayControl_Load;
        }

        private void DisplayControl_Load(object sender, EventArgs e)
        {
            foreach (var connectionNode in InputNodes)
            {
                connectionNode.ParentLogicControl = this;
                MainImage.Controls.Add(connectionNode);
                connectionNode.ConnectionMade += node_ConnectionMade;
            }
        }

        public List<ConnectionNode> InputNodes { get; set; }

    }
}
