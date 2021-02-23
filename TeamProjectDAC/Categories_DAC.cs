using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProjectVO;

namespace TeamProjectDAC
{
    public class Categories_DAC : ConnectionDB , IDisposable
    {
        SqlConnection conn;

        public Categories_DAC()
        {
            conn = new SqlConnection
            {
                ConnectionString = this.ConnectionDBs
            };

            conn.Open();
        }

        #region Select
        /// <summary>
        /// 카테고리를 디비전 아이디를 기준으로 찾아 리스트로 리턴
        /// 카테고리에 디비전 아이디는 넣지 않음
        /// </summary>
        /// <param name="Division_ID"></param>
        /// <returns></returns>
        public List<CategoriesVO> SelectCategoriesFromDivisionID(int Division_ID)
        {
            List<CategoriesVO> categories = new List<CategoriesVO>();
            SqlCommand cmd = new SqlCommand
            {
                Connection = conn,
                CommandText = "select Category_ID, Category_Name from Categories where Division_ID = @Division_ID;"
            };
            cmd.Parameters.AddWithValue("@Division_ID", Division_ID);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CategoriesVO VO = new CategoriesVO();
                VO.Category_ID = Convert.ToInt32(reader["Category_ID"]);
                VO.Category_Name = reader["Category_Name"].ToString();
                categories.Add(VO);
            }

            return categories;
        }
        #endregion




        public void Dispose()
        {
            conn.Close();
        }
    }
}
