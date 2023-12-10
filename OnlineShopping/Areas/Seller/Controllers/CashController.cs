using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.Areas.Seller.Controllers
{
    [Area("Seller")]
    public class CashController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        Context context = new Context();
        public CashController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> MyCash()
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            var cash = context.Orders.Where(x => x.Product.StoreID == value.StoreID).Where(x => x.OrderDateTime.Value.Month == DateTime.Now.Month).Where(x => x.OrderDateTime.Value.Year == DateTime.Now.Year).Where(x=>x.OrderStatusID == 1).Select(x => x.Price).Sum();
            var order = context.Orders.Where(x => x.Product.StoreID == value.StoreID).Count();
            ViewBag.Cash = cash;
            ViewBag.Order = order;

            var lastcash = context.Orders.Where(x => x.Product.StoreID == value.StoreID).Where(x => x.OrderDateTime.Value.Month == DateTime.Now.AddMonths(-1).Month).Where(x => x.OrderDateTime.Value.Year == DateTime.Now.Year).Where(x => x.OrderStatusID == 1).Select(x => x.Price).Sum();

            ViewBag.LastCash = lastcash;

            float? difference = cash - lastcash;
            float? percentage = (difference * 100) / lastcash;
            ViewBag.Percentage = percentage;
            return View();

        }
    }
}
