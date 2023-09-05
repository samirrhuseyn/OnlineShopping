using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.ViewComponents.SellerLayout
{
    public class ProfileLayout : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
