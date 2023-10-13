using Microsoft.AspNetCore.Mvc;
namespace OnlineShopping.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

       
    }
}