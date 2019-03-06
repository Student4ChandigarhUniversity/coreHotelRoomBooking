using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace coreHotelRoomBookingUserPanel.Models
{
    public partial class coreHotelRoomBookingFinalDbContext : DbContext
    {
        public coreHotelRoomBookingFinalDbContext()
        {
        }

        public coreHotelRoomBookingFinalDbContext(DbContextOptions<coreHotelRoomBookingFinalDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<HotelRooms> HotelRooms { get; set; }
        public virtual DbSet<Hotels> Hotels { get; set; }
        public virtual DbSet<HotelTypes> HotelTypes { get; set; }
        public virtual DbSet<RoomFacilities> RoomFacilities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=TRD-520; Database=coreHotelRoomBookingFinalDb;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
        }
    }
}
