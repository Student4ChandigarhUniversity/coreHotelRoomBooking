using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreHotelRoomBookingAdminPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace coreHotelRoomBookingAdminPortal.Controllers
{
    public class HotelController : Controller
    {
        HotelAdminDbContext context;

        public HotelController(HotelAdminDbContext _context)
        {
            context = _context;
        }

        public IActionResult Index()
        {
            var hotel = context.Hotels.ToList();
            return View(hotel);
        }
        [HttpGet]
        public ViewResult Create()
        {
            ViewBag.hotelType = new SelectList(context.HotelTypes, "HotelTypeId", "HotelTypeName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Hotel e1)
        {
            context.Hotels.Add(e1);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ViewResult Details(int id)
        {
            Hotel hotel = context.Hotels.Where(x => x.HotelId == id).SingleOrDefault();
            return View(hotel);
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            Hotel hotel = context.Hotels.Find(id);

            return View(hotel);
        }

        [HttpPost]
        public ActionResult Delete(int id, Hotel e1)
        {
            var hotel = context.Hotels.Where(x => x.HotelId == id).SingleOrDefault();
            context.Hotels.Remove(hotel);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Hotel ud = context.Hotels.Where(x => x.HotelId == id).SingleOrDefault();
            ViewBag.hotelType = new SelectList(context.HotelTypes, "HotelTypeId", "HotelTypeName");
            return View(ud);
        }

        [HttpPost]
        public ActionResult Edit(int id, Hotel h1)
        {
            Hotel hotel = context.Hotels.Where(x => x.HotelId == id).SingleOrDefault();
            
            hotel.HotelName = h1.HotelName;
            hotel.HotelAddress = h1.HotelAddress;
            hotel.HotelEmailId = h1.HotelEmailId;
            hotel.HotelDistrict = h1.HotelDistrict;
            hotel.HotelCity = h1.HotelCity;
            hotel.HotelState = h1.HotelState;
            hotel.HotelCountry = h1.HotelCountry;
            hotel.HotelContactNumber = h1.HotelContactNumber;
            hotel.HotelRating = h1.HotelRating;
            hotel.HotelImage = h1.HotelImage;
            hotel.HotelDescription = h1.HotelDescription;
            hotel.HotelTypeId = h1.HotelTypeId;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}