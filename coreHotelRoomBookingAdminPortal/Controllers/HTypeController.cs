using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreHotelRoomBookingAdminPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace coreHotelRoomBookingAdminPortal.Controllers
{
    public class HTypeController : Controller
    {
        HotelAdminDbContext context;
    
        public HTypeController(HotelAdminDbContext _context)
        {
            context = _context;
        }

        public IActionResult Index()
        {
            var hotelType = context.HotelTypes.ToList();
            return View(hotelType);
        }
        [HttpGet]
        public ViewResult Create()
        {
            //ViewBag.hotelType = new SelectList(context.HotelTypes, "HotelId", "HotelName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("HotelTypeName","HotelTypeDescription")] HotelType e1)
        {
            if (ModelState.IsValid)
            {
                context.HotelTypes.Add(e1);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(e1);
            
        }
        public ViewResult Details(int id)
        {
            HotelType hotelType = context.HotelTypes.Where(x => x.HotelTypeId == id).SingleOrDefault();
            return View(hotelType);
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            HotelType hotelType = context.HotelTypes.Find(id);

            return View(hotelType);
        }

        [HttpPost]
        public ActionResult Delete(int id, HotelType e1)
        {
            var hotelType = context.HotelTypes.Where(x => x.HotelTypeId == id).SingleOrDefault();
            context.HotelTypes.Remove(hotelType);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            HotelType ud = context.HotelTypes.Where(x => x.HotelTypeId == id).SingleOrDefault();
            //ViewBag.hotelType = new SelectList(context.Hotels, "HotelId", "HotelName",ud.Hotels);
            return View(ud);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( int id , [Bind("HotelTypeName", "HotelTypeDescription")] HotelType e1)
        {
            if (ModelState.IsValid)
            {
                HotelType hotelType = context.HotelTypes.Where(x => x.HotelTypeId == id).SingleOrDefault();
            hotelType.HotelTypeName = e1.HotelTypeName;
            hotelType.HotelTypeDescription = e1.HotelTypeDescription;
            //context.Entry(hotelType).CurrentValues.SetValues(e1);
            context.SaveChanges();
            return RedirectToAction("Index");
            }
            return View(e1);
        }
    }
}