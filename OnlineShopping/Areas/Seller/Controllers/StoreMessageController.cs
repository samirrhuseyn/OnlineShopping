using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.Areas.Seller.Controllers
{
    [Area("Seller")]
    public class StoreMessageController : Controller
    {
        SMessageManager sMessageManager = new SMessageManager(new EfSMessageDal());
        private readonly UserManager<AppUser> _userManager;

        public StoreMessageController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = sMessageManager.GetListStoreMessages().Where(x => x.StoreID == value.StoreID);
            return View(values);
        }

        public IActionResult MessageDetails(int id)
        {
            var value = sMessageManager.GetMessage(id);
            return View(value);
        }

        public IActionResult DeleteMessage(int id)
        {
            var value = sMessageManager.TGetByID(id);
            sMessageManager.TDelete(value);
            return RedirectToAction("Index");
        }
    }
}
