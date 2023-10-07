using System.ComponentModel.DataAnnotations;

namespace OnlineShopping.Areas.Seller.Models
{
	public class DisscountByCodeViewModel
	{
        [Required(ErrorMessage = "Məhsul kodu daxil edin!")]
        public string? ProductCode { get; set; }
        public int Interest { get; set; }
    }
}
