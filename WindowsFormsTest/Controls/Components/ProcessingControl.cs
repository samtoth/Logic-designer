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
    public partial class ProcessingControl : LogicControl
    {
        public ProcessingControl()
        {
            InitializeComponent();
        }

        public virtual ConnectionNode OutputNode { get { return null; } }
    }
}
