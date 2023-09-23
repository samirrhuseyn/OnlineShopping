using System.ComponentModel.DataAnnotations;

namespace OnlineShopping.Areas.Admin.Models
{
    public class EditStoreViewModel
    {
        [Key]
        public int StoreID { get; set; }

        [Required(ErrorMessage = "Mağaza adı boş buraxıla bilməz!")]
        [MaxLength(50, ErrorMessage = "Mağaza adı 50 hərfdən çox ola bilməz!")]
        [MinLength(3, ErrorMessage = "Mağaza adı 3 hərfdən az ola bilməz!")]
        public string? Name { get; set; }
        public IFormFile? LogoImage { get; set; }

        public string? LogoPreviev { get; set; }

        [Required(ErrorMessage = "Mağaza ünvanı boş buraxıla bilməz!")]
        [MaxLength(50, ErrorMessage = "Mağaza ünvanı 50 hərfdən çox ola bilməz!")]
        [MinLength(3, ErrorMessage = "Mağaza ünvanı 3 hərfdən az ola bilməz!")]
        public string? Adress { get; set; }
        public bool IsActive { get; set; }
    }
}
