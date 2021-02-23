using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProjectVO;

namespace TeamProjectDAC
{
	class Purchase_DAC : ConnectionDB, IDisposable
	{
		string strConn;
		SqlConnection conn;

		public Purchase_DAC()
		{
			strConn = this.ConnectionDBs;
			conn = new SqlConnection(strConn);
			conn.Open();
		}

		public bool InsertAddress(PurchaseVO vo)
		{
			//insert into User_Purchase(user_ID, Addr_No)
			//	   values(@user_ID, @Addr_No)

			//insert into User_Purchase_info(Purchase_ID, Products_ID, Purchase_Count, Products_Price, Order_Price)
			//	   values(@Purchase_ID, @Products_ID, @Purchase_Count, @Products_Price, @Order_Price)

			try
			{
				string sql = @"";
				using (SqlCommand cmd = new SqlCommand(sql, conn))
				{
					

					int iRowAffect = cmd.ExecuteNonQuery();
					if (iRowAffect > 0)
						return true;
					else
						return false;
				}
			}
			catch (Exception err)
			{
				return false;
			}
		}

		public void Dispose()
		{
			conn.Close();
		}
	}
}
