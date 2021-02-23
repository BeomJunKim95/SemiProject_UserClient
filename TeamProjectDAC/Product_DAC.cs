using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Data.SqlClient;
using TeamProjectVO;
using System.Data;

namespace TeamProjectDAC
{
    public class Product_DAC : ConnectionDB , IDisposable
    {
        string strConn;
        SqlConnection conn;

        public Product_DAC()
        {
            strConn = this.ConnectionDBs;
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        /// <summary>
        /// 구분 및 카테고리를 통해 제품의 목록을 불러옴
        /// </summary>
        /// <param name="gubun">완제품, 부품등 제품의 구분</param>
        /// <param name="category">CPU, GPU등 제품의 카테고리</param>
        /// <returns>제품목록 리스트</returns>
        public List<ProductVO> GetProductList(string gubun, string category)
        {
            using(SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SP_GetProductList";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                cmd.Parameters.AddWithValue("@Division", string.IsNullOrEmpty(gubun) ? DBNull.Value : (object)gubun);
                cmd.Parameters.AddWithValue("@CategoryName", string.IsNullOrEmpty(category) ? DBNull.Value : (object)category);

                List<ProductVO> list = Helper.DataReaderMapToList<ProductVO>(cmd.ExecuteReader());
                conn.Close();
                return list;
            }
        }

        /// <summary>
        /// 카테고리 목록을 불러옴
        /// </summary>
        /// <returns>카테고리 목록 리스트</returns>
        public List<CategoryVO> GetCategoryList()
        {
            using(SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = @"select Category_Name, Division_Name
	                                                                from Categories as cg, Divisions as dv
	                                                                where cg.Division_ID = dv.Division_ID";
                cmd.Connection = conn;

                List<CategoryVO> list = Helper.DataReaderMapToList<CategoryVO>(cmd.ExecuteReader());
                conn.Close();
                return list;
            }
        }




        #region 이용현
        #region 스토어드 프로시저
        public List<ProductListVO> ProductJoinProp(int Category_ID)
        {
            SqlCommand sql = new SqlCommand
            {
                Connection = conn,
                CommandText = "SP_ProductJoinProp",
                CommandType = System.Data.CommandType.StoredProcedure
            };
            sql.Parameters.AddWithValue("@Category_ID", Category_ID);

            SqlDataReader reader = sql.ExecuteReader();
            List<ProductListVO> ProductLists = new List<ProductListVO>();
            while (reader.Read())
            {
                ProductListVO temp = new ProductListVO();
                temp.Product_ID = Convert.ToInt32(reader["Product_ID"]);
                temp.Product_Info = reader["Product_Info"].ToString();
                temp.Product_Info_ID = reader["Product_Info_ID"].ToString();
                temp.Product_Name = reader["Product_Name"].ToString();
                temp.Product_Price = reader["Product_Price"].ToString();
                temp.Product_Img = (byte[])reader["Product_Img"];
                ProductLists.Add(temp);
            }

            return ProductLists;
        }

        #endregion

        #region 스토어드 프로시저
        public void test(byte[] bs, int prode)
        {
            SqlCommand sql = new SqlCommand
            {
                Connection = conn,
                CommandText = @"update Products set Product_Img  = @Product_Img
        where Product_ID = @Product_ID; "
            };
            sql.Parameters.Add("@Product_Img", SqlDbType.Image);
            sql.Parameters["@Product_Img"].Value = bs;
            sql.Parameters.Add("@Product_ID", SqlDbType.Int);
            sql.Parameters["@Product_ID"].Value = prode;

            sql.ExecuteNonQuery();
        }

        public void test(byte[] bs)
        {
            SqlCommand sql = new SqlCommand
            {
                Connection = conn,
                CommandText = @"update Products set Product_Img  = @Product_Img"
            };
            sql.Parameters.Add("@Product_Img", SqlDbType.Image);
            sql.Parameters["@Product_Img"].Value = bs;

            sql.ExecuteNonQuery();
        }

        #endregion
        #endregion


        public void Dispose()
        {
            conn.Dispose();
        }
    }
}
