using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ISaleService : IGenericService<Sale>
    {
        Sale GetByID(string id);
    }
}
