using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeamProjectVO;

namespace TeamProject
{
    public partial class Uctrl_CartItemList : UserControl
    {
        public event EventHandler ThisCheck;
        public delegate void DelCart(object sender, CartArgs e);
        public event DelCart DelCartList;

        MyCartListVO info = new MyCartListVO();

        public bool ThisChecked 
        {
            get { return cbx_Check.Checked; }
            set { cbx_Check.Checked = value; }
        }

        public MyCartListVO MyCartInfo
        {
            get { return info; }
            set { info = value; }
        }

        public int Count { get { return (int)nu_ProdCount.Value; } }

        public Uctrl_CartItemList()
        {
            InitializeComponent();
        }

        private void Uctrl_CartItemList_Load(object sender, EventArgs e)
        {
            lbl_Price.Text = ((int)info.Product_Price).ToString();
            lbl_ProdName.Text = info.Product_Name;
            nu_ProdCount.Value = info.CartProd_Count;

            if (info.Product_Img != null)
            {
                pb_ProductImg.Image = CommonUtil.ByteToImage(info.Product_Img);
            }
        }

        private void btn_DelCart_Click(object sender, EventArgs e)
        {
            if (DelCartList != null)
            {
                CartArgs args = new CartArgs();
                args.CartNum = info.Cart_No;
                DelCartList(this, args);
            }
        }

        public class CartArgs : EventArgs
        {
            int cartNum;

            public int CartNum { get { return cartNum; } set { cartNum = value; } }
        }

        private void cbx_Check_CheckedChanged(object sender, EventArgs e)
        {
            ThisCheck?.Invoke(this, null);
        }

        private void nu_ProdCount_ValueChanged(object sender, EventArgs e)
        {
            ThisCheck?.Invoke(this, null);
            info.CartProd_Count = (int)nu_ProdCount.Value;
        }
    }
}
