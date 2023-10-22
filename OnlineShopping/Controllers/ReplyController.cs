using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Models;

namespace OnlineShopping.Controllers
{
    public class ReplyController : Controller
    {
        ReplyManager replyManager = new ReplyManager(new EfReplyDal());
        private readonly UserManager<AppUser> _userManager;

        public ReplyController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpPost]
        public async Task<IActionResult> AddReply(AddReplyViewModel addReply)
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
            return LocalRedirect("/Product/ProductDetails/" + addReply.ProductId);
        }
    }
}
