using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
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
        public IActionResult AddSurvey(CampaignSurvey campaignSurvey) 
        {
            CompaignSurveyValidator surveyValidator = new CompaignSurveyValidator();
            ValidationResult result = surveyValidator.Validate(campaignSurvey);
            if (result.IsValid)
            {
                campaignSurvey.SendDate = DateTime.Parse(DateTime.Now.ToShortTimeString());
                campaignSurvey.IsApproved = false;
                campaignSurvey.StoreID = 2;
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
