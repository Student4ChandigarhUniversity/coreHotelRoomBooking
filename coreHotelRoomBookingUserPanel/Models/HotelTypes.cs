using System;
using System.Collections.Generic;

namespace coreHotelRoomBookingUserPanel.Models
{
    public partial class HotelTypes
    {
        public HotelTypes()
        {
            Hotels = new HashSet<Hotels>();
        }

        public int HotelTypeId { get; set; }
        public string HotelTypeName { get; set; }
        public string HotelTypeDescription { get; set; }
        public int? UserDetailUserId { get; set; }

        public UserDetails UserDetailUser { get; set; }
        public ICollection<Hotels> Hotels { get; set; }
    }
}
