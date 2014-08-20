using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using WindowsFormsTest.component;
using System.Drawing.Drawing2D;
using Newtonsoft.Json;

namespace WindowsFormsTest.Controls
{

    //TODO implement proper algorithm/s for updating gates and the ability to re-order them
    //TODO Add selection support
    //TODO Add proper deletions for other things that are not gates

    public partial class MainLogicDesigner : UserControl
    {
        public MainLogicDesigner()
        {
            InitializeComponent();
            Changed += MainLogicDesigner_Changed;
        }

        #region Classes
        public class DesignerProperties
        {
            
            public DesignerProperties()
            {
                WireOnColor = Color.Red;
                WireOffColor = Color.Blue;
                TickRate = 250;
            }
            [Description("The wire color when its state is on.")]
            public Color WireOnColor { get; set; }
            [Description("The wire color when its state is off.")]
            public Color WireOffColor { get; set; }
            [Description("The delay in miliseconds bewtween each update in logic.")]
            [RadRange(1, int.MaxValue)]
            public int TickRate { get; set; }
        }

        private class ConnectedNodes
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

        private class SaveData
        {
            public List<GateControl.LogicSaveData> gateControls = new List<GateControl.LogicSaveData>();
            public List<ConnectedSerializableNodes> connections = new List<ConnectedSerializableNodes>();
            public DesignerProperties Properties = new DesignerProperties();
        }

        private class SerializableNode
        {
            public Guid GateGuid;
            public string Name;
        }

        private class ConnectedSerializableNodes
        {
            public SerializableNode Output = new SerializableNode();
            public SerializableNode Input = new SerializableNode();
        }

        #endregion
        
        #region ClassLevelVariablesAndProperties
        private CancellationTokenSource _cts;
        private bool _running;
        private bool _changedFlag;
        private List<ConnectedNodes> connectedNodes = new List<ConnectedNodes>();

        public event EventHandler Changed;
        public String FilePath = null;
        public const String FileExtension = ".ldsch";
        public const String FileTypeName = "Logic designer schematic";
        public List<LogicControl> LogicComponents = new List<LogicControl>();
        public DesignerProperties Properties = new DesignerProperties();

        public bool ChangedFlag
        {
            get { return _changedFlag; }
            set
            {
                _changedFlag = value;
                //if (value)
                {
                    if (Changed != null)
                    {
                        Changed(this, new EventArgs());
                    }
                }
            }
        }
        public bool Running
        {
            get { return _running; }
            set
            {
                _running = value;
                if (value)
                {
                    _cts = new CancellationTokenSource();
                    UpdateLogicLoop(_cts.Token);
                }
                else
                {
                    _cts.Cancel();
                }
            }
        }
        #endregion

        #region SettingUpUiAndSavingEctMainThread
        private void MainLogicDesigner_DragEnter(object sender, DragEventArgs e)
        {
            // e.Effect = DragDropEffects.Copy;

            if (e.Data.GetData(e.Data.GetFormats()[0]) is ILogicGate || e.Data.GetData(e.Data.GetFormats()[0]) is bool || e.Data.GetData(e.Data.GetFormats()[0]) is InputControl)
            {
                e.Effect = DragDropEffects.Copy;
            }
        }
        private void MainLogicDesigner_Changed(object sender, EventArgs e)
        {
            if ((sender as MainLogicDesigner).ChangedFlag)
            {
                if (!this.Parent.Text.EndsWith("*"))
                {
                    this.Parent.Text += "*";
                }
            }
            else
            {
                if (this.Parent.Text.EndsWith("*"))
                {
                    this.Parent.Text = this.Parent.Text.TrimEnd('*');
                }

            }
        }
        private void MainLogicDesigner_DragDrop(object sender, DragEventArgs e)
        {
            //Creqate a new LogicGAe
            //RadTreeNode node = (RadTreeNode)e.Data.GetData(typeof(RadTreeNode));            
            if (e.Data.GetData(e.Data.GetFormats()[0]) is ILogicGate)
            {
                Point pos = this.PointToClient(new Point(e.X, e.Y));
                var lc = (ILogicGate) e.Data.GetData(e.Data.GetFormats()[0]);
                CreateGate(pos, lc.GetType());
            }

            if (e.Data.GetData(e.Data.GetFormats()[0]) is bool)
            {
                Point pos = this.PointToClient(new Point(e.X, e.Y));
                bool high = (bool) e.Data.GetData(e.Data.GetFormats()[0]); //Todo Change from data being bool to being constant control
                ConstantControl control = new ConstantControl(high)
                {
                    Location = pos
                };

                this.drawingSurface.Controls.Add(control);
                LogicComponents.Add(control);
            }

            if (e.Data.GetData((e.Data.GetFormats()[0])) is InputControl) //TODO Change Data from being input control to just a type
            {
                var control = new InputControl
                {
                    Location = PointToClient(new Point(e.X, e.Y))
                };
                this.drawingSurface.Controls.Add(control);
                LogicComponents.Add(control);
            }
        }

