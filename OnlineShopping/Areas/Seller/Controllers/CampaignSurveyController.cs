using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.Areas.Seller.Controllers
{
    [Area("Seller")]
    [Authorize(Roles = "Seller")]
    public class CampaignSurveyController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        CampaignSurveyManager campaignSurveyManager = new CampaignSurveyManager(new EfCampaignSurveyDal());

        public CampaignSurveyController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var value = campaignSurveyManager.GetAllWithStore().Where(x => x.StoreID == values.StoreID).ToList();
            return View(value);
        }

        public IActionResult Details(int id)
        {
            var value = campaignSurveyManager.TGetByID(id);
            return View(value);
        }

        [HttpGet]
        public IActionResult AddSurvey()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSurvey(CampaignSurvey campaignSurvey)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            CompaignSurveyValidator surveyValidator = new CompaignSurveyValidator();
            ValidationResult result = surveyValidator.Validate(campaignSurvey);
            if (result.IsValid)
            {
                campaignSurvey.SendDate = DateTime.Parse(DateTime.Now.ToShortTimeString());
                campaignSurvey.IsApproved = false;
                campaignSurvey.StoreID = values.StoreID;
                campaignSurveyManager.TAdd(campaignSurvey);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult EditSurvey(int id)
        {
            var value = campaignSurveyManager.TGetByID(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult EditSurvey(CampaignSurvey survey)
        {
            CompaignSurveyValidator surveyValidator = new CompaignSurveyValidator();
            ValidationResult result = surveyValidator.Validate(survey);
            if (result.IsValid)
            {
                var value = campaignSurveyManager.TGetByID(survey.CampaignID);
                value.Title = survey.Title;
                value.Description = survey.Description;
                value.SendDate = value.SendDate;
                value.IsApproved = value.IsApproved;
                value.StoreID = value.StoreID;
                campaignSurveyManager.TUpdate(value);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult DeleteSurvey(int id)
        {
            var value = campaignSurveyManager.TGetByID(id);
            campaignSurveyManager.TDelete(value);
            return RedirectToAction("Index");
        }
    }
}
