using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace coreHotelRoomBookingAdminPortal.Models
{
    public class RoomFacility
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int RoomFacilityId { get; set; }
        public bool IsAvilable { get; set; }
        public bool Wifi { get; set; }
        public bool AirConditioner { get; set; }
        public bool Ekettle { get; set; }
        public bool Refrigerator { get; set; }
        public string RoomFacilityDescription { get; set; }

        public int RoomId { get; set; }

        //Navigation  Property
        public HotelRoom HotelRoom { get; set; }
    }
}
