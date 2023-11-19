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
    public class EfSMessageDal : GenericRepository<StoreMessage>, ISMessageDal
    {
        public List<StoreMessage> GetListMessage()
        {
            using (Context context = new Context())
            {
                return context.StoreMessages
                    .Include(x => x.User)
                    .OrderByDescending(x=>x.MessageDateTime)
                    .ToList();
            }
        }

        public StoreMessage GetMessageWithUser(int id)
        {
            using (Context context = new Context())
            {
                return context.StoreMessages
                    .Include(x => x.User)
                    .FirstOrDefault(x => x.MessageID == id);
            }
        }
    }
}
