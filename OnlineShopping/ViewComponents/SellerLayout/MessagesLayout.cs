using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.ViewComponents.SellerLayout
{
    public class MessagesLayout : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
