using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IComplaintDal:IGenericDal<Complaint>
    {
        List<Complaint> GetComplaintList();
        Complaint GetComplaint(int id);
    }
}
