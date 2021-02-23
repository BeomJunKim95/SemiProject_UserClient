using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeamProject.PopUp;
using TeamProjectVO;

namespace TeamProject
{
	public partial class frmPurchase : Form
	{


		public List<MyCartListVO> list;
		List<AddressVO> mainAddr;

		public frmPurchase()
		{
			InitializeComponent();
		}

        public frmPurchase(List<MyCartListVO> info)
        {
			InitializeComponent();
			list = info;
        }

		private void frmPurchase_Load(object sender, EventArgs e)
		{
			cbo_Phone1.DropDownStyle = ComboBoxStyle.DropDownList;

			ShowPurchaseList();
			GetMainAddr(GlobalUser.LoginUserInfo.user_ID);

			int total = 0;
			CommonUtil.ControlAction<Panel, UC_PurchaseProductList>(pnl_ItemList, (item) =>
			{
				total += item.TotalPrice;
			});

			lbl_Total.Text = total.ToString();
		}

		private void ShowPurchaseList()
        {
			for (int i = 0; i < list.Count; i++)
			{
				UC_PurchaseProductList pinfo = new UC_PurchaseProductList
				{
					MyOrderInfo = list[i],
					Size = new Size(730, 110),
					Location = new Point(2, 2 + (110 * i)),
					Name = i.ToString()
				};

				pnl_ItemList.Controls.Add(pinfo);
            }
        }



		#region 주소 부분

		#region 이벤트

		private void btn_AddrList_Click(object sender, EventArgs e) // 배송지목록 버튼
		{
			// 배송지 목록폼에서 선택한 주소정보 가져와서 보여주기
			frmAddrList frm = new frmAddrList();
			if(frm.ShowDialog() == DialogResult.OK)
			{
				lbl_AddrNo.Text = frm.AddressInfo.Addr_No.ToString();
				lbl_UserID.Text = frm.AddressInfo.User_ID;
				txt_Receiver.Text = frm.AddressInfo.Addr_Receiver;
				string[] phones = frm.AddressInfo.Addr_Phone.Split('-');
				if (phones.Length == 3)
				{
					cbo_Phone1.Text = phones[0];
					txt_Phone2.Text = phones[1];
					txt_Phone3.Text = phones[2];
				}
				txt_NickName.Text = frm.AddressInfo.Addr_NickName;
				txt_PostCode.Text = frm.AddressInfo.Addr_PostCode.ToString();
				txt_Addr.Text = frm.AddressInfo.Addr;
				txt_AddrDetail.Text = frm.AddressInfo.Addr_Detail;
			}

		}

		private void btn_SearchAddr_Click(object sender, EventArgs e) // 주소찾기 버튼
		{
			frmSearchAddr frm = new frmSearchAddr();
			if (frm.ShowDialog() == DialogResult.OK)
			{
				txt_PostCode.Text = frm.ZipCode.ToString();
				txt_Addr.Text = frm.Address1;
				txt_AddrDetail.Text = frm.Address2;
			}
		}

		private void rdb_CheckedChanged(object sender, EventArgs e) // 배송지 선택 라디오 버튼 눌렀을 때 이벤트
		{
			if (rdb_MainAddr.Checked)
			//기본배송지를 선택하면 DB에 기본배송지로 설정한 주소 정보를 가져오고 주소를 수정할 필요가 없는 부분은 Enable = false
			{
				txt_NickName.Enabled = false;
				txt_PostCode.Enabled = false;
				txt_Addr.Enabled = false;
				txt_AddrDetail.Enabled = false;
				btn_SearchAddr.Enabled = false;
				txt_Receiver.Enabled = false;
				txt_Phone2.Enabled = false;
				txt_Phone3.Enabled = false;
				btn_AddrList.Enabled = true;

				GetMainAddr(GlobalUser.LoginUserInfo.user_ID);
			}
			else // 새로 등록을 선택하면 직접 수정해야하니 반대로
			{
				txt_Receiver.Enabled = true;
				txt_NickName.Enabled = true;
				txt_PostCode.Enabled = true;
				txt_Addr.Enabled = true;
				txt_AddrDetail.Enabled = true;
				btn_SearchAddr.Enabled = true;
				txt_Phone2.Enabled = true;
				txt_Phone3.Enabled = true;
				btn_AddrList.Enabled = false;
				txt_NickName.Text = "";
				lbl_AddrNo.Text = "";
				txt_PostCode.Text = "우편 번호";
				txt_Addr.Text = "기본 주소";
				txt_AddrDetail.Text = "상세주소 입력";
				txt_Receiver.Text = "";
				cbo_Phone1.Text = "010";
				txt_Phone2.Text = "";
				txt_Phone3.Text = "";

			}
		}
		#endregion

		#endregion

		#region 메서드
		private void GetMainAddr(string userID)
		{
			Address_Service service = new Address_Service();
			mainAddr = service.GetMainAddress(userID);
			service.Dispose();

			mainAddr.ForEach((e) => lbl_AddrNo.Text = e.Addr_No.ToString());
			mainAddr.ForEach((e) => txt_Receiver.Text = e.Addr_Receiver);
			string[] phones = new string[3];
			mainAddr.ForEach((e) => phones = e.Addr_Phone.Split('-'));
			if (phones.Length == 3)
			{
				cbo_Phone1.Text = phones[0];
				txt_Phone2.Text = phones[1];
				txt_Phone3.Text = phones[2];
			}
			mainAddr.ForEach((e) => txt_NickName.Text = e.Addr_NickName);
			mainAddr.ForEach((e) => txt_Addr.Text = e.Addr);
			mainAddr.ForEach((e) => txt_AddrDetail.Text = e.Addr_Detail);
			mainAddr.ForEach((e) => txt_PostCode.Text = e.Addr_PostCode.ToString());
		}

        #endregion

        private void btn_Cancle_Click(object sender, EventArgs e)
        {
			this.Close();
        }

        private void btn_Purchase_Click(object sender, EventArgs e)
        {
			User_Service service = new User_Service();
			bool result = false;
			if (lbl_AddrNo.Text.Length > 0)
				 result = service.PurchaseSave(GlobalUser.LoginUserInfo.user_ID, int.Parse(lbl_AddrNo.Text), list);
			else
            {
				AddressVO2 addrInfo = new AddressVO2
				{
					User_ID = GlobalUser.LoginUserInfo.user_ID,
					Addr_No = int.Parse(txt_PostCode.Text),
					Addr_PostCode = int.Parse(txt_PostCode.Text), 
					Addr = txt_Addr.Text,
					Addr_Detail = txt_AddrDetail.Text,
					Addr_NickName = txt_NickName.Text,
					Addr_Phone = cbo_Phone1.Text + "-" + txt_Phone2.Text + "-" + txt_Phone3.Text, 
					Addr_Receiver = txt_Receiver.Text
				};

				result = service.PurchaseSave(addrInfo, list);

            }

			if(result)
            {
				this.DialogResult = DialogResult.OK;
				this.Close();
            }
			else
            {
                MessageBox.Show("거래신청중 오류가 발생했거나 물품의 갯수가 부족합니다.");
            }

        }
    }
}
