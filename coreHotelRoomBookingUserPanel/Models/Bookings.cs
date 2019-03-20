using System;
using System.Collections.Generic;

namespace coreHotelRoomBookingUserPanel.Models
{
    public partial class Bookings
    {
        public Bookings()
        {
            BookingRecords = new HashSet<BookingRecords>();
            HotelRooms = new HashSet<HotelRooms>();
        }


        public int BookingId { get; set; }
        public double TotalAmount { get; set; }
        public DateTime BookingDate { get; set; }
        public int HotelId { get; set; }
        public int? CustomerId { get; set; }

        public Customers Customer { get; set; }
        public ICollection<BookingRecords> BookingRecords { get; set; }
        public ICollection<HotelRooms> HotelRooms { get; set; }
    }
}
