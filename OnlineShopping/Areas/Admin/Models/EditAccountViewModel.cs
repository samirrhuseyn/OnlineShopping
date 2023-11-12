using System.ComponentModel.DataAnnotations;

namespace OnlineShopping.Areas.Admin.Models
{
    public class EditAccountViewModel
    {
        [Key]
        public string? Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Admin adını əlavə edin!")]
        public string? Name { get; set; }

        [Display(Name = "Surname")]
        [Required(ErrorMessage = "Admin soyadını əlavə edin!")]
        public string? Surname { get; set; }

        [Display(Name = "User Name")]
        [Required(ErrorMessage = "Admin istifadəçi adını əlavə edin!")]
        public string? Username { get; set; }

        [Display(Name = "Mail")]
        [Required(ErrorMessage = "Admin elektron poçtunu əlavə edin!")]
        public string? Email { get; set; }

        public IFormFile? Image { get; set; }

        public string? ImagePreview { get; set; }

        public int StoreID { get; set; }

        [Display(Name = "Password")]
        public string? Password { get; set; }

        [Display(Name = "Password Again")]
        [Compare("Password", ErrorMessage = "Şifrələr eyni deyil!")]
        public string? ConfirmPassword { get; set; }
        public bool IsSeller { get; set; }
        public bool IsAdmin { get; set; }

        [Display(Name = "Phone")]
        [Required(ErrorMessage = "Admin telefon nömrəsini əlavə edin!")]
        public string? Phone { get; set; }
        public bool IsActive { get; set; }
    }
}
