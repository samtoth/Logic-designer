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
using WindowsFormsTest.Forms;
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
            drawingSurface.Click += drawingSurface_Click;
        }
        
        #region Classes
        public class DesignerProperties
        {
            
            public DesignerProperties()
            {
                WireOnColor = Color.Red;
                WireOffColor = Color.Blue;
                TickRate = 250;
                StartGates = new List<GateControl>();
            }
            [Description("The wire color when its state is on.")]
            public Color WireOnColor { get; set; }
            [Description("The wire color when its state is off.")]
            public Color WireOffColor { get; set; }
            [Description("The delay in miliseconds bewtween each update in logic.")]
            [RadRange(1, int.MaxValue)]
            public int TickRate { get; set; }
            [Description("If it is not found automatically, This will set the gates which will be calculated first in the step. (Is important for syncing issues)")]
            public List<GateControl> StartGates { get; set; }
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
            public List<GateControl.LogicSaveData> LogicControls = new List<GateControl.LogicSaveData>();
            public List<ConnectedSerializableNodes> Connections = new List<ConnectedSerializableNodes>();
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

            if (e.Data.GetData(e.Data.GetFormats()[0]) is ILogicGate || e.Data.GetData(e.Data.GetFormats()[0]) is ConstantControl || e.Data.GetData(e.Data.GetFormats()[0]) is InputControl)
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
                CreateLogicControl(lc.GetType(), pos);
            }

            if (e.Data.GetData(e.Data.GetFormats()[0]) is ConstantControl)
            {
                
                
                Point pos = this.PointToClient(new Point(e.X, e.Y));

                Object o = e.Data.GetData(e.Data.GetFormats()[0]);
                
                var ctrl = CreateLogicControl(o.GetType(), pos);
                
            }

            if (e.Data.GetData((e.Data.GetFormats()[0])) is InputControl)
            {
                CreateLogicControl(typeof(InputControl), PointToClient(new Point(e.X, e.Y)));
            }
        }

        private LogicControl CreateLogicControl(Type t, Point pos)
        {
            LogicControl control;
            if (typeof(ILogicGate).IsAssignableFrom(t))
            {
                control = CreateGate(t);
            }
            else
            {
                //create
                control = (LogicControl)Activator.CreateInstance(t);
                control.Guid = Guid.NewGuid();//TODO see if this is required
            }
            control.Location = pos;
            drawingSurface.Controls.Add(control);

            //add to list
            LogicComponents.Add(control);

            //hook events
            control.ControlSelected += control_ControlSelected;
            control.NodeConnectionMade += gc_NodeConnectionMade;
            control.Moving += gc_Moving;
            control.Moved += gc_Moved;
            control.MoveStart += Control_MoveStart;
            control.OutputNode.deleteNodeRequest += OutputNode_deleteNodeRequest;

            if (control is ConstantControl)
            {

                (control as ConstantControl).ControlColor = control is ConstantControlHigh ? Properties.WireOnColor : Properties.WireOffColor;
            }
            else if (control is GateControl)
            {
                foreach (var node in (control as GateControl).LogicGate.InputNodes)
                {
                    node.deleteNodeRequest += OutputNode_deleteNodeRequest;
                }
            }
            else if(control is InputControl)
            {
                (control as InputControl).InputToggle += MainLogicDesigner_InputToggle;
            }

            return control;
        }

        void MainLogicDesigner_InputToggle(object sender, EventArgs e)
        {
            foreach (InputControl logicComponent in LogicComponents.Where(gate => gate.Selected))
            {
                logicComponent.IsOn = !logicComponent.IsOn;
            }
        }

        void OutputNode_deleteNodeRequest(object sender, EventArgs e)
        {
            List<ConnectedNodes> nodesToRemove = connectedNodes.Where(node => sender == node.Input || sender == node.Output).ToList();
            foreach (var node in nodesToRemove)
            {
                connectedNodes.Remove(node);
            }
            Refresh();
        }

        void control_ControlSelected(object sender, LogicControl.SelectionEventHandler e)
        {
            //If control key not down then unselect all other controls
            if (ModifierKeys != Keys.Control)
            {
                foreach (var item in LogicComponents.Where(item => item != sender))
                {
                    item.Selected = false;
                }
            }
        }
        void drawingSurface_Click(object sender, EventArgs e)
        {
            control_ControlSelected(this, new LogicControl.SelectionEventHandler(new LogicControl()));
        }
        private GateControl CreateGate(Type gateType)
        {
            return CreateGate(gateType, Guid.NewGuid());
        }

        private GateControl CreateGate(Type gateType, Guid guid)
        {
            var newLc = Activator.CreateInstance(gateType);
            GateControl result = new GateControl((ILogicGate) (newLc), guid);

            return result;
        }

        private void MoveTimer_Tick(object sender, EventArgs e)
        {
            moveHandler();
        }

        private void Control_MoveStart(object sender, EventArgs e)
        {
            MoveTimer.Enabled = true;
        }

        private Point previousPos;

        protected void moveHandler()
        {
            if (MouseButtons == MouseButtons.Left)
            {
                Point CurrentPos = Parent.PointToClient(MousePosition);

                if (!previousPos.IsEmpty)
                {
                    var Ydif = previousPos.Y - CurrentPos.Y;
                    var Xdif = CurrentPos.X - previousPos.X;

                    foreach (var item in LogicComponents.Where(item => item.Selected))
                    {
                        item.Left += Xdif;
                        item.Top -= Ydif;
                        if (item.Left < 0)
                        {
                            item.Left = 0;
                        }
                        if (item.Top < 0)
                        {
                            item.Top = 0;
                        }
                    }
                    if (!Running)
                    {
                        Refresh();
                    }
                }



                //if (this.Moving != null)
                //{
                //    this.Moving(this, new GateEventHandler(this.Location));
                //}
                previousPos = CurrentPos;
            }
            else
            {
                if (previousPos.X > trashcan.Location.X && previousPos.Y > trashcan.Location.Y)
                {
                    foreach (var logicComponent in LogicComponents.Where(item => item.Selected))
                    {
                        DeleteLogicControl(logicComponent);
                    }
                }

                MoveTimer.Enabled = false;
                previousPos = Point.Empty;
                this.Refresh();

                

                ChangedFlag = true;
                //if (this.Moved != null)
                //{
                //    this.Moved(this, new GateEventHandler(this.Location));
                //}
            }
        }

        private void gc_Moving(object sender, LogicControl.GateEventHandler e)
        {
            this.Refresh();
            foreach (var item in LogicComponents.Where(item => item.Selected))
            {
                item.MoveEnabled = true;
            }
        }

        private void gc_Moved(object sender, LogicControl.GateEventHandler e)
        {
            this.Refresh();

            if (e.point.X > trashcan.Location.X && e.point.Y > trashcan.Location.Y)
            {

                DeleteLogicControl((LogicControl) sender);
            }

            ChangedFlag = true;
        }

        private void DeleteLogicControl(LogicControl pGateControl)
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

            foreach (var ctrl in data.LogicControls)
            {
                CreateLogicControl(ctrl.Type, ctrl.Pos).Guid = ctrl.Guid;
            }
            foreach (var connection in data.Connections)
            {
                ConnectionNode output = null;
                ConnectionNode input = null;
                foreach (var ctrl in LogicComponents)
                {
                    if (ctrl.Guid == connection.Output.GateGuid)
                    {
                        //Dealing with the outuput node
                        output = ctrl.OutputNode;
                    }

                    if (ctrl.Guid == connection.Input.GateGuid)
                    {
                        if (ctrl is GateControl)
                        {
                            foreach (var node in(ctrl as GateControl).LogicGate.InputNodes.Where(node => node.ConnectionName == connection.Input.Name))
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
        }//TODO

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

            foreach (var item in LogicComponents)
            {
                json.LogicControls.Add(item.GetSaveData());
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

                json.Connections.Add(nodeConnection);
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
            try
            {
                await UpdateLogic();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Refresh();
        }

        private async Task UpdateLogic()
        {
            //First loop through all the constants that are low
            foreach (var component in LogicComponents.Where(item => item is ConstantControlHigh))
            {
                UpdateComponent(component);
            }
            //Then the high ones so that high takes precident over those that are low
            foreach (var component in LogicComponents.Where(item => item is ConstantControlLow))
            {
                UpdateComponent(component);
            }
            //Then the inputs
            foreach (var component in LogicComponents.Where(item => item is InputControl))
            {
                UpdateComponent(component);
            }
            UpdateGates();
        }

        private void UpdateGates()
        {

            List<GateControl> calculatedGates = new List<GateControl>();

            //Get All input nodes that are connected to gate controls
            Dictionary<ConnectionNode, ConnectionNode> nodesConnectedToGates = connectedNodes.Where(connectedNode => connectedNode.Input.ParentLogicControl is GateControl && connectedNode.Output.ParentLogicControl is GateControl).ToDictionary(connectedNode => connectedNode.Input, connectedNode => connectedNode.Output);

            var pendingGates = new List<GateControl>();

            //get List of gates that could start (Gates that have no other gates connected to its inputs)
            List<GateControl> startGates = GetStartGates(nodesConnectedToGates);
            
            //TODO Handle No start gates
            if (startGates.Count == 0)
            {
                using (ListPicker frm = new ListPicker("Select a starter Gate", "No start gates were identified. (This could be caused by a circular refrence)\n Please choose a start gate from the list of gates"))
                {
                    frm.ListControl.DataSource = LogicComponents.Where(item => item is GateControl).ToList();
                    frm.ListControl.DisplayMember = "DisplayName";
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        startGates.Add(frm.ListControl.SelectedItem.DataBoundItem as GateControl);
                        Properties.StartGates.Add(frm.ListControl.SelectedItem.DataBoundItem as GateControl);
                    }
                    else
                    {
                        throw new NotImplementedException("No start gates found (This might be caused by a circular refrence)");
                    }
                }
            }
            //Maybe TODO Look out for more than one individual circuit on on doc Ie. two circuits two circuits that are indipendant of each other

            //Update each starting gate
            foreach (var gateControl in startGates)
            {
                UpdateComponent(gateControl);
                calculatedGates.Add(gateControl);
            }

            //Call a recurcive method gate that is connected to the start gates output
            foreach (var gateControl in startGates)
            {
                foreach (var connectedNode in connectedNodes.Where(node => node.Output == gateControl.OutputNode && node.Input.ParentLogicControl is GateControl))
                {
                    UpdateGate(connectedNode.Input.ParentLogicControl as GateControl, calculatedGates, nodesConnectedToGates, pendingGates);
                }
            }
        }

        private void UpdateGate(GateControl gateControl, List<GateControl> calculatedGates, Dictionary<ConnectionNode, ConnectionNode> nodesThatAreConnected, List<GateControl> pendingGates)
        {
            if (pendingGates.Contains(gateControl))
            {
                throw new NotImplementedException("Circular refrence detected");
            }

            pendingGates.Add(gateControl);

            //Check that all inputs have been calculated
            foreach (var node in gateControl.LogicGate.InputNodes)
            {
                if (nodesThatAreConnected.ContainsKey(node))
                {
                    if (!calculatedGates.Contains(nodesThatAreConnected[node].ParentLogicControl))
                    {
                        //Check that its not in the pending gate list
                        if (!pendingGates.Contains(nodesThatAreConnected[node].ParentLogicControl))
                        {
                            UpdateGate(nodesThatAreConnected[node].ParentLogicControl as GateControl, calculatedGates, nodesThatAreConnected, pendingGates);
                        }
                    }
                }
            }

            if (!calculatedGates.Contains(gateControl))
            {
                UpdateComponent(gateControl);
                calculatedGates.Add(gateControl);
                if (pendingGates.Contains(gateControl))
                {
                    pendingGates.Remove(gateControl);
                }
                foreach (var connectedNode in connectedNodes.Where(node => node.Output == gateControl.OutputNode && node.Input.ParentLogicControl is GateControl))
                {
                    UpdateGate(connectedNode.Input.ParentLogicControl as GateControl, calculatedGates, nodesThatAreConnected, pendingGates);
                }
            }
        }

        private List<GateControl> GetStartGates(Dictionary<ConnectionNode, ConnectionNode> nodesConnectedToGates)
        {
            if (Properties.StartGates.Count == 0)
            {
                var result = new List<GateControl>();

                foreach (GateControl gate in LogicComponents.Where(item => item is GateControl))
                {
                    bool addToResult = true;
                    foreach (var node in gate.LogicGate.InputNodes)
                    {
                        //if node is in the list of nodes connected to gates
                        if (!nodesConnectedToGates.ContainsKey(node))
                        {
                            continue;
                        }

                        //If the thing its connected to is itself then continue
                        if (nodesConnectedToGates[node].ParentLogicControl == gate)
                        {
                            continue;
                        }

                        addToResult = false;
                        break;
                    }
                    if (addToResult)
                    {
                        result.Add(gate);
                    }
                }
                return result;
            }
            else
            {
                return Properties.StartGates;
            }
        }

        private void UpdateComponent(LogicControl component)
        {
            component.UpdateOutputState();
            foreach (var item in connectedNodes.Where(item => item.Output == component.OutputNode))
            {
                item.Input.IsOn = item.Output.IsOn;
                item.On = item.Output.IsOn;
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
                await UpdateLogicAsync();
                Refresh();
            }

        }
        #endregion
        
    }
}
