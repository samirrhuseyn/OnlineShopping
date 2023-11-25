using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.Areas.Admin.Models;

namespace OnlineShopping.Areas.Seller.Controllers
{
    [Area("Seller")]
    public class AccountController : Controller
    {
		MailManager mailManager = new MailManager();
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
                return RedirectToAction("MyAccount");
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

		[HttpGet]
		[AllowAnonymous]
		public IActionResult ForgotPassword()
		{
			return View();
		}

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> ForgotPassword(PasswordViewModel model)
		{
			var user = await _userManager.FindByEmailAsync(model.Email);
			if (user != null)
			{
				var passwordCode = await _userManager.GeneratePasswordResetTokenAsync(user);
				var returnUrl = Url.Action("UpdatePassword", new { userId = user.Id, passwordCode });
				var body = "http://localhost:19728" + returnUrl;
				mailManager.SendMail(model.Email, body, subject: "Reset Link");
				return RedirectToAction("LinkSuccess");
			}
			return RedirectToAction("EmailNotFound");
		}

        [HttpGet]
        [AllowAnonymous]
        public IActionResult UpdatePassword(string userId, string passwordCode)
        {
            if (userId != null && passwordCode != null)
            {
                var passwordDto = new PasswordViewModel();
                passwordDto.UserId = userId;
                passwordDto.PasswordCode = passwordCode;
                return View(passwordDto);
            }
            return RedirectToAction("EmailNotFound");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdatePassword(PasswordViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model.NewPassword != null)
            {
                var user = await _userManager.FindByIdAsync(model.UserId);
                var result = await _userManager.ResetPasswordAsync(user, model.PasswordCode, model.NewPassword);
                if (result.Succeeded)
                    return RedirectToAction("UpdateSuccess");
            }
            return RedirectToAction("UpdateFailed");
        }

        [AllowAnonymous]
        public IActionResult LinkSuccess()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult EmailNotFound()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult UpdateSuccess()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult UpdateFailed()
        {
            return View();
        }
    }
}


