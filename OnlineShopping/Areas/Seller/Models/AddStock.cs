using System.ComponentModel.DataAnnotations;

namespace OnlineShopping.Areas.Seller.Models
{
    public class AddStock
    {
        [Required(ErrorMessage = "Bu xana boş buraxıla bilməz!")]
        public string? ProductCode { get; set; }

        [Required(ErrorMessage = "Bu xana boş buraxıla bilməz!")]
        public int Stock { get; set; }
    }
}
