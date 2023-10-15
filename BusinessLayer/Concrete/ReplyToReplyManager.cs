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
    public class ReplyToReplyManager : IReplyToReplyService
    {
        IReplyToReplyDal _replyToReplyDal;

        public ReplyToReplyManager(IReplyToReplyDal replyToReplyDal)
        {
            _replyToReplyDal = replyToReplyDal;
        }

        public List<ReplyToReply> GetReplyToReplyListByReplyID()
        {
            return _replyToReplyDal.ReplyToReplyListByReplyID();
        }

        public void TAdd(ReplyToReply t)
        {
            _replyToReplyDal.Insert(t);
        }

        public void TDelete(ReplyToReply t)
        {
            _replyToReplyDal.Delete(t);
        }

        public ReplyToReply TGetByID(int id)
        {
            return _replyToReplyDal.GetByID(id);
        }

        public List<ReplyToReply> TGetList()
        {
            return _replyToReplyDal.GetList();
        }

        public void TUpdate(ReplyToReply t)
        {
            _replyToReplyDal.Update(t);
        }
    }
}
