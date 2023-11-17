using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.Controllers
{
    public class StoreController : Controller
    {
        StoreManager storeManager = new StoreManager(new EfStoreDal());
        private readonly UserManager<AppUser> userManager;

        public StoreController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IActionResult> StoreDetails(int id)
        {
            var value = storeManager.TGetByID(id);
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.userid = user.Id;
            return View(value);
        }
    }
}
