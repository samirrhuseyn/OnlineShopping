using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
	public interface ICampaignDal : IGenericDal<Campaign>
	{
		List<Campaign> Campaigns();
		Campaign GetCampaign(int id);
		List<Campaign> GetCampaignListByStore(int id);
	}
}
