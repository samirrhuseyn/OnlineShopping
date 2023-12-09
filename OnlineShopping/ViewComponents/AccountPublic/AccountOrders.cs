using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.ViewComponents.AccountPublic
{
    public class AccountOrders : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        OrderManager orderManager = new OrderManager(new EfOrderDal());
        public AccountOrders(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = orderManager.GetListByUser().Where(x => x.UserID == value.Id);
            return View(values);
        }
    }
}
