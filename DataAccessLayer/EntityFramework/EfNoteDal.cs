using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfNoteDal : GenericRepository<Note>, INoteDal
    {
        public List<Note> GetListWithUser()
        {
            using(Context context =  new Context())
            {
                return context.Notes
                    .OrderByDescending(x=>x.NoteDateTime)
                    .ToList();
            }
        }
    }
}
