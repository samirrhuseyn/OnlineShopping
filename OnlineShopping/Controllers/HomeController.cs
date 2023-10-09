using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Models;
using System.Diagnostics;

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