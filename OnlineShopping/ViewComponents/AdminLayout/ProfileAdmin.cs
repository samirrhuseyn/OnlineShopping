using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.ViewComponents.AdminLayout
{
	public class ProfileAdmin : ViewComponent
	{
		private readonly UserManager<AppUser> _userManager;
		Context context = new Context();
		public ProfileAdmin(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var username = User.Identity.Name;
			var user = context.Users.Where(x => x.UserName == username).Select(x => x.Id).FirstOrDefault();
			string id = user;
			ViewBag.CountMessage = context.Messages.Where(x => x.ReceiverID == id).Where(x=>x.IsRead == false).Count();
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			return View(values);
		}
	}
}
