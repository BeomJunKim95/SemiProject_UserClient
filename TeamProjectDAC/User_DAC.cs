using TeamProjectVO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TeamProjectDAC
{
    public class User_DAC : ConnectionDB , IDisposable
    {
        string strConn;
        SqlConnection conn;

        public User_DAC()
        {
            #region DB연결하고 오픈
            strConn = this.ConnectionDBs;
            conn = new SqlConnection(strConn);
            conn.Open();
            #endregion
        }

        #region select 

        #region 로그인
        /// <summary>
        /// 입력한 ID, 비밀번호와 일치하는 회원정보를 가져옴
        /// </summary>
        /// <param name="vo">입력한 ID, 비밀번호</param>
        /// <returns>회원정보</returns>
        public UserInfoVO Login(UserInfoVO vo)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = @"select user_ID, user_Pwd, user_Name, user_Phone, user_Email, user_Deleted
                                      from User_Info
                                     where user_ID = @user_ID and
                                           user_Pwd = @user_Pwd ";

                cmd.Parameters.AddWithValue("@user_ID", vo.user_ID);
                cmd.Parameters.AddWithValue("@user_Pwd", vo.user_Pwd);


                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    UserInfoVO login = new UserInfoVO();
                    login.user_ID = reader["user_ID"].ToString();
                    login.user_Pwd = reader["user_Pwd"].ToString();
                    login.user_Name = reader["user_Name"].ToString();
                    login.user_Phone = reader["user_Phone"].ToString();
                    login.user_Email = reader["user_Email"].ToString();
                    login.user_Deleted = reader["user_Deleted"].ToString();
                    return login;
                }
                else
                {
                    return null;
                }
            }
            
        }
        #endregion

        #region 아이디 찾기
 
        #region 회원가입 폼에서 ID 중복체크
        /// <summary>
        /// 입력한 ID과 DB에 일치하는 ID가 있는지 체크
        /// </summary>
        /// <param name="user_ID">입력한 ID</param>
        /// <returns>같은 ID가 있으면 1</returns>
        public bool IDSearch(string user_ID)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = @"Select Count(*) from  User_Info 
                                    where user_ID = @user_ID;";


                cmd.Parameters.AddWithValue("@user_ID", user_ID);

                int iRowAffect = cmd.ExecuteNonQuery();

                return Convert.ToInt32(cmd.ExecuteScalar()) == 0 ? false: true;
            }
        }
        #endregion

        #region ID찾기 폼에서 ID찾기
        /// <summary>
        /// 입력한 이름, 이메일과 일치하는 회원이 있으면 회원 ID를 가져옴
        /// </summary>
        /// <param name="vo">입력한 이름, 이메일</param>
        /// <returns>회원ID</returns>
        public string GetID(UserInfoVO vo)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = @"select user_ID from User_Info 
                where user_Name=@user_Name and user_Email=@user_Email";


                cmd.Parameters.AddWithValue("@user_Name", vo.user_Name);
                cmd.Parameters.AddWithValue("@user_Email", vo.user_Email);


                string iRowAffect = Convert.ToString(cmd.ExecuteScalar());

                return iRowAffect;
            }
        }
        #endregion

        #endregion

        #region 찜목록 가져오기
        public List<MyWishInfoVO> GetAllMyWishList(string id)
        {
            List<MyWishInfoVO> list = null;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = @"select User_ID, uw.Wish_NickName, uw.Wish_no, uwd.Product_ID, uwd.Wish_Count, pro.Product_Name, pro.Product_Price, pro.Product_Img
	                                                                from User_WishList as uw, User_Wish_Detail as uwd, Products as pro
	                                                                where uw.Wish_no = uwd.Wish_No
	                                                                    and uwd.Product_ID = pro.Product_ID
		                                                                and uw.User_ID = @uid;";
                cmd.Parameters.AddWithValue("@uid", id);

                list = Helper.DataReaderMapToList<MyWishInfoVO>(cmd.ExecuteReader());
                conn.Close();
            }

            return list;
        }

        public bool PurchaseSave(string user_ID, int addrNo, List<MyCartListVO> list)
        {
            using(SqlCommand cmd = new SqlCommand())
            {
                string prodcntjoin = "";
                for (int i = 0; i < list.Count; i++)
                {
                    prodcntjoin += $"{list[i].Product_ID}_{list[i].CartProd_Count}";
                    if (i != (list.Count - 1))
                        prodcntjoin += "|";

                }

                try
                {
                    cmd.Connection = conn;
                    SqlTransaction trans = conn.BeginTransaction();
                    cmd.CommandText = @"SP_PurchaseItemCheck";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@prodlist", prodcntjoin);
                    cmd.Parameters.Add("@result", SqlDbType.Int);
                    cmd.Parameters["@result"].Direction = ParameterDirection.Output;

                    cmd.Transaction = trans;
                    cmd.ExecuteNonQuery();

                    int result = Convert.ToInt32(cmd.Parameters["@result"].Value);

                    if (result == 1)
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = @"insert into User_Purchase(user_ID, Purchase_Date, Purchase_State, Addr_No)
					                                                            values(@uid, getdate(), 'SS01', @addrno);
                                                             select @@IDENTITY;";

                        cmd.Parameters.AddWithValue("@uid", user_ID);
                        cmd.Parameters.AddWithValue("@addrno", addrNo);

                        try
                        {
                            int pNo = Convert.ToInt32(cmd.ExecuteScalar());

                            cmd.CommandText = @"insert into User_Purchase_info(Purchase_ID, Products_ID, Purchase_Count, Products_Price, Order_Price)
											                                                                values(@pNo, @pID, @cnt, @price, (select Order_Price 
																													                                                            from Company_Detail 
																													                                                            where Product_ID = @pID));
                                                                delete from User_Cart where user_ID = @uid and Product_ID = @pID;
                                                                update Products set Product_LogCount = Product_LogCount - @cnt where Product_ID = @pID;";

                            for (int i = 0; i < list.Count; i++)
                            {
                                cmd.Parameters.Clear();

                                cmd.Parameters.AddWithValue("@pNo", pNo);
                                cmd.Parameters.AddWithValue("@pID", list[i].Product_ID);
                                cmd.Parameters.AddWithValue("@cnt", list[i].CartProd_Count);
                                cmd.Parameters.AddWithValue("@price", list[i].Product_Price);
                                cmd.Parameters.AddWithValue("@uid", user_ID);

                                cmd.ExecuteNonQuery();
                            }

                            trans.Commit();
                            return true;
                        }
                        catch (Exception err)
                        {
                            string serrMsg = err.Message;
                            trans.Rollback();
                            return false;
                        }
                    }
                    else
                        return false;
                }
                catch(Exception err)
                {
                    string errMsg = err.Message;
                    return false;
                }
                
                
            }
        }

        public bool PurchaseSave(AddressVO2 addrInfo, List<MyCartListVO> list)
        {
            using(SqlCommand cmd = new SqlCommand())
            {
                string prodcntjoin = "";
                for(int i = 0; i<list.Count; i++)
                {
                    prodcntjoin += $"{list[i].Product_ID}_{list[i].CartProd_Count}";
                    if (i != (list.Count - 1))
                        prodcntjoin += "|"; 

                }

                cmd.Connection = conn;
                SqlTransaction trans = conn.BeginTransaction();
                cmd.CommandText = @"SP_PurchaseItemCheck";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prodlist", prodcntjoin);
                cmd.Parameters.Add("@result", SqlDbType.Int);
                cmd.Parameters["@result"].Direction = ParameterDirection.Output;
                cmd.Transaction = trans;

                cmd.ExecuteNonQuery();

                int result = Convert.ToInt32(cmd.Parameters["@result"].Value);

                if (result == 1)
                {
                    cmd.CommandText = @"declare @addrNo int;
                                                            insert into User_AddressInfo(user_ID, Addr_Receiver, Addr_Phone, Addr, Addr_Detail, Addr_PostCode, Addr_NickName, Addr_Main)
                                                            										 values(@id, @receiv, @phn, @addr, @detail, @postc, @nick, 'N');
                                                            select @addrNo = @@IDENTITY;
                                                            insert into User_Purchase(user_ID, Purchase_Date, Purchase_State, Addr_No)
                                                            									values(@id, getdate(), '상품준비중', @addrNo);
                                                            select @@IDENTITY;";
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@id", addrInfo.User_ID);
                    cmd.Parameters.AddWithValue("@receiv", addrInfo.Addr_Receiver);
                    cmd.Parameters.AddWithValue("@phn", addrInfo.Addr_Phone);
                    cmd.Parameters.AddWithValue("@addr", addrInfo.Addr);
                    cmd.Parameters.AddWithValue("@detail", addrInfo.Addr_Detail);
                    cmd.Parameters.AddWithValue("@postc", addrInfo.Addr_PostCode);
                    cmd.Parameters.AddWithValue("@nick", addrInfo.Addr_NickName);


                    cmd.Transaction = trans;
                }
                else
                    return false;

                try
                {
                    int pno = Convert.ToInt32(cmd.ExecuteScalar());

                    cmd.CommandText = @"insert into User_Purchase_info(Purchase_ID, Products_ID, Purchase_Count, Products_Price, Order_Price)
											                                                                values(@pcid, @pdid, @cnt, @price, ( select Order_Price 
                                                                                                                                                                                        from Company_Detail 
                                                                                                                                                                                        where Product_ID = @pdid ));
                                                                delete from User_Cart where user_ID = @uid and Product_ID = @pdid;
                                                                update Products set Product_LogCount = Product_LogCount - @cnt where Product_ID = @pdid;";

                    for(int i = 0; i<list.Count; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@uid", addrInfo.User_ID);
                        cmd.Parameters.AddWithValue("@pcid", pno);
                        cmd.Parameters.AddWithValue("@pdid", list[i].Product_ID);
                        cmd.Parameters.AddWithValue("@cnt", list[i].CartProd_Count);
                        cmd.Parameters.AddWithValue("@price", list[i].Product_Price);

                        cmd.ExecuteNonQuery();
                    }

                    trans.Commit();
                    return true;
                }
                catch
                {
                    trans.Rollback();
                    return false;
                }
            }
        }

        #endregion

        #region 장바구니 가져오기
        public List<MyCartListVO> GetAllMyCartList(string id)
        {
            List<MyCartListVO> list = null;

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = @"SELECT uc.Cart_No, uc.CartProd_Count, uc.Product_ID, p.Product_Name, p.Product_Price, p.Product_PsyCount, p.Product_LogCount, p.Product_Img
	                                                                      FROM User_Cart as uc, Products as p
	                                                                      where uc.Product_ID = p.Product_ID
	                                                                          and uc.user_ID = @uid;";
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@uid", id);
                list = Helper.DataReaderMapToList<MyCartListVO>(cmd.ExecuteReader());
                conn.Close();

                return list;
            }
        }
        #endregion

        #region 거래내역 가져오기
        public List<MyPurchaseInfoVO> GetMyPurchaseList(string id)
        {
            List<MyPurchaseInfoVO> list = null;

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = @"select up.user_ID, up.Purchase_ID, up.Purchase_Date, cm.Common_Name as Purchase_State, 
	                                                                    upi.Purchase_info_ID, 
	                                                                    ud.Addr_Receiver, ud.Addr_Phone, concat('(', ud.Addr_NickName, ')', ud.Addr, ' ', ud.Addr_Detail) as Addr, 
	                                                            		upi.Products_ID, upi.Products_Price, pd.Product_Name, upi.Purchase_Count, pd.Product_Img
	                                                            from User_Purchase as up, User_Purchase_info as upi, User_AddressInfo as ud, Products as pd, Common as cm
	                                                            where up.Purchase_ID = upi.Purchase_ID
	                                                                and up.Addr_No = ud.Addr_No
	                                                            	and upi.Products_ID = pd.Product_ID
																	and up.Purchase_State = cm.Common_Code
	                                                            	and up.user_ID = @id";

                cmd.Parameters.AddWithValue("@id", id);
                list = Helper.DataReaderMapToList<MyPurchaseInfoVO>(cmd.ExecuteReader());
                conn.Close();

                return list;
            }
        }
        #endregion

        #endregion

        #region Update

        #region 비밀번호 변경
        /// <summary>
        /// 새로운 비밀번호로 변경
        /// </summary>
        /// <param name="UserID">회원 ID</param>
        /// <param name="Pwd">입력받은 비밀번호</param>
        /// <returns>초기화에 성공하면 1</returns>
        public bool UpdatePwd(string UserID, string Pwd)
        {

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = @"update User_Info set user_Pwd = @user_Pwd where user_ID = @user_ID";

                cmd.Parameters.AddWithValue("@user_Pwd", Pwd);
                cmd.Parameters.AddWithValue("@user_ID", UserID);

                int iRows = cmd.ExecuteNonQuery();
                if (iRows > 0)
                    return true;
                else
                    return false;
            }
        }
        #endregion

        #region 비밀번호 초기화
        /// <summary>
        /// 입력한 아이디, 이름, 이메일이 맞으면 비밀번호를 초기화
        /// </summary>
        /// <param name="UserID">회원ID</param>
        /// <param name="user_Email">회원Email</param>
        /// <param name="user_Pwd">초기화된 비밀번호</param>
        /// <param name="user_Name">회원이름</param>
        /// <returns>초기화에 성공하면 1</returns>
        public bool UpdatePwd(string UserID,string user_Email, string user_Pwd, string user_Name)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = @"update User_Info set user_Pwd = @user_Pwd 
                where user_ID = @user_ID and user_Email = @user_Email and user_Name = @user_Name";

                cmd.Parameters.AddWithValue("@user_Email", user_Email);
                cmd.Parameters.AddWithValue("@user_Name", user_Name);
                cmd.Parameters.AddWithValue("@user_Pwd", user_Pwd);
                cmd.Parameters.AddWithValue("@user_ID", UserID);

                int iRows = cmd.ExecuteNonQuery();
                if (iRows > 0)
                    return true;
                else
                    return false;
            }
        }
        #endregion

        #region 회원탈퇴
        /// <summary>
        /// 회원탈퇴를 하면 Delete를 Y로 업데이트해줌
        /// </summary>
        /// <param name="UserID">회원 ID</param>
        /// <param name="UserDeleted">탈퇴 여부</param>
        /// <returns>탈퇴에 성공하면 1</returns>
        public bool UserWithdrawal(string UserID, string UserDeleted)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = @"update User_Info set user_Deleted='Y'
                                    where user_ID=@user_ID";

                cmd.Parameters.AddWithValue("@user_ID", UserID);
                cmd.Parameters.AddWithValue("@user_Deleted", UserDeleted);

                int iRows = cmd.ExecuteNonQuery();
                if (iRows > 0)
                    return true;
                else
                    return false;
            }
        }
        #endregion

        #endregion

        #region insert

        #region 회원가입
        /// <summary>
        /// 회원가입 때 입력한 정보 저장
        /// </summary>
        /// <param name="vo">유저정보</param>
        /// <returns> 0보다 클때 return</returns>
        public bool RegisterUser(UserInfoVO vo)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = @"insert into User_Info(user_ID, user_Pwd, user_Name, user_Phone, user_Email, user_RegDate, user_Deleted)
                                                  values (@user_ID, @user_Pwd, @user_Name, @user_Phone, @user_Email, @user_RegDate, @user_Deleted)";

                cmd.Parameters.AddWithValue("@user_ID", vo.user_ID);
                cmd.Parameters.AddWithValue("@user_Pwd", vo.user_Pwd);
                cmd.Parameters.AddWithValue("@user_Name", vo.user_Name);
                cmd.Parameters.AddWithValue("@user_Phone", vo.user_Phone);
                cmd.Parameters.AddWithValue("@user_Email", vo.user_Email);
                cmd.Parameters.AddWithValue("@user_RegDate", vo.user_RegDate);
                cmd.Parameters.AddWithValue("@user_Deleted", vo.user_Deleted);

                int iRowAffect = cmd.ExecuteNonQuery();
                return iRowAffect > 0;
            }
        }
        #endregion

        #region 찜목록 등록
        /// <summary>
        /// 찜목록에 추가하기 ( Detail > 트랜잭션 사용 )
        /// 찜목록 별명을 설정하지 않았을 때는 등록한 날짜로 대체
        /// </summary>
        /// <param name="vo">찜목록 정보</param>
        /// <returns>bool</returns>
        public bool AddWishList(WishListVO vo)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = @"SP_AlreadyWishListCheck";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uid", vo.User_ID);
                cmd.Parameters.AddWithValue("@name", string.IsNullOrEmpty(vo.NickName) ? DBNull.Value : (object)vo.NickName);
                cmd.Parameters.Add("@iden", SqlDbType.Int);
                cmd.Parameters["@iden"].Direction = ParameterDirection.Output;

                SqlTransaction trans = conn.BeginTransaction();
                cmd.Transaction = trans;

                

                try
                {
                    cmd.ExecuteNonQuery();

                    int lastinsertNum = Convert.ToInt32(cmd.Parameters["@iden"].Value);

                    foreach (var item in vo.ItemList)
                    {
                        cmd.Parameters.Clear();

                        cmd.CommandType = CommandType.Text;

                        cmd.CommandText = @"insert into User_Wish_Detail(Wish_No, Product_ID, Wish_Count) 
                                                                                                           values(@no, @prodID, @count);";
                        
                        cmd.Parameters.AddWithValue("@no", lastinsertNum);
                        cmd.Parameters.AddWithValue("@prodID", item.Key);
                        cmd.Parameters.AddWithValue("@count", item.Value);

                        cmd.ExecuteNonQuery();
                    }

                    trans.Commit();
                    conn.Close();
                    return true;
                }
                catch (Exception err)
                {
                    string error = err.Message;
                    trans.Rollback();
                    return false;
                }
            }
        }
        #endregion

        #region 찜목록 장바구니로
        public bool SendCartList(List<MyWishInfoVO> checkList, string uid)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = @"exec SP_AlreadyAddCartCheck @id, @pid, @cnt, @wishno";

                SqlTransaction trans = conn.BeginTransaction();

                cmd.Transaction = trans;

                try
                {
                    foreach (var item in checkList)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@id", uid);
                        cmd.Parameters.AddWithValue("@pid", item.Product_ID);
                        cmd.Parameters.AddWithValue("@cnt", item.Wish_Count);
                        cmd.Parameters.AddWithValue("@wishno", item.Wish_no);
                        cmd.ExecuteNonQuery();
                    }

                    trans.Commit();
                    conn.Close();
                    return true;
                }
                catch (Exception err)
                {
                    string msg = err.Message;
                    trans.Rollback();
                    return false;
                }
            }
        }
        #endregion

        #endregion

        #region Delete

        #region 찜목록 삭제
        public bool DelWishList(List<int> delWishList)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = @"delete from User_Wish_Detail where Wish_No = @no;
                                                            delete from User_WishList where Wish_no = @no;";
                SqlTransaction trans = conn.BeginTransaction();
                cmd.Transaction = trans;

                try
                {
                    for (int i = 0; i < delWishList.Count; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@no", delWishList[i]);
                        cmd.ExecuteNonQuery();
                    }
                    trans.Commit();
                    return true;
                }
                catch
                {
                    trans.Rollback();
                    return false;
                }
            }
        }
        #endregion

        #region 장바구니 삭제
        public bool DelCartList(int cartNum)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = @"delete from User_Cart where Cart_No = @no";
                cmd.Parameters.AddWithValue("@no", cartNum);

                int cnt = cmd.ExecuteNonQuery();

                if (cnt == 1)
                    return true;
                else
                    return false;
            }
        }
        #endregion

        #endregion


        public void Dispose()
        {
            conn.Close();
        }

    }
}
