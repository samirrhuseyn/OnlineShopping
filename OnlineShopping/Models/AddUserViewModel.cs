using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace OnlineShopping.Models
{
    public class AddUserViewModel
    {
        [Key]
        public string? SellerId { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Satıcı adını əlavə edin!")]
        public string? Name { get; set; }

        [Display(Name = "Surname")]
        [Required(ErrorMessage = "Satıcı soyadını əlavə edin!")]
        public string? Surname { get; set; }

        [Display(Name = "User Name")]
        [Required(ErrorMessage = "Satıcı istifadəçi adını əlavə edin!")]
        public string? Username { get; set; }

        [Display(Name = "Mail")]
        [Required(ErrorMessage = "Satıcı elektron poçtunu əlavə edin!")]
        public string? Email { get; set; }

        public IFormFile? Image { get; set; }
        public int StoreID { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Şifrə əlavə edin!")]
        public string? Password { get; set; }

        [Display(Name = "Password Again")]
        [Compare("Password", ErrorMessage = "Şifrələr eyni deyil!")]
        public string? ConfirmPassword { get; set; }
        public bool IsSeller { get; set; }
        public bool IsAdmin { get; set; }

        [Display(Name = "Phone")]
        [Required(ErrorMessage = "Satıcı telefon nömrəsini əlavə edin!")]
        public string? Phone { get; set; }
        public bool IsActive { get; set; }
    }
}
