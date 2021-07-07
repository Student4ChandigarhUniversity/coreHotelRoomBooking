using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace coreHotelRoomBookingAdminPortal.Models
{
    public class Customer
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerAddress { get; set; }
        public long CustomerContactNumber { get; set; }
        public string CustomerEmailId { get; set; }
        public string CustomerPassword { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }

        //Relationship
        public virtual List<Booking> Bookings { get; set; }
        //public Payment Payment { get; set; }
    }
}
