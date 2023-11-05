using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Areas.Admin.Models;

namespace OnlineShopping.Areas.Admin.Controllers
{
    [Area("Admin")]
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

        [HttpGet]
        public IActionResult SpecialAdmin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SpecialAdmin(Notification notification)
        {
            var Admins = context.Users.Where(x => x.IsAdmin == true).ToList();
            foreach (var user in Admins)
            {
                notification.NotificationTitle = "Adminlər üçün bildiriş!";
                notification.NotificationDate = DateTime.Parse(DateTime.Now.ToShortTimeString());
                notification.NotificationTypeTypeID = 5;
                notification.UserID = user.Id;
                context.Notifications.Add(notification);
                context.BulkSaveChanges();
            }
            return RedirectToAction("Index", "Product");
        }

        [HttpGet]
        public IActionResult SpecialSeller()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SpecialSeller(Notification notification)
        {
            var Admins = context.Users.Where(x => x.IsSeller == true).ToList();
            foreach (var user in Admins)
            {
                notification.NotificationTitle = "Satıcılar üçün bildiriş!";
                notification.NotificationDate = DateTime.Parse(DateTime.Now.ToShortTimeString());
                notification.NotificationTypeTypeID = 5;
                notification.UserID = user.Id;
                context.Notifications.Add(notification);
                context.BulkSaveChanges();
            }
            return RedirectToAction("Index", "Product");
        }


        
    }
}
