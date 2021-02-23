using TeamProjectVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TeamProjectVO
{
    public class UserInfoVO
    {
         public string user_ID { get; set; }
         public string user_Pwd { get; set; }
         public string user_Name { get; set; }
         public string user_Phone { get; set; }
         public string user_Email { get; set; }
         public DateTime user_RegDate { get; set; }
         public string user_Deleted { get; set; }

    }

    public class MyWishListVO
    {
        public int Wish_no { get; set; }
        public string Wish_NickName { get; set; }
        public int Product_ID { get; set; }
        public int Wish_Count { get; set; }
        public string Product_Name { get; set; }
        public decimal Product_Price { get; set; }
    }

    public class MyWishInfoVO
    {
        public int Wish_no { get; set; }
        public string Wish_NickName { get; set; }
        public int Product_ID { get; set; }
        public int Wish_Count { get; set; }
        public string Product_Name { get; set; }
        public decimal Product_Price { get; set; }
        public byte[] Product_Img { get; set; }
    }

    public class MyCartListVO
    {
        public int Cart_No { get; set; }
        public int Product_ID { get; set; }
        public int CartProd_Count { get; set; }
        public decimal Product_Price { get; set; }
        public string Product_Name { get; set; }
        public int Product_PsyCount { get; set; }
        public int Product_LogCount { get; set; }
        public byte[] Product_Img { get; set; }
    }

    public class MyPurchaseInfoVO
    {
        public string user_ID { get; set; }
        public int Purchase_ID { get; set; }
        public DateTime Purchase_Date { get; set; }
        public string Purchase_State { get; set; }
        public int Purchase_Info_ID { get; set; }
        public string Product_Name { get; set; }
        public decimal Products_Price { get; set; }
        public string Addr_Receiver { get; set; }
        public string Addr_Phone { get; set; }
        public string Addr { get; set; }
        public int Products_ID { get; set; }
        public byte[] Product_Img { get; set; }
        public int Purchase_Count { get; set; }
    }
}
