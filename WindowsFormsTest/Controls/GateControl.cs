using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsTest.component;

namespace WindowsFormsTest.Controls
{
    public partial class GateControl : UserControl
    {

        public Guid guid { get; set; }

        public class GateEventHandler : EventArgs
        {
            public Point point;

            public GateEventHandler(Point Ppoint)
            {
                point = Ppoint;
            }
        }

        public delegate void MovementEventDelegate(Object sender, GateEventHandler  e);

        public event MovementEventDelegate Moved;

        public event MovementEventDelegate Moving;

        public event ConnectionNode.ConnectionMadeDelegate NodeConnectionMade;

        public ILogicComponent LogicComponent { get { return _logicComponent; } }

        ILogicComponent _logicComponent;

        public GateControl(ILogicComponent logicComponent)
        {
            guid = Guid.NewGuid();
            _logicComponent = logicComponent;
            InitializeComponent();            
        }

        public GateControl(ILogicComponent logicComponent, Guid pGuid)
        {
            guid = pGuid;
            _logicComponent = logicComponent;
            InitializeComponent(); 
        }


        private void Gate_Load(object sender, EventArgs e)
        {
            this.pictureBox1.Image = _logicComponent.DesignerImage;
            foreach (var node in _logicComponent.Nodes)
            {
                node.Parent = pictureBox1;
                node.gateControl = this;
                node.ConnectionMade += node_ConnectionMade;
            }
        }

        void node_ConnectionMade(object sender, ConnectionNode.ConnectionMadeEventArgs e)
        {
            if (NodeConnectionMade != null)
            {
                NodeConnectionMade(sender, e);
            }
        }

        //bool _moving;

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


        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            #region DragDropCode
            //if (e.Button == System.Windows.Forms.MouseButtons.Left)
            //{
            //    this.DoDragDrop(this, DragDropEffects.Move);
            //}
            #endregion

            if (e.Button == MouseButtons.Left && isDesignTime())
            {
                //_moving = true;
                MoveTimer.Enabled = true;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //if (_moving)
            //{
            //   //Point pos = this.Parent.PointToClient(new Point(e.X, e.Y));
            //    this.Left = e.Location.X;
            //    this.Top = e.Location.Y;

            //    //this.Refresh();
            //}
        }


        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            //_moving = false;
        }

        private void MoveTimer_Tick(object sender, EventArgs e)
        {
            moveHandler();
            
        }


        private bool isDesignTime()
        {
            return true;
        }

        public SaveData getSaveData()
        {
            SaveData saveData = new SaveData();

            saveData.type = this.LogicComponent.GetType();
            saveData.pos = this.Location;
            saveData.guid = this.guid;

            //result = Newtonsoft.Json.JsonConvert.SerializeObject(saveData, Newtonsoft.Json.Formatting.Indented);
            
            return saveData;
        }

        public class SaveData
        {
            public Type type;
            public Point pos;
            public Guid guid;
        }
    }

}
