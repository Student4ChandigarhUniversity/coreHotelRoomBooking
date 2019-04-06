using System;
using System.Collections.Generic;

namespace coreHotelRoomBookingUserPanel.Models
{
    public partial class Feedbacks
    {
        public int FeedbackId { get; set; }
        public int Appearance { get; set; }
        public string Eexpectation { get; set; }
        public string ImproveServices { get; set; }
        public string Comments { get; set; }
        public int HotelId { get; set; }
        public int CustomerId { get; set; }
    }
}
