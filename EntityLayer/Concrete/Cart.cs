using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Cart
    {
        [Key]
        public int CartID { get;  set; }
        public string? UserID { get; set; }
        public AppUser? User { get; set; }
        public int ProductID { get; set; }
        public Product? Product { get; set; }
        public int Count { get; set; }
        public DateTime AddDateTime { get; set; }
    }
}
