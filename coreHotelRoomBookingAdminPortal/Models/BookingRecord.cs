using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace coreHotelRoomBookingAdminPortal.Models
{
    public class BookingRecord
    {


        [Column(Order = 0), Key, ForeignKey("Booking")]
        public int BookingId { get; set; }
        [Column(Order = 1), Key, ForeignKey("HotelRoom")]

        public int RoomId { get; set; }
        public int Quantity { get; set; }
        public Booking Booking { get; set; }
        public HotelRoom HotelRoom { get; set; }
    }
}
