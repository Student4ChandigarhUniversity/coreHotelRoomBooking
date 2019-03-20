using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace coreHotelRoomBookingAdminPortal.Models
{
    public class HotelRoom
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int RoomId { get; set; }
        public string RoomType { get; set; }
        public int RoomPrice { get; set; }
        public string RoomDescription { get; set; }
        public string RoomImage { get; set; }


        public int HotelId { get; set; }

        //Navigation Properties

        public RoomFacility RoomFacility { get; set; }
        public virtual Booking Booking { get; set; }
        public virtual Hotel Hotel { get; set; }
        //public Hotel Hotel { get; set; }
        //public RoomFacility RoomFacility { get; set; }
    }
}
