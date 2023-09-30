using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using OnlineShopping.Areas.Admin.Models;

namespace OnlineShopping.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CampaignController : Controller
    {
        CampaignManager campaignManager = new CampaignManager(new EfCampaignDal());
        StoreManager storeManager = new StoreManager(new EfStoreDal());
        public IActionResult Index()
        {
            var value = campaignManager.GetCampaigns();
            return View(value);
        }
        [HttpGet]
        public IActionResult AddCampaign()
        {
            List<SelectListItem> storevalues = (from x in storeManager.TGetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.Name,
                                                    Value = x.StoreID.ToString()
                                                }).ToList();
            ViewBag.sv = storevalues;
            return View();
        }

        [HttpPost]
        public IActionResult AddCampaign(AddCampaignViewModel addCampaign)
        {
            if (ModelState.IsValid)
            {
                Campaign campaign = new Campaign()
                {
                    Title = addCampaign.Title,
                    Content = addCampaign.Content,
                    StoreID = addCampaign.StoreID,
                    StartDate = addCampaign.StartDate,
                    EndDate = addCampaign.EndDate,
                    Image = UploadFile(addCampaign.Image),
                    IsExpired = false
                };
                campaignManager.TAdd(campaign);
                return RedirectToAction("Index");
            }
            return View(addCampaign);
        }

        private string UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return null;

            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot/ImagesFiles/CampaignImagesFiles/",
                        file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return "/ImagesFiles/CampaignImagesFiles/" + file.FileName;
        }

        public IActionResult CompaignDetails(int id)
        {
            var value = campaignManager.GetCampaign(id);
            return View(value);
        }

        [HttpGet]
        public IActionResult EditCampaign(int id)
        {
            var value = campaignManager.TGetByID(id);
            List<SelectListItem> storevalues = (from x in storeManager.TGetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.Name,
                                                    Value = x.StoreID.ToString()
                                                }).ToList();
            ViewBag.sv = storevalues;
            var editCampaignViewModel = new EditCampaignViewModel
            {
                ImagePreview = value.Image,
                Title = value.Title,
                CampaignID = value.CampaignID,
                StoreID = value.StoreID,
                Content = value.Content,
                EndDate = value.EndDate,
                StartDate = value.StartDate
            };
            return View(editCampaignViewModel);
        }

        [HttpPost]
        public IActionResult EditCampaign(EditCampaignViewModel editCampaign)
        {
            if (ModelState.IsValid)
            {
                var value = campaignManager.TGetByID(editCampaign.CampaignID);
                value.Title = editCampaign.Title;
                value.Content = editCampaign.Content;
                value.EndDate = editCampaign.EndDate != null ? editCampaign.EndDate : value.EndDate;
                value.StartDate = editCampaign.StartDate != null ? editCampaign.StartDate : value.StartDate;
                value.Image = editCampaign.Image != null ? UploadFile(editCampaign.Image) : value.Image;
                value.StoreID = editCampaign.StoreID;
                value.IsExpired = value.IsExpired;
                campaignManager.TUpdate(value);
                return RedirectToAction("Index");
            }
            return View(editCampaign);
        }

        public IActionResult DeleteCampaign(int id)
        {
            var value = campaignManager.TGetByID(id);
            campaignManager.TDelete(value);
            return RedirectToAction("Index");
        }
    }
}
