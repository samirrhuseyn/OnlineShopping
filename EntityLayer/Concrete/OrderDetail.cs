using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }
        public int Count { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? Adress { get; set; }
        List<Order>? Order { get; set; }
    }
}
