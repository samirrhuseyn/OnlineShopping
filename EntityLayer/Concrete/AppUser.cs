using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AppUser : IdentityUser
    {
        public string? ProfileImage { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public int StoreID { get; set; }
        public Store? Store { get; set; }
        public bool IsSeller { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }
        public string? Phone { get; set; }
        public List<Comment>? Comments { get; set; }
        public List<Reply>? Reply { get; set; }
    }
}
