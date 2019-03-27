using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace coreHotelRoomBookingAdminPortal.Models
{
    public class Hotel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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


        public virtual HotelType HotelType { get; set; }
        public virtual List<HotelRoom> HotelRooms { get; set; }
        //public List<HotelRoom> HotelRooms { get; set; }

        //public HotelType HotelType { get; set; }
    }
}
