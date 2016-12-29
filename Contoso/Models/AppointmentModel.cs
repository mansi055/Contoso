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

        public int BranchId { get; set; }

        // This property will hold all available specialities for selection
        public IEnumerable<SelectListItem> Specialities { get; set; }

        public virtual IEnumerable<SelectListItem> BranchNames { get; set; }
    }
}