using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace OnlineShopping.ViewComponents.PublicHome
{
    public class CartLayoutDropDown : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        CartManager cartManager = new CartManager(new EfCartDal());
        Context context = new Context();

        public CartLayoutDropDown(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var value = cartManager.GetListByUserID().Where(x => x.UserID == values.Id).Take(2);
            ViewBag.Count = context.Cart.Where(x => x.UserID == values.Id).Count();
            return View(value);
        }
    }
}
