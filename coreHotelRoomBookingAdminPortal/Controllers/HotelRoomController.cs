using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreHotelRoomBookingAdminPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace coreHotelRoomBookingAdminPortal.Controllers
{
    public class HotelRoomController : Controller
    {
        HotelAdminDbContext context;

        public HotelRoomController(HotelAdminDbContext _context)
        {
            context = _context;
        }

        public IActionResult Index()
        {
            var hotelRoom = context.HotelRooms.ToList();
            return View(hotelRoom);
        }
        [HttpGet]
        public ViewResult Create()
        {
            ViewBag.hotel = new SelectList(context.Hotels, "HotelId", "HotelName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(HotelRoom e1)
        {
            context.HotelRooms.Add(e1);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ViewResult Details(int id)
        {
            HotelRoom hotelRoom = context.HotelRooms.Where(x => x.RoomId == id).SingleOrDefault();
            return View(hotelRoom);
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            HotelRoom hotelRoom = context.HotelRooms.Find(id);

            return View(hotelRoom);
        }

        [HttpPost]
        public ActionResult Delete(int id, HotelRoom e1)
        {
            var hotelRoom = context.HotelRooms.Where(x => x.RoomId == id).SingleOrDefault();
            context.HotelRooms.Remove(hotelRoom);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            HotelRoom ud = context.HotelRooms.Where(x => x.RoomId == id).SingleOrDefault();
            ViewBag.hotel = new SelectList(context.Hotels, "HotelId", "HotelName");
            return View(ud);
        }

        [HttpPost]
        public ActionResult Edit(int id, HotelRoom e1)
        {
            HotelRoom hotelRoom = context.HotelRooms.Where(x => x.RoomId == id).SingleOrDefault();
            hotelRoom.RoomType = e1.RoomType;
            hotelRoom.RoomPrice = e1.RoomPrice;
            hotelRoom.RoomDescription = e1.RoomDescription;
            hotelRoom.RoomImage = e1.RoomImage;
            hotelRoom.HotelId = e1.HotelId;
            //context.Entry(hotelRoom).CurrentValues.SetValues(e1);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}