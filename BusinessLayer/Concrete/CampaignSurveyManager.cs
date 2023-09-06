using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CampaignSurveyManager : ICampaignSurveyService
    {
        ICampaignSurveyDal _campaignSurvey;

        public CampaignSurveyManager(ICampaignSurveyDal campaignSurvey)
        {
            _campaignSurvey = campaignSurvey;
        }

        public List<CampaignSurvey> GetAllWithStore()
        {
            return _campaignSurvey.GetAll();
        }

        public void TAdd(CampaignSurvey t)
        {
            _campaignSurvey.Insert(t);  
        }

        public void TDelete(CampaignSurvey t)
        {
            _campaignSurvey.Delete(t);
        }

        public CampaignSurvey TGetByID(int id)
        {
            return _campaignSurvey.GetByID(id);
        }

        public List<CampaignSurvey> TGetList()
        {
            return _campaignSurvey.GetList();
        }

        public void TUpdate(CampaignSurvey t)
        {
            _campaignSurvey.Update(t);
        }
    }
}
