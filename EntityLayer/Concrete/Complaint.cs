using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Complaint
    {
        [Key]
        public int ComplaintID { get; set; }
        public string? Reason { get; set; }
        public string? Image1 { get; set; }
        public string? Image2 { get; set; }
        public int ProductID { get; set; }
        public Product? Product { get; set; }
        public string? SalesCode { get; set; }
        public string? UserID { get; set; }
        public AppUser? User { get; set; }
        public DateTime? DateTime { get; set;}
        public bool IsLooked { get; set; }  
    }
}
