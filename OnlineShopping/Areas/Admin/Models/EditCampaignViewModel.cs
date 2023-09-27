using System.ComponentModel.DataAnnotations;

namespace OnlineShopping.Areas.Admin.Models
{
    public class EditCampaignViewModel
    {
        [Key]
        public int CampaignID { get; set; }

        [Required(ErrorMessage = "Kompaniya başlığı daxil edin!")]
        [MaxLength(50, ErrorMessage = "Kompaniya başlığı 50 simvoldan çox ola bilməz!")]
        [MinLength(5, ErrorMessage = "Kompaniya başlığı 5 simvoldan az ola bilməz!")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Kompaniya haqqında məlumatı daxil edin!")]
        [MaxLength(2000, ErrorMessage = "Kompaniya haqqında məlumat 2000 simvoldan çox ola bilməz!")]
        [MinLength(5, ErrorMessage = "Kompaniya haqqında məlumat 5 simvoldan az ola bilməz!")]
        public string? Content { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public IFormFile? Image { get; set; }
        public string? ImagePreview { get; set; }
        public bool IsExpired { get; set; }
        public int StoreID { get; set; }
    }
}
