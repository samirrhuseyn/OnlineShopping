using EntityLayer.Concrete;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopping.Models
{
    public class AddOrderViewModel
    {
        [Key]
        public int OrderId { get; set; }
        public string? OrderCode { get; set; }
        public DateTime? OrderDateTime { get; set; }
        public string? UserID { get; set; }
        public int CardID { get; set; }
        public int ProductID { get; set; }
        public int AdressID { get; set; }
        public int Count { get; set; }
        public int OrderStatusID { get; set; }

        [Display(Name = "Müqavilə şərtləri")]
        [Required(ErrorMessage = "Müqavilə şərtləri ilə razılaşın!")]
        public bool IsApplied { get; set; }

        public float? Price { get; set; }
    }
}
