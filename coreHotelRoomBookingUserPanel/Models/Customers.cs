using System;
using System.Collections.Generic;

namespace coreHotelRoomBookingUserPanel.Models
{
    public partial class Customers
    {
        public Customers()
        {
            Bookings = new HashSet<Bookings>();
        }

        public int CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerAddress { get; set; }
        public long CustomerContactNumber { get; set; }
        public string CustomerEmailId { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public string CustomerPassword { get; set; }

        public ICollection<Bookings> Bookings { get; set; }
    }
}
