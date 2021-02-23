using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProjectDAC;
using TeamProjectVO;

namespace TeamProject
{
    public class Product_Service
    {
        public List<ProductVO> GetProductList(string gubun, string category)
        {
            Product_DAC dac = new Product_DAC();
            return dac.GetProductList(gubun, category);
        }

        public List<CategoryVO> GetCategoryList()
        {
            Product_DAC dac = new Product_DAC();
            return dac.GetCategoryList();
        }

        public List<ProductListVO> ProductJoinProp(int Category_ID)
        {
            List<ProductListVO> Result;
            Product_DAC db = new Product_DAC();
            Result =  db.ProductJoinProp(Category_ID);
            db.Dispose();

            return Result;
        }
    }
}
