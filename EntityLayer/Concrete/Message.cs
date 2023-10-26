using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Message
	{
		[Key]
		public int MessageID { get; set; }
		public string SenderID { get; set; }
		public string ReceiverID { get; set; }
		public string Subject { get; set; }
		public string MessageDetails { get; set; }
		public DateTime MessageDate { get; set; }
		public bool IsDelete { get; set; }
		public bool IsRead { get; set; }
		public AppUser SenderUser { get; set; }
		public AppUser RecieverUser { get; set; }
	}
}
