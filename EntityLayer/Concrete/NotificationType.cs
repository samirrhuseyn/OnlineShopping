using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class NotificationType
    {
        [Key]
        public int TypeID { get; set; }
        public string? TypeName { get; set; }
        public string? Icon { get; set; }
        public string? Color { get; set; }
        public List<Notification>? Notification { get; set; }

    }
}
