using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace OnlineShopping.ViewComponents.MessageContacts
{
    public class SellerList : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public SellerList(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            var value = _userManager.Users.Include(x => x.Store).Where(x => x.IsSeller == true).Where(x => x.IsAdmin == false).ToList();
            return View(value);
        }
    }
}
