using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Areas.Admin.Models;

namespace OnlineShopping.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StoreController : Controller
    {
        StoreManager storeManager = new StoreManager(new EfStoreDal());
        public IActionResult Index()
        {
            var value = storeManager.TGetList();
            return View(value);
        }

        public IActionResult StoreDetails(int id)
        {
            var value = storeManager.TGetByID(id);
            return View(value);
        }

        [HttpGet]
        public IActionResult AddStore()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddStore(AddStoreViewModel addStore)
        {
            if(ModelState.IsValid)
            {
                Store store = new Store()
                {
                    StoreID = addStore.StoreID,
                    Name = addStore.Name,
                    Adress = addStore.Adress,
                    IsActive = true,
                    LogoImage = UploadFile(addStore.LogoImage)
                };
                storeManager.TAdd(store);
                return RedirectToAction("Index");
            }
            return View(addStore);
        }

        [HttpGet]
        public IActionResult EditStore(int id) 
        {
            var value = storeManager.TGetByID(id);
            var editCategory = new EditStoreViewModel
            {
                LogoPreviev = value.LogoImage,
                Name = value.Name,
                Adress = value.Adress,
                StoreID = value.StoreID,
            };
            return View(editCategory);
        }

        [HttpPost]
        public IActionResult EditStore(EditStoreViewModel editStore)
        {
            if(ModelState.IsValid)
            {
                var value = storeManager.TGetByID(editStore.StoreID);
                value.Name = editStore.Name;
                value.Adress = editStore.Adress;
                value.LogoImage = editStore.LogoImage != null ? UploadFile(editStore.LogoImage) : value.LogoImage;
                value.IsActive = value.IsActive;
                storeManager.TUpdate(value);
                return RedirectToAction("Index");
            }
            return View(editStore);
        }

        public IActionResult DeleteStore(int id)
        {
            var value = storeManager.TGetByID(id);
            storeManager.TDelete(value);
            return RedirectToAction("Index");
        }

        public IActionResult ChangeStatusPassive(int id)
        {
            var value = storeManager.TGetByID(id);
            value.IsActive = false;
            storeManager.TUpdate(value);
            return RedirectToAction("Index");
        }

        public IActionResult ChangeStatusActive(int id)
        {
            var value = storeManager.TGetByID(id);
            value.IsActive = true;
            storeManager.TUpdate(value);
            return RedirectToAction("Index");
        }

        private string UploadFile(IFormFile? file)
        {
            if (file == null || file.Length == 0)
                return null;

            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot/ImagesFiles/StoreImagesFiles/",
                        file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return "/ImagesFiles/StoreImagesFiles/" + file.FileName;
        }
    }
}
