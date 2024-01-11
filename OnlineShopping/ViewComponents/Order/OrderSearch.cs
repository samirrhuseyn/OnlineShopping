using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.ViewComponents.Order
{
    public class OrderSearch : ViewComponent
    {
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
