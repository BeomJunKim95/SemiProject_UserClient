using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProjectVO;
using System.Data;
using System.Diagnostics;

namespace TeamProjectDAC
{
	public class AddressDAC : ConnectionDB, IDisposable
	{
		string strConn;
		SqlConnection conn;

		public AddressDAC()
		{
			strConn = this.ConnectionDBs;
			conn = new SqlConnection(strConn);
			conn.Open();
		}

		/// <summary>
		/// DB에 모든 주소를 조회하는 메서드
		/// </summary>
		/// <returns>성공 : 주소목록 List, 실패 : null</returns>
		public List<AddressVO> GetAllAddress(string id)
		{
			try
			{
				string sql = @"select user_ID, 
									  Addr_No, 
									  Addr_Receiver, 
									  Addr_Phone, 
									  concat(Addr, ' ', Addr_Detail) Addr_show,
									  Addr_NickName,
									  Addr,
									  Addr_Detail,
									  Addr_PostCode,
									  Addr_Main
								 from User_AddressInfo
								where user_ID = @user_ID";
				using(SqlCommand cmd = new SqlCommand(sql, conn))
				{
					cmd.Parameters.AddWithValue("@user_ID", id);

					SqlDataReader reader = cmd.ExecuteReader();
					List<AddressVO> list = Helper.DataReaderMapToList<AddressVO>(reader);

					return list;
				}
			}
			catch (Exception err)
			{
				Debug.WriteLine(err.Message);
				return null;
			}
		}

		/// <summary>
		/// 주소테이블에 해당 유저의 기본배송지를 가져오는 메서드
		/// </summary>
		/// <param name="id">유저ID</param>
		/// <returns>성공 : 주소목록 List, 실패 : null</returns>
		public List<AddressVO> GetMainAddress(string id)
		{
			try
			{
				string sql = @"select Addr_No, 
									  Addr_Receiver, 
									  Addr_Phone, 
									  Addr_NickName,
									  Addr,
									  Addr_Detail,
									  Addr_PostCode
								 from User_AddressInfo
								where Addr_Main = 'Y'
								  and user_ID = @user_ID";
				using (SqlCommand cmd = new SqlCommand(sql, conn))
				{
					cmd.Parameters.AddWithValue("@user_ID", id);

					SqlDataReader reader = cmd.ExecuteReader();
					List<AddressVO> list = Helper.DataReaderMapToList<AddressVO>(reader);

					return list;
				}
			}
			catch (Exception err)
			{
				Debug.WriteLine(err.Message);
				return null;
			}
		}

		/// <summary>
		/// 주소 테이블에 새로운 주소를 Insert하는 메서드
		/// </summary>
		/// <param name="vo">주소정보 객체</param>
		/// <returns>성공 : true,   실패 : false</returns>
		public bool InsertAddress(AddressVO vo)
		{
			try
			{
				string sql = @"insert into User_AddressInfo(user_ID, Addr_Receiver, Addr_Phone, Addr, Addr_Detail, Addr_PostCode, Addr_NickName, Addr_Main)
									  values(@user_ID, @Addr_Receiver, @Addr_Phone, @Addr, @Addr_Detail, @Addr_PostCode, @Addr_NickName, @Addr_Main)";
				using(SqlCommand cmd = new SqlCommand(sql, conn))
				{
					cmd.Parameters.AddWithValue("@user_ID", vo.User_ID);
					cmd.Parameters.AddWithValue("@Addr_Receiver", vo.Addr_Receiver);
					cmd.Parameters.AddWithValue("@Addr_Phone", vo.Addr_Phone);
					cmd.Parameters.AddWithValue("@Addr", vo.Addr);
					cmd.Parameters.AddWithValue("@Addr_Detail", vo.Addr_Detail);
					cmd.Parameters.AddWithValue("@Addr_PostCode", vo.Addr_PostCode);
					cmd.Parameters.AddWithValue("@Addr_NickName", vo.Addr_NickName);
					cmd.Parameters.AddWithValue("@Addr_Main", vo.Addr_Main);

					int iRowAffect = cmd.ExecuteNonQuery();
					if (iRowAffect > 0)
						return true;
					else
						return false;
				}
			}
			catch(Exception err)
			{
				return false;
			}
		}

		/// <summary>
		/// 주소 테이블에 주소를 Update하는 메서드
		/// </summary>
		/// <param name="vo">주소정보 객체</param>
		/// <returns>성공 : true,   실패 : false</returns>
		public bool UpdateAddress(AddressVO vo)
		{
			try
			{
				string sql = @"update User_AddressInfo
							      set Addr_Receiver = @Addr_Receiver, 
							    	  Addr_Phone = @Addr_Phone, 
							    	  Addr_NickName = @Addr_NickName,
							    	  Addr = @Addr,
							    	  Addr_Detail = @Addr_Detail,
							    	  Addr_PostCode = @Addr_PostCode,
							    	  Addr_Main = @Addr_Main
							    where Addr_No = @Addr_No";
				using (SqlCommand cmd = new SqlCommand(sql, conn))
				{
					cmd.Parameters.AddWithValue("@Addr_No", vo.Addr_No);
					cmd.Parameters.AddWithValue("@Addr_Receiver", vo.Addr_Receiver);
					cmd.Parameters.AddWithValue("@Addr_Phone", vo.Addr_Phone);
					cmd.Parameters.AddWithValue("@Addr", vo.Addr);
					cmd.Parameters.AddWithValue("@Addr_Detail", vo.Addr_Detail);
					cmd.Parameters.AddWithValue("@Addr_PostCode", vo.Addr_PostCode);
					cmd.Parameters.AddWithValue("@Addr_NickName", vo.Addr_NickName);
					cmd.Parameters.AddWithValue("@Addr_Main", vo.Addr_Main);

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
		/// <summary>
		/// 주소 테이블에 주소를 Delete하는 메서드
		/// </summary>
		/// <param name="addrNo">주소번호(기본키)</param>
		/// <returns>성공 : true,   실패 : false </returns>
		public bool DeleteAddress(int addrNo)
		{
			try
			{
				string sql = @"delete from User_AddressInfo 
									 where Addr_No = @Addr_No";
				using (SqlCommand cmd = new SqlCommand(sql, conn))
				{
					cmd.Parameters.AddWithValue("@Addr_No", addrNo);
					
					int iRowAffect = cmd.ExecuteNonQuery();
					if (iRowAffect < 1)
						throw new Exception("주소번호 없음");

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
