using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.Controllers
{
    public class AdressController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        AdressManager adressManager = new AdressManager(new EfAdressDal());
        public AdressController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult AddAdress()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAdress(Adress adress)
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            adress.UserID = value.Id;
            adressManager.TAdd(adress);
            return LocalRedirect("/Account/MyAccount");
        }

        public IActionResult DeleteAdress(int id)
        {
            var value = adressManager.TGetByID(id);
            adressManager.TDelete(value);
            return LocalRedirect("/Account/MyAccount");
        }
    }
}
