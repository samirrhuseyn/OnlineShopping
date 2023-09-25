using System;
using BusinessLayer.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
	public class CampaignManager : ICampaignService
	{
		public Campaign GetCampaign(int id)
		{
			throw new NotImplementedException();
		}

		public List<Campaign> GetCampaigns()
		{
			throw new NotImplementedException();
		}

		public void TAdd(Campaign t)
		{
			throw new NotImplementedException();
		}

		public void TDelete(Campaign t)
		{
			throw new NotImplementedException();
		}

		public Campaign TGetByID(int id)
		{
			throw new NotImplementedException();
		}

		public List<Campaign> TGetList()
		{
			throw new NotImplementedException();
		}

		public void TUpdate(Campaign t)
		{
			throw new NotImplementedException();
		}
	}
}
