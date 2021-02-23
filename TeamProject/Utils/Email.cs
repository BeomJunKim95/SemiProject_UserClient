using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject
{
    public class Mail
    {
        private MailAddress sendAddress = null; 
        private MailAddress toAddress = null; // 초기값을 null로
        private string sendPassword = "lee960923";

        public Mail(string sendMail = "dydrkfsladl@gmail.com")
        {
            this.sendAddress = new MailAddress(sendMail);
        }

        #region 메일 주소지정 메서드
        /// <summary>
        /// 메일을 전송할 주소 지정
        /// </summary>
        /// <param name="toMail">입력받은 이메일 주소</param>
        public void SetToAddress(string toMail)
        {
            try
            {
                this.toAddress = new MailAddress(toMail);
            }catch(Exception err)
            {

            }
        }
        #endregion

        #region 메일전송 메서드
        /// <summary>
        /// 메일 네트워크를 사용하여 메일전송
        /// </summary>
        /// <param name="subject">메일 제목</param>
        /// <param name="body">메일로 보낼 내용</param>
        /// <returns></returns>
        public string SendEmail(string subject, string body)
        {
            SmtpClient smtp = null;
            MailMessage message = null;
            try
            {
                smtp = new SmtpClient()
                {
                    Host = "smtp.gmail.com", //smtp.naver.com
                    EnableSsl = true,       //보안서버
                    DeliveryMethod = SmtpDeliveryMethod.Network,        //네트워크사용하여 전송
                    Credentials = new NetworkCredential(sendAddress.Address, sendPassword), //암호기반 인증체계에 자격증명
                    Timeout = 30000         //타입아웃
                };
                message = new MailMessage(sendAddress, toAddress)
                {
                    Subject = subject,      //제목설정
                    Body = body,             //내용설정
                    SubjectEncoding = Encoding.UTF8,
                    BodyEncoding = Encoding.UTF8
                };
                smtp.Send(message);         //보냄
                return "send mail Ok";      //정상적으로 보냈으면
            }
            catch (Exception err)
            {
                return "send nail fail";
            }
            finally
            {
                if (smtp != null) { smtp.Dispose(); }//리소스 해제
                if (message != null) { message.Dispose(); }
            }
        }
        #endregion

    }
}
