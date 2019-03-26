using System;
using System.Collections.Generic;

namespace coreHotelRoomBookingUserPanel.Models
{
    public partial class HotelRooms
    {
        public HotelRooms()
        {
            BookingRecords = new HashSet<BookingRecords>();
        }

        public int RoomId { get; set; }
        public string RoomType { get; set; }
        public int RoomPrice { get; set; }
        public string RoomDescription { get; set; }
        public string RoomImage { get; set; }
        public int HotelId { get; set; }

        public Hotels Hotel { get; set; }
        public RoomFacilities RoomFacilities { get; set; }
        public ICollection<BookingRecords> BookingRecords { get; set; }
    }
}
