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
    public class ComplaintManager : IComplaintService
    {
        IComplaintDal _complaintDal;

        public ComplaintManager(IComplaintDal complaintDal)
        {
            _complaintDal = complaintDal;
        }

        public List<Complaint> GetComplaints()
        {
            return _complaintDal.GetComplaintList();
        }

        public void TAdd(Complaint t)
        {
            _complaintDal.Insert(t);
        }

        public void TDelete(Complaint t)
        {
            _complaintDal.Delete(t);
        }

        public Complaint TGetByID(int id)
        {
            return _complaintDal.GetByID(id);
        }

        public List<Complaint> TGetList()
        {
            return _complaintDal.GetList();
        }

        public void TUpdate(Complaint t)
        {
            _complaintDal.Update(t);
        }
    }
}
