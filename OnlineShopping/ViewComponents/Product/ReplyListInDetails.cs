using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.ViewComponents.Product
{
    public class ReplyListInDetails : ViewComponent
    {
        ReplyManager replyManager = new ReplyManager(new EfReplyDal());

        public IViewComponentResult Invoke()
        {
            var value = replyManager.GetListWIthCommentID().Where(x => x.CommentID == ViewBag.commentID);
            return View(value);
        }
    }
}
