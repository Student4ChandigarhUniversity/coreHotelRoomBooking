using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreHotelRoomBookingUserPanel.Models;
using Microsoft.AspNetCore.Mvc;

namespace coreHotelRoomBookingUserPanel.Controllers
{
    public class HotelRoomsController : Controller
    {
        coreHotelRoomBookingFinalDbContext context = new coreHotelRoomBookingFinalDbContext();

        public IActionResult Index()
        {
            var hotelRoom = context.HotelRooms.ToList();
            return View(hotelRoom);
        }
    }
}