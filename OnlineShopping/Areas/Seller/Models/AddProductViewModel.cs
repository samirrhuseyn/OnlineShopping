using EntityLayer.Concrete;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopping.Areas.Seller.Models
{
    public class AddProductViewModel
    {
        [Key]
        public int ProductID { get; set; }
        public IFormFile? Image1 { get; set; }
        public IFormFile? Image2 { get; set; }
        public IFormFile? Image3 { get; set; }

        [Required(ErrorMessage = "Məhsulun adını boş buraxa bilməzsiniz!")]
        [MaxLength(50, ErrorMessage = "Məhsulun adı 50 simvoldan çox ola bilməz!")]
        [MinLength(3, ErrorMessage = "Məhsulun adı 3 simvoldan az ola bilməz!")]
        public string? ProductName { get; set; }

        [Required(ErrorMessage = "Məhsul haqqında geniş məlumat hissəsi boş buraxa bilməzsiniz!")]
        [MaxLength(2000, ErrorMessage = "Məhsul haqqında geniş məlumat hissəsi 2000 simvoldan çox ola bilməz!")]
        [MinLength(3, ErrorMessage = "Məhsul haqqında geniş məlumat hissəsi 3 simvoldan az ola bilməz!")]
        public string? ProductDescription { get; set; }

        public string? Color { get; set; }

        public string? Size { get; set; }

        [Required(ErrorMessage = "Məhsulun qiymətini boş buraxa bilməzsiniz!")]
        public string? Price { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int StoreID { get; set; }
        public int CategoryID { get; set; }
        public bool InStock { get; set; }
    }
}
