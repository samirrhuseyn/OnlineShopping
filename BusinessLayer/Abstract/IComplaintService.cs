﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IComplaintService:IGenericService<Complaint>
    {
        List<Complaint> GetComplaints();
        Complaint GetComplaint(int id);
    }
}
