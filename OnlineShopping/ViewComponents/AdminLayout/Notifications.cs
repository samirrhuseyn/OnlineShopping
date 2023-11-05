using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.ViewComponents.AdminLayout
{
    public class Notifications : ViewComponent
    {
        NotificationManager notificationManager = new NotificationManager(new EfNotificationDal());
        private readonly UserManager<AppUser> _userManager;
        Context context = new Context();

        public Notifications(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            var username = User.Identity.Name;
            var user = context.Users.Where(x => x.UserName == username).Select(x => x.Id).FirstOrDefault();
            string id = user;
            var value = notificationManager.GetListWihType(id).Take(3);
            return View(value);
        }
    }
}
