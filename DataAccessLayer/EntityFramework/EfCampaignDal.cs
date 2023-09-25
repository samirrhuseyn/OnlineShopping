using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
	public class EfCampaignDal : GenericRepository<Campaign>, ICampaignDal
	{
		public List<Campaign> Campaigns()
		{
			using(Context context = new Context())
			{
				return context.Campaigns
					.Include(x=>x.Store)
					.OrderByDescending(x=>x.StartDate)
					.ToList();
			}
		}

		public Campaign GetCampaign(int id)
		{
			using(var context = new Context())
			{
				return context.Campaigns
					.Include(x=>x.Store)
					.FirstOrDefault(x=>x.CampaignID == id);
			}
		}
	}
}
