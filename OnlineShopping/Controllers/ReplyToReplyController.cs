using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Models;

namespace OnlineShopping.Controllers
{
    public class ReplyToReplyController : Controller
    {
        ReplyToReplyManager replyManager = new ReplyToReplyManager(new EfReplyToReplyDal());
        public IActionResult AddReply(AddReplyToReplyViewModel addReplyToReply)
        {
            ReplyToReply replyToReply = new ReplyToReply()
            {
                ReplyToReplyID = addReplyToReply.Id,
                ReplyToReplyContent = addReplyToReply.Content,
                UserID = "90fadbf2-c167-4a60-8c2e-879f77134ddd",
                ReplyID = addReplyToReply.ReplyID,
                ReplyToReplyDateTime = DateTime.Parse(DateTime.Now.ToShortTimeString())
            };
            replyManager.TAdd(replyToReply);
            return LocalRedirect("/Product/ProductDetails/" + addReplyToReply.ProductId);
        }
    }
}
