using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.ViewComponents.PublicHome
{
	public class TrendingProducts : ViewComponent
	{
		ProductManager productManager = new ProductManager(new EfProductDal());
		
		public IViewComponentResult Invoke()
		{
			var value = productManager.TGetList().OrderByDescending(x=>x.CreatedDate);
			return View(value);
		}
	}
}
