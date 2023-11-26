using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Amount
    {
        public int AmountID { get; set; }
        public int CardID { get; set; }
        public Card? Card { get; set; }
        public string? AmountCount { get; set; }
    }
}
