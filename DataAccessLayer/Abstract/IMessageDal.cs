using DataAccessLayer.Migrations;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
	public interface IMessageDal : IGenericDal<Message>
	{
		List<Message> GetMessageListByName(string id);
		List<Message> GetSentListByName(string id);
		Message GetMessage(int id);
		Message GetSentMessage(int id);
		List<Message> GetMessageListByID(string id);
		List<Message> DeletedInMessage(string id);
		List<Message> DeletedSentMessage(string id);
	}
}
