using System.ComponentModel.DataAnnotations;

namespace OnlineShopping.Areas.Admin.Models
{
    public class AddCategoryViewModel
    {
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Kateqoriya adını boş buraxa bilməzsiniz!")]
        [MaxLength(50, ErrorMessage = "Kateqoriya adı 50 simvoldan çox ola bilməz!")]
        [MinLength(3, ErrorMessage = "Kateqoriya adı 50 simvoldan az ola bilməz!")]
        public string? Name { get; set; }
        public IFormFile? Image { get; set; }
        public bool IsActive { get; set; }
    }
}
