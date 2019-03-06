using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using coreHotelRoomBookingUserPanel.Models;

namespace coreHotelRoomBookingUserPanel.Controllers
{
    public class HomeController : Controller
    {
        coreHotelRoomBookingFinalDbContext context = new coreHotelRoomBookingFinalDbContext();
        public IActionResult Index()
        {
            var hotel = context.Hotels.ToList();
            return View(hotel);
        }

        public IActionResult Details()
        {
            return View();
        }
    }
}
