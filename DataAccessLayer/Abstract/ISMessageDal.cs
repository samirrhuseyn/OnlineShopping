using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ISMessageDal : IGenericDal<StoreMessage>
    {
        List<StoreMessage> GetListMessage();
        StoreMessage GetMessageWithUser(int id);
    }
}
