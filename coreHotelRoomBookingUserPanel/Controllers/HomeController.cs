using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using coreHotelRoomBookingUserPanel.Models;
using coreHotelRoomBookingUserPanel.Helper;
using Microsoft.AspNetCore.Http;

namespace coreHotelRoomBookingUserPanel.Controllers
{
    public class HomeController : Controller
    {
        coreHotelRoomBookingFinalDatabaseContext context =new coreHotelRoomBookingFinalDatabaseContext() ;

        public IActionResult Index()
        {
            var hotel = context.Hotels.ToList();
            List<Item> booking = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "Booking");
            int count = 0;
            if (booking != null)
            {
                foreach (var item in booking)
                {
                    count++;
                }
                if (count != 0)
                {
                    HttpContext.Session.SetString("CartItem", count.ToString());
                }
               
            }
            

            return View(hotel);
            
        }
        public ViewResult Details(int id)
        {
            Hotels hotel = context.Hotels.Where(x => x.HotelId == id).SingleOrDefault();
            ViewBag.Hotel = hotel;

            int hotelTypeId = ViewBag.Hotel.HotelTypeId;
            HotelTypes hotelTypes = context.HotelTypes.Where(x => x.HotelTypeId == hotelTypeId).SingleOrDefault();
            ViewBag.HotelType = hotelTypes;
            return View();
        }

        public IActionResult HotelRoomsIndex(int id)
        {
            List<Item> booking = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "Booking");
            int count = 0;
            if (booking != null)
            {
                foreach (var item in booking)
                {
                    count++;
                }
                if (count != 0)
                {
                    HttpContext.Session.SetString("CartItem", count.ToString());
                }
            }
            var hotelRoom = context.HotelRooms.Where(x => x.HotelId == id).ToList();
            ViewBag.HotelRoomIndex = hotelRoom;
            TempData["hotel"] = id;
            return View(hotelRoom);
        }

        public ViewResult RoomsDetails(int id)
        {
            int hotelId = int.Parse(TempData["hotel"].ToString());
            Hotels hotel = context.Hotels.Where(x => x.HotelId == hotelId).SingleOrDefault();
            ViewBag.Hotel = hotel;

            HotelRooms hotelRoom = context.HotelRooms.Where(x => x.RoomId == id).SingleOrDefault();
            ViewBag.HotelRoom = hotelRoom;
            RoomFacilities roomFacilities = context.RoomFacilities.Where(x => x.RoomId == id).SingleOrDefault();
            ViewBag.RoomFacilities = roomFacilities;
            return View();
        }

        [Route("search")]
        [HttpGet]
        public IActionResult Search(string search)
        {
            ViewBag.Hotel = context.Hotels.Where(x => x.HotelName == search || x.HotelCity == search || x.HotelState == search || search == null).ToList();
            return View(context.Hotels.Where(x => x.HotelName == search || search == null).ToList());
        }
    }
}
