using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeamProjectVO;

namespace TeamProject
{
    public partial class CategoriesList : UserControl
    {
        public event EventHandler ThisClick;
        public override string Text { get => label1.Text; set => label1.Text = value; }
        public bool Selected { get; set; }
        public CategoriesVO Vo { get; set; }
        public List<int> ProductInfoID = new List<int>();
        public CategoriesList()
        {
            InitializeComponent();
        }

        public CategoriesList(CategoriesVO VO)
        {
            InitializeComponent();
            Vo = VO;
            Text = VO.Category_Name;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            ThisClick?.Invoke(this, e);
        }

        private void UserControl5_Load(object sender, EventArgs e)
        {

        }
    }
}
