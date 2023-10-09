using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.ViewComponents.PublicHome
{
	public class Brands : ViewComponent
	{
		StoreManager storeManager = new StoreManager(new EfStoreDal());

		public IViewComponentResult Invoke()
		{
			var value = storeManager.TGetList();
			return View(value);
		}
	}
}
