using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CampaignSurveyController : Controller
    {
        CampaignSurveyManager campaignSurveyManager = new CampaignSurveyManager(new EfCampaignSurveyDal());
        public IActionResult Index()
        {
            var value = campaignSurveyManager.GetAllWithStore();
            return View(value);
        }

        public IActionResult Details(int id) 
        {
            var value = campaignSurveyManager.GetBySurveyId(id);
            return View(value);
        }

        public IActionResult Approve(int id)
        {
            var value = campaignSurveyManager.TGetByID(id);
            value.IsApproved = true;
            campaignSurveyManager.TUpdate(value);
            return RedirectToAction("Index");
        }
    }
}
