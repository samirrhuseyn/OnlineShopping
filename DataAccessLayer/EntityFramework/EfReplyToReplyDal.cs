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
    public class EfReplyToReplyDal : GenericRepository<ReplyToReply>, IReplyToReplyDal
    {
        public List<ReplyToReply> ReplyToReplyListByReplyID()
        {
            using (Context context = new Context())
            {
                return context.ReplyToReplies
                    .Include(x => x.User)
                    .OrderByDescending(x => x.ReplyToReplyDateTime)
                    .ToList();
            }
        }
    }
}
