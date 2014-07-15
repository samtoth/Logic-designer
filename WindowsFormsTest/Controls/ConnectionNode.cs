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
    public partial class ConnectionNode : UserControl
    {
        Point _RPos;

        String _connectionName;

        bool _isInput;

        public Point RelativePosition { get { return _RPos; } }

        public bool IsInput { get { return _isInput; } }

        public String ConnectionName { get { return _connectionName; } }

        public ConnectionNode(Point RelativePosition, String ConnectionName, bool IsInput)
        {
            InitializeComponent();
            _RPos = RelativePosition;
            _connectionName = ConnectionName;
            _isInput = IsInput;
            toolTip1.SetToolTip(this.ConnectionNodeImage, ConnectionName);
            this.ParentChanged += ConnectionNode_ParentChanged;
        }

        void ConnectionNode_ParentChanged(object sender, EventArgs e)
        {
            this.Left = this.RelativePosition.X;
            this.Top = this.RelativePosition.Y;
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Cross;
        }


        private void panel1_DragDrop(object sender, DragEventArgs e)
        {

            var connectionNode = (ConnectionNode)e.Data.GetData(e.Data.GetFormats()[0]);
            if (connectionNode != null)
            {
                if (connectionNode.Parent != this.Parent || connectionNode.IsInput != this.IsInput)
                {
                    Console.WriteLine("Worked and my parent is: " + ((ConnectionNode)e.Data.GetData(e.Data.GetFormats()[0])).Parent.ToString());
                    System.Drawing.Graphics graphics = this.CreateGraphics();
                    //System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(100, 100, 200, 200);
                    //graphics.DrawEllipse(System.Drawing.Pens.Black, rectangle);
                    //graphics.DrawRectangle(System.Drawing.Pens.Red, rectangle);
                    graphics.DrawLine(System.Drawing.Pens.Black, new Point(10, 15), new Point(50, 100));
                }
            }

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            this.DoDragDrop(this, DragDropEffects.All);
        }

        private void panel1_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(e.Data.GetFormats()[0]) is ConnectionNode)
            {
                e.Effect = DragDropEffects.All;
            }
        }





    }
}
