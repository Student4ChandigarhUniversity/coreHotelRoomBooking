using System;
using System.Collections.Generic;

namespace coreHotelRoomBookingUserPanel.Models
{
    public partial class UserDetails
    {
        public UserDetails()
        {
            HotelTypes = new HashSet<HotelTypes>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmailId { get; set; }
        public string UserPassword { get; set; }
        public string UserType { get; set; }
        public long UserContactNumber { get; set; }

        public ICollection<HotelTypes> HotelTypes { get; set; }
    }
}
