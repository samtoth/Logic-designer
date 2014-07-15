using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using WindowsFormsTest.component;

namespace WindowsFormsTest.Controls
{
    public partial class MainLogicDesigner : UserControl
    {
        public MainLogicDesigner()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //System.Drawing.Graphics graphics = this.CreateGraphics();
            //System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(100, 100, 200, 200);
            //graphics.DrawEllipse(System.Drawing.Pens.Black, rectangle);
            //graphics.DrawRectangle(System.Drawing.Pens.Red, rectangle);

            GateControl Og = new GateControl(new Gates.OrGate());

            Og.Parent = radScrollablePanel1;

            GateControl Ag = new GateControl(new Gates.AndGate());

            Ag.Parent = radScrollablePanel1;

            Ag.Left = Og.Width + Og.Left;

        }

        private void MainLogicDesigner_DragEnter(object sender, DragEventArgs e)
        {
           // e.Effect = DragDropEffects.Copy;

            if (e.Data.GetData(e.Data.GetFormats()[0]) is ILogicComponent)
            {
                e.Effect = DragDropEffects.Copy;
            }

            //if (e.Data is GateControl)
            //{
            //    e.Effect = DragDropEffects.Move;
            //}
            //else
            //{
            //    e.Effect = DragDropEffects.None;
            //}
        }

        private void MainLogicDesigner_DragDrop(object sender, DragEventArgs e)
        {
            //Creqate a new LogicGAe
            //RadTreeNode node = (RadTreeNode)e.Data.GetData(typeof(RadTreeNode));            
            if (e.Data.GetData(e.Data.GetFormats()[0]) is ILogicComponent)
            {
                Point pos = this.PointToClient(new Point(e.X, e.Y));
                var lc = (ILogicComponent)e.Data.GetData(e.Data.GetFormats()[0]);
                var newLc = Activator.CreateInstance(lc.GetType());
                GateControl gc = new GateControl((ILogicComponent)(newLc));
                gc.Parent = this.radScrollablePanel1;
                gc.Left = pos.X;
                gc.Top = pos.Y;
            }
        }
    }
}
