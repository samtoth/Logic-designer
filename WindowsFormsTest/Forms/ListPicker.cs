using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsTest.Forms
{
    public partial class ListPicker : Form
    {

        public Object GetSelectedItem()
        {
            return ListControl.SelectedItem;
        }

        public ListPicker(String title, String message )
        {
            InitializeComponent();
            Text = title;
            radLabel1.Text = message;
            
            //radListView1.DataSource = dataList;
        }

        private void Ok_btn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
