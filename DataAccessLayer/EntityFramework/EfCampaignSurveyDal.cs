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
    public class EfCampaignSurveyDal : GenericRepository<CampaignSurvey>, ICampaignSurveyDal
    {
        public List<CampaignSurvey> GetAll()
        {
            using (Context context = new Context())
            {
                return context.CampaignSurveys
                    .Include(x => x.Store)
                    .OrderByDescending(x=>x.SendDate)
                    .ToList();
            }
        }
    }
}
