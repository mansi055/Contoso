namespace Contoso.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SlotBooking : DbContext
    {
        public SlotBooking()
            : base("name=SlotBooking")
        {
        }

        public virtual DbSet<Slot> Slots { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
