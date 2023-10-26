using DataAccessLayer.Migrations;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IMessageService : IGenericService<Message>
	{
		List<Message> GetMessagesByAdmin(string id);
		List<Message> GetMessageListByAdmin(string id);
		List<Message> GetSentMessageByAdmin(string id);
		Message GetMessage(int id);
		Message GetSentMessage(int id);
		List<Message> DeletedInMessage(string id);
		List<Message> DeletedSentMessage(string id);
	}
}
