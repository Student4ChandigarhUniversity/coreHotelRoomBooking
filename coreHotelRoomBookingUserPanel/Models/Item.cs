using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreHotelRoomBookingUserPanel.Models
{
    public class Item
    {

        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public DateTime ItemAdded { get; set; }
        public int RoomId { get; set; }
        public HotelRooms HotelRooms { get; set; }
    }
}
