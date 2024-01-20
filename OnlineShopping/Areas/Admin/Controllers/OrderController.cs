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

        public IActionResult ChooseSearch()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SearchIndex()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SearchIndex(OrderSearch orderSearch)
        {
            TempData["StartDate"] = orderSearch.StartDate;
            TempData["EndDate"] = orderSearch.EndDate;
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            var Start = (DateTime)TempData["StartDate"];
            var End = (DateTime)TempData["EndDate"];

            var total = context.Orders.Where(x => x.OrderDateTime >= Start).Where(x => x.OrderDateTime <= End).Where(x => x.OrderStatusID == 1).Select(x => x.Price).Sum();
            ViewBag.Total = total;
            var values = orderManager.GetListByUser().Where(x => x.OrderDateTime >= Start).Where(x => x.OrderDateTime <= End).ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult SearchCode()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SearchCode(OrderSearchCode searchCode)
        {
            TempData["Code"] = searchCode.Code;
            return RedirectToAction("IndexCode");
        }

        public IActionResult IndexCode()
        {
            var Codee = (string)TempData["Code"];
            var total = context.Orders.Where(x => x.OrderCode == Codee).Where(x => x.OrderStatusID == 1).Select(x => x.Price).Sum();
            ViewBag.Total = total;
            var values = orderManager.GetListByUser().Where(x => x.OrderCode == Codee).ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult SearchBuyer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SearchBuyer(SearchBuyer searchBuyer)
        {
            TempData["name"] = searchBuyer.Name;
            TempData["surname"] = searchBuyer.Surname;
            return RedirectToAction("IndexBuyer");
        }

        public IActionResult IndexBuyer()
        {
            var Name = (string)TempData["name"];
            var Surname = (string)TempData["surname"];
            var userid = context.Users.Where(x => x.Name == Name).Where(x => x.Surname == Surname).Select(x => x.Id).FirstOrDefault();
            var total = context.Orders.Where(x => x.UserID == userid).Where(x => x.OrderStatusID == 1).Select(x => x.Price).Sum();
            ViewBag.Total = total;
            var values = orderManager.GetListByUser().Where(x => x.UserID == userid).ToList();
            return View(values);
        }
    }
}
