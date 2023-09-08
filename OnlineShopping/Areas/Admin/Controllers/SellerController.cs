using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineShopping.Areas.Admin.Models;

namespace OnlineShopping.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SellerController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        StoreManager storeManager = new StoreManager(new EfStoreDal());
        Context context = new Context();
        public SellerController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddSeller()
        {
            List<SelectListItem> storevalues = (from x in storeManager.TGetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.StoreID.ToString()
                                                   }).ToList();
            ViewBag.sv = storevalues;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSeller(AddSellerViewModel addSeller)
        {

            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser()
                {
                    Email = addSeller.Email,
                    Name = addSeller.Name,
                    Surname = addSeller.Surname,
                    UserName = addSeller.Username,
                    StoreID = addSeller.StoreID,
                    ProfileImage = UploadFile(addSeller.Image)
                };
                var result = await _userManager.CreateAsync(appUser, addSeller.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Seller");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(addSeller);
        }

        private string UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return null;

            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot/ImagesFiles/SellerImagesFiles/",
                        file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return "/ImagesFiles/SellerImagesFiles/" + file.FileName;
        }
    }
}
