using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.ViewComponents.Product
{
    public class StoreCommentList : ViewComponent
    {
        StoreNotificationManager notificationManager = new StoreNotificationManager(new EfStoreNotificationDal());
        private readonly UserManager<AppUser> _userManager;

        public StoreCommentList(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult>  InvokeAsync()
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            int id = value.StoreID;
            var values = notificationManager.GetListWithUser().Where(x=>x.StoreID == id);

            return View(values);
        }
    }
}
