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

namespace TeamProject.PopUp
{
	public partial class frmAddrInsUp : Form
	{
		public enum OpenMode { Insert, Update } //등록,수정 구분을 위한 열거형 타입
		OpenMode frmMode; //현재 창의 상태를 저장하기 위한 변수

		public AddressVO AddressInfo
		{
			get
			{
				return new AddressVO
				{
					Addr_No = Convert.ToInt32(lbl_Addr_No.Text),
					User_ID = GlobalUser.LoginUserInfo.user_ID,
					Addr_Receiver = txt_Receiver.Text,
					Addr_Phone = string.Join("-", cbo_AddrPhone1.Text, txt_AddrPhone2.Text, txt_AddrPhone3.Text),
					Addr_NickName = txt_NickName.Text,
					Addr = txt_Addr.Text,
					Addr_Detail = txt_Addr_Detail.Text,
					Addr_PostCode = Convert.ToInt32(txt_PostCode.Text),
					Addr_Main = ckb_Main.Tag.ToString()
				};
			}
			set
			{
				lbl_Addr_No.Text = value.Addr_No.ToString();
				txt_Receiver.Text = value.Addr_Receiver;
				string[] phones = value.Addr_Phone.Split('-');
				if (phones.Length == 3)
				{
					cbo_AddrPhone1.Text = phones[0];
					txt_AddrPhone2.Text = phones[1];
					txt_AddrPhone3.Text = phones[2];
				}
				txt_Addr.Text = value.Addr;
				txt_Addr_Detail.Text = value.Addr_Detail;
				txt_PostCode.Text = value.Addr_PostCode.ToString();
				txt_NickName.Text = value.Addr_NickName;
				if (value.Addr_Main == "Y")
				{
					ckb_Main.Checked = true;
				}
				else
				{
					ckb_Main.Checked = false;
				}
			}
		}

		public frmAddrInsUp(OpenMode mode) //등록, 수정 구분을 위한 생성자
		{
			InitializeComponent();

			if (mode == OpenMode.Insert)
			{
				this.Text = "배송지 등록";
				frmMode = OpenMode.Insert;
			}
			else
			{
				this.Text = "배송지 수정";
				frmMode = OpenMode.Update;
			}
		}

		#region 이벤트
		private void btn_SearchAddr_Click(object sender, EventArgs e) //검색버튼
		{
			frmSearchAddr frm = new frmSearchAddr();
			if (frm.ShowDialog() == DialogResult.OK)
			{
				txt_PostCode.Text = frm.ZipCode.ToString();
				txt_Addr.Text = frm.Address1;
				txt_Addr_Detail.Text = frm.Address2;
			}
		}

		private void ckb_Main_CheckedChanged(object sender, EventArgs e) //기본배송지 체크박스
		{
			if (ckb_Main.Checked == true)
			{
				ckb_Main.Tag = "Y";
			}
			else
			{
				ckb_Main.Tag = "N";
			}
		}

		private void btn_OK_Click(object sender, EventArgs e) //확인버튼
		{
			//유효성체크
			StringBuilder sb = new StringBuilder(); //한번에 입력안된 부분을 출력해주기 위한 StringBuilder객체
			if (string.IsNullOrEmpty(txt_Receiver.Text))
				sb.AppendLine("수령인");
			if(string.IsNullOrEmpty(txt_AddrPhone2.Text) || string.IsNullOrEmpty(txt_AddrPhone3.Text))
				sb.AppendLine("연락처");
			if (txt_Addr_Detail.Text == "상세 주소 입력")
				sb.AppendLine("주소");
			if(sb.Length > 0)
			{
				sb.Append("모두 입력해주세요");
				MessageBox.Show(sb.ToString());
				return;
			}

			try
			{
				AddressVO address = AddressInfo; //insert,Update메서드에 넘겨주기위한 주소정보 객체
				Address_Service service = new Address_Service();
				bool bResult;

				if (frmMode == OpenMode.Insert) //등록모드 일때
				{
					bResult = service.InsertAddress(address);
					service.Dispose();
					if (bResult)
					{
						MessageBox.Show("주소 등록이 완료되었습니다.");
						this.DialogResult = DialogResult.OK;
						this.Close();
					}
					else
					{
						MessageBox.Show("주소 등록중 오류가 발생했습니다. 다시 시도해 주세요");
						return;
					}
				}
				else //수정모드 일때
				{
					bResult = service.UpdateAddress(address);
					service.Dispose();
					if (bResult)
					{
						MessageBox.Show("주소 수정이 완료되었습니다.");
						this.DialogResult = DialogResult.OK;
						this.Close();
					}
					else
					{
						MessageBox.Show("주소 수정중 오류가 발생했습니다. 다시 시도해 주세요");
						return;
					}
				}
			}
			catch(Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}

		#endregion

		private void btn_Close_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

        private void frmAddrInsUp_Load(object sender, EventArgs e)
        {
			txt_AddrPhone2.KeyPress += UtilEvent.TextBoxIsDigit;
			txt_AddrPhone3.KeyPress += UtilEvent.TextBoxIsDigit;

        }
    }
}
