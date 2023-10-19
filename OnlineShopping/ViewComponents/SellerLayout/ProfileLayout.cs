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
        Context context = new Context();
        public ProfileLayout(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var username = User.Identity.Name;
            var ID = context.Users.Where(x => x.UserName == username).Select(x => x.Id).FirstOrDefault();
            ViewBag.user = context.Users.Where(x=>x.Id == ID).Include(x => x.Store).Select(x => x.StoreID);
            return View(values);
        }
    }
}
