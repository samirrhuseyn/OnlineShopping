using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace OnlineShopping.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CashController : Controller
    {
        Context context = new Context();
        public IActionResult Index()
        {
            var cash = context.Orders.Where(x => x.OrderDateTime.Value.Month == DateTime.Now.Month).Where(x => x.OrderDateTime.Value.Year == DateTime.Now.Year).Where(x => x.OrderStatusID == 1).Select(x => x.Price).Sum();
            ViewBag.Cash = cash;


            var lastcash = context.Orders.Where(x => x.OrderDateTime.Value.Month == DateTime.Now.AddMonths(-1).Month).Where(x => x.OrderDateTime.Value.Year == DateTime.Now.Year).Where(x => x.OrderStatusID == 1).Select(x => x.Price).Sum();

            ViewBag.LastCash = lastcash;

            float? difference = cash - lastcash;
            float? percentage = (difference * 100) / lastcash;
            ViewBag.Percentage = percentage;
            return View();
        }
    }
}
