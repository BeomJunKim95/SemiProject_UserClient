using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeamProjectVO;

namespace TeamProject
{
	public partial class frmLogin : Form
	{
		public frmLogin()
		{
			InitializeComponent();
		}

		private void frmLogin_Load(object sender, EventArgs e)
		{
            #region 텍스트박스 이벤트 설정

            txtID.KeyPress += UtilEvent.tbx_Trim;
			txtID.KeyPress += UtilEvent.isAlphaAndDigit_KeyPress;

			txtPwd.KeyPress += UtilEvent.tbx_Trim;
			txtPwd.KeyPress += UtilEvent.isAlphaAndDigit_KeyPress;

            #endregion
        }

        #region 버튼클릭

        #region 로그인 버튼 클릭
        private void btnLogin_Click(object sender, EventArgs e)
		{
			if (txtID.Text.Trim().Length < 1 || txtPwd.Text.Trim().Length < 1)
			{
				MessageBox.Show("입력한 아이디가 없습니다."); // 유효성체크
				return;
			}

			UserInfoVO emp = new UserInfoVO() 
			{
				user_ID = txtID.Text.Trim(),
				user_Pwd = txtPwd.Text.Trim(),  // 텍스트에 입력한 ID, Pwd를 DB에 연결하기위해 값 저장

			};

			User_Service service = new User_Service(); // service 연결
			UserInfoVO login = service.Login(emp);   // login에 정보 담기


			if (login == null)
			{
				MessageBox.Show("입력한 비밀번호가 맞지않습니다.");
				txtID.Text = "";
				txtPwd.Text = "";
				return;
			}
			if (login.user_Deleted.Trim() =="Y")
			{
				MessageBox.Show("탈퇴된 회원입니다.");   // 탈퇴한 회원인지 확인
				txtID.Text = "";
				txtPwd.Text = "";
				return; 
			}

			GlobalUser.LoginUserInfo = login;   // 글로벌에 있는 유저정보에 추가

			this.DialogResult = DialogResult.OK;
			this.Close();
		}
		#endregion

        #region ID/Pwd찾기 버튼 클릭
        private void btnIDPwdSearch_Click(object sender, EventArgs e)
        {
			frmIDPwdSearch frm = new frmIDPwdSearch();
			frm.ShowDialog();
		}
        #endregion

        #region 회원가입버튼 클릭
        private void btnUserInfo_Click(object sender, EventArgs e)
        {
			frm_User_Sign frm = new frm_User_Sign();
			frm.ShowDialog();
		}
        #endregion

        #region 닫기버튼 클릭
        private void btnClose_Click(object sender, EventArgs e)
        {
			this.Close();
        }
        #endregion

        #endregion

        #region 엔터키 이벤트
        private void frmLogin_KeyDown(object sender, KeyEventArgs e)  
        {
			if (e.KeyCode == Keys.Enter)

			{
				btnLogin_Click(sender, e);  // 엔터키를 누르면 로그인버튼 클릭하게 설정
			}
		}
        #endregion
    }
}
