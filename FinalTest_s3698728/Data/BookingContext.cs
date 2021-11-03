using FinalTest_s3698728.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalTest_s3698728.Data
{
    public class BookingContext : DbContext
    {
        public BookingContext(DbContextOptions<BookingContext> potions) : base(potions)
        {

        }
        public DbSet<Rooms> Rooms { get; set; }
        public DbSet<Bookings> Bookings { get; set; }
        public DbSet<Staff> Staff { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Rooms>().HasMany(x => x.Bookings).WithOne(x => x.Room).HasForeignKey(x => x.RoomID);

            builder.Entity<Staff>().HasMany(x => x.Bookings).WithOne(x => x.Staff).HasForeignKey(x => x.StaffID);

            builder.Entity<Bookings>().HasKey(x => x.StaffID);

            builder.Entity<Bookings>().HasKey(x => x.RoomID);
        }
    }
}
