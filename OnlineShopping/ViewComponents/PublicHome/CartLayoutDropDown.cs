using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace OnlineShopping.ViewComponents.PublicHome
{
    public class CartLayoutDropDown : ViewComponent
    {
        CartManager cartManager = new CartManager(new EfCartDal());
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            var value = cartManager.GetListByUserID().Where(x => x.UserID == "90fadbf2-c167-4a60-8c2e-879f77134ddd").Take(2);
            ViewBag.Count = context.Cart.Where(x => x.UserID == "90fadbf2-c167-4a60-8c2e-879f77134ddd").Count();
            return View(value);
        }
    }
}
