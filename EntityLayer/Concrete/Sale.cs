using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Sale
    {
        [Key]
        public string? SaleID { get; set; }
        public Product? Product { get; set; }
        public int ProductID { get; set; }
        public DateTime DateTime { get; set; }
        List<Order>? Order { get; set; }
        public int CardID { get; set; }
        public Card? Card { get; set; }
    }
}
