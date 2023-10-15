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
    public class EfReplyDal : GenericRepository<Reply>, IReplyDal
    {
        public List<Reply> ListByCommentId()
        {
            using(Context context = new Context())
            {
                return context.Replies
                    .Include(x => x.User)
                    .OrderByDescending(x => x.ReplyDateTime)
                    .ToList();
            }
        }
    }
}
