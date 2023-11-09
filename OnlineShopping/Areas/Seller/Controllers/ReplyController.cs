using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Models;

namespace OnlineShopping.Areas.Seller.Controllers
{
    [Area("Seller")]
    public class ReplyController : Controller
    {
        NotificationManager notificationManager = new NotificationManager(new EfNotificationDal());
        ReplyManager replyManager = new ReplyManager(new EfReplyDal());
        private readonly UserManager<AppUser> _userManager;
        Context context = new Context();
        public ReplyController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpPost]
        public async Task<IActionResult> ReplyAdd(AddReplyViewModel addReply)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            Reply reply = new Reply()
            {
                ReplyId = addReply.Id,
                ReplyContent = addReply.Content,
                CommentID = addReply.CommentId,
                UserID = values.Id,
                ReplyDateTime = DateTime.Parse(DateTime.Now.ToShortTimeString())
            };
            replyManager.TAdd(reply);
            Notification notification = new Notification()
            {
                NotificationTitle = values.Name + " " + values.Surname + " sənə cavab verdi!",
                NotificationContent = addReply.Content,
                NotificationTypeTypeID = 3,
                NotificationDate = Convert.ToDateTime(DateTime.Now.ToShortTimeString()),
                UserID = context.Comments.Where(x => x.CommentID == addReply.CommentId).Select(x => x.UserID).FirstOrDefault()
            };
            notificationManager.TAdd(notification);
            return LocalRedirect("/Seller/Product/ProductDetails/" + addReply.ProductId);
        }

        public IActionResult DeleteReply(int id)
        {
            var value = replyManager.TGetByID(id);
            replyManager.TDelete(value);
            return LocalRedirect("/Seller/Product/Index/");
        }
    }
}

