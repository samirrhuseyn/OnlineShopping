﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ICampaignSurveyDal:IGenericDal<CampaignSurvey>
    {
        List<CampaignSurvey> GetAll();
        CampaignSurvey GetSurveyById(int id);
    }
}
