﻿using System;
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

        public Point RelativePosition { get { return _RPos; } }

        public String ConnectionName { get { return _connectionName; } }

        public ConnectionNode(Point RelativePosition, String ConnectionName)
        {
            InitializeComponent();
            _RPos = RelativePosition;
            _connectionName = ConnectionName;
            toolTip1.SetToolTip(this.pictureBox1, ConnectionName);
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

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            this.DoDragDrop(this, DragDropEffects.All);
        }

        private void pictureBox1_DragDrop(object sender, DragEventArgs e)
        {
            //if (e.Data.GetData(e.Data.GetFormats()[0]) is ConnectionNode && ((ConnectionNode)e.Data.GetData(e.Data.GetFormats()[0])).Parent != this.Parent)
            //{
                Console.WriteLine("Worked and my parent is: " + ((ConnectionNode)e.Data.GetData(e.Data.GetFormats()[0])).Parent.ToString());
            //}
        }




    }
}
