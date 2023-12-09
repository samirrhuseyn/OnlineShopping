using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.Areas.Seller.Controllers
{
    [Area("Seller")]
    public class OrderController : Controller
    {
        OrderManager orderManager = new OrderManager(new EfOrderDal());
        private readonly UserManager<AppUser>  _userManager;

        public OrderController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = orderManager.GetListByUser().Where(x => x.Product.StoreID == value.StoreID).ToList();
            return View(values);
        }
    }
}
