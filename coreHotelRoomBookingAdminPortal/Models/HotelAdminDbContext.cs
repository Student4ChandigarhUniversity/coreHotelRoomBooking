using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreHotelRoomBookingAdminPortal.Models
{
    public class HotelAdminDbContext : DbContext
    {
        public DbSet<HotelType> HotelTypes { get; set; }

        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<HotelRoom> HotelRooms { get; set; }

        public DbSet<RoomFacility> RoomFacilities { get; set; }

        public DbSet<UserDetail> UserDetails { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Booking> Bookings { get; set; }

        public DbSet<BookingRecord> BookingRecords { get; set; }

        public DbSet<Feedback> Feedbacks { get; set; }

        public HotelAdminDbContext(DbContextOptions<HotelAdminDbContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>().HasOne(h => h.HotelType).WithMany(b => b.Hotels).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<HotelType>().HasOne(h => h.UserDetail).WithMany(b => b.HotelTypes).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Booking>().HasOne(h => h.Customer).WithMany(b => b.Bookings).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<HotelRoom>().HasOne(h => h.Hotel).WithMany(b => b.HotelRooms).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BookingRecord>(
                build =>
                {
                    build.HasKey(t => new { t.BookingId, t.RoomId });
                }
                );
            //modelBuilder.Entity<Customer>().HasOne(h => h.Payment).WithOne(b => b.Customer).OnDelete(DeleteBehavior.SetNull);
            //modelBuilder.Entity<HotelRoom>().HasOne(h => h.RoomFacility).WithOne(b => b.HotelRoom).OnDelete(DeleteBehavior.SetNull);
        }

    }
}
