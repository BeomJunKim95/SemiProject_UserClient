using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProjectDAC;
using TeamProjectVO;

namespace TeamProject
{
    public class Valuez_Service
    {
        public List<ValuezcConnFeatureVO> GetValuezcConns(int Category_ID)
        {

            Valuez_DAC db = new Valuez_DAC();
            List<ValuezcConnFeatureVO> temp = db.GetValuezcConns(Category_ID);
            db.Dispose();
            return temp;
        }
    }
}
