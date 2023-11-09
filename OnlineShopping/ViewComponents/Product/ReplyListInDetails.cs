using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.ViewComponents.Product
{
    public class ReplyListInDetails : ViewComponent
    {
        ReplyManager replyManager = new ReplyManager(new EfReplyDal());
        private readonly UserManager<AppUser> _userManager;

        public ReplyListInDetails(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var UserID = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.UserID = UserID.Id;
            var value = replyManager.GetListWIthCommentID().Where(x => x.CommentID == ViewBag.commentID);
            return View(value);
        }
    }
}
