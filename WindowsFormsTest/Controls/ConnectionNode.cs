using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WindowsFormsTest.Controls
{
    public partial class ConnectionNode : UserControl
    {

        public class ConnectionMadeEventArgs : EventArgs {
            public ConnectionNode nodeFrom{get; set;}                     
            public ConnectionNode nodeTo{get; set;}

            public ConnectionMadeEventArgs(ConnectionNode pNodeFrom, ConnectionNode pNodeTo)
            {
                nodeFrom = pNodeFrom;
                nodeTo = pNodeTo;
            }
        }

        
        
        [JsonIgnore]
        public GateControl gateControl { get; set; }

        Point _RPos;

        String _connectionName;

        bool _isInput;

        public bool IsOn { get; set; }

        public Point RelativePosition { get { return _RPos; } }

        public bool IsInput { get { return _isInput; } }

        public String ConnectionName { get { return _connectionName; } }

        public delegate void ConnectionMadeDelegate(Object sender, ConnectionMadeEventArgs e);

        public event ConnectionMadeDelegate ConnectionMade;

        public ConnectionNode(Point RelativePosition, String ConnectionName, bool IsInput)
        {
            SetupNode(RelativePosition, ConnectionName, IsInput);
        }

        private void SetupNode(Point RelativePosition, String ConnectionName, bool IsInput)
        {
            InitializeComponent();
            _RPos = RelativePosition;
            _connectionName = ConnectionName;
            _isInput = IsInput;
            toolTip1.SetToolTip(this.ConnectionNodeImage, ConnectionName);
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


        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(e.Data.GetFormats()[0]) is ConnectionNode)
            {
                var connectionNode = (ConnectionNode)e.Data.GetData(e.Data.GetFormats()[0]);
                if (connectionNode != null)
                {
                    if (connectionNode.Parent != this.Parent || connectionNode.IsInput != this.IsInput)
                    {
                        Console.WriteLine("Worked and my parent is: " + ((ConnectionNode)e.Data.GetData(e.Data.GetFormats()[0])).Parent.ToString());

                        if (ConnectionMade != null)
                        {
                            ConnectionMade(this, new ConnectionNode.ConnectionMadeEventArgs(connectionNode, this));
                        }
                    }
                }
            }
            /*else if (e.Data.GetData(e.Data.GetFormats()[0]) is ConstantControl)
            {
                var connectionNode = (ConstantControl)e.Data.GetData(e.Data.GetFormats()[0]);
                if (connectionNode != null)
                {
                    if (this.IsInput)
                    {
                        if (ConnectionMade != null)
                        {
                            //ConnectionMade(this, new ConnectionNode.ConnectionMadeEventArgs(connectionNode, this));
                        }
                    }
                }
            }*/
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            this.DoDragDrop(this, DragDropEffects.All);
        }

        private void panel1_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(e.Data.GetFormats()[0]) is ConnectionNode || e.Data.GetData(e.Data.GetFormats()[0]) is ConstantControl)
            {
                e.Effect = DragDropEffects.All;
            }
        }


        //string getSaveData()
        //{
        //    string result = "";

        //    //save type, guid, pos, 

        //    return result;
        //}


    }
}
