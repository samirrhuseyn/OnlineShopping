using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class CampaignSurvey
    {
        [Key]
        public int CampaignID { get; set; }
        public int StoreID { get; set; }
        public Store? Store { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? SendDate { get; set; }
        public bool IsApproved { get; set; }
    }
}
