using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public bool IsActive { get; set; }
        public List<Product>? Products { get; set; }
    }
}
