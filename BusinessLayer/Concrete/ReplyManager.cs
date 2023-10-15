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
    public class ReplyManager : IReplyService
    {
        IReplyDal _replyDal;

        public ReplyManager(IReplyDal replyDal)
        {
            _replyDal = replyDal;
        }

        public List<Reply> GetListWIthCommentID()
        {
            return _replyDal.ListByCommentId();
        }

        public void TAdd(Reply t)
        {
            _replyDal.Insert(t);
        }

        public void TDelete(Reply t)
        {
            _replyDal.Delete(t);
        }

        public Reply TGetByID(int id)
        {
            return _replyDal.GetByID(id);
        }

        public List<Reply> TGetList()
        {
            return _replyDal.GetList();
        }

        public void TUpdate(Reply t)
        {
            _replyDal.Update(t);
        }
    }
}
