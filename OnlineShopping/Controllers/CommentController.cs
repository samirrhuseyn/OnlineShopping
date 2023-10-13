using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Models;

namespace OnlineShopping.Controllers
{
    public class CommentController : Controller
    {
        CommentManager commentManager = new CommentManager(new EfCommentDal());


        [HttpPost]
        public IActionResult AddComment(AddCommentViewModel commentModel)
        {
            
            Comment comment = new Comment()
            {
                CommentID = commentModel.Id,
                Content = commentModel.Content,
                CommentDateTime = DateTime.Parse(DateTime.Now.ToShortTimeString()),
                ProductID = commentModel.ProductID,
                UserID = "299fada1-a845-4d73-80c1-07bc3769026d",
            };
            commentManager.TAdd(comment);
            return LocalRedirect("/Product/ProductDetails/" + comment.ProductID);
        }
    }
}
