using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProjectDAC;
using TeamProjectVO;

namespace TeamProject
{
	class Address_Service : IDisposable
	{
		AddressDAC dac;
		public Address_Service()
		{
			dac = new AddressDAC();
		}

		public List<AddressVO> GetAllAddress(string id)
		{
			return dac.GetAllAddress(id);
		}

		public List<AddressVO> GetMainAddress(string id)
		{
			return dac.GetMainAddress(id);
		}

		public bool InsertAddress(AddressVO vo)
		{
			return dac.InsertAddress(vo);
		}

		public bool UpdateAddress(AddressVO vo)
		{
			return dac.UpdateAddress(vo);
		}

		public bool DeleteAddress(int addrNo)
		{
			return dac.DeleteAddress(addrNo);
		}

		public void Dispose()
		{
			dac.Dispose();
		}
	}
}
