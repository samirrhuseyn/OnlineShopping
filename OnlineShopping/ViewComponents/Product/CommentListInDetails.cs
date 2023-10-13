using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.ViewComponents.Product
{
    public class CommentListInDetails : ViewComponent
    {
        CommentManager commentManager = new CommentManager(new EfCommentDal());

        public IViewComponentResult Invoke()
        {
            int id = ViewBag.ID;
            var value = commentManager.GetCommentsWithUserInfo().Where(x=>x.ProductID == id);
            return View(value);
        }
    }
}
