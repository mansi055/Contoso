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

        public Dictionary<User, List<Schedule>> GetDoctorSchedule(List<User> docs)
        {
            Dictionary<User, List<Schedule>> docsSchedule = new Dictionary<User, List<Schedule>>();

            foreach (User us in docs)
            {
                int ft = (from d in db.Doctors
                          where d.UserID == us.Id
                          select d.Id).FirstOrDefault();
                var schedule = (from sc in db.Schedules
                                where sc.DoctorId == ft
                                select sc);

                docsSchedule.Add(us, schedule.ToList());
            }

            return docsSchedule;
        }

        public User GetUserCustomer(AppointmentModel app)
        {
            if(app.UserCustomer != null)
            {
                return app.UserCustomer;
            }

            return null;
        }


        public string GetSlotName(AppointmentModel app)
        {
            return app.SlotName;
        }

    }
}

