using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProjectVO;

namespace TeamProjectDAC
{
    public class Valuez_DAC : ConnectionDB, IDisposable
    {
        SqlConnection conn;

        public Valuez_DAC()
        {
            conn = new SqlConnection
            {
                ConnectionString = this.ConnectionDBs
            };

            conn.Open();
        }

        #region select
        public List<ValuezcConnFeatureVO> GetValuezcConns(int Category_ID)
        {
            SqlCommand sql = new SqlCommand()
            {
                Connection = conn,
                CommandText = $@"SELECT V.Value_Name, V.Value_ID, F.Feature_Name
    FROM Valuez V join Features F 
	on V.Feature_ID = F.Feature_ID
	join Categories C 
    on F.Category_ID = C.Category_ID
    where C.Category_ID = @Category_ID;"
            };

            sql.Parameters.AddWithValue("@Category_ID", Category_ID);
            SqlDataReader reader = sql.ExecuteReader();

            List<ValuezcConnFeatureVO> vs = new List<ValuezcConnFeatureVO>();
            while (reader.Read())
            {
                vs.Add(new ValuezcConnFeatureVO
                {
                    Value_Name = reader["Value_Name"].ToString(),
                    Value_ID = Convert.ToInt32(reader["Value_ID"]),
                    Feature_Name = reader["Feature_Name"].ToString()
                });
            }

            return vs;

        }

        #endregion


        public void Dispose()
        {
            conn.Dispose();
        }
    }
}
