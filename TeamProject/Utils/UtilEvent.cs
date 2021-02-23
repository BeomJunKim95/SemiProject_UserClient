using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeamProject
{
    public static class UtilEvent
    {
        #region TextBoxKeyPressEvent

        #region 숫자 입력
        /// <summary>
        /// 숫자만 입력 가능하게 해줌
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void TextBoxIsDigit(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == '\b'))
            {
                e.Handled = true;
            }
        }
        #endregion

        #region 숫자 입력 불가능
        /// <summary>
        /// 숫자입력을 불가능하게 해줌
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">숫자</param>
        public static void TextBoxNoIsDigit(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar)) 
            {
                e.Handled = true;
            }
        }
        #endregion

        #region 공백 입력 불가
        /// <summary>
        /// 공백입력을 불가능하게 해줌
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">공백</param>
        public static void tbx_Trim(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ') // 공백입력
            {
                e.Handled = true;
            }
        }
        #endregion

        #region 한글 입력
        /// <summary>
        /// 한글만 입력 가능하게 해줌
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">한글</param>
        public static void isHangul_KeyPress(object sender, KeyPressEventArgs e)
        {
            string a = e.KeyChar.ToString();
            Regex regex = new Regex("[ㄱ-ㅎ가-힣]"); // 정규식을 한글로
            if (!(regex.IsMatch(a) || e.KeyChar == 8 || e.KeyChar == ' ')) // 정규식, BackSpace(e.KeyChar == 8), 공백
            {
                e.Handled = true;
            }
        }
        #endregion

        #region 영어 입력
        /// <summary>
        /// 영어 + 숫자만 입력가능하게 해줌
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">영어</param>
        public static void isAlpha_KeyPress(object sender, KeyPressEventArgs e)
        {
            string a = e.KeyChar.ToString();
            Regex regex = new Regex(@"[a-zA-Z]"); // 정규식을 영어로
            if (!(regex.IsMatch(a) || e.KeyChar == 8 || e.KeyChar == ' ')) // 정규식, BackSpace(e.KeyChar == 8), 공백 
            {
                e.Handled = true;
            }
        }
        #endregion

        #region 영어 + 숫자입력
        /// <summary>
        /// 영어 + 숫자만 입력가능하게 해줌
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">영어 + 숫자</param>
        public static void isAlphaAndDigit_KeyPress(object sender, KeyPressEventArgs e)
        {
            string a = e.KeyChar.ToString(); // 눌린 키를 a에 담고
            Regex regex = new Regex(@"[a-zA-Z0-9]"); // 정규식을 영어와 숫자로
            if (!(regex.IsMatch(a) || e.KeyChar == 8 || e.KeyChar == ' '))  // 정규식, BackSpace(e.KeyChar == 8), 공백 
            {
                e.Handled = true;
            }
        }
        #endregion

        #region 모든 입력 불가능
        /// <summary>
        /// 모든 키의 입력을 불가능하게 해줌
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">모든키</param>
        public static void Handled_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true; // 키 이벤트가 처리됐다는 뜻, 
        }
        #endregion

        #region 비밀번호 확인
        /// <summary>
        /// 비밀번호 확인 메서드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void tbx_password_Test(object sender, EventArgs e)
        {
            Regex test1 = new Regex("(?=.*?[a-zA-Z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}"); // 최소 8자리부터 영어, 숫자, 특수문자 중에서만 사용
            Regex test2 = new Regex("(?=.*?[a-zA-Z])(?=.*?[0-9]).{8,}");
            if (test1.IsMatch(""))
            {

            }
            else if (test2.IsMatch(""))
            {

            }
            else
            {

            }
        }
        #endregion

        #endregion

        #region 텍스트박스
        /// <summary>
        /// 텍스트박스에 아무것도 입력받지 않았을때 
        /// </summary>
        /// <param name="txt">텍스트박스 컨트롤명</param>
        /// <param name="msg">메세지박스에 출력할 문자열</param>
        public static void TextBoxIsNotNull(TextBox txt, string msg)
		{
			if (string.IsNullOrEmpty(txt.Text.Trim()))
			{
                MessageBox.Show(msg);
                return;
			}
		}
        #endregion
    }
}
