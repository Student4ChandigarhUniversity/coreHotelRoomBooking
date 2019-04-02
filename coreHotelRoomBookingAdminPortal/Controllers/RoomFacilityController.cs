using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreHotelRoomBookingAdminPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace coreHotelRoomBookingAdminPortal.Controllers
{
    public class RoomFacilityController : Controller
    {
        HotelAdminDbContext context;
    
        public RoomFacilityController(HotelAdminDbContext _context)
        {
            context = _context;
        }

        public IActionResult Index()
        {
            var roomFacilities = context.RoomFacilities.ToList();
            return View(roomFacilities);
        }
        [HttpGet]
        public ViewResult Create()
        {
            ViewBag.hotelRoom = new SelectList(context.HotelRooms, "RoomId", "RoomType");
            return View();
        }
        [HttpPost]
        public ActionResult Create(RoomFacility e1)
        {
            try
            {
                context.RoomFacilities.Add(e1);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return RedirectToAction("Index");
        }
        public ViewResult Details(int id)
        {
            RoomFacility roomFacility = context.RoomFacilities.Where(x => x.RoomFacilityId == id).SingleOrDefault();
            return View(roomFacility);
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            RoomFacility roomFacility = context.RoomFacilities.Find(id);

            return View(roomFacility);
        }

        [HttpPost]
        public ActionResult Delete(int id, RoomFacility e1)
        {
            var facility = context.RoomFacilities.Where(x => x.RoomFacilityId == id).SingleOrDefault();
            context.RoomFacilities.Remove(facility);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            RoomFacility ud = context.RoomFacilities.Where(x => x.RoomFacilityId == id).SingleOrDefault();
            ViewBag.hotelRoom = new SelectList(context.HotelRooms, "RoomId", "RoomType",ud.RoomId);
            return View(ud);
        }

        [HttpPost]
        public ActionResult Edit(int id, RoomFacility e1)
        {
            RoomFacility hotelRoom = context.RoomFacilities.Where(x => x.RoomFacilityId == id).SingleOrDefault();
            hotelRoom.IsAvilable = e1.IsAvilable;
            hotelRoom.Wifi = e1.Wifi;
            hotelRoom.AirConditioner = e1.AirConditioner;
            hotelRoom.Ekettle = e1.Ekettle;
            hotelRoom.Refrigerator = e1.Refrigerator;
            hotelRoom.RoomFacilityDescription = e1.RoomFacilityDescription;

            //context.Entry(hotelRoom).CurrentValues.SetValues(e1);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}