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
    public partial class UC_ShowItemList : UserControl
    {
        public enum UC_Type{ Wish, Purchase }
        public event EventHandler ThisClose;

        object itemlist;
        int pnlWidth;
        UC_Type thistype;

        public object List 
        {
            get { return itemlist; }
            set { itemlist = value; }
        }

        public UC_Type ThisType { set { thistype = value; } }

        public UC_ShowItemList()
        {
            InitializeComponent();
        }

        public void PurchaseList()
        {
            List<MyPurchaseInfoVO> list = (List<MyPurchaseInfoVO>)itemlist;

            for(int i = 0; i<list.Count; i++)
            {
                ProductInfo pi = new ProductInfo(list[i])
                {
                    Thistype = ProductInfo.UC_Type.Purchase,
                    Size = new Size(pnlWidth - 20, 90), 
                    Location = new Point(3, 3+(i*110)), 
                    Name = list[i].Purchase_Info_ID.ToString()
                };

                pnl_Lists.Controls.Add(pi);
            }
        }

        public void WishList()
        {
            List<MyWishInfoVO> list = (List<MyWishInfoVO>)itemlist;

            for (int i = 0; i < list.Count; i++)
            {
                ProductInfo pi = new ProductInfo(list[i])
                {
                    Thistype = ProductInfo.UC_Type.Wish, 
                    Size = new Size(pnlWidth - 20, 90),
                    Location = new Point(3, 3 + (i * 110)),
                    Name = list[i].Product_ID.ToString()
                };

                pnl_Lists.Controls.Add(pi);
            }
        }

        private void UC_ShowItemList_Load(object sender, EventArgs e)
        {
            pnlWidth = pnl_Lists.Width;
            if (thistype == UC_Type.Wish)
                WishList();
            else if (thistype == UC_Type.Purchase)
                PurchaseList();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            if(ThisClose != null)
                ThisClose(this, null);
        }
    }
}
