using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Card
    {
        [Key]
        public int CardID { get; set; }
        public string? UserID { get; set; }
        public AppUser? User { get; set; }
        public string? CardName { get; set; }
        public long Code16 { get; set; }
        public string? Name { get; set; }
        public string? EndOfDate { get; set; }
        public int SecurityCode { get; set; }
        public List<Amount>? Amount { get; set;}
    }
}
