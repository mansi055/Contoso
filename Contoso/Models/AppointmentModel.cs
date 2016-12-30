using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Contoso.Models
{
    public class AppointmentModel
    {
        public string Speciality { get; set; }

        public string Address { get; set; }

        // This property will hold all available specialities for selection
        public IEnumerable<SelectListItem> Specialities { get; set; }

        public virtual IEnumerable<SelectListItem> BranchNames { get; set; }

        public int ScheduleId { get; set; }

        public int DoctorId { get; set; }

        public int UserId { get; set; }
        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }
    }
}