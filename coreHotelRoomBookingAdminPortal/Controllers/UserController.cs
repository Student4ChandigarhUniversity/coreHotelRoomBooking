using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreHotelRoomBookingAdminPortal.Models;
using Microsoft.AspNetCore.Mvc;

namespace coreHotelRoomBookingAdminPortal.Controllers
{
    public class UserController : Controller
    {
        HotelAdminDbContext context;
    
        public UserController(HotelAdminDbContext _context)
        {
            context = _context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ViewResult Create()
        {
            //ViewBag.hotelType = new SelectList(context.HotelTypes, "HotelId", "HotelName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserDetail e1)
        {
                context.UserDetails.Add(e1);
                context.SaveChanges();
                return RedirectToAction("Index","Account");

        }
    }
}