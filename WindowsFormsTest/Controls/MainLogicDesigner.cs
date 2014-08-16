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
using System.Drawing.Drawing2D;
using Newtonsoft.Json;

namespace WindowsFormsTest.Controls
{
    public partial class MainLogicDesigner : UserControl
    {
        public MainLogicDesigner()
        {
            InitializeComponent();
            Changed += MainLogicDesigner_Changed;
        }

        void MainLogicDesigner_Changed(object sender, EventArgs e)
        {
            if (!this.Parent.Text.EndsWith("*"))
            {
                this.Parent.Text += "*";
            }
        }

        public event EventHandler Changed;

        private bool _changedFlag;

        public bool ChangedFlag
        {
            get { return _changedFlag; }
            set
            {
                _changedFlag = value;
                if (value)
                {
                    if (Changed != null) { Changed(this, new EventArgs()); }
                }
            }
        }

        public String FilePath = null;

        public const String FileExtension = ".ldsch";

        public const String FileTypeName = "Logic designer schematic";

        public List<GateControl> gates = new List<GateControl>();

        class ConnectedNodes
        {
            public bool On { get; set; }
            public ConnectionNode Output { get; set; }
            public ConnectionNode Input { get; set; }
            public ConnectedNodes(ConnectionNode output, ConnectionNode input)
            {
                Output = output;
                Input = input;
            }
        }

        List<ConnectedNodes> connectedNodes = new List<ConnectedNodes>();

        private void button1_Click(object sender, EventArgs e)
        {
            //System.Drawing.Graphics graphics = this.CreateGraphics();
            //System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(100, 100, 200, 200);
            //graphics.DrawEllipse(System.Drawing.Pens.Black, rectangle);
            //graphics.DrawRectangle(System.Drawing.Pens.Red, rectangle);

            GateControl Og = new GateControl(new Gates.OrGate());

            Og.Parent = drawingSurface;

            GateControl Ag = new GateControl(new Gates.AndGate());

            Ag.Parent = drawingSurface;

            Ag.Left = Og.Width + Og.Left;

        }
        
        private void MainLogicDesigner_DragEnter(object sender, DragEventArgs e)
        {
            // e.Effect = DragDropEffects.Copy;

            if (e.Data.GetData(e.Data.GetFormats()[0]) is ILogicComponent || e.Data.GetData(e.Data.GetFormats()[0]) is bool)
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
                CreateGate(pos, lc.GetType());
            }

            if (e.Data.GetData(e.Data.GetFormats()[0]) is bool)
            {
                Point pos = this.PointToClient(new Point(e.X, e.Y));
                bool high = (bool)e.Data.GetData(e.Data.GetFormats()[0]);
                ConstantControl control = new ConstantControl(high);
                control.Location = pos;
                this.drawingSurface.Controls.Add(control);
            }
        }

        private void CreateGate(Point pos, Type gateType)
        {
            var newLc = Activator.CreateInstance(gateType);
            GateControl gc = new GateControl((ILogicComponent)(newLc));
            gc.Parent = this.drawingSurface;
            gc.Left = pos.X;
            gc.Top = pos.Y;

            gc.NodeConnectionMade += gc_NodeConnectionMade;
            gc.Moving += gc_Moving;
            gc.Moved += gc_Moved;

            gates.Add(gc);
        }

        private void CreateGate(Point pos, Type gateType, Guid guid)
        {
            var newLc = Activator.CreateInstance(gateType);
            GateControl gc = new GateControl((ILogicComponent)(newLc), guid);
            gc.Parent = this.drawingSurface;
            gc.Left = pos.X;
            gc.Top = pos.Y;

            gc.NodeConnectionMade += gc_NodeConnectionMade;
            gc.Moving += gc_Moving;
            gc.Moved += gc_Moved;

            gates.Add(gc);
        }

        void gc_Moving(object sender, GateControl.GateEventHandler e)
        {
            this.Refresh();

        }

        void gc_Moved(object sender, GateControl.GateEventHandler e)
        {
            this.Refresh();

            if (e.point.X > trashcan.Location.X && e.point.Y > trashcan.Location.Y)
            {

                DeleteGateControl((GateControl)sender);
            }

            ChangedFlag = true;
        }

