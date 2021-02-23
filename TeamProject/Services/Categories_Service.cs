using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProjectVO;
using TeamProjectDAC;

namespace TeamProject
{
    public class Categories_Service
    {
        public List<CategoriesVO> SelectCategoriesFromDivisionID(int DivisionID)
        {
            List<CategoriesVO> temp;
            Categories_DAC db = new Categories_DAC();
            temp = db.SelectCategoriesFromDivisionID(DivisionID);
            db.Dispose();
            return temp;

        }
    }
}
