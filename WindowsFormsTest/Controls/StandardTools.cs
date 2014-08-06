﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using WindowsFormsTest.component;
using Telerik.WinControls.UI;

namespace WindowsFormsTest.Controls
{
    public partial class StandardTools : UserControl
    {
        public StandardTools()
        {
            InitializeComponent();

        }

        private void LoadTools()
        {
            radTreeView1.Nodes.Clear();

            RadTreeNode GatesParentNode = radTreeView1.Nodes.Add("Logic gates");

            var type = typeof(ILogicComponent);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p)&&p.Name!=type.Name&&p.Name!="LogicComponentBase");

            foreach (Type t in types)
            {
                //if (t.Name != "LogicComponentBase")
                //{
                    Console.WriteLine(t.Name);
                    RadTreeNode node = GatesParentNode.Nodes.Add(t.Name);

                    var lc = Activator.CreateInstance(t);

                    node.Tag = lc;
                    node.Image = (Image)lc.GetType().GetProperty("ToolboxIcon").GetValue(lc, null);
                //}
            }

            RadTreeNode ConstantsParentNode = radTreeView1.Nodes.Add("Constants");

            RadTreeNode highNode = ConstantsParentNode.Nodes.Add("High");
            highNode.Image = Properties.Resources.High;
            highNode.Tag = true;

            RadTreeNode lowNode = ConstantsParentNode.Nodes.Add("Low");
            lowNode.Image = Properties.Resources.Low;
            lowNode.Tag = false;

            RadTreeNode InputParentNode = radTreeView1.Nodes.Add("Input");

        }

        private void StandardTools_Load(object sender, EventArgs e)
        {
            if (DesignMode == false)
            {
                LoadTools();
            }
        }

        private void radTreeView1_DragStarting(object sender, RadTreeViewDragCancelEventArgs e)
        {
            
        }

        private void radTreeView1_NodeMouseDown(object sender, RadTreeViewMouseEventArgs e)
        {
            if(e.Node.Parent == radTreeView1.Nodes[0] || e.Node.Parent == radTreeView1.Nodes[1]){
                this.DoDragDrop(e.Node.Tag, DragDropEffects.Copy);
            }
        }
    }
}
