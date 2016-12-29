using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Contoso.Models;

namespace Contoso.Controllers
{
    public class DoctorService
    {
        BookingSystem db = new BookingSystem();
        public List<User> GetSelectedDoctors(string spec, string branch)
        {
            int branchAddr = (from br in db.Branches
                          where br.Address == branch
                          select br.Id).FirstOrDefault();

           
            var docs = (from us in db.Users
                        join d in db.Doctors on us.Id equals d.UserID
                        join br in db.Branches on d.BranchID equals br.Id
                        where d.Speciality == spec 
                        where d.BranchID == branchAddr                 
                        select us);
            return docs.ToList();
        }

    }
}

