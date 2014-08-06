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
    public partial class ConstantControl : UserControl
    {

        public bool high = true;

        public class ConnectionMadeEventArgs : EventArgs
        {
            public ConnectionNode nodeFrom { get; set; }
            public ConnectionNode nodeTo { get; set; }

            public ConnectionMadeEventArgs(ConnectionNode PnodeFrom, ConnectionNode PnodeTo)
            {
                nodeFrom = PnodeFrom;
                nodeTo = PnodeTo;
            }
        }

        public class GateEventHandler : EventArgs
        {
            public Point point;

            public GateEventHandler(Point Ppoint)
            {
                point = Ppoint;
            }
        }

        public delegate void MovementEventDelegate(Object sender, GateEventHandler e);

        public event MovementEventDelegate Moved;

        public event MovementEventDelegate Moving;

        public delegate void ConnectionMadeDelegate(Object sender, ConnectionMadeEventArgs e);

        public event ConnectionMadeDelegate ConnectionMade;

        public ConstantControl(bool pHigh)
        {
            InitializeComponent();

            high = pHigh;

            if(high){
                MainImage.Image = Properties.Resources.High;
            }
            else
            {
                MainImage.Image = Properties.Resources.Low;
            }


        }

        void moveHandler()
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

        private void MainImage_click(object sender, MouseEventArgs e)
        {            
            if (e.Button == MouseButtons.Left)
            {
                //_moving = true;
                MoveTimer.Enabled = true;
            }
            else
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Middle)
                {
                    this.DoDragDrop(this, DragDropEffects.Copy);
                }
            }
        }
        
        private void MainImage_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(e.Data.GetFormats()[0]) is ConnectionNode || e.Data.GetData(e.Data.GetFormats()[0]) is ConstantControl)
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private void ConstantControl_MouseDown(object sender, MouseEventArgs e)
        {
            
        }



    }    
}
