using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeamProjectVO;

namespace TeamProject
{
    public partial class frm_User_Sign : Form
    {
        bool Handledresult = true;
        string isMail = null;

        public frm_User_Sign()
        {
            InitializeComponent();
        }

        private void frm_User_Sign_Load(object sender, EventArgs e)
        {
            SetEvent(); // 설정한 이벤트를 호출
            txtUserPhoneHead.SelectedIndex = 1; // 콤보박스의 디폴트를 010으로 설정
        }

        #region 버튼클릭

        #region 회원가입 버튼 클릭
        /// <summary>
        /// 버튼을 클릭하면 입력한 값이 있는지 유효성 검사하고 통과하면 입력한 정보를 DB에 저장
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUserInsert_Click(object sender, EventArgs e)
        {
            // 유효성 체크
            if ((lblIDfail.Visible || lblPwdfail1.Visible || lblPwdfail2.Visible || lbl_Name.Visible || lbl_PhonNumber.Visible || lbl_Mail_chek.Visible))
            {
                MessageBox.Show("옳지 않은 값이 들어간 곳이 있습니다.");
                return;
            }

            // VO 객체생성
            UserInfoVO emp = new UserInfoVO()
            {
                user_ID = txtUserID.Text.Trim(),
                user_Pwd = txtUserPwd.Text.Trim(),
                user_Name = txtUserName.Text.Trim(),
                user_Phone = txtUserPhoneHead.SelectedItem.ToString() + txtUserPhone1.Text.Trim() + txtUserPhone2.Text.Trim(),
                user_Email = txtUserEmail1.Text.Trim() + "@" + txtUserEmail2.Text.Trim(),
                user_RegDate = DateTime.Now,
                user_Deleted = "N"
            };

            User_Service service = new User_Service();
            bool bResult = service.RegisterUser(emp);

            //저장 결과 처리
            if (bResult)
            {
                MessageBox.Show("회원등록이 완료되었습니다.");
                this.Close();
            }
            else
            {
                MessageBox.Show("회원등록에 실패하였습니다.");
                this.Close();
            }
        }
        #endregion

