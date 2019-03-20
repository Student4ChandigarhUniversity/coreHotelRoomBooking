using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace coreHotelRoomBookingAdminPortal.Models
{
    public class HotelType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int HotelTypeId { get; set; }
        [Required]
        public string HotelTypeName { get; set; }
        [Required]
        public string HotelTypeDescription { get; set; }

        //public List<Hotel> Hotels { get; set; }

        public virtual UserDetail UserDetail { get; set; }
        public virtual List<Hotel> Hotels { get; set; }
    }
}
