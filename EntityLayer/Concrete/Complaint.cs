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
        public int Reason { get; set; }
        public string? Image1 { get; set; }
        public string? Image2 { get; set; }
        public int ProductID { get; set; }
        public Product? Product { get; set; }
        public string? SalesCode { get; set; }
    }
}
