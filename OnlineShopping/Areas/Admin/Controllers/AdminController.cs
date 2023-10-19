using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.Areas.Admin.Models;

namespace OnlineShopping.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public AdminController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAdmin(AddAdminViewModel addAdmin)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser()
                {
                    Name = addAdmin.Name,
                    Surname = addAdmin.Surname,
                    Email = addAdmin.Email,
                    UserName = addAdmin.Username,
                    StoreID = 4,
                    ProfileImage = UploadFile(addAdmin.Image),
                    Phone = addAdmin.Phone,
                    IsAdmin = true,
                    IsSeller = false,
                    IsActive = true
                };
                var result = await _userManager.CreateAsync(appUser, addAdmin.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(appUser, "ADMIN");
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(addAdmin);
        }

        private string UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return null;

            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot/ImagesFiles/AdminImagesFiles/",
                        file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return "/ImagesFiles/AdminImagesFiles/" + file.FileName;
        }

        public IActionResult Index()
        {
            var value = _userManager.Users.Where(x => x.StoreID == 4).Where(x => x.IsSeller == false).Where(x => x.IsAdmin == true).ToList();
            return View(value);
        }

        public IActionResult UserList()
        {
            var value = _userManager.Users.Where(x => x.IsSeller == false).Where(x => x.IsAdmin == false).ToList();
            return View(value);
        }
    }
}
