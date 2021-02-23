using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProjectVO
{
    public class ProductVO
    {
        public int Product_ID { get; set; }
        public string Product_Name { get; set; }
        public decimal Product_Price { get; set; }
        public int Product_PsyCount { get; set; }
        public string Product__Stand { get; set; }
        public string Category_Name { get; set; }
        public string Division_Name { get; set; }
        public byte[] Product_Img { get; set; }
    }

    public class ProductListVO
    {
        public int Product_ID { get; set; }
        public string Product_Name { get; set; }
        public string Product_Price { get; set; }
        public string Product_Info { get; set; }
        public string Product_Info_ID { get; set; }
        public byte[] Product_Img { get; set; }
    }

    public class WishListVO
    {
        public Dictionary<int, int> ItemList { get; set; } // Key : 제품번호, Value : 갯수
        public string User_ID { get; set; }
        public string NickName { get; set; }
    }
}
