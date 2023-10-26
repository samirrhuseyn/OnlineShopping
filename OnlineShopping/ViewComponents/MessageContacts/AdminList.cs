using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.ViewComponents.MessageContacts
{
    public class AdminList : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public AdminList(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            var value = _userManager.Users.Where(x => x.StoreID == 4).Where(x => x.IsSeller == false).Where(x => x.IsAdmin == true).ToList();
            return View(value);
        }
    }
}
