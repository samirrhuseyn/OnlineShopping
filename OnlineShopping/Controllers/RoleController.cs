using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.Controllers
{
    public class RoleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
