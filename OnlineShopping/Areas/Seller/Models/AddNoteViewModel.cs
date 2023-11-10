using System.ComponentModel.DataAnnotations;

namespace OnlineShopping.Areas.Seller.Models
{
    public class AddNoteViewModel
    {
        [Key]
        public int NoteId { get; set; }
        public string? NoteTitle { get; set; }
        public string? NoteContent { get; set; }
        public DateTime? NoteDateTime { get; set; }
    }
}
