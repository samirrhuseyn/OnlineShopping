using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.Areas.Seller.Controllers
{
    [Area("Seller")]
    public class NotificationController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        NotificationManager notificationManager = new NotificationManager(new EfNotificationDal());
        Context context = new Context();

        public NotificationController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var username = User.Identity.Name;
            var user = context.Users.Where(x => x.UserName == username).Select(x => x.Id).FirstOrDefault();
            string id = user;
            var value = notificationManager.GetListWihType(id);
            return View(value);
        }
    }
}
