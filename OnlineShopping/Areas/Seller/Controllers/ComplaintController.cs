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
    }
}
