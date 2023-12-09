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
        public string? OrderCode { get; set; }
        public DateTime? OrderDateTime { get; set; }
        public string? UserID { get; set; }
        public AppUser? User { get; set; }
        public int CardID { get; set; }
        public Card? Card { get; set; }
        public int ProductID { get; set; }
        public Product? Product { get; set; }
        public int AdressID { get; set; }
        public Adress? Adress { get; set; }
        public int Count { get; set; }
        public int OrderStatusID { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public float? Price { get; set; }
    }
}
