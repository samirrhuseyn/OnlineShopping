using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace OnlineShopping.Areas.Admin.Models
{
    public class AddSellerViewModel
    {
        [Key]
        public string? SellerId { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please Enter Name")]
        public string? Name { get; set; }

        [Display(Name = "Surname")]
        [Required(ErrorMessage = "Please Enter Surname")]
        public string? Surname { get; set; }

        [Display(Name = "User Name")]
        [Required(ErrorMessage = "Please Enter User Name")]
        public string? Username { get; set; }

        [Display(Name = "Mail")]
        [Required(ErrorMessage = "Please Enter Mail")]
        public string? Email { get; set; }

        public IFormFile? Image { get; set; }
        public int StoreID { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please Enter Password")]
        public string? Password { get; set; }

        [Display(Name = "Password Again")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string? ConfirmPassword { get; set; }
    }
}
