using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Models;

namespace OnlineShopping.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentController : Controller
    {
        CommentManager commentManager = new CommentManager(new EfCommentDal());
        private readonly UserManager<AppUser> _userManager;

        public CommentController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(AddCommentViewModel commentModel)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            Comment comment = new Comment()
            {
                CommentID = commentModel.Id,
                Content = commentModel.Content,
                CommentDateTime = DateTime.Parse(DateTime.Now.ToShortTimeString()),
                ProductID = commentModel.ProductID,
                UserID = values.Id
            };
            commentManager.TAdd(comment);
            return LocalRedirect("/Admin/Product/Details/" + comment.ProductID);
        }

        public IActionResult DeleteComment(int id)
        {
            var value = commentManager.TGetByID(id);
            commentManager.TDelete(value);
            return LocalRedirect("/Admin/Product/Details/" + value.ProductID);
        }
    }
}
