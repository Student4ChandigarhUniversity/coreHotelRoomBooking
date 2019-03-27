using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace coreHotelRoomBookingUserPanel.Models
{
    public partial class coreHotelRoomBookingFinalDatabaseContext : DbContext
    {
        public coreHotelRoomBookingFinalDatabaseContext()
        {
        }

        public coreHotelRoomBookingFinalDatabaseContext(DbContextOptions<coreHotelRoomBookingFinalDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BookingRecords> BookingRecords { get; set; }
        public virtual DbSet<Bookings> Bookings { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<HotelRooms> HotelRooms { get; set; }
        public virtual DbSet<Hotels> Hotels { get; set; }
        public virtual DbSet<HotelTypes> HotelTypes { get; set; }
        public virtual DbSet<Payments> Payments { get; set; }
        public virtual DbSet<RoomFacilities> RoomFacilities { get; set; }
        public virtual DbSet<UserDetails> UserDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=TRD-520;Initial Catalog=coreHotelRoomBookingFinalDatabase;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookingRecords>(entity =>
            {
                entity.HasKey(e => new { e.BookingId, e.RoomId });

                entity.HasIndex(e => e.RoomId);

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.BookingRecords)
                    .HasForeignKey(d => d.BookingId);

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.BookingRecords)
                    .HasForeignKey(d => d.RoomId);
            });

            modelBuilder.Entity<Bookings>(entity =>
            {
                entity.HasKey(e => e.BookingId);

                entity.HasIndex(e => e.CustomerId);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustomerId);
            });

            modelBuilder.Entity<HotelRooms>(entity =>
            {
                entity.HasKey(e => e.RoomId);

                entity.HasIndex(e => e.HotelId);

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.HotelRooms)
                    .HasForeignKey(d => d.HotelId);
            });

            modelBuilder.Entity<Hotels>(entity =>
            {
                entity.HasKey(e => e.HotelId);

                entity.HasIndex(e => e.HotelTypeId);

                entity.HasOne(d => d.HotelType)
                    .WithMany(p => p.Hotels)
                    .HasForeignKey(d => d.HotelTypeId);
            });

            modelBuilder.Entity<HotelTypes>(entity =>
            {
                entity.HasKey(e => e.HotelTypeId);

                entity.HasIndex(e => e.UserDetailUserId);

                entity.Property(e => e.HotelTypeDescription).IsRequired();

                entity.Property(e => e.HotelTypeName).IsRequired();

                entity.HasOne(d => d.UserDetailUser)
                    .WithMany(p => p.HotelTypes)
                    .HasForeignKey(d => d.UserDetailUserId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Payments>(entity =>
            {
                entity.HasKey(e => e.PaymentId);

                entity.HasIndex(e => e.BookingId);

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.BookingId);
            });

            modelBuilder.Entity<RoomFacilities>(entity =>
            {
                entity.HasKey(e => e.RoomFacilityId);

                entity.HasIndex(e => e.RoomId)
                    .IsUnique();

                entity.HasOne(d => d.Room)
                    .WithOne(p => p.RoomFacilities)
                    .HasForeignKey<RoomFacilities>(d => d.RoomId);
            });

            modelBuilder.Entity<UserDetails>(entity =>
            {
                entity.HasKey(e => e.UserId);
            });
        }
    }
}
