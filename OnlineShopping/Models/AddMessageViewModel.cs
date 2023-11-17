using System.ComponentModel.DataAnnotations;

namespace OnlineShopping.Models
{
    public class AddMessageViewModel
    {
        [Key]
        public int MessageID { get; set; }
        public string? MessageTitle { get; set; }
        public string? MessageBody { get; set; }
        public int StoreID { get; set; }
        public string? UserID { get; set; }
    }
}