        #region 아이디 중복체크버튼 클릭
        /// <summary>
        /// DB에 입력한 아이디가 있으면 유효성 라벨 보여주고 없으면 유효성통과
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIDCheck_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUserID.Text))
            {
                User_Service service = new User_Service();
                if (service.IDSearch(txtUserID.Text))
                {
                    MessageBox.Show("이미 중복된 아이디가 있습니다");
                    return;
                }
                lblIDfail.Visible = false;
            }
        }
        #endregion

        #region 메일확인 버튼 클릭
        /// <summary>
        /// 랜덤으로 코드를 메일로 발송하고, 메일을 다시 보낼 수 있는 버튼을 생성, 메일 유효성라벨 보여줌
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Mail mail = new Mail();
            if (!(string.IsNullOrEmpty(txtUserEmail1.Text.Trim()) || string.IsNullOrEmpty(txtUserEmail2.Text.Trim())))
            {
                mail.SetToAddress(txtUserEmail1.Text.Trim() + "@" + txtUserEmail2.Text.Trim());
            }
            isMail = CommonUtil.MakingPK();
            MessageBox.Show(mail.SendEmail("회원가입 체크", isMail));
            ((Button)sender).Text = "재전송";
            txt_Mail.Visible = btnCodeCheck.Visible = true;
        }
        #endregion

        #region 코드체크 버튼 클릭
        /// <summary>
        /// 보낸 메일의 내용과 입력한 텍스트가 일치하면 유효성통과
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCodeCheck_Click(object sender, EventArgs e)
        {
            if (isMail == txt_Mail.Text)
            {
                txt_Mail.Visible = btnCodeCheck.Visible = false;
                lbl_Mail_chek.Visible = false;
                btnSendMail.Text = "메일 확인";
            }
        }
        #endregion

        #region 닫기버튼
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #endregion

        #region 텍스트박스, 콤보박스, 유효성라벨에 대한 이벤트
        /// <summary>
        /// 텍스트박스, 콤보박스, 유효성라벨에 대한 이벤트 설정
        /// </summary>
        private void SetEvent()
        {
            txtUserID.KeyPress += UtilEvent.tbx_Trim;
            txtUserID.KeyPress += UtilEvent.isAlphaAndDigit_KeyPress;

            txtUserPwd.KeyPress += UtilEvent.tbx_Trim;
            txtUserPwd.KeyPress += UtilEvent.isAlphaAndDigit_KeyPress;

            txtUserPwd2.KeyPress += UtilEvent.tbx_Trim;
            txtUserPwd2.KeyPress += UtilEvent.isAlphaAndDigit_KeyPress;

            txtUserPhone1.KeyPress += UtilEvent.tbx_Trim;
            txtUserPhone1.KeyPress += UtilEvent.TextBoxIsDigit;
            txtUserPhone2.KeyPress += UtilEvent.tbx_Trim;
            txtUserPhone2.KeyPress += UtilEvent.TextBoxIsDigit;

            txtUserEmail1.KeyPress += UtilEvent.tbx_Trim;
            txtUserEmail1.KeyPress += UtilEvent.isAlphaAndDigit_KeyPress;

            txtUserEmail2.KeyPress += UtilEvent.tbx_Trim;

            txtUserName.KeyPress += UtilEvent.tbx_Trim;
            txtUserName.KeyPress += UtilEvent.isHangul_KeyPress;

            txtUserPwd.TextChanged += tbx_password_Test;

            txtUserPhoneHead.KeyPress += UtilEvent.Handled_KeyPress;

            txtUserEmail2.KeyPress += UtilEvent.Handled_KeyPress;
        }
        #endregion

        #region 유효성라벨, 메일 콤보박스

        #region 아이디 확인 라벨컨트롤
        /// <summary>
        /// 아이디 확인 라벨
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUserID_TextChanged(object sender, EventArgs e)
        {
            if (!lblIDfail.Visible)
            {
                lblIDfail.Visible = true;
            }
        }
        #endregion

        #region 비밀번호 확인 라벨컨트롤
        /// <summary>
        /// 비밀번호 확인라벨
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbx_password_Test(object sender, EventArgs e)
        {
            Regex test = new Regex("(?=.*?[a-zA-Z])(?=.*?[0-9]).{8,}");  // 영어와 숫자를 8자리이상부터 Maxlength까지
            if (test.IsMatch(((TextBox)sender).Text.Trim()))
            {
                lblPwdfail1.Visible = false;
            }
            else
            {
                lblPwdfail1.Visible = true;
            }
            if (!lblPwdfail2.Visible)
            {
                lblPwdfail2.Visible = true;
            }
        }
        #endregion

        #region 비밀번호 확인2 라벨컨트롤
        /// <summary>
        /// 입력한 비밀번호와 맞지 않으면 유효성라벨 보여줌
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUserPwd2_TextChanged(object sender, EventArgs e)
        {
            if (txtUserPwd.Text.Trim() == txtUserPwd2.Text.Trim())
            {
                lblPwdfail2.Visible = false;
            }
            else
            {
                lblPwdfail2.Visible = true;
            }
        }
        #endregion

        #region 이름 유효성라벨 컨트롤
        /// <summary>
        /// 이름을 입력하면 유효성 라벨을 없애주고 아니면 보여줌
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                lbl_Name.Visible = true;
            }
            else
            {
                lbl_Name.Visible = false;
            }
        }
        #endregion

        #region 전화번호 유효성라벨 컨트롤
        /// <summary>
        /// 전화번호를 입력하면 유효성라벨을 없애주고, 아니면 보여줌
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUserPhone1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserPhone1.Text) || string.IsNullOrWhiteSpace(txtUserPhone2.Text))
            {
                lbl_PhonNumber.Visible = true;
            }
            else
            {
                lbl_PhonNumber.Visible = false;
            }
        }
        #endregion

        #region 메일 유효성라벨 컨트롤
        /// <summary>
        /// 메일입력받는 칸의 텍스트가 변경되면 유효성라벨 보여줌
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUserEmail1_TextChanged(object sender, EventArgs e)
        {
            if (!lbl_Mail_chek.Visible)
            {
                lbl_Mail_chek.Visible = true;
            }
        }
        #endregion

        #region 메일 콤보박스 컨트롤
        /// <summary>
        /// 콤보박스에 아이템이 선택되면 메일2 텍스트에 써줌
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!lbl_Mail_chek.Visible)
            {
                lbl_Mail_chek.Visible = true;
            }
            if (comboBox2.SelectedItem.ToString() != "직접입력")
            {
                txtUserEmail2.Text = comboBox2.SelectedItem.ToString();
                if (!Handledresult)
                {
                    txtUserEmail2.KeyPress += UtilEvent.Handled_KeyPress;
                    Handledresult = true;
                }
            }
            else
            {
                if (Handledresult)
                {
                    txtUserEmail2.Text = "";
                    Handledresult = false;
                    txtUserEmail2.KeyPress -= UtilEvent.Handled_KeyPress;
                }
            }
        }
        #endregion

        #endregion


    }
}
