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

        public ILogicComponent LogicComponent { get { return _logicComponent; } }

        ILogicComponent _logicComponent;

        public GateControl(ILogicComponent logicComponent)
        {
            _logicComponent = logicComponent;
            InitializeComponent();            
        }


        private void Gate_Load(object sender, EventArgs e)
        {
            this.pictureBox1.Image = _logicComponent.DesignerImage;
            foreach (var node in _logicComponent.Nodes)
            {
                node.Parent = pictureBox1;              
            }
        }

        //bool _moving;

        void Moving()
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
            }
            else
            {
                MoveTimer.Enabled = false;

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
            Moving();
        }


        private bool isDesignTime()
        {
            return true;
        }
    }
}
