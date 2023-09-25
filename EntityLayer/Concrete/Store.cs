using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Store
    {
        [Key]
        public int StoreID { get; set; }
        public string? Name { get; set; }
        public string? LogoImage { get; set; }
        public string? Adress { get; set; }
        public bool IsActive { get; set; }
        public List<Product>? Products { get; set; }
        public List<CampaignSurvey>? Campaigns { get; set; }
        public List<AppUser>? AppUsers { get; set; }
        public List<Campaign>? Campaignss { get; set; }
    }
}
