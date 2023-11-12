using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.Areas.Admin.Models;

namespace OnlineShopping.Areas.Seller.Controllers
{
    [Area("Seller")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        Context context = new Context();

        public AccountController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> MyAccount()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var value = context.Users.Include(x => x.Store).FirstOrDefault(x => x.Id == values.Id);
            ViewBag.Store = value.Store.Name;
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> EditAccount()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var account = new EditAccountViewModel
            {
                Id = values.Id,
                Name = values.Name,
                Surname = values.Surname,
                Email = values.Email,
                Username = values.UserName,
                Phone = values.Phone,
                ImagePreview = values.ProfileImage
            };
            return View(account);
        }

        [HttpPost]
        public async Task<IActionResult> EditAccount(EditAccountViewModel editAccount)
        {
            if (ModelState.IsValid)
            {
                var values = await _userManager.FindByNameAsync(User.Identity.Name);
                values.Name = editAccount.Name;
                values.Surname = editAccount.Surname;
                values.Email = editAccount.Email;
                values.UserName = editAccount.Username;
                values.Phone = editAccount.Phone;
                values.PasswordHash = editAccount.Password != null ? editAccount.Password : values.PasswordHash;
                values.ProfileImage = editAccount.Image != null ? UploadFile(editAccount.Image) : values.ProfileImage;
                await _userManager.UpdateAsync(values);
                return RedirectToAction("Index", "Product");
            }
            return View(editAccount);
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
    }
}


