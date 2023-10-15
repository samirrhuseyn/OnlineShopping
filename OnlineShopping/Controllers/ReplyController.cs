using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Models;

namespace OnlineShopping.Controllers
{
    public class ReplyController : Controller
    {
        ReplyManager replyManager = new ReplyManager(new EfReplyDal());

        [HttpPost]
        public IActionResult AddReply(AddReplyViewModel addReply)
        {
            Reply reply = new Reply()
            {
                ReplyId = addReply.Id,
                ReplyContent = addReply.Content,
                CommentID = addReply.CommentId,
                UserID = "90fadbf2-c167-4a60-8c2e-879f77134ddd",
                ReplyDateTime = DateTime.Parse(DateTime.Now.ToShortTimeString())
            };
            replyManager.TAdd(reply);
            return LocalRedirect("/Product/ProductDetails/" + addReply.ProductId);
        }
    }
}
