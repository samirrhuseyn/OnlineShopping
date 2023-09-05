using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.ViewComponents.SellerLayout
{
    public class NotesLayout : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
