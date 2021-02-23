using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProjectVO
{
	public class PurchaseVO
	{
		public string user_ID { get; set; }
		public string Purchase_ID { get; set; }
		public string Purchase_Date { get; set; }
		public string Purchase_State { get; set; }
		public int Addr_No { get; set; }
		public int Purchase_info_ID { get; set; }
		public int Products_ID { get; set; }
		public int Purchase_Count { get; set; }
		public decimal Products_Price { get; set; }
		public decimal Order_Price { get; set; }
	}
}
