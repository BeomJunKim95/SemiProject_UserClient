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
	public partial class frmIDPwdSearch : Form
	{
		public frmIDPwdSearch()
		{
			InitializeComponent();
		}

        private void frmIDPwdSearch_Load(object sender, EventArgs e)
        {
            rbtn_ID.Checked = true;

            #region 텍스트 이벤트 설정

            txt_UserName1.KeyPress += UtilEvent.tbx_Trim;
            txt_UserName1.KeyPress += UtilEvent.isHangul_KeyPress;

            txt_UserName2.KeyPress += UtilEvent.tbx_Trim;
            txt_UserName2.KeyPress += UtilEvent.isHangul_KeyPress;


            txtUserID.KeyPress += UtilEvent.tbx_Trim;
            txtUserID.KeyPress += UtilEvent.isAlphaAndDigit_KeyPress;

            txtUserEmail1.KeyPress += UtilEvent.tbx_Trim;
            txtUserEmail1.KeyPress += UtilEvent.isAlphaAndDigit_KeyPress;
            txtUserEmail2.KeyPress += UtilEvent.tbx_Trim;
            txtUserEmail2.KeyPress += UtilEvent.isAlphaAndDigit_KeyPress;
            txtUserEmail3.KeyPress += UtilEvent.tbx_Trim;
            txtUserEmail3.KeyPress += UtilEvent.isAlphaAndDigit_KeyPress;
            txtUserEmail4.KeyPress += UtilEvent.tbx_Trim;
            txtUserEmail4.KeyPress += UtilEvent.isAlphaAndDigit_KeyPress;

            #endregion
        }

        #region 버튼 클릭

        #region ID찾기 버튼 클릭
        /// <summary>
        /// 입력한 이름과 이메일이 등록된 아이디를 이메일로 보내줌
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIDSearch_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txt_UserName1.Text) || string.IsNullOrEmpty(txtUserEmail1.Text) || string.IsNullOrWhiteSpace(comboBox3.Text))
            {
                return;
            }

            UserInfoVO vo = new UserInfoVO { user_Name = txt_UserName1.Text, user_Email = txtUserEmail1.Text + "@" + comboBox3.Text }; // 입력한 이름, 이메일을 vo에 저장
            User_Service service = new User_Service();
            string UserID = service.GetID(vo);  // 입력된 이름과, 이메일이 일치하는 회원의 아이디를 검색해서 UserID에 저장

            if (string.IsNullOrEmpty(UserID))
            {
                MessageBox.Show("검색된 아이디가 없습니다.");
                return;
            }

            Mail mail = new Mail();
            mail.SetToAddress(vo.user_Email); // 메일을 전송받을 주소 설정
            MessageBox.Show(mail.SendEmail("아이디 확인", UserID)); // 검색된 ID를 메일로 전송

        }
        #endregion

        #region 비밀번호 찾기 버튼 클릭
        /// <summary>
        /// 입력한 ID, 이름, 이메일이 등록된 아이디에 대한 비밀번호를 초기화하고 초기화된 비밀번호르 이메일로 발송시켜줌
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_UserName2.Text) || string.IsNullOrEmpty(txtUserEmail3.Text) || string.IsNullOrWhiteSpace(comboBox4.Text) || string.IsNullOrEmpty(txtUserID.Text))
            {
                return;
            }
            string newPwd = CommonUtil.MakingPK(); // 초기화할 비밀번호 저장
            UserInfoVO vo = new UserInfoVO { user_Name = txt_UserName2.Text, user_Email = txtUserEmail3.Text + "@" + comboBox4.Text, user_ID = txtUserID.Text , user_Pwd = newPwd}; // 입력한 ID,이메일,아이디, 초기화할 비밀번호를 vo에 저장
            User_Service service = new User_Service(); // 서비스 접근
            bool UserID = service.UpdatePwd(vo.user_ID, vo.user_Email, vo.user_Pwd, vo.user_Name); // 비밀번호를 업데이트하고 성공했으면 ture 실패면 false

            if (!UserID)
            {
                MessageBox.Show("비밀번호 초기화 실패");
                return;
            }
            Mail mail = new Mail();
            mail.SetToAddress(vo.user_Email); // 메일을 전송받을 주소 설정
            MessageBox.Show(mail.SendEmail("비밀번호 초기화 값 확인", newPwd)); // 초기화된 이메일을 입력한 이메일로 전송
        }
        #endregion

        #region ID찾기 닫기 버튼

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Pwd찾기 닫기 버튼

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #endregion

        #region 이벤트

        #region 라디오버튼 이벤트
        private void RadioBtnChecked(object sender, EventArgs e)
        {
            if (((Control)sender).Tag.ToString() == "ID") // 컨트롤의 태그가 ID이면 ID찾기 페널 보여주고 아니면 Pwd찾기 페널 보여줌
            {
                pnl_ID.Visible = true;
                pnl_Pwd.Visible = false;
            }
            else
            {
                pnl_Pwd.Visible = true;
                pnl_ID.Visible = false;
            }
        }
        #endregion

        #region ID찾기 이메일 콤보박스 이벤트

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 직접입력이 아닌 아이템 선택시 텍스트로 연동
            if(comboBox3.SelectedItem.ToString() != "직접입력")
                txtUserEmail2.Text = comboBox3.SelectedItem.ToString();
        }

        #endregion

        #region Pwd찾기 이메일 콤보박스 이벤트

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 직접입력이 아닌 아이템 선택시 텍스트로 연동
            if (comboBox4.SelectedItem.ToString() != "직접입력")
                txtUserEmail4.Text = comboBox4.SelectedItem.ToString();
        }

        #endregion

        #endregion

    }
}
