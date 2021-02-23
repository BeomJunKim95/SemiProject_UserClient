using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeamProject
{
    public class CommonUtil
    {

        #region 콤보박스 바인딩해주는 메서드
        /// <summary>
        /// 콤보박스에 선택된 항목과 관련된 정보를 보여줌
        /// </summary>
        /// <param name="cbo"></param>
        /// <param name="dt"></param>
        /// <param name="valueMember"></param>
        /// <param name="displayMember"></param>
        /// <param name="blankItemAdd"></param>
        public static void BindingComboBox(ComboBox cbo, DataTable dt, string valueMember, string displayMember, bool blankItemAdd = true)
        {
            if (blankItemAdd) // 아이템 추가를 막는거? 가 있으면
            {
                DataRow dr = dt.NewRow(); // 새로운 로우 추가
                dr[valueMember] = ""; // 초기화
                dr[displayMember] = ""; // 초기화 
                dt.Rows.InsertAt(dr, 0); // 로우에 추가
                dt.AcceptChanges(); // 커밋
            }

            cbo.ValueMember = valueMember; // 콤보박스에 값 속성 설정
            cbo.DisplayMember = displayMember; // 콤보박스 표시 속성 설정
            cbo.DataSource = dt; // 콤보박스에 값 저장
        }
        #endregion

        #region 데이터그리드뷰를 설정해주는 메서드
        /// <summary>
        /// 데이터그리드뷰 설정
        /// </summary>
        /// <param name="dgv"></param>
        public static void SetInitGridView(DataGridView dgv)
        {
            dgv.AutoGenerateColumns = false; // 열 추가를 할 수 없게 설정
            dgv.AllowUserToAddRows = false; // 행 추가를 할 수 없게 설정
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // 데이터그리드뷰 행의 아무 곳 이나 클릭해도 자동으로 전체 행을 선택할 수 있도록 설정
        }
        #endregion

        #region 데이터그리드뷰에 텍스트 박스 셀을 추가할때 설정 
        /// <summary>
        /// 데이터그리드뷰에 텍스트 박스 셀을 추가
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="headerText"></param>
        /// <param name="dataPropertyName"></param>
        /// <param name="colWidth"></param>
        /// <param name="visibility"></param>
        /// <param name="textAlign"></param>
        public static void AddGridTextColumn(
                            DataGridView dgv,
                            string headerText,
                            string dataPropertyName,
                            int colWidth = 100,
                            bool visibility = true,
                            DataGridViewContentAlignment textAlign = DataGridViewContentAlignment.MiddleLeft)
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.Name = dataPropertyName; // 텍스트박스 컬럼 열의 이름 설정
            col.HeaderText = headerText; // 텍스트박스 컬럼 열의 머리글 설정
            col.DataPropertyName = dataPropertyName; // 텍스트 박스의 데이터원본 프로퍼티 설정
            col.Width = colWidth; // 텍스트 박스의 너비 설정
            col.DefaultCellStyle.Alignment = textAlign; // 택스트 박스 컬럼 열의 텍스트 정렬조건 설정
            col.Visible = visibility; // Visible을 true로 설정
            col.ReadOnly = true; // 읽을수만 있게 설정

            dgv.Columns.Add(col); // 데이터그리드뷰에 저장
        }
        #endregion

        #region 데이터그리드뷰에 체크 박스 셀을 추가해주는 메서드
        /// <summary>
        /// 데이터그리드뷰에 체크 박스 셀을 추가
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="headerText"></param>
        /// <param name="dataPropertyName"></param>
        /// <param name="colWidth"></param>
        /// <param name="visibility"></param>
        /// <param name="textAlign"></param>
        public static void AddGridCheckColumn(
                                DataGridView dgv,
                                string headerText,
                                string dataPropertyName,
                                int colWidth = 100,
                                bool visibility = true,
                                DataGridViewContentAlignment textAlign = DataGridViewContentAlignment.MiddleLeft)
        {
            DataGridViewCheckBoxColumn col = new DataGridViewCheckBoxColumn();
            col.Name = dataPropertyName; // 체크박스 컬럼 열의 이름 설정
            col.HeaderText = headerText; // 체크박스 컬럼 열의 머리글 설정 
            col.Width = colWidth; // 체크박스의 컬럼 열의 너비 설정
            col.DefaultCellStyle.Alignment = textAlign; // 체크박스의 컬럼 열의 텍스트 정렬조건 설정
            col.Visible = visibility; // Visible을 true로 설정
            dgv.Columns.Add(col); // 데이터그리드뷰에 추가
        }
        #endregion

        #region 데이터그리드뷰에 이미지 셀을 추가해주는 메서드
        /// <summary>
        /// 데이터그리드뷰에 이미지 셀을 추가
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="headerText"></param>
        /// <param name="dataPropertyName"></param>
        /// <param name="colWidth"></param>
        /// <param name="visibility"></param>
        /// <param name="textAlign"></param>
        public static void AddGridImageColumn(
                                DataGridView dgv,
                                string headerText,
                                string dataPropertyName,
                                int colWidth = 100,
                                bool visibility = true,
                                DataGridViewContentAlignment textAlign = DataGridViewContentAlignment.MiddleLeft)
        {
            DataGridViewImageColumn col = new DataGridViewImageColumn();
            col.Name = dataPropertyName; // 이미지 열의 이름 설정
            col.HeaderText = headerText; // 이미지 머리글 설정
            col.ImageLayout = DataGridViewImageCellLayout.Stretch; // 이미지의 레이아웃을 너비에 맞게 증가
            col.DataPropertyName = dataPropertyName; // 이미지 데이터원본 프로퍼티 설정
            col.Visible = visibility; // Visible을 true로
            dgv.Columns.Add(col); // 데이터그리드뷰에 저장
        }
        #endregion

        #region 웹에 있는 이미지를 읽어서 저장하는 메서드
        /// <summary>
        /// 웹에 있는 이미지를 읽어서 저장해줌
        /// </summary>
        /// <param name="URL">웹주소</param>
        /// <returns></returns>
        public static Bitmap WebImageView(string URL)
        {
            try
            {
                WebClient Downloader = new WebClient(); // 웹클라이언트를 new해주고
                Stream ImageStream = Downloader.OpenRead(URL); // 웹 URL을 읽어서 저장
                Bitmap DownloadImage = Bitmap.FromStream(ImageStream) as Bitmap; // URL에 있는 이미지를 Bitmap 타입으로 이미지 저장
                return DownloadImage; // 
            }
            catch (Exception e) 
            {
                Debug.WriteLine(e.Message); // 디버그창에 오류메세지 출력
                return null;
            }

        }
        #endregion

        public static List<R> ControlFunc<T, R, Covert>(T pnl, Func<Covert, R> func) where T : Control where Covert : Control
        {
            List<R> r = new List<R>();
            foreach (Control ctrl in pnl.Controls)
            {
                if(ctrl is Covert temp)
                    r.Add(func(temp));
            }
            return r;
        }

        public static void ControlAction<T, Covert>(T pnl, Action<Covert> Action) where T : Control where Covert : Control
        {
            foreach (Control ctrl in pnl.Controls)
            {
                if (ctrl is Covert temp)
                    Action(temp);
            }
        }

        public static string ConvertToIntFromPrice(int price)
        {
            NumberFormatInfo NF = new CultureInfo("ko-KR", false).NumberFormat;
            return price.ToString("C", NF);
        }

        #region Mdi를 설정하지 않고 입력받은 폼을 열어주는 메서드
        /// <summary>
        /// Mdi를 설정하지 않고 입력받은 폼을 열어줌
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static void OpenCreateForm<T>() where T : Form, new()
        {
            foreach (Form form in Application.OpenForms) // 열려있는 폼들중에 하나를 꺼냄
            {
                if (form.GetType() == typeof(T)) // form의 타입이 열려고하는거랑 타입이 같은지
                {
                    form.Activate(); // 폼 활성화
                    return;
                }
            }

            T frm = new T();
            frm.Show(); // 폼 열기
        }
        #endregion

        #region 입력받은 Func으로 폼여는 메서드 ( 수정해야됨 )
        /// <summary>
        /// 입력받은 Func으로 폼열기
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func"></param>
        public static void OpenCreateForm<T>(Func<T> func) where T : Form, new()
        {
            foreach (Form form in Application.OpenForms) // 열려있는 폼들중에 하나를 꺼냄
            {
                if (form.GetType() == typeof(T)) // form의 타입이 열려고하는거랑 타입이 같은지
                {
                    form.Activate(); // 폼 활성화
                    return;
                }
            }
            T frm = func();
            frm.Show(); // 폼 열기
        }
        #endregion

        #region 비밀번호 초기화 메서드
        /// <summary>
        /// 비밀번호 초기화값 설정
        /// </summary>
        /// <returns></returns>
        public static string MakingPK()        //앞 4글자 난수 + 뒤 6글자 분,초,밀리세컨드 합쳐서 PK  만드는 함수
        {
            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();
            for (int i = 0; i < 4; i++)
            {
                int num = rnd.Next(0, 36);
                if (num < 10)
                {
                    sb.Append(num); // 숫자 한자리수 까지는 문자열에 더함
                }
                else
                    sb.Append((char)(num + 55)); // 숫자가 두자리수가 되면 문자로 바꿔서 문자열에 더함

            }
            sb.Append(DateTime.Now.ToString("mmssff"));
            return sb.ToString();
        }
        #endregion

        #region 이미지타입을 바이트타입으로 변환하는 메서드
        /// <summary>
        /// 이미지를 바이트타입으로 형변환해줌
        /// </summary>
        /// <param name="img">이미지타입</param>
        /// <returns>이미지값</returns>
        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter(); // 이미지를 바이트로 형변환 하기위해 converter 생성
            return (byte[])converter.ConvertTo(img, typeof(byte[])); // 이미지를 바이트타입으로 형변환
        }
        #endregion

        #region 바이트타입을 이미지타입으로 형변환해주는 메서드
        /// <summary>
        /// 바이트타입의 이미지를 이미지타입으로 형변환해줌
        /// </summary>
        /// <param name="data">바이트타입</param>
        /// <returns>이미지값</returns>
        public static Image ByteToImage(byte[] data)
        {
            TypeConverter tc = TypeDescriptor.GetConverter(typeof(Bitmap)); // 형변환을 하기위한 tc 생성
            return (Bitmap)(tc.ConvertFrom(data)); // 바이트타입 데이터를 이미지타입으로 형변환
        }
        #endregion
    }
}

