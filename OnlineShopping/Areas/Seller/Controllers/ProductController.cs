using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using OnlineShopping.Areas.Seller.Models;
using System.Data;

namespace OnlineShopping.Areas.Seller.Controllers
{
	[Area("Seller")]
    [Authorize(Roles = "Seller")]
    public class ProductController : Controller
	{
        private readonly UserManager<AppUser> _userManager;
        ProductManager productManager = new ProductManager(new EfProductDal());
		CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
		Context context = new Context();

        public ProductController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
		{
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var value = productManager.GetListAllWithCategory().Where(x=>x.StoreID == values.StoreID).ToList();
			return View(value);
		}

		[HttpGet]
		public IActionResult AddProduct()
		{
			List<SelectListItem> categoryvalues = (from x in categoryManager.TGetList()
												   select new SelectListItem
												   {
													   Text = x.Name,
													   Value = x.CategoryID.ToString()
												   }).ToList();
			ViewBag.cv = categoryvalues;
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> AddProduct(AddProductViewModel addProduct)
		{
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            if (ModelState.IsValid)
			{
				Product product = new Product()
				{
					ProductID = addProduct.ProductID,
					ProductDescription = addProduct.ProductDescription,
					ProductName = addProduct.ProductName,
					CreatedDate = DateTime.Parse(DateTime.Now.ToShortTimeString()),
					CategoryID = addProduct.CategoryID,
					Image1 = UploadFile(addProduct.Image1),
					Image2 = UploadFile(addProduct.Image2),
					Image3 = UploadFile(addProduct.Image3),
					Size = addProduct.Size,
					Color = addProduct.Color,
					InStock = true,
					Price = addProduct.Price,
					StoreID = values.StoreID,
					ProductCode = addProduct.ProductCode
				};
				productManager.TAdd(product);
				return RedirectToAction("Index");
			}
			return View(addProduct);
		}

		public IActionResult DeleteProduct(int id)
		{
			var value = productManager.TGetByID(id);
			productManager.TDelete(value);
			return RedirectToAction("Index");
		}

		public IActionResult ProductDetails(int id)
		{
			var value = productManager.GetByIdWIthCategory(id);
			return View(value);
		}

		[HttpGet]
		public IActionResult EditProduct(int id)
		{
			var value = productManager.TGetByID(id);
			List<SelectListItem> categoryvalues = (from x in categoryManager.TGetList()
												   select new SelectListItem
												   {
													   Text = x.Name,
													   Value = x.CategoryID.ToString()
												   }).ToList();
			ViewBag.cv = categoryvalues;
			var productModel = new EditProductViewModel
			{
				ProductID = value.ProductID,
				ProductName = value.ProductName,
				ProductDescription = value.ProductDescription,
				Price = value.Price,
				CategoryID = value.CategoryID,
				Color = value.Color,
				Image1Pre = value.Image1,
				Image2Pre = value.Image2,
				Image3Pre = value.Image3,
				DiscountedPrice = value.DiscountedPrice,
				Size = value.Size
			};
			return View(productModel);
		}
		[HttpPost]
		public IActionResult EditProduct(EditProductViewModel editProduct)
		{
			if (ModelState.IsValid)
			{
				var values = productManager.TGetByID(editProduct.ProductID);
				values.ProductName = editProduct.ProductName;
				values.ProductDescription = editProduct.ProductDescription;
				values.Price = editProduct.Price;
				values.StoreID = values.StoreID;
				values.CategoryID = editProduct.CategoryID;
				values.Color = editProduct.Color;
				values.ProductID = editProduct.ProductID;
				values.CreatedDate = values.CreatedDate;
				values.DiscountedPrice = editProduct.DiscountedPrice;
				values.Size = editProduct.Size;
				values.Image1 = editProduct.Image1 != null ? UploadFile(editProduct.Image1) : values.Image1;
				values.Image2 = editProduct.Image2 != null ? UploadFile(editProduct.Image2) : values.Image2;
				values.Image3 = editProduct.Image3 != null ? UploadFile(editProduct.Image3) : values.Image3;
				productManager.TUpdate(values);
				return RedirectToAction("Index");
			}
			return View(editProduct);
		}
		private string UploadFile(IFormFile? file)
		{
			if (file == null || file.Length == 0)
				return null;

			var path = Path.Combine(
						Directory.GetCurrentDirectory(), "wwwroot/ImagesFiles/ProductImagesFiles/",
						file.FileName);

			using (var stream = new FileStream(path, FileMode.Create))
			{
				file.CopyTo(stream);
			}

			return "/ImagesFiles/ProductImagesFiles/" + file.FileName;
		}

		[HttpGet]
        public IActionResult ApplyDisscount()
		{
            List<SelectListItem> categoryvalues = (from x in categoryManager.TGetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues;
            return View();
		}

		[HttpPost]
        public async Task<IActionResult> ApplyDisscount(ApplyDisscountViewModel applyDisscount)
		{

            var values = await _userManager.FindByNameAsync(User.Identity.Name);
			applyDisscount.StoreID = values.StoreID;
			productManager.ApplyDisscount(applyDisscount.CategoryID, applyDisscount.Interest, applyDisscount.StoreID);
            return RedirectToAction("Interests");
		}

		[HttpGet]
		public IActionResult ApplyDisscountByProductCode()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> ApplyDisscountByProductCode(DisscountByCodeViewModel disscountByCode)
		{
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var pc = context.Products.Where(x => x.ProductCode == disscountByCode.ProductCode).Select(x => x.StoreID).FirstOrDefault();
			if (pc == values.StoreID)
			{
				
				if (ModelState.IsValid)
				{
                    disscountByCode.StoreID = values.StoreID;
                    productManager.ApplyDisscountByCode(disscountByCode.ProductCode, disscountByCode.Interest, disscountByCode.StoreID);
					return RedirectToAction("Index");
				}
				else
				{
					return View(disscountByCode);
				}
			}
			else
			{
				return Content("Başqa mağazanın məhsuluna endirim tətbiq edə bilməzsiniz!");
			}
		}

		public async Task<IActionResult> Interests()
		{

            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var value = productManager.GetListAllWithCategory().DistinctBy(x=>x.CategoryID).Where(x=>x.StoreID == values.StoreID);
			return View(value);
		}
    }
}
