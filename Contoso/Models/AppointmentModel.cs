using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Contoso.Models
{
    public class AppointmentModel
    {
        [Required]
        public string Speciality { get; set; }

        [Required]
        public string Address { get; set; }

        // This property will hold all available specialities for selection
        public IEnumerable<SelectListItem> Specialities { get; set; }

        public virtual IEnumerable<SelectListItem> BranchNames { get; set; }

        public int ScheduleId { get; set; }

        public int DoctorId { get; set; }

        public int UserId { get; set; }
        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public User UserCustomer { get; set; }

        public TimeSpan SlotTime { get; set; }

        [DefaultValue(false)]
        public bool SlotSelected { get; set; }

        [Required(ErrorMessage = "Please enter your name.")]
        [DisplayName("Your Name")]
        public string SlotName { get; set; }
    }
}