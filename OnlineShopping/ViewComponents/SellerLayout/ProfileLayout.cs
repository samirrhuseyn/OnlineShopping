using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace OnlineShopping.ViewComponents.SellerLayout
{
    public class ProfileLayout : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        public ProfileLayout(UserManager<AppUser> userManager)
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
