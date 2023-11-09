using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Models;

namespace OnlineShopping.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentController : Controller
    {
        CommentManager commentManager = new CommentManager(new EfCommentDal());
        private readonly UserManager<AppUser> _userManager;
        StoreNotificationManager notificationManager = new StoreNotificationManager(new EfStoreNotificationDal());
        Context context = new Context();

        public CommentController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(AddCommentViewModel commentModel)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            Comment comment = new Comment()
            {
                CommentID = commentModel.Id,
                Content = commentModel.Content,
                CommentDateTime = DateTime.Parse(DateTime.Now.ToShortTimeString()),
                ProductID = commentModel.ProductID,
                UserID = values.Id
            };
            commentManager.TAdd(comment);
            StoreNotification storeNotification = new StoreNotification()
            {
                StoreNotificationTitle = values.Name + " " + values.Surname + " məhsula rəy yazdı!",
                StoreNotificationContent = commentModel.Content,
                IsRead = false,
                StoreNotificationDate = Convert.ToDateTime(DateTime.Now.ToShortTimeString()),
                StoreID = context.Products.Where(x => x.ProductID == commentModel.ProductID).Select(x => x.StoreID).FirstOrDefault(),
                UserID = values.Id,
                ProductID = comment.ProductID,

            };
            notificationManager.TAdd(storeNotification);
            return LocalRedirect("/Admin/Product/Details/" + comment.ProductID);
        }

        public IActionResult DeleteComment(int id)
        {
            var value = commentManager.TGetByID(id);
            commentManager.TDelete(value);
            return LocalRedirect("/Admin/Product/Details/" + value.ProductID);
        }
    }
}
