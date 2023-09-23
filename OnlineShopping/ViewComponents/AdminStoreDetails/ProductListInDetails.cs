using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.ViewComponents.AdminStoreDetails
{
    public class ProductListInDetails : ViewComponent
    {
        ProductManager productManager = new ProductManager(new EfProductDal());

        public IViewComponentResult Invoke()
        {
            int id = ViewBag.ID;
            var value = productManager.GetProductListByStoreID(id);
            return View(value);
        }
    }
}
