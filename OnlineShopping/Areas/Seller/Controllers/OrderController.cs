using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Areas.Seller.Models;

namespace OnlineShopping.Areas.Seller.Controllers
{
    [Area("Seller")]
    public class OrderController : Controller
    {
        OrderManager orderManager = new OrderManager(new EfOrderDal());
        private readonly UserManager<AppUser>  _userManager;
        Context context = new Context();
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

        [HttpGet]
        public IActionResult OrderCancel()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> OrderCancel(OrderCancel orderCancel)
        {
            
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            var productid = context.Orders.Where(x=>x.OrderCode == orderCancel.OrderCode).Select(x=>x.ProductID).FirstOrDefault();
            var store = context.Products.Where(x=>x.ProductID == productid).Select(x=>x.StoreID).FirstOrDefault();
            var orderid = context.Orders.Where(x => x.OrderCode == orderCancel.OrderCode).Select(x=>x.OrderId).FirstOrDefault();
            if (value.StoreID == store)
            {
                var values = orderManager.TGetByID(orderid);
                values.OrderStatusID = 2;
                orderManager.TUpdate(values);
                return RedirectToAction("Index");
            }
            return View(orderCancel);
        }
    }
}
