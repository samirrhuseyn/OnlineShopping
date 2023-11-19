using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.Controllers
{
    public class ComplaintController : Controller
    {
        public IActionResult AddComplaint()
        {
            return View();
        }
    }
}
