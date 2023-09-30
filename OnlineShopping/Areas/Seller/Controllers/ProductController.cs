using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using OnlineShopping.Areas.Seller.Models;

namespace OnlineShopping.Areas.Seller.Controllers
{
	[Area("Seller")]
	public class ProductController : Controller
	{
		ProductManager productManager = new ProductManager(new EfProductDal());
		CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
		public IActionResult Index()
		{
			var value = productManager.GetListAllWithCategory();
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
		public IActionResult AddProduct(AddProductViewModel addProduct)
		{
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
					StoreID = 1
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

		public IActionResult ApplyDisscount()
		{

			return View();
		}

    }
}
