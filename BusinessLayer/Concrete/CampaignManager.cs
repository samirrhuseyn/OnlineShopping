using System;
using BusinessLayer.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using DataAccessLayer.Abstract;

namespace BusinessLayer.Concrete
{
	public class CampaignManager : ICampaignService
	{
		ICampaignDal _campaignDal;

		public CampaignManager(ICampaignDal campaignDal)
		{
			_campaignDal = campaignDal;
		}

		public Campaign GetCampaign(int id)
		{
			return _campaignDal.GetCampaign(id);
		}

        public List<Campaign> GetCampaignListByStoreID(int id)
        {
            return _campaignDal.GetCampaignListByStore(id);
        }

        public List<Campaign> GetCampaigns()
		{
			return _campaignDal.Campaigns();
		}

		public void TAdd(Campaign t)
		{
			_campaignDal.Insert(t);
		}

		public void TDelete(Campaign t)
		{
			_campaignDal.Delete(t);
		}

		public Campaign TGetByID(int id)
		{
			return _campaignDal.GetByID(id);
		}

		public List<Campaign> TGetList()
		{
			return _campaignDal.GetList();
		}

		public void TUpdate(Campaign t)
		{
			_campaignDal.Update(t);
		}
	}
}
