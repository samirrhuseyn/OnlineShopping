using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.ViewComponents.SellerLayout
{
    public class SMessageNotification : ViewComponent
    {
        SMessageManager sMessageManager = new SMessageManager(new EfSMessageDal());
        private readonly UserManager<AppUser> _userManager;

        public SMessageNotification(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = sMessageManager.GetListStoreMessages().Where(x => x.StoreID == value.StoreID).Take(3);
            ViewBag.CountMessage = sMessageManager.GetListStoreMessages().Where(x => x.StoreID == value.StoreID).Count();
            return View(values);
        }
    }
}