        private void CreateGate(Point pos, Type gateType)
        {
            CreateGate(pos, gateType, Guid.NewGuid());
        }

        private void CreateGate(Point pos, Type gateType, Guid guid)
        {
            var newLc = Activator.CreateInstance(gateType);
            GateControl gc = new GateControl((ILogicGate) (newLc), guid);
            drawingSurface.Controls.Add(gc);
            gc.Left = pos.X;
            gc.Top = pos.Y;

            gc.NodeConnectionMade += gc_NodeConnectionMade;
            gc.Moving += gc_Moving;
            gc.Moved += gc_Moved;

            LogicComponents.Add(gc);
        }

        private void gc_Moving(object sender, GateControl.GateEventHandler e)
        {
            this.Refresh();

        }

        private void gc_Moved(object sender, GateControl.GateEventHandler e)
        {
            this.Refresh();

            if (e.point.X > trashcan.Location.X && e.point.Y > trashcan.Location.Y)
            {

                DeleteGateControl((GateControl) sender);
            }

            ChangedFlag = true;
        }

        private void DeleteGateControl(GateControl pGateControl)
        {
            var nodesToRemove =
                connectedNodes.Where(
                    nodes => pGateControl == nodes.Output.ParentLogicControl || pGateControl == nodes.Input.ParentLogicControl)
                    .ToList();

            foreach (var nodes in nodesToRemove)
            {
                nodes.Input.IsOn = false;
                connectedNodes.Remove(nodes);
            }

            drawingSurface.Controls.Remove(pGateControl);
            pGateControl.Dispose();
            Globals.MainForm.Refresh();
        }

        private void gc_NodeConnectionMade(object sender, ConnectionNode.ConnectionMadeEventArgs e)
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
                        myPen.Width = 1;

                        /*myPen.Color = DesignerSettings.WireColor;

                        foreach (var item in connectedNodes)
                        {
                            e.Graphics.DrawPath(myPen, getConnectionPath(item));
                        }*/
                    