        private void DeleteGateControl(GateControl pGateControl)
        {
            var nodesToRemove = connectedNodes.Where(nodes => pGateControl == nodes.Output.gateControl || pGateControl == nodes.Input.gateControl).ToList();

            foreach (var nodes in nodesToRemove)
            {
                connectedNodes.Remove(nodes);
            }

            drawingSurface.Controls.Remove(pGateControl);
            pGateControl.Dispose();
            Globals.MainForm.Refresh();
        }

        void gc_NodeConnectionMade(object sender, ConnectionNode.ConnectionMadeEventArgs e)
        {
            if (!e.nodeFrom.IsInput)
            {
                if (e.nodeFrom.IsInput != e.nodeTo.IsInput)
                {
                    connectedNodes.Add(new ConnectedNodes(e.nodeFrom, e.nodeTo));
                }
            }
            this.Refresh();
            //drawLine(this.PointToClient(), this.PointToClient(e.Input.Location));

            ChangedFlag = true;
        }


        private void DrawLine(Point p1, Point p2)
        {
            Graphics graphics = this.drawingSurface.CreateGraphics();
            graphics.DrawLine(System.Drawing.Pens.Black, p1, p2);
            graphics.DrawLine(System.Drawing.Pens.Black, new Point(10, 10), new Point(20, 10));
        }

        private void radScrollablePanel1_Paint(object sender, PaintEventArgs e)
        {
            using (var myPen = new Pen(Color.FromArgb(255, 148, 86)))
            {
                myPen.Width = 30;

                //foreach (var item in connectedNodes)
                {
                    e.Graphics.DrawLine(myPen, new Point(165, 37), new Point(299, 37));
                    e.Graphics.DrawLine(myPen, new Point(10, 10), new Point(20, 10));

                    //System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
                    //path.AddLine(item.Output.Parent.Parent.Location, new Point(item.Input.Parent.Parent.Location.X, item.Output.Parent.Parent.Location.Y));
                    //path.AddLine(new Point(item.Input.Parent.Parent.Location.X, item.Output.Parent.Parent.Location.Y), item.Input.Parent.Parent.Location);
                    //e.Graphics.DrawPath(myPen, path);


                    //e.Graphics.DrawLine(myPen, item.Output.Parent.Parent.Location, new Point(item.Input.Parent.Parent.Location.X, item.Output.Parent.Parent.Location.Y));

                }
            }
        }

    
        private void drawingSurface_Paint(object sender, PaintEventArgs e)
        {
            if (!DesignMode)
            {
                using (Pen myPen = new Pen(Color.Red))
                {
                   // if (!isOn)
                    {
                        myPen.Width = 1;

                        myPen.Color = DesignerSettings.WireColor;

                        foreach (var item in connectedNodes)
                        {
                            e.Graphics.DrawPath(myPen, getConnectionPath(item));
                        }
                    }
                    //else
                    {
                        foreach (var item in connectedNodes)
                        {
                            e.Graphics.DrawPath(myPen, getConnectionPath(item));
                        }
                    }
                }
            }
        }

