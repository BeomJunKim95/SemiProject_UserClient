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
    public partial class Uctrl_WishList : UserControl
    {
        public delegate void ShowItem<T>(object sender, ListArgs<T> args);
        public event ShowItem<MyWishInfoVO> Show_wList;
        public event ShowItem<MyPurchaseInfoVO> Show_pList;

        public enum UC_Type { Wish, Purchase }
        UC_Type thistype;

        int tot = 0; // 총 아이템 갯수
        string fst = string.Empty;
        List<MyWishInfoVO> myWlist = new List<MyWishInfoVO>();
        MyWishInfoVO myWish;
        List<MyPurchaseInfoVO> myPlist = new List<MyPurchaseInfoVO>();
        MyPurchaseInfoVO myPurchase;

        public UC_Type ThisType { set { thistype = value; } }

        public string NickName
        {
            get { return lbl_WishName.Text; }
            set { lbl_WishName.Text = value; }
        }

        #region 찜목록
        public List<MyWishInfoVO> MyWishList
        {
            get { return myWlist; }
        }

        public MyWishInfoVO WishItem
        {
            set
            {
                myWish = value;
                myWlist.Add(value);
            }
        }

        #endregion

        #region 거래목록
        public List<MyPurchaseInfoVO> MyPurchaseList
        {
            get { return myPlist; }
        }

        public MyPurchaseInfoVO PurchaseItem
        {
            set
            {
                myPurchase = value;
                myPlist.Add(value);
            }
        }
        #endregion

        public int Wish_No 
        {
            get { return myWish.Wish_no; }
        }

        public bool ThisChecked
        {
            get { return cbx_Select.Checked; }
        }

        public string Price
        {
            get { return lbl_price.Text; }
            set { lbl_price.Text = value; }
        }

        public int TotalItemCount
        {
            get { return tot; }
            set { tot = value; }
        }

        public string FstItem
        {
            get { return fst; }
            set { fst = value; }
        }

        public Uctrl_WishList()
        {
            InitializeComponent();
        }

        private void Uctrl_WishList_Load(object sender, EventArgs e)
        {
            lbl_ProdList.Text = fst + $"외 {tot - 1}개 물품";
        }

        private void btn_ShowList_Click(object sender, EventArgs e)
        {
            if(thistype == UC_Type.Wish)
            {
                if (Show_wList != null)
                {
                    ListArgs<MyWishInfoVO> args = new ListArgs<MyWishInfoVO>();
                    args.ItemList = myWlist;
                    Show_wList(this, args);
                }
            }
            else if(thistype == UC_Type.Purchase)
            {
                if (Show_pList != null)
                {
                    ListArgs<MyPurchaseInfoVO> args = new ListArgs<MyPurchaseInfoVO>();
                    args.ItemList = myPlist;
                    Show_pList(this, args);
                }
            }
        }

        public class ListArgs<T> : EventArgs
        {
            List<T> list = new List<T>();

            public List<T> ItemList 
            {
                get { return list; }
                set { list = value; }
            }
        }
    }
}
