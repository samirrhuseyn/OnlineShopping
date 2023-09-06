using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.Areas.Seller.Controllers
{
    [Area("Seller")]
    public class CampaignSurveyController : Controller
    {
        CampaignSurveyManager campaignSurveyManager = new CampaignSurveyManager(new EfCampaignSurveyDal());
        public IActionResult Index()
        {
            var value = campaignSurveyManager.GetAllWithStore();
            return View(value);
        }
    }
}