                    {
                        foreach (var item in connectedNodes)
                        {
                            myPen.Color = item.On ? Properties.WireOnColor : Properties.WireOffColor;
                            e.Graphics.DrawPath(myPen, getConnectionPath(item));
                        }
                    }
                }
            }
        }

        public void OpenFile(string fileName)
        {
            string jsonData = System.IO.File.ReadAllText(fileName);
            SaveData data = JsonConvert.DeserializeObject<SaveData>(jsonData);

            foreach (var gate in data.gateControls)
            {
                CreateGate(gate.Pos, gate.Type, gate.Guid);
            }
            foreach (var connection in data.connections)
            {
                ConnectionNode output = null;
                ConnectionNode input = null;
                foreach (var gate in LogicComponents)
                {
                    if (gate.Guid == connection.Output.GateGuid)
                    {
                        //Dealing with the outuput node
                        output = gate.OutputNode;
                    }

                    if (gate.Guid == connection.Input.GateGuid)
                    {
                        if (gate is GateControl)
                        {
                            foreach (var node in(gate as GateControl).LogicGate.InputNodes.Where(node => node.ConnectionName == connection.Input.Name))
                            {
                                input = node;
                            }
                        }
                    }
                }
                if (output != null && input != null)
                {
                    connectedNodes.Add(new ConnectedNodes(output, input));
                }
            }

            Properties = data.Properties;

            this.ChangedFlag = false;
            this.Refresh();
        }

        private GraphicsPath getConnectionPath(ConnectedNodes nodes)
        {
            GraphicsPath result = new GraphicsPath();

            Point nodeFromLocation = new Point(nodes.Output.Location.X + nodes.Output.ParentLogicControl.Location.X,
                nodes.Output.Location.Y + nodes.Output.ParentLogicControl.Location.Y);

            Point nodeToLocation = new Point(nodes.Input.Location.X + nodes.Input.ParentLogicControl.Location.X,
                nodes.Input.Location.Y + nodes.Input.ParentLogicControl.Location.Y);

            int linePadding = 20;

            /*
            //is node on left side
            if (nodes.Output.Location.X < nodes.Output.Control.Width / 2)
            {
                //Is other node on the Right side of first one
                if (nodeToLocation.X > nodeFromLocation.X)
                {
                    result.AddLine(nodeFromLocation, new Point(nodes.Output.Control.Location.X - linePadding, nodeFromLocation.Y));
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
                    if (nodes.Input.Location.X > nodes.Input.Control.Width / 2)
                    {
                        result.AddLine(nodeFromLocation, new Point(nodes.Output.Control.Location.X + nodes.Output.Control.Width + linePadding, nodeFromLocation.Y));
                        result.AddLine(new Point(nodes.Output.Control.Location.X + nodes.Output.Control.Width + linePadding, nodeFromLocation.Y), new Point(nodes.Output.Control.Location.X + nodes.Output.Control.Width + linePadding, nodes.Output.Control.Location.Y - 20));
                        result.AddLine(new Point(nodes.Output.Control.Location.X + nodes.Output.Control.Width + linePadding, nodes.Output.Control.Location.Y - 20), new Point(nodeToLocation.X + (Math.Abs(nodeToLocation.X - nodeFromLocation.X) / 2), nodes.Output.Control.Location.Y - 20));
                        result.AddLine(new Point(nodeToLocation.X + (Math.Abs(nodeToLocation.X - nodeFromLocation.X) / 2), nodes.Output.Control.Location.Y - 20), new Point(nodeToLocation.X + (Math.Abs(nodeToLocation.X - nodeFromLocation.X) / 2), nodeToLocation.Y));
                        result.AddLine(new Point(nodeToLocation.X + (Math.Abs(nodeToLocation.X - nodeFromLocation.X) / 2), nodeToLocation.Y), nodeToLocation);
                    }
                    else
                    {
                        result.AddLine(nodeFromLocation, new Point(nodes.Output.Control.Location.X + nodes.Output.Control.Width + linePadding, nodeFromLocation.Y));
                        result.AddLine(new Point(nodes.Output.Control.Location.X + nodes.Output.Control.Width + linePadding, nodeFromLocation.Y), new Point(nodes.Output.Control.Location.X + nodes.Output.Control.Width + linePadding, nodes.Output.Control.Location.Y - 20));
                        result.AddLine(new Point(nodes.Output.Control.Location.X + nodes.Output.Control.Width + linePadding, nodes.Output.Control.Location.Y - 20), new Point(nodeToLocation.X + (Math.Abs(nodeToLocation.X - nodeFromLocation.X) / 2), nodes.Output.Control.Location.Y - 20));
                        result.AddLine(new Point(nodeToLocation.X + (Math.Abs(nodeToLocation.X - nodeFromLocation.X) / 2), nodes.Output.Control.Location.Y - 20), new Point(nodeToLocation.X + (Math.Abs(nodeToLocation.X - nodeFromLocation.X) / 2), nodes.Input.Control.Location.Y - 20));
                        result.AddLine(new Point(nodeToLocation.X + (Math.Abs(nodeToLocation.X - nodeFromLocation.X) / 2), nodes.Input.Control.Location.Y - 20), new Point(nodeToLocation.X, nodes.Input.Control.Location.Y - 20));
                        result.AddLine(new Point(nodeToLocation.X, nodes.Input.Control.Location.Y - 20), nodeToLocation);
                    }
                }
                //other node is on right side of first one
                else
                {
                    //if other node is on left side
                    if (nodes.Input.Location.X < nodes.Input.Control.Width / 2)
                    {
                        result.AddLine(nodeFromLocation, new Point(nodeFromLocation.X + (nodeToLocation.X - nodeFromLocation.X) / 2, nodeFromLocation.Y));
                        result.AddLine(new Point(nodeFromLocation.X + (nodeToLocation.X - nodeFromLocation.X) / 2, nodeFromLocation.Y), new Point(nodeFromLocation.X + (nodeToLocation.X - nodeFromLocation.X) / 2, nodeToLocation.Y));
                        result.AddLine(new Point(nodeFromLocation.X + (nodeToLocation.X - nodeFromLocation.X) / 2, nodeToLocation.Y), nodeToLocation);
                    }
                    else
                    {
                        result.AddLine(nodeFromLocation, new Point(nodeFromLocation.X + (nodes.Input.Control.Location.X - nodeFromLocation.X) / 2, nodeFromLocation.Y));
                        result.AddLine(new Point(nodeFromLocation.X + (nodeToLocation.X - nodeFromLocation.X) / 2, nodeFromLocation.Y), new Point(nodeFromLocation.X + (nodeToLocation.X - nodeFromLocation.X) / 2, nodes.Input.Control.Location.Y - 20));
                        result.AddLine(new Point(nodeFromLocation.X + (nodeToLocation.X - nodeFromLocation.X) / 2, nodes.Input.Control.Location.Y - 20), new Point(nodeToLocation.X, nodes.Input.Control.Location.Y - 20));
                        result.AddLine(new Point(nodeToLocation.X, nodes.Input.Control.Location.Y - 20), nodeToLocation);
                    }
                }
            }*/

            //result.AddArc(nodes.Output.Location.X, nodes.Output.Location.Y, (nodes.Input.Location.X - nodes.Output.Location.X) / 2, (nodes.Input.Location.Y - nodes.Output.Location.Y) / 2, nodes.Output.Location.Y < nodes.Input.Location.Y ? 280 : 60, 0);

            Point[] points = new Point[3];

            points[0] = nodeFromLocation;
            points[1] = new Point(((nodeToLocation.X - nodeFromLocation.X)/2) + nodeFromLocation.X, nodeFromLocation.Y);
            points[2] = nodeToLocation;

            result.AddCurve(points, 0.5f);

            return result;
        }

        public string GetSaveData()
        {
            string result = String.Empty;

            var json = new SaveData();

            foreach (var gate in LogicComponents)
            {
                json.gateControls.Add(gate.GetSaveData());
            }

            foreach (var connection in connectedNodes)
            {
                ConnectedSerializableNodes nodeConnection = new ConnectedSerializableNodes
                {
                    Output = {GateGuid = connection.Output.ParentLogicControl.Guid},
                    Input = {GateGuid = connection.Input.ParentLogicControl.Guid}
                };

                nodeConnection.Output.Name = connection.Output.ConnectionName;
                nodeConnection.Input.Name = connection.Input.ConnectionName;

                json.connections.Add(nodeConnection);
            }

            json.Properties = Properties;

            result = JsonConvert.SerializeObject(json, Formatting.Indented);

            return result;
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

        #endregion
        
        #region BackgroundThreadWireUpdating

        public async Task UpdateLogicAsync()
        {
            await UpdateLogic();
            Refresh();
        }

        private async Task UpdateLogic()
        {
            //First loop through all the constants that are low
            foreach (var component in LogicComponents.Where(item => item is ConstantControl && (item as ConstantControl).High == false))
            {
                UpdateComponent(component);
            }
            //Then the high ones so that high takes precident over those that are low
            foreach (var component in LogicComponents.Where(item => item is ConstantControl && (item as ConstantControl).High == true))
            {
                UpdateComponent(component);
            }
            //Then the high ones so that high takes precident over those that are low
            foreach (var component in LogicComponents.Where(item => item is InputControl))
            {
                UpdateComponent(component);
            }
            //Finnaly Do the gate Controls
            foreach (var component in LogicComponents.Where(item => item is GateControl))
            {
                UpdateComponent(component);
            }
        }

        private void UpdateComponent(LogicControl component)
        {
            component.UpdateOutputState();
            foreach (var item in connectedNodes.Where(item => item.Output == component.OutputNode))
            {
                item.Input.IsOn = item.Output.IsOn;
                item.On = item.Input.IsOn;
            }
        }

        private async Task UpdateLogicLoop(CancellationToken ct)
        {
            while (true)
            {
                if (ct.IsCancellationRequested)
                {
                    break;
                }
                await Task.Delay(Properties.TickRate, ct);
                await UpdateLogic();
                Refresh();
            }

        }
        #endregion
    }
}
