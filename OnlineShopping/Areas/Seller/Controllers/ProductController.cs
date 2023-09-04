using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineShopping.Areas.Seller.Models;

namespace OnlineShopping.Areas.Seller.Controllers
{
    [Area("Seller")]
    public class ProductController : Controller
    {
        ProductManager productManager = new ProductManager(new EfProductDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        StoreManager storeManager = new StoreManager(new EfStoreDal());
        public IActionResult Index()
        {
            var value = productManager.TGetList();
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
                    StoreID = 1,
                };
                productManager.TAdd(product);
                return RedirectToAction("Index");
            }
            return View(addProduct);
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
    }
}
