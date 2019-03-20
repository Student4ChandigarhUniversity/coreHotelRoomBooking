using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace coreHotelRoomBookingUserPanel.Models
{
    public partial class Customers
    {
        public Customers()
        {
            Bookings = new HashSet<Bookings>();
        }

        public int CustomerId { get; set; }
        [Required]
        public string CustomerFirstName { get; set; }
        [Required]
        public string CustomerLastName { get; set; }
        [Required]
        public string CustomerAddress { get; set; }
        [Required]
        public long CustomerContactNumber { get; set; }
        [Required]
        public string CustomerEmailId { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public int Zip { get; set; }

        public Payments Payments { get; set; }
        public ICollection<Bookings> Bookings { get; set; }
    }
}
