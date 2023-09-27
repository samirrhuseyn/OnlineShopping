using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface ICampaignService : IGenericService<Campaign>
	{
		List<Campaign> GetCampaigns();
		Campaign GetCampaign(int id);
        List<Campaign> GetCampaignListByStoreID(int id);
    }
}
