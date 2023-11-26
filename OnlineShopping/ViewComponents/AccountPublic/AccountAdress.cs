using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.ViewComponents.AccountPublic
{
    public class AccountAdress : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        AdressManager adressManager = new AdressManager(new EfAdressDal());

        public AccountAdress(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var value = adressManager.TGetList().Where(x => x.UserID == user.Id);
            return View(value);
        }
    }
}
