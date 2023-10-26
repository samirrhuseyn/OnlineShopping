using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class MessageManager : IMessageService
	{
		IMessageDal _messageDal;

		public MessageManager(IMessageDal messageDal)
		{
			_messageDal = messageDal;
		}

		public List<Message> DeletedInMessage(string id)
		{
			return _messageDal.DeletedInMessage(id);
		}

		public List<Message> DeletedSentMessage(string id)
		{
			return _messageDal.DeletedSentMessage(id);
		}

		public Message GetMessage(int id)
		{
			return _messageDal.GetMessage(id);
		}

		public List<Message> GetMessageListByAdmin(string id)
		{
			return _messageDal.GetMessageListByName(id);
		}

		public List<Message> GetMessagesByAdmin(string id)
		{
			return _messageDal.GetMessageListByID(id);
		}

		public Message GetSentMessage(int id)
		{
			return _messageDal.GetSentMessage(id);
		}

		public List<Message> GetSentMessageByAdmin(string id)
		{
			return _messageDal.GetSentListByName(id);
		}

		public void TAdd(Message t)
		{
			_messageDal.Insert(t);
		}

		public void TDelete(Message t)
		{
			_messageDal.Delete(t);
		}

		public Message TGetByID(int id)
		{
			return _messageDal.GetByID(id);
		}

		public List<Message> TGetList()
		{
			return _messageDal.GetList();
		}

		public void TUpdate(Message t)
		{
			_messageDal.Update(t);
		}
	}
}
