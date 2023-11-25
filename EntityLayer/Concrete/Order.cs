using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public string? SaleID { get; set; }
        public Sale? Sale { get; set; }
        public string? UserID { get; set; }
        public AppUser? User { get; set; }
        public int OrderDetailID { get; set;}
        public OrderDetail? OrderDetail { get; set; }
    }
}
