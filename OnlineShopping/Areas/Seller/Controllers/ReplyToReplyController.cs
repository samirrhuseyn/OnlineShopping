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
    public class ReplyToReplyController : Controller
    {
        ReplyToReplyManager replyManager = new ReplyToReplyManager(new EfReplyToReplyDal());
        private readonly UserManager<AppUser> _userManager;
        Context context = new Context();
        NotificationManager notificationManager = new NotificationManager(new EfNotificationDal());

        public ReplyToReplyController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> AddReply(AddReplyToReplyViewModel addReplyToReply)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ReplyToReply replyToReply = new ReplyToReply()
            {
                ReplyToReplyID = addReplyToReply.Id,
                ReplyToReplyContent = addReplyToReply.Content,
                UserID = values.Id,
                ReplyID = addReplyToReply.ReplyID,
                ReplyToReplyDateTime = DateTime.Parse(DateTime.Now.ToShortTimeString())
            };
            replyManager.TAdd(replyToReply);
            Notification notification = new Notification()
            {
                NotificationTitle = values.Name + " " + values.Surname + " sənə cavab verdi!",
                NotificationContent = addReplyToReply.Content,
                NotificationTypeTypeID = 3,
                NotificationDate = Convert.ToDateTime(DateTime.Now.ToShortTimeString()),
                UserID = context.Replies.Where(x => x.ReplyId == addReplyToReply.ReplyID).Select(x => x.UserID).FirstOrDefault()
            };
            notificationManager.TAdd(notification);
            return LocalRedirect("/Seller/Product/ProductDetails/" + addReplyToReply.ProductId);
        }


        public IActionResult DeleteReply(int id)
        {
            var value = replyManager.TGetByID(id);
            replyManager.TDelete(value);
            return LocalRedirect("/Seller/Product/Index/");
        }
    }
}
