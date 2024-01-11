using System.ComponentModel.DataAnnotations;

namespace OnlineShopping.Areas.Seller.Models
{
    public class OrderCancel
    {
        [Required(ErrorMessage = "Bu xana boş buraxıla bilməz!")]
        public string? OrderCode { get; set; }
    }
}
