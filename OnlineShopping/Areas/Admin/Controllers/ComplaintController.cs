using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.Areas.Admin.Controllers
{
    [Area("Admin")]
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
            return View(value);
        }
    }
}
