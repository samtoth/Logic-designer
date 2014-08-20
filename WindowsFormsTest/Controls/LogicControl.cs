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
    public partial class LogicControl : UserControl
    {
        public LogicControl()
        {
            InitializeComponent();
            Guid = new Guid();
        }

        public virtual ConnectionNode OutputNode { get { return null; } }
    

        public class GateEventHandler : EventArgs
        {
            public Point point;

            public GateEventHandler(Point Ppoint)
            {
                point = Ppoint;
            }
        }

        public virtual void UpdateOutputState(){}
        
        

        protected void node_ConnectionMade(object sender, ConnectionNode.ConnectionMadeEventArgs e)
        {
            if (NodeConnectionMade != null)
            {
                NodeConnectionMade(sender, e);
            }
        }

        protected void moveHandler()
        {
            if (MouseButtons == MouseButtons.Left)
            {
                Point pos = this.Parent.PointToClient(MousePosition);

                if (pos.X < 0)
                {
                    pos.X = 0;
                }
                if (pos.Y < 0)
                {
                    pos.Y = 0;
                }
                this.Left = pos.X;
                this.Top = pos.Y;

                if (this.Moving != null)
                {
                    this.Moving(this, new GateEventHandler(this.Location));
                }
            }
            else
            {
                MoveTimer.Enabled = false;
                if (this.Moved != null)
                {
                    this.Moved(this, new GateEventHandler(this.Location));
                }
            }
        }

        private void MoveTimer_Tick(object sender, EventArgs e)
        {
            moveHandler();
        }

        public event MovementEventDelegate Moved;

        public event MovementEventDelegate Moving;

        public event ConnectionNode.ConnectionMadeDelegate NodeConnectionMade;

        public delegate void MovementEventDelegate(Object sender, GateEventHandler e);

        public Guid Guid { get; set; }

        private void MainImage_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && !(ModifierKeys == Keys.Control))
            {
                //_moving = true;
                MoveTimer.Enabled = true;
            }
        }

        public class LogicSaveData
        {
            public Type Type;
            public Point Pos;
            public Guid Guid;
        }

        public virtual LogicSaveData GetSaveData()
        {
             var result = new LogicSaveData
            {
                //Type = this.LogicGate.GetType(),
                Pos = this.Location,
                Guid = this.Guid
            };

            return result;
        }

    }
}
