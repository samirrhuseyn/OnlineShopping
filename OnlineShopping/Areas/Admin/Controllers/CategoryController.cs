using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using OnlineShopping.Areas.Admin.Models;

namespace OnlineShopping.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        public IActionResult Index()
        {
            var value = categoryManager.TGetList();
            return View(value);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(AddCategoryViewModel addCategory)
        {
            if(ModelState.IsValid)
            {
                Category category = new Category()
                {
                    CategoryID = addCategory.CategoryID,
                    Name = addCategory.Name,
                    Image = UploadFile(addCategory.Image),
                    IsActive = true
                };
                categoryManager.TAdd(category);
                return RedirectToAction("Index");
            }
            return View(addCategory);
        }

        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            var value = categoryManager.TGetByID(id);
            var editCategoryViewModel = new EditCategoryViewModel
            {
                ImagePreview = value.Image,
                CategoryID = value.CategoryID,
                Name = value.Name
            };
            return View(editCategoryViewModel);
        }

        [HttpPost]
        public IActionResult EditCategory(EditCategoryViewModel editCategory)
        {
            if (ModelState.IsValid)
            {
                var value = categoryManager.TGetByID(editCategory.CategoryID);
                value.Name = editCategory.Name;
                value.Image = editCategory.Image != null ? UploadFile(editCategory.Image) : value.Image;
                value.IsActive = value.IsActive;
                categoryManager.TUpdate(value);
                return RedirectToAction("Index");
            }
            return View(editCategory);
        }

        public IActionResult DeleteCategory(int id)
        {
            var value = categoryManager.TGetByID(id);
            categoryManager.TDelete(value);
            return RedirectToAction("Index");
        }

        public IActionResult ChangeStatusPassive(int id)
        {
            var value = categoryManager.TGetByID(id);
            value.IsActive = false;
            categoryManager.TUpdate(value);
            return RedirectToAction("Index");
        }
        
        public IActionResult ChangeStatusActive(int id)
        {
            var value = categoryManager.TGetByID(id);
            value.IsActive = true;
            categoryManager.TUpdate(value);
            return RedirectToAction("Index");
        }

        private string UploadFile(IFormFile? file)
        {
            if (file == null || file.Length == 0)
                return null;

            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot/ImagesFiles/CategoryImagesFiles/",
                        file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return "/ImagesFiles/CategoryImagesFiles/" + file.FileName;
        }
    }
}
