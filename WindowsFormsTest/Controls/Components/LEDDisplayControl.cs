using System;
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
    public partial class LedDisplayControl : DisplayControl
    {
        public LedDisplayControl()
        {
            InitializeComponent();
            IsOn = false;
            InputNodes.Add(new ConnectionNode(new Point(18, 18), "Input A", true));
        }

        public bool IsOn
        {
            get { return _isOn; }
            set
            {
                _isOn = value;
                MainImage.Image = value ? Properties.Resources.Led_Green : Properties.Resources.Led_off_green;
            }
        }

        private bool _isOn;
        
        public override void UpdateOutputState()
        {
            IsOn = InputNodes.Any(item => item.IsOn);
        }
    }
}
