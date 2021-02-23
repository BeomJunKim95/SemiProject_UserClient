using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeamProject.UserControls
{
    public partial class ProductList_Control : UserControl
    {
        public delegate void AddProdInfo(object sender, ProdInfoArgs e);
        public event AddProdInfo AddProdEvent;

        public int Prop_Product_ID
        {
            get { return int.Parse(lbl_ProductID.Text); }
            set { lbl_ProductID.Text = value.ToString(); }
        }

        public string Prop_ProductName
        {
            get { return lbl_PorductName.Text; }
            set { lbl_PorductName.Text = value; }
        }

        public string Prop_ProductPrice
        {
            get { return lbl_ProductPrice.Text; }
            set { lbl_ProductPrice.Text = value; }
        }

        public string Prop_ProductDetail
        {
            get { return lbl_ProductDetail.Text; }
            set { lbl_ProductDetail.Text = value; }
        }

        public string Prop_Category 
        {
            get { return lblCategory.Text; }
            set { lblCategory.Text = value; }
        }

        public ProductList_Control()
        {
            InitializeComponent();
        }

        private void btn_ProductAdd_Click(object sender, EventArgs e)
        {
            if(AddProdEvent != null)
            {
                string price = lbl_ProductPrice.Text.Replace(",", "");
                price = price.Replace("원", "");

                ProdInfoArgs args = new ProdInfoArgs();
                args.ProdID = int.Parse(lbl_ProductID.Text);
                args.ProdName = lbl_PorductName.Text;
                args.ProdPrice = price;
                args.ProdCategory = lblCategory.Text;
                AddProdEvent(this, args);
            }
        }

        public class ProdInfoArgs : EventArgs
        {
            int prodID;
            string prodName, prodPrice, prodCategory;

            public int ProdID
            {
                get { return prodID; }
                set { prodID = value; }
            }

            public string ProdName
            {
                get { return prodName; }
                set { prodName = value; }
            }
            public string ProdPrice 
            {
                get { return prodPrice; }
                set { prodPrice = value; }
            }
            public string ProdCategory
            {
                get { return prodCategory; }
                set { prodCategory = value; }
            }
        }
    }
}
