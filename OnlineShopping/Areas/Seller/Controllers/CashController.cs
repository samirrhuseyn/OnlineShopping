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

        public async Task<IActionResult>  MyCash()
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            var cash = context.Orders.Where(x => x.Product.StoreID == value.StoreID).Select(x => x.Price).Sum();
            ViewBag.Cash = cash;
            return View();
        }
    }
}
