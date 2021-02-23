using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeamProject
{
    public partial class CompatibilityCheck : UserControl
    {
        public string product_item1 { set => lbl_product_item1.Text = value; }
        public string product_item2 { set => lbl_product_item2.Text = value; }
        public string item_Compat1  { set => lbl_item_Compat1.Text = value; }
        public string item_Compat2  { set => lbl_item_Compat2.Text = value; }
        public string item_CompatName1 { set => lbl_item_CompatName1.Text = value; }
        public string item_CompatName2 { set => lbl_item_CompatName2.Text = value; }

        public CompatibilityCheck()
        {
            InitializeComponent();
        }

        private void CompatibilityCheck_Load(object sender, EventArgs e)
        {

        }
    }
}
