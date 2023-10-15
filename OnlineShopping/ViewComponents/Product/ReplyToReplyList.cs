using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.ViewComponents.Product
{
    public class ReplyToReplyList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ReplyToReplyManager replyManager = new ReplyToReplyManager(new EfReplyToReplyDal());

            var value = replyManager.GetReplyToReplyListByReplyID().Where(x => x.ReplyID == ViewBag.ReplyID);
            return View(value);
        }
    }
}
