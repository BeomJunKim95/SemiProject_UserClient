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
	public partial class UC_PurchaseProductList : UserControl
	{
		MyCartListVO info = new MyCartListVO();

		public MyCartListVO MyOrderInfo
		{
            get { return info; }
			set { info = value; }
		}

        public int TotalPrice 
		{
			get { return int.Parse(lbl_TotalPrice.Text); }
		}

        public UC_PurchaseProductList()
		{
			InitializeComponent();
		}

		private void UC_PurchaseProductList_Load(object sender, EventArgs e)
		{
			lbl_Price.Text = ((int)info.Product_Price).ToString();
			lbl_ProdName.Text = info.Product_Name;
			lbl_count.Text = info.CartProd_Count.ToString();
			lbl_TotalPrice.Text = ((int)info.Product_Price * info.CartProd_Count).ToString();

			if (info.Product_Img != null)
				pb_ProductImg.Image = CommonUtil.ByteToImage(info.Product_Img);

		}
	}
}
