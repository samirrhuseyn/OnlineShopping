using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class OrderStatus
    {
        [Key]
        public int OrderStatusID { get; set; }
        public string? StatusName { get; set; }
        public string? StatusColor { get; set;}
        public List<Order>? Order { get; set; }
    }
}
