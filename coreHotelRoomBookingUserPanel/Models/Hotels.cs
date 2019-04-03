using System;
using System.Collections.Generic;

namespace coreHotelRoomBookingUserPanel.Models
{
    public partial class Hotels
    {
        public Hotels()
        {
            HotelRooms = new HashSet<HotelRooms>();
        }

        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public string HotelAddress { get; set; }
        public string HotelDistrict { get; set; }
        public string HotelCity { get; set; }
        public string HotelState { get; set; }
        public string HotelCountry { get; set; }
        public string HotelEmailId { get; set; }
        public string HotelRating { get; set; }
        public long HotelContactNumber { get; set; }
        public string HotelImage { get; set; }
        public string HotelDescription { get; set; }
        public int HotelTypeId { get; set; }

        public HotelTypes HotelType { get; set; }
        public ICollection<HotelRooms> HotelRooms { get; set; }
    }
}