        GraphicsPath getConnectionPath(ConnectedNodes nodes)
        {
            GraphicsPath result = new GraphicsPath();

            Point nodeFromLocation = new Point(nodes.Output.Location.X + nodes.Output.gateControl.Location.X, nodes.Output.Location.Y + nodes.Output.gateControl.Location.Y);

            Point nodeToLocation = new Point(nodes.Input.Location.X + nodes.Input.gateControl.Location.X, nodes.Input.Location.Y + nodes.Input.gateControl.Location.Y);

            int linePadding = 20;

            /*
            //is node on left side
            if (nodes.Output.Location.X < nodes.Output.gateControl.Width / 2)
            {
                //Is other node on the Right side of first one
                if (nodeToLocation.X > nodeFromLocation.X)
                {
                    result.AddLine(nodeFromLocation, new Point(nodes.Output.gateControl.Location.X - linePadding, nodeFromLocation.Y));
                }
                else
                {

                }
            }

            //Node is on right side
            else
            {
                //Is other Node left side of the first one
                if (nodeToLocation.X < nodeFromLocation.X)
                {
                    if (nodes.Input.Location.X > nodes.Input.gateControl.Width / 2)
                    {
                        result.AddLine(nodeFromLocation, new Point(nodes.Output.gateControl.Location.X + nodes.Output.gateControl.Width + linePadding, nodeFromLocation.Y));
                        result.AddLine(new Point(nodes.Output.gateControl.Location.X + nodes.Output.gateControl.Width + linePadding, nodeFromLocation.Y), new Point(nodes.Output.gateControl.Location.X + nodes.Output.gateControl.Width + linePadding, nodes.Output.gateControl.Location.Y - 20));
                        result.AddLine(new Point(nodes.Output.gateControl.Location.X + nodes.Output.gateControl.Width + linePadding, nodes.Output.gateControl.Location.Y - 20), new Point(nodeToLocation.X + (Math.Abs(nodeToLocation.X - nodeFromLocation.X) / 2), nodes.Output.gateControl.Location.Y - 20));
                        result.AddLine(new Point(nodeToLocation.X + (Math.Abs(nodeToLocation.X - nodeFromLocation.X) / 2), nodes.Output.gateControl.Location.Y - 20), new Point(nodeToLocation.X + (Math.Abs(nodeToLocation.X - nodeFromLocation.X) / 2), nodeToLocation.Y));
                        result.AddLine(new Point(nodeToLocation.X + (Math.Abs(nodeToLocation.X - nodeFromLocation.X) / 2), nodeToLocation.Y), nodeToLocation);
                    }
                    else
                    {
                        result.AddLine(nodeFromLocation, new Point(nodes.Output.gateControl.Location.X + nodes.Output.gateControl.Width + linePadding, nodeFromLocation.Y));
                        result.AddLine(new Point(nodes.Output.gateControl.Location.X + nodes.Output.gateControl.Width + linePadding, nodeFromLocation.Y), new Point(nodes.Output.gateControl.Location.X + nodes.Output.gateControl.Width + linePadding, nodes.Output.gateControl.Location.Y - 20));
                        result.AddLine(new Point(nodes.Output.gateControl.Location.X + nodes.Output.gateControl.Width + linePadding, nodes.Output.gateControl.Location.Y - 20), new Point(nodeToLocation.X + (Math.Abs(nodeToLocation.X - nodeFromLocation.X) / 2), nodes.Output.gateControl.Location.Y - 20));
                        result.AddLine(new Point(nodeToLocation.X + (Math.Abs(nodeToLocation.X - nodeFromLocation.X) / 2), nodes.Output.gateControl.Location.Y - 20), new Point(nodeToLocation.X + (Math.Abs(nodeToLocation.X - nodeFromLocation.X) / 2), nodes.Input.gateControl.Location.Y - 20));
                        result.AddLine(new Point(nodeToLocation.X + (Math.Abs(nodeToLocation.X - nodeFromLocation.X) / 2), nodes.Input.gateControl.Location.Y - 20), new Point(nodeToLocation.X, nodes.Input.gateControl.Location.Y - 20));
                        result.AddLine(new Point(nodeToLocation.X, nodes.Input.gateControl.Location.Y - 20), nodeToLocation);
                    }
                }
                //other node is on right side of first one
                else
                {
                    //if other node is on left side
                    if (nodes.Input.Location.X < nodes.Input.gateControl.Width / 2)
                    {
                        result.AddLine(nodeFromLocation, new Point(nodeFromLocation.X + (nodeToLocation.X - nodeFromLocation.X) / 2, nodeFromLocation.Y));
                        result.AddLine(new Point(nodeFromLocation.X + (nodeToLocation.X - nodeFromLocation.X) / 2, nodeFromLocation.Y), new Point(nodeFromLocation.X + (nodeToLocation.X - nodeFromLocation.X) / 2, nodeToLocation.Y));
                        result.AddLine(new Point(nodeFromLocation.X + (nodeToLocation.X - nodeFromLocation.X) / 2, nodeToLocation.Y), nodeToLocation);
                    }
                    else
                    {
                        result.AddLine(nodeFromLocation, new Point(nodeFromLocation.X + (nodes.Input.gateControl.Location.X - nodeFromLocation.X) / 2, nodeFromLocation.Y));
                        result.AddLine(new Point(nodeFromLocation.X + (nodeToLocation.X - nodeFromLocation.X) / 2, nodeFromLocation.Y), new Point(nodeFromLocation.X + (nodeToLocation.X - nodeFromLocation.X) / 2, nodes.Input.gateControl.Location.Y - 20));
                        result.AddLine(new Point(nodeFromLocation.X + (nodeToLocation.X - nodeFromLocation.X) / 2, nodes.Input.gateControl.Location.Y - 20), new Point(nodeToLocation.X, nodes.Input.gateControl.Location.Y - 20));
                        result.AddLine(new Point(nodeToLocation.X, nodes.Input.gateControl.Location.Y - 20), nodeToLocation);
                    }
                }
            }*/

            //result.AddArc(nodes.Output.Location.X, nodes.Output.Location.Y, (nodes.Input.Location.X - nodes.Output.Location.X) / 2, (nodes.Input.Location.Y - nodes.Output.Location.Y) / 2, nodes.Output.Location.Y < nodes.Input.Location.Y ? 280 : 60, 0);

            Point[] points = new Point[3];
            
            points[0] = nodeFromLocation;
            points[1] = new Point(((nodeToLocation.X - nodeFromLocation.X) / 2) + nodeFromLocation.X, nodeFromLocation.Y);
            points[2] = nodeToLocation;

            result.AddCurve(points, 0.5f); 

            return result;
        }

