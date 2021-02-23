using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using TeamProjectVO;

namespace TeamProject.PopUp
{
	public partial class frmSearchAddr : Form
	{
		int zip;
		string addr1;
		string addr2;

		public int ZipCode { get { return zip; } }
		public string Address1 { get { return addr1; } }
		public string Address2 { get { return addr2; } }

		public frmSearchAddr()
		{
			InitializeComponent();
		}

		#region 이벤트

		private void frmSearchAddr_Load(object sender, EventArgs e)
		{
			#region 데이터그리드뷰 셋팅
			CommonUtil.SetInitGridView(dgv_AddrSearch);

			CommonUtil.AddGridTextColumn(dgv_AddrSearch, "우편번호", "zipNo");
			CommonUtil.AddGridTextColumn(dgv_AddrSearch, "도로명 주소", "roadAddr", 200);
			CommonUtil.AddGridTextColumn(dgv_AddrSearch, "지번 주소", "jibunAddr", 200);
			CommonUtil.AddGridTextColumn(dgv_AddrSearch, "주소2", "roadAddrPart1", 10, false);
			CommonUtil.AddGridTextColumn(dgv_AddrSearch, "주소2", "roadAddrPart2", 10, false);
			#endregion
		}

		private void btn_Search_Click(object sender, EventArgs e)
		{
			SearchAddr(); //검색버튼을 눌렀을때 주소검색 메서드 호출
		}

		private void txt_Search_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 13)
			{
				//엔터를 치면 검색버튼을 눌린거 처럼해라.
				btn_Search.PerformClick();
			}
		}

		private void dgv_AddrSearch_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			zip = Convert.ToInt32(dgv_AddrSearch["zipNo", e.RowIndex].Value);
			addr1 = dgv_AddrSearch["roadAddrPart1", e.RowIndex].Value.ToString();
			addr2 = dgv_AddrSearch["roadAddrPart2", e.RowIndex].Value.ToString();

			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		#endregion

		#region 메서드


		private void SearchAddr()
		{
			UtilEvent.TextBoxIsNotNull(txt_Search, "주소를 입력해주세요.");

			string url = "http://www.juso.go.kr/addrlink/addrLinkApi.do";
			string apiKey = ConfigurationManager.AppSettings["RoadAPIKey"].ToString();

			string apiUrl = $"{url}?confmKey={apiKey}" +
				$"&currentPage=1&countPerPage=1000&keyword={txt_Search.Text.Trim()}";

			WebClient wc = new WebClient();
			XmlReader reader = new XmlTextReader(wc.OpenRead(apiUrl));
			DataSet ds = new DataSet();
			ds.ReadXml(reader);

			if (ds.Tables.Count > 1)
				dgv_AddrSearch.DataSource = ds.Tables[1];
			else
				MessageBox.Show(ds.Tables[0].Rows[0]["errorMessage"].ToString());
		}



		#endregion

		
	}
}
