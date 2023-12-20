using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        OrderManager orderManager = new OrderManager(new EfOrderDal());
        private readonly UserManager<AppUser> _userManager;

        public OrderController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            
            var values = orderManager.GetListByUser();
            return View(values);
        }
    }
}
