using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
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
        Context context = new Context();
        public SMessageNotification(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = sMessageManager.GetListStoreMessages().Where(x => x.StoreID == value.StoreID).Take(3);
            return View(values);
        }
    }
}
