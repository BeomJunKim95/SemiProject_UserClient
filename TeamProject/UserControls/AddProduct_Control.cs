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

namespace TeamProject.UserControls
{
    public partial class AddProduct_Control : UserControl
    {
        public event EventHandler DelClickEvent;
        public event EventHandler CountChangedEvent;
        private ProductListVO vo;
        public ProductListVO Vo { get => vo;}

        public string ProdName 
        {
            get { return lblProductName.Text; }
            set { lblProductName.Text = value; }
        }
        public int ProdCount 
        {
            get { return (int)nuCount.Value; }
            set { nuCount.Value = value; }
        }
        public int ProdPrice 
        {
            get { return Convert.ToInt32(lblPrice.Text); }
        }

        public int ProdID { get; set; }

        public AddProduct_Control()
        {
            InitializeComponent();
        }

        public AddProduct_Control(ProductListVO vo)
        {
            InitializeComponent();
            this.vo = vo;
        }

        private void lblPrice_SizeChanged(object sender, EventArgs e)// 좌측 고정
        {
            lblPrice.Location = new Point(235 - lblPrice.Width, 8);
        }

        private void AddProduct_Control_Load(object sender, EventArgs e)
        {
            lblPrice.Text = Vo.Product_Price.Replace(".0000", "");
            lblProductName.Text = Vo.Product_Name;
            ProdID = vo.Product_ID;
        }

        private void btn_DeleteProduct_Click(object sender, EventArgs e)
        {
            DelClickEvent?.Invoke(this, null);
        }

        private void nuCount_ValueChanged(object sender, EventArgs e)
        {
            lblPrice.Text = Convert.ToString(Convert.ToInt32(Vo.Product_Price.Replace(".0000", "")) * nuCount.Value);
            CountChangedEvent?.Invoke(this, null);
        }

        public void DeleteProductClick()
        {
            btn_DeleteProduct.PerformClick();
        }
    }
}