        public string getSaveData()
        {
            string result = String.Empty;

            var json = new SaveData();

            foreach (var gate in gates)
            {
                json.gateControls.Add(gate.getSaveData());
            }

            foreach (var connection in connectedNodes)
            {
                ConnectedSerializableNodes nodeConnection = new ConnectedSerializableNodes
                {
                    NodeFrom = {GateGuid = connection.Output.gateControl.guid},
                    NodeTo = {GateGuid = connection.Input.gateControl.guid}
                };

                nodeConnection.NodeFrom.Name = connection.Output.ConnectionName;
                nodeConnection.NodeTo.Name = connection.Input.ConnectionName;

                json.connections.Add(nodeConnection);
            }

            result = JsonConvert.SerializeObject(json, Formatting.Indented);

            return result;
        }

        private class SaveData
        {
            public List<GateControl.SaveData> gateControls = new List<GateControl.SaveData>();
            public List<ConnectedSerializableNodes> connections = new List<ConnectedSerializableNodes>();
        }

        private class SerializableNode
        {
            public Guid GateGuid;
            public string Name;
        }
        private class ConnectedSerializableNodes
        {
            public SerializableNode NodeFrom = new SerializableNode();
            public SerializableNode NodeTo = new SerializableNode();
        }

        public void OpenFile(string fileName)
        {
            string jsonData = System.IO.File.ReadAllText(fileName);
            SaveData data = JsonConvert.DeserializeObject<SaveData>(jsonData);

            foreach (var gate in data.gateControls)
            {
                CreateGate(gate.pos, gate.type, gate.guid);
            }
            foreach (var connection in data.connections)
            {
                ConnectionNode nodeFrom = null;
                ConnectionNode nodeTo = null;
                foreach (var gate in gates)
                {
                    if (gate.guid == connection.NodeFrom.GateGuid)
                    {
                        foreach (var node in gate.LogicComponent.Nodes.Where(node => node.ConnectionName == connection.NodeFrom.Name))
                        {
                            nodeFrom = node;
                        }
                    }

                    if (gate.guid == connection.NodeTo.GateGuid)
                    {
                        foreach (var node in gate.LogicComponent.Nodes.Where(node => node.ConnectionName == connection.NodeTo.Name))
                        {
                            nodeTo = node;
                        }
                    }                        
                }
                if (nodeFrom != null && nodeTo != null)
                {
                    connectedNodes.Add(new ConnectedNodes(nodeFrom, nodeTo));
                }
            }

            this.Refresh();

        }

        private void drawingSurface_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Middle)
            {
                //TODO Implement draging around veiw Port.
            }
        }

        public bool CanClose()
        {
            return false;
        }

        private void MainLogicDesigner_ControlAdded(object sender, ControlEventArgs e)
        {
            ChangedFlag = true;
        }

        private void MainLogicDesigner_ControlRemoved(object sender, ControlEventArgs e)
        {
            ChangedFlag = true;
        }
    }
}
