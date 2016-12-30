namespace Contoso.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Slot")]
    public partial class Slot
    {
        public int Id { get; set; }

        public int DoctorId { get; set; }

        public int SlotNumber { get; set; }

        [Required]
        [StringLength(100)]
        public string SlotName { get; set; }

        public int ScheduleId { get; set; }

        public TimeSpan StartTime { get; set; }
    }
}
