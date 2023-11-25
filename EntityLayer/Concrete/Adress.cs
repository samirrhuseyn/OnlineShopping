using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Adress
    {
        [Key]
        public int AdressID { get; set; }
        public string? UserID { get; set; }
        public AppUser? User { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
    }
}
