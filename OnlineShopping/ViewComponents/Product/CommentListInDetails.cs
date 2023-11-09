using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.ViewComponents.Product
{
    public class CommentListInDetails : ViewComponent
    {
        CommentManager commentManager = new CommentManager(new EfCommentDal());
        private readonly UserManager<AppUser> _userManager;

        public CommentListInDetails(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var UserID = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.UserID = UserID.Id;
            int id = ViewBag.ID;
            var value = commentManager.GetCommentsWithUserInfo().Where(x=>x.ProductID == id);
            return View(value);
        }
    }
}
