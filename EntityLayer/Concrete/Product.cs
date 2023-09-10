using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string? Image1 { get; set; }
        public string? Image2 { get; set; }
        public string? Image3 { get; set; }
        public string? ProductName { get; set; }
        public string? Price { get; set; }
        public string? DiscountedPrice { get; set; }
        public string? ProductDescription { get; set; }
        public string? Color { get; set; }
        public string? Size { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int StoreID { get; set; }
        public Store? Store { get; set; }
        public Category? Category { get; set; }
        public int CategoryID { get; set; }
        public bool InStock { get; set; }
        public string? ProductCode { get; set; }
        public List<Sale>? Sale { get; set; }
        public List<Complaint>? Complaints { get; set; }
    }

    
}