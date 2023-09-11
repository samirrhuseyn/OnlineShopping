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
    public class EfComplaintDal : GenericRepository<Complaint>, IComplaintDal
    {
        public Complaint GetComplaint(int id)
        {
            using (Context context = new Context())
            {
                return context.Complaints
                    .Include(x => x.User)
                    .Include(x => x.Product)
                    .FirstOrDefault(x => x.ComplaintID == id);
            }
        }

        public List<Complaint> GetComplaintList()
        {
            using (Context context = new Context())
            {
                return context.Complaints
                    .Include(x => x.User)
                    .Include(x => x.Product)
                    .OrderByDescending(x => x.DateTime)
                    .ToList();
            }
        }
    }
}
