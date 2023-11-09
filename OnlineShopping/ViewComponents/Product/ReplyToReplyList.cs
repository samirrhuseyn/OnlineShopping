using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.ViewComponents.Product
{
    public class ReplyToReplyList : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public ReplyToReplyList(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ReplyToReplyManager replyManager = new ReplyToReplyManager(new EfReplyToReplyDal());
            var UserID = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.UserID = UserID.Id;
            var value = replyManager.GetReplyToReplyListByReplyID().Where(x => x.ReplyID == ViewBag.ReplyID);
            return View(value);
        }
    }
}
