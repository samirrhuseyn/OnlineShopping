using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.Areas.Seller.Controllers
{
    [Area("Seller")]
    public class ComplaintController : Controller
    {
        ComplaintManager complaintManager = new ComplaintManager(new EfComplaintDal());
        public IActionResult Index()
        {
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
