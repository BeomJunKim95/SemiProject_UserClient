using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using TeamProjectVO;
using System.IO;

namespace TeamProject
{
    public partial class ProductInfo : UserControl
    {
        public enum UC_Type { Prod, Wish, Purchase }

        public string Productinfo { get => lbl_Productinfo.Text;}
        public event EventHandler btnClick;
        public ProductListVO VO;
        MyWishInfoVO winfo;
        MyPurchaseInfoVO pinfo;

        UC_Type thistype = UC_Type.Prod;

        public UC_Type Thistype { set { thistype = value; } }

        public ProductInfo()
        {
            InitializeComponent();
        }

        public ProductInfo(MyWishInfoVO wVo)
        {
            InitializeComponent();
            winfo = wVo;
        }

        public ProductInfo(MyPurchaseInfoVO pVo)
        {
            InitializeComponent();
            pinfo = pVo;
        }

        public ProductInfo(ProductListVO vO)
        {
            InitializeComponent();
            VO = vO;
        }

        private void UserControl6_Load(object sender, EventArgs e)
        {
            if(thistype == UC_Type.Prod)
            {
                lbl_Count.Visible = false;
                lbl_ProductName.Text = VO.Product_Name;
                lbl_Productinfo.Text = VO.Product_Info;
                lbl_Producprice.Text = VO.Product_Price.Replace(".0000", "원");
                MemoryStream stream = new MemoryStream(VO.Product_Img, 0, VO.Product_Img.Length);
                Image image = Image.FromStream(stream);
                pictureBox2.Image = image;
            }
            else
            {
                btn_Add.Visible = false;
                lbl_Productinfo.Visible = false;
                if (thistype == UC_Type.Wish)
                {
                    lbl_Count.Text = winfo.Wish_Count.ToString() + "개";
                    lbl_Producprice.Text = winfo.Product_Price.ToString().Replace(".0000", "원");
                    lbl_ProductName.Text = winfo.Product_Name;
                    pictureBox2.Image = CommonUtil.ByteToImage(winfo.Product_Img);
                }
                else
                {
                    lbl_Count.Text = pinfo.Purchase_Count.ToString() + "개";
                    lbl_Producprice.Text = pinfo.Products_Price.ToString().Replace(".0000", "원");
                    lbl_ProductName.Text = pinfo.Product_Name;
                    pictureBox2.Image = CommonUtil.ByteToImage(pinfo.Product_Img);
                }
            }
        }

        private void lbl_Producprice_SizeChanged(object sender, EventArgs e)
        {
            if(thistype == UC_Type.Prod)
            {
                Control control = (Control)sender;
                control.Location = new Point(560 - control.Width, control.Location.Y);
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            btnClick?.Invoke(this, e);
        }
    }
}



/*
* select PP.Product_ID
  ,STUFF((select '/' +V1.Value_Name from Product_Prop PP1 join Valuez V1
  on  PP1.Value_ID = V1.Value_ID where PP1.Product_ID = pp.Product_ID  FOR XML PATH(''))
  , 1, 1, '')
  FROM  Product_Prop PP join Valuez V
  on  PP.Value_ID = V.Value_ID join
  Products P on  P.Product_ID = PP.Product_ID
  where PP.Product_ID = 1
  group by PP.Product_ID;
*/
