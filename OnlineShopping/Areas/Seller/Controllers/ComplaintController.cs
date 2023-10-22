using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace OnlineShopping.Areas.Seller.Controllers
{
    [Area("Seller")]
    [Authorize(Roles = "Seller")]
    public class ComplaintController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        ComplaintManager complaintManager = new ComplaintManager(new EfComplaintDal());

        public ComplaintController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.StoryID = values.StoreID;
            var value = complaintManager.GetComplaints();
            return View(value);
        }


        public IActionResult Details(int id)
        {
            var value = complaintManager.GetComplaint(id);
            value.IsLooked = true;
            complaintManager.TUpdate(value);
            return View(value);
        }

        public IActionResult Delete(int id) 
        {
            var value = complaintManager.TGetByID(id);
            complaintManager.TDelete(value);
            return RedirectToAction("Index");
        }
    }
}
