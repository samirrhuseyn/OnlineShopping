using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.ViewComponents.PublicHome
{
	public class Categories : ViewComponent
	{
		CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
		Context context = new Context();
		public IViewComponentResult Invoke()
		{
			var value = categoryManager.TGetList();
			return View(value);
		}
	}
}
