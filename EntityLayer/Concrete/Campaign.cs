using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Campaign
	{
        public int CampaignID { get; set; }
		public string? Title { get; set; }
		public string? Content { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public string? Image { get; set; }
		public bool IsExpired { get; set;}
		public int StoreID { get; set; }
		public Store? Store { get; set; }
    }
}
