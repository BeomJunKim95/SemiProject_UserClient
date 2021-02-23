using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProjectVO
{
	public class AddressVO2
	{
		//헬퍼 사용으로 주소목록 조회할때 프로퍼티는 있는데 값이 없을때 오류 방지를 위해 VO하나 더 만듦
		public string User_ID { get; set; }
		public int Addr_No { get; set; }
        public string Addr_Detail { get; set; }
        public int Addr_PostCode { get; set; }

        public string Addr_Receiver { get; set; }
		public string Addr_Phone { get; set; }
		public string Addr { get; set; }
		//public string Addr_Detail { get; set; }
		//public int Addr_PostCode { get; set; }
		public string Addr_NickName { get; set; }
		//public string Addr_Main { get; set; }
	}

	public class AddressVO
	{
		public string User_ID { get; set; }
		public int Addr_No { get; set; }
		public string Addr_Receiver { get; set; }
		public string Addr_Phone { get; set; }
		public string Addr { get; set; }
		public string Addr_Detail { get; set; }
		public int Addr_PostCode { get; set; }
		public string Addr_NickName { get; set; }
		public string Addr_Main { get; set; }
		public string Addr_show { get; set; }
	}
}
