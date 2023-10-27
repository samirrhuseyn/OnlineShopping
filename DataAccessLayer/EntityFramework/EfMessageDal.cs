using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
	public class EfMessageDal : GenericRepository<Message>, IMessageDal
	{
		public List<Message> DeletedInMessage(string id)
		{
			using (var context = new Context())
			{
				return context.Messages
					.Include(x => x.SenderUser)
					.Where(x => x.ReceiverID == id)
					.Where(x=>x.IsDelete == true)
					.OrderByDescending(x => x.MessageDate)
					.ToList();
			}
		}

		public List<Message> DeletedSentMessage(string id)
		{
            using (var context = new Context())
            {
                return context.Messages
                    .Include(x => x.RecieverUser)
                    .Where(x => x.SenderID == id)
                    .Where(x => x.IsDelete == true)
                    .OrderByDescending(x => x.MessageDate)
                    .ToList();
            }
        }

		public Message GetMessage(int id)
		{
			using (var context = new Context())
			{
				return context.Messages
					.Include(x => x.SenderUser)
					.Include(x=>x.SenderUser.Store)
					.FirstOrDefault(x => x.MessageID == id);
			}
		}

		public List<Message> GetMessageListByID(string id)
		{
			using (var context = new Context())
			{
				return context.Messages
					.Include(x => x.SenderUser)
					.Where(x => x.ReceiverID == id)
					.Where(x => x.IsDelete == false)
					.OrderByDescending(x => x.MessageDate)
					.ToList();
			}
		}

		public List<Message> GetMessageListByName(string id)
		{
			using (var context = new Context())
			{
				return context.Messages
					.Include(x => x.SenderUser)
					.Where(x => x.ReceiverID == id)
					.OrderByDescending(x => x.MessageDate)
					.Take(3)
					.ToList();
			}
		}

		public List<Message> GetSentListByName(string id)
		{
			using (var context = new Context())
			{
				return context.Messages
					.Include(x => x.RecieverUser)
					.Where(x => x.SenderID == id)
					.Where(x => x.IsDelete == false)
					.OrderByDescending(x => x.MessageDate)
					.ToList();
			}
		}

		public Message GetSentMessage(int id)
		{
			using (var context = new Context())
			{
				return context.Messages
					.Include(x => x.RecieverUser)
					.FirstOrDefault(x => x.MessageID == id);
			}
		}
	}
}
