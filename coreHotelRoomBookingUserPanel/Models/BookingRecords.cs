using System;
using System.Collections.Generic;

namespace coreHotelRoomBookingUserPanel.Models
{
    public partial class BookingRecords
    {
        public int BookingId { get; set; }
        public int RoomId { get; set; }
        public int Quantity { get; set; }

        public Bookings Booking { get; set; }
        public HotelRooms Room { get; set; }
    }
}
