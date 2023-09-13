using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
		ProductManager productManager = new ProductManager(new EfProductDal());
		public IActionResult Index()
        {
            var value = productManager.GetListAllWithCategory();
            return View(value);
        }

        public IActionResult Details(int id)
        {
            var value = productManager.GetByIdWIthCategory(id);
            return View(value);
        }
    }
}
