using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace coreHotelRoomBookingAdminPortal.Models
{
    public class Feedback
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FeedbackId { get; set; }
        public int Appearance { get; set; }
        public string Eexpectation { get; set; }
        public string ImproveServices { get; set; }
        public string Comments { get; set; }

        public int HotelId { get; set; }
        public int CustomerId { get; set; }
    }
}
