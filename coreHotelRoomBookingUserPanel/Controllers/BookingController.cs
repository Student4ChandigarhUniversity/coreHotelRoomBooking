using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreHotelRoomBookingUserPanel.Helper;
using coreHotelRoomBookingUserPanel.Models;
using Microsoft.AspNetCore.Mvc;

namespace coreHotelRoomBookingUserPanel.Controllers
{
    [Route("booking")]
    public class BookingController : Controller
    {
        coreHotelRoomBookingFinalDbContext context = new coreHotelRoomBookingFinalDbContext();
        [Route ("index")]
        public IActionResult Index()
        {
            var booking = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "Booking");
            ViewBag.booking = booking;
            ViewBag.total = booking.Sum(item => item.HotelRooms.RoomPrice * item.Quantity);
            return View();
        }


        [Route("buy/{id}")]
        public IActionResult Buy (int id)
        {
            if (SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session,"Booking") == null)
            {
                List<Item> booking = new List<Item>();
                booking.Add(new Item
                {
                    HotelRooms = context.HotelRooms.Find(id),
                    Quantity = 1
                });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "Booking", booking);
            }
            else
            {
                List<Item> booking = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "Booking");
                int index = isExist(id);
                if(index != -1)
                {
                    booking[index].Quantity++;
                }
                else
                {
                    booking.Add(new Item
                    {
                        HotelRooms = context.HotelRooms.Find(id),
                        Quantity = 1
                    });
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "Booking", booking);
                }
                
            }
            return RedirectToAction("Index");
        }


        [Route("remove/{id}")]

        public IActionResult Remove (int id)
        {
            List<Item> booking = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "Booking");
            int index = isExist(id);
            booking.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "Booking", booking);
            return RedirectToAction("Index");
        }

        private int isExist(int id)
        {
            List<Item> booking = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "Booking");
            for (int i = 0; i < booking.Count; i++)
            {
                if (booking[i].HotelRooms.RoomId.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }
    }

}