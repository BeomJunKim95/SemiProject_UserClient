using TeamProjectVO;
using TeamProjectDAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject
{
    class User_Service
    {

        #region 회원가입 메서드 연결
        /// <summary>
        /// 회원가입 메서드
        /// </summary>
        /// <param name="vo">입력받은 ID, 비밀번호, 이름, 전화번호, 이메일</param>
        /// <returns>회원가입에 성공하면 1</returns>
        public bool RegisterUser(UserInfoVO vo)
        {
            User_DAC dac = new User_DAC();
            return dac.RegisterUser(vo);
        }
        #endregion

        #region 로그인 메서드 연결
        /// <summary>
        /// 로그인 메서드
        /// </summary>
        /// <param name="vo">입력한 ID, 비밀번호</param>
        /// <returns>회원 정보</returns>
        public UserInfoVO Login(UserInfoVO vo)
        {
            User_DAC dac = new User_DAC();
            return dac.Login(vo);
        }
        #endregion

        #region 회원가입 폼에서 ID 중복확인 메서드 연결
        /// <summary>
        /// ID찾기 메서드 연결
        /// </summary>
        /// <param name="vo">입력한 ID</param>
        /// <returns>등록된 ID가 있으면 1</returns>
        public bool IDSearch(string user_ID)
        {
            User_DAC dac = new User_DAC();
            bool result = dac.IDSearch(user_ID);
            dac.Dispose();
            return result;
        }
        #endregion

        #region ID 찾기폼에서 ID 찾기 메서드 연결
        /// <summary>
        /// ID 찾기 메서드
        /// </summary>
        /// <param name="vo">입력한 이름, 이메일</param>
        /// <returns>등록된 회원ID</returns>
        public string GetID(UserInfoVO vo)
        {
            User_DAC dac = new User_DAC();
            string result = dac.GetID(vo);
            dac.Dispose();
            return result;
        }
        #endregion

        #region 내정보폼에서 비밀번호 초기화 메서드 연결
        /// <summary>
        /// 비밀번호 초기화 메서드 연결
        /// </summary>
        /// <param name="UserID">회원 ID</param>
        /// <param name="Pwd">입력받은 비밀번호</param>
        /// <returns>초기화에 성공하면 1</returns>
        public bool UpdatePwd(string UserID, string Pwd)
        {
            User_DAC dac = new User_DAC();
            bool result = dac.UpdatePwd(UserID, Pwd);
            dac.Dispose();
            return result;
        }
        #endregion

        #region 비밀번호 찾기폼에서 비밀번호 초기화 메서드 연결
        /// <summary>
        /// 비밀번호 초기화해서 메일로 보내주는 메서드에 연결
        /// </summary>
        /// <param name="UserID">입력받은 ID</param>
        /// <param name="UserEmail">입력받은 이메일</param>
        /// <param name="Pwd">초기화된 비밀번호</param>
        /// <param name="UserName">입력받은 이름</param>
        /// <returns></returns>
        public bool UpdatePwd(string UserID, string UserEmail, string Pwd,string UserName)
        {
            User_DAC dac = new User_DAC();
            bool result = dac.UpdatePwd(UserID, UserEmail, Pwd, UserName);
            dac.Dispose();
            return result;
        }
        #endregion

        #region 회원탈퇴 메서드 연결
        /// <summary>
        /// 회원탈퇴 메서드
        /// </summary>
        /// <param name="UserID">회원ID</param>
        /// <param name="UserDeleted">삭제여부</param>
        /// <returns>탈퇴를 성공하면 1</returns>
        public bool UserWithdrawal(string UserID, string UserDeleted)
        {
            User_DAC dac = new User_DAC();
            bool result = dac.UserWithdrawal(UserID, UserDeleted);
            dac.Dispose();
            return result;
        }
        #endregion


        public bool AddWishList(WishListVO vo)
        {
            User_DAC dac = new User_DAC();
            return dac.AddWishList(vo);
        }

        public List<MyWishInfoVO> GetAllMyWishList(string id)
        {
            User_DAC dac = new User_DAC();
            return dac.GetAllMyWishList(id);
        }

        public List<MyCartListVO> GetAllMyCartList(string id)
        {
            User_DAC dac = new User_DAC();
            return dac.GetAllMyCartList(id);
        }

        internal bool SendCartList(List<MyWishInfoVO> checkList, string uid)
        {
            User_DAC dac = new User_DAC();
            return dac.SendCartList(checkList, uid);
        }

        public List<MyPurchaseInfoVO> GetMyPurchaseList(string id)
        {
            User_DAC dac = new User_DAC();
            return dac.GetMyPurchaseList(id);
        }
        internal bool DelCartList(int cartNum)
        {
            User_DAC dac = new User_DAC();
            return dac.DelCartList(cartNum);
        }

        internal bool PurchaseSave(string user_ID, int addrNo, List<MyCartListVO> list)
        {
            User_DAC dac = new User_DAC();
            bool result = dac.PurchaseSave(user_ID, addrNo, list);
            dac.Dispose();
            return result;
        }

        internal bool DelWishList(List<int> delWishList)
        {
            User_DAC dac = new User_DAC();
            bool result = dac.DelWishList(delWishList);
            dac.Dispose();
            return result;
        }

        internal bool PurchaseSave(AddressVO2 addrInfo, List<MyCartListVO> list)
        {
            User_DAC dac = new User_DAC();
            bool result = dac.PurchaseSave(addrInfo, list);
            dac.Dispose();
            return result;
        }
    }
}
