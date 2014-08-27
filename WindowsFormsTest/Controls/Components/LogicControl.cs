using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace WindowsFormsTest.Controls
{
    public partial class LogicControl : UserControl
    {
        public LogicControl()
        {
            InitializeComponent();
            Guid = new Guid();
            MainImage.MouseClick += MainImage_MouseClick;
            Selected = false;
            Name = GetType().Name + Guid;
        }
        
        void MainImage_MouseClick(object sender, MouseEventArgs e)
        {
            if(!Selected)
            Selected = true;
        }
        

        public bool MoveEnabled { get { return MoveTimer.Enabled; }
            set { MoveTimer.Enabled = value; }
        }

        public class GateEventHandler : EventArgs
        {
            public Point point;

            public GateEventHandler(Point Ppoint)
            {
                point = Ppoint;
            }
        }

        public virtual void UpdateOutputState(){}

        public class SelectionEventHandler : EventArgs
        {
            public LogicControl SelectedLogicControl;

            public SelectionEventHandler(LogicControl pLogicControl)
            {
                SelectedLogicControl = pLogicControl;
            }
        }

        public delegate void SelectionEventDelegate(Object sender, SelectionEventHandler e);

        public event SelectionEventDelegate ControlSelected;

        public bool Selected
        {
            get { return BorderStyle == BorderStyle.FixedSingle; }
            set
            {
                BorderStyle = value ? BorderStyle.FixedSingle : BorderStyle.None;
                if (ControlSelected != null && value)
                {
                    ControlSelected(this, new SelectionEventHandler(this));
                }
            }
        }

        protected void node_ConnectionMade(object sender, ConnectionNode.ConnectionMadeEventArgs e)
        {
            if (NodeConnectionMade != null)
            {
                NodeConnectionMade(sender, e);
            }
        }

        private Point preveousePos;

        protected void moveHandler()
        {
            if (MouseButtons == MouseButtons.Left)
            {
                Point CurrentPos = Parent.PointToClient(MousePosition);
                
                if (!preveousePos.IsEmpty)
                {
                    var Ydif = preveousePos.Y - CurrentPos.Y;
                    var Xdif = CurrentPos.X - preveousePos.X;

                    Left += Xdif;
                    Top -= Ydif;
                }

                if (Left < 0)
                {
                    Left = 0;
                }
                if (Top < 0)
                {
                    Top = 0;
                }

                if (this.Moving != null)
                {
                    this.Moving(this, new GateEventHandler(this.Location));
                }
                preveousePos = CurrentPos;
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

        public event EventHandler MoveStart;

        public event ConnectionNode.ConnectionMadeDelegate NodeConnectionMade;

        public delegate void MovementEventDelegate(Object sender, GateEventHandler e);

        [Browsable(true)]
        [ReadOnly(true)]
        [DisplayName("Unique identifier")]
        [Description("gives the program a way of identifiting each Logic component")]
        [Category("LogicControl")]
        [RadSortOrder(0)]
        public Guid Guid { get; set; }

        [RadSortOrder(0)]
        [Category("LogicControl")]
        [Browsable(true)]
        [Description("Sets the name of the logic component")]
        public string Name { get { return toolTip1.GetToolTip(MainImage); } set{toolTip1.SetToolTip(MainImage, value);} }


        private void MainImage_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && ModifierKeys != Keys.Control && Selected)
            {
                ////_moving = true;
                //preveousePos = Point.Empty;
                //MoveTimer.Enabled = true;
                if (MoveStart != null)
                {
                    MoveStart(this, new EventArgs());
                }
            }
        }

        public class LogicSaveData
        {
            public Type Type;
            public Point Pos;
            public Guid Guid;
            public string Name;
        }

        public virtual LogicSaveData GetSaveData()
        {
             var result = new LogicSaveData
            {
                Type = this.GetType(),
                Pos = this.Location,
                Guid = this.Guid,
                Name = this.Name
            };

            return result;
        }

    }
}
