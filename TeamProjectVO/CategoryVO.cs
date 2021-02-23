using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProjectVO
{
    public class CategoryVO
    {
        public string Category_Name { get; set; }
        public string Division_Name { get; set; }
    }

    public class CategoriesVO
    {
        public int Category_ID { get; set; }
        public string Category_Name { get; set; }
        public int Division_ID { get; set; }
    }
}
