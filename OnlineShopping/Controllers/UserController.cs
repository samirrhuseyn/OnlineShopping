using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.Models;

namespace OnlineShopping.Controllers
{
    [AllowAnonymous]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        
        public UserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(AddUserViewModel addUser)
        {
            AppUser appUser = new AppUser()
            {
                Name = addUser.Name,
                Surname = addUser.Surname,
                Email = addUser.Email,
                UserName = addUser.Username,
                StoreID = 4,
                ProfileImage = UploadFile(addUser.Image),
                Phone = addUser.Phone,
                IsAdmin = false,
                IsSeller = false,
                IsActive = true
            };
            var result = await _userManager.CreateAsync(appUser, addUser.Password);
            
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(appUser, "GUEST");
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View(addUser);
        }

        

        private string UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return null;

            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot/ImagesFiles/UserImagesFiles/",
                        file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return "/ImagesFiles/UserImagesFiles/" + file.FileName;
        }
    }
}
