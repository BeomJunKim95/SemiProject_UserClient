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
	public partial class frmAddrList : Form
	{
		List<AddressVO> allList;

		public AddressVO AddressInfo { get; set; }
		

		public frmAddrList()
		{
			InitializeComponent();
		}

		private void frmAddrList_Load(object sender, EventArgs e)
		{
			#region 데이터그리드뷰
			CommonUtil.SetInitGridView(dgv_AddrList);
			CommonUtil.AddGridCheckColumn(dgv_AddrList, "선택", "chk", 40, true, DataGridViewContentAlignment.MiddleCenter); //0번째 컬럼 셋팅 ( 체크박스 )
			CommonUtil.AddGridTextColumn(dgv_AddrList, "ID", "user_ID", 10, false); //1번째 컬럼 (숨김)
			CommonUtil.AddGridTextColumn(dgv_AddrList, "수령인", "Addr_Receiver", 80, true, DataGridViewContentAlignment.MiddleCenter); //2번째 컬럼
			CommonUtil.AddGridTextColumn(dgv_AddrList, "배송지명", "Addr_NickName", 80, true, DataGridViewContentAlignment.MiddleCenter); //3번째 컬럼
			CommonUtil.AddGridTextColumn(dgv_AddrList, "주소", "Addr_show", 300, true, DataGridViewContentAlignment.MiddleCenter); //4번째 컬럼
			CommonUtil.AddGridTextColumn(dgv_AddrList, "연락처", "Addr_Phone", 100, true, DataGridViewContentAlignment.MiddleCenter); //5번째 컬럼
			CommonUtil.AddGridTextColumn(dgv_AddrList, "주소ID", "Addr_No", 10, false);//6번째 (주소 기본키)
			CommonUtil.AddGridTextColumn(dgv_AddrList, "주소", "Addr", 10, false);//7번째
			CommonUtil.AddGridTextColumn(dgv_AddrList, "주소상세", "Addr_Detail", 10, false);//8번째
			CommonUtil.AddGridTextColumn(dgv_AddrList, "우편번호", "Addr_PostCode", 10, false);//9번쨰
			CommonUtil.AddGridTextColumn(dgv_AddrList, "기본주소여부", "Addr_Main", 10, false);//10번째
			#endregion

			LoadData(); //주소목록 조회
		}

		#region 이벤트
		private void btn_AddAddr_Click(object sender, EventArgs e) //배송지 추가버튼
		{
			frmAddrInsUp frm = new frmAddrInsUp(frmAddrInsUp.OpenMode.Insert);
			if(frm.ShowDialog() == DialogResult.OK)
			{
				LoadData();
			}

		}

		private void btn_UpdateAddr_Click(object sender, EventArgs e) //배송지 수정버튼
		{
			int rowIndex = dgv_AddrList.CurrentRow.Index; //선택한 셀 인덱스 번호 담기
			AddressVO vo = new AddressVO
			{
				User_ID = dgv_AddrList[1, rowIndex].Value.ToString(),
				Addr_Receiver = dgv_AddrList[2, rowIndex].Value.ToString(),
				Addr_NickName = dgv_AddrList[3, rowIndex].Value.ToString(),
				Addr = dgv_AddrList[7, rowIndex].Value.ToString(),
				Addr_Detail = dgv_AddrList[8, rowIndex].Value.ToString(),
				Addr_Phone = dgv_AddrList[5, rowIndex].Value.ToString(),
				Addr_PostCode = Convert.ToInt32(dgv_AddrList[9, rowIndex].Value),
				Addr_Main = dgv_AddrList[10, rowIndex].Value.ToString(),
				Addr_No = Convert.ToInt32(dgv_AddrList[6, rowIndex].Value)
			};

			frmAddrInsUp frm = new frmAddrInsUp(frmAddrInsUp.OpenMode.Update);
			frm.AddressInfo = vo;

			if (frm.ShowDialog() == DialogResult.OK)
			{

				LoadData();
			}
		}

		private void btn_DelAddr_Click(object sender, EventArgs e) //배송지 삭제 버튼
		{
			int rowIndex = dgv_AddrList.CurrentRow.Index; //선택한 셀 인덱스 번호 담기

			if(MessageBox.Show("정말로 삭제 하시겠습니까?", "삭제 확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				int addrNo = Convert.ToInt32(dgv_AddrList[6, rowIndex].Value);

				Address_Service service = new Address_Service();
				bool bFlag = service.DeleteAddress(addrNo);
				service.Dispose();
				if (bFlag)
				{
					MessageBox.Show("삭제가 완료되었습니다.");
					LoadData(); //삭제후 바로 데이터 갱신
				}
				else
					MessageBox.Show("삭제에 실패하였습니다. 다시 시도해 주세요.");
			}
		}

		private void btn_Select_Click(object sender, EventArgs e) //배송지로 선택 버튼
		{
			dgv_AddrList.EndEdit(); //체크를 하고있는 셀에 수정중인 것을 커밋 했다라는 뜻의 코드
			int rowIndex = dgv_AddrList.CurrentRow.Index; //선택한 셀 인덱스 번호 담기
			if (Convert.ToBoolean(dgv_AddrList[0, rowIndex].Value)) // 체크박스의 밸류로 받고 불린형으로 형변환을 해주면 체크여부가 트루,펄스로 반환됨
			{
				AddressVO vo = new AddressVO
				{
					User_ID = dgv_AddrList[1, rowIndex].Value.ToString(),
					Addr_Receiver = dgv_AddrList[2, rowIndex].Value.ToString(),
					Addr_NickName = dgv_AddrList[3, rowIndex].Value.ToString(),
					Addr = dgv_AddrList[7, rowIndex].Value.ToString(),
					Addr_Detail = dgv_AddrList[8, rowIndex].Value.ToString(),
					Addr_Phone = dgv_AddrList[5, rowIndex].Value.ToString(),
					Addr_PostCode = Convert.ToInt32(dgv_AddrList[9, rowIndex].Value),
					Addr_No = Convert.ToInt32(dgv_AddrList[6, rowIndex].Value)
				};

				AddressInfo = vo; //주소 정보를 넘겨주기 위해 프로퍼티에 vo객체 넘김

				this.DialogResult = DialogResult.OK;
			} 
		}
		#endregion

		#region 메서드
		/// <summary>
		/// 주소목록 조회 메서드
		/// </summary>
		private void LoadData()
		{
			Address_Service service = new Address_Service();
			allList = service.GetAllAddress(GlobalUser.LoginUserInfo.user_ID);
			service.Dispose();
			dgv_AddrList.DataSource = allList;
		}



		#endregion

		private void dgv_AddrList_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if(e.RowIndex > -1)
            {
				if(e.ColumnIndex == 0)
                {
					int addrno = Convert.ToInt32(dgv_AddrList["Addr_No", e.RowIndex].Value);

					foreach (DataGridViewRow dr in dgv_AddrList.Rows)
					{
						if (Convert.ToInt32(dr.Cells["Addr_No"].Value) != addrno)
						{
							((DataGridViewCheckBoxCell)dr.Cells["chk"]).Value = false;
						}
					}
				}
			}

			//dgv_AddrList.EndEdit(); //체크를 하고있는 셀에 수정중인 것을 커밋 했다라는 뜻의 코드
			//int rowIndex = dgv_AddrList.CurrentRow.Index; //선택한 셀 인덱스 번호 담기
			//if (Convert.ToBoolean(dgv_AddrList[0, rowIndex].Value))
			//{
				
			//}
		}


	}
}
