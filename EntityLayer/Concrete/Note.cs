using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Note
    {
        [Key]
        public int NoteId { get; set; }
        public string? NoteTitle { get; set; }
        public string? NoteContent { get; set;}
        public DateTime? NoteDateTime { get; set; }
        public string? CollapseText { get; set; }
        public string? UserID { get; set; }
        public AppUser? User { get; set; }
    }
}
