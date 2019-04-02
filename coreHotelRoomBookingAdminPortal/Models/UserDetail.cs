using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace coreHotelRoomBookingAdminPortal.Models
{
    public class UserDetail
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmailId { get; set; }
        public string UserPassword { get; set; }
        public string UserType { get; set; }
        public long UserContactNumber { get; set; }

        public virtual List<HotelType> HotelTypes { get; set; }
    }
}
