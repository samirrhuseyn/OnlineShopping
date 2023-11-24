using System.ComponentModel.DataAnnotations;

namespace OnlineShopping.Areas.Admin.Models
{
    public class PasswordViewModel
    {
        public string? UserId { get; set; }

        [Display(Name = "New Password")]
        [Required(ErrorMessage = "Yeni şifrənizi yazın")]
        public string? NewPassword { get; set; }

        [Display(Name = "New Password")]
        [Required(ErrorMessage = "Please Enter Password")]
        [Compare("NewPassword", ErrorMessage = "Passwords do not match")]
        public string? RePassword { get; set; }

        public string? PasswordCode { get; set; }
        public string? Email { get; set; }
    }
}
