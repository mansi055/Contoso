namespace Contoso.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BookingSystem : DbContext
    {
        public BookingSystem()
            : base("name=BookingSystem")
        {
        }

        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Branch>()
                .Property(e => e.PhoneNumber)
                .IsFixedLength();

            modelBuilder.Entity<Branch>()
                .HasMany(e => e.Doctors)
                .WithRequired(e => e.Branch)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Doctor>()
                .HasMany(e => e.Schedules)
                .WithRequired(e => e.Doctor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Schedule>()
                .Property(e => e.Day)
                .IsFixedLength();

            modelBuilder.Entity<Schedule>()
                .Property(e => e.Room)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.LastName)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.PhoneNumber)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .HasMany(e => e.Customers)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Doctors)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
