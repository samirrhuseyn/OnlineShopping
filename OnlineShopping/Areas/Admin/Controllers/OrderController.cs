using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Areas.Admin.Models;

namespace OnlineShopping.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        OrderManager orderManager = new OrderManager(new EfOrderDal());
        Context context = new Context();

        public IActionResult Index(OrderSearch search)
        {

            var total = context.Orders.Select(x=>x.Price).Sum();
            ViewBag.Total = total;
            var values = orderManager.GetListByUser();
            return View(values);
        }
    }
}
