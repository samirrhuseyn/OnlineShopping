using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.ViewComponents.PublicHome
{
    public class ProfileIdentity : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileIdentity(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            return View(values);
        }
    }
}
