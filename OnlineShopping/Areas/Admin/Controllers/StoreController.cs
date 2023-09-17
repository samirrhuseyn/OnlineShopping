using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StoreController : Controller
    {
        StoreManager storeManager = new StoreManager(new EfStoreDal());
        public IActionResult Index()
        {
            var value = storeManager.TGetList();
            return View(value);
        }

        public IActionResult StoreDetails(int id)
        {
            var value = storeManager.TGetByID(id);
            return View(value);
        }
    }
}
