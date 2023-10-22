using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Models;

namespace OnlineShopping.Controllers
{
    public class ReplyToReplyController : Controller
    {
        ReplyToReplyManager replyManager = new ReplyToReplyManager(new EfReplyToReplyDal());
        private readonly UserManager<AppUser> _userManager;

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
            return LocalRedirect("/Product/ProductDetails/" + addReplyToReply.ProductId);
        }
    }
}
