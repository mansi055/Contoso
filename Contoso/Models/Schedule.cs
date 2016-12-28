namespace Contoso.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Schedule")]
    public partial class Schedule
    {
        public int Id { get; set; }

        public int DoctorId { get; set; }

        [Required]
        [StringLength(15)]
        public string Day { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        [Required]
        [StringLength(10)]
        public string Room { get; set; }

        public virtual Doctor Doctor { get; set; }
    }
}
