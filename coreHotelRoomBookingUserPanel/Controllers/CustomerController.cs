﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreHotelRoomBookingUserPanel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace coreHotelRoomBookingUserPanel.Controllers
{
    [Route("customer")]
    public class CustomerController : Controller
    {
        coreHotelRoomBookingFinalDatabaseContext context = new coreHotelRoomBookingFinalDatabaseContext();

        [Route("index")]
        public IActionResult Index()
        {
            var cname = HttpContext.Session.GetString("uname");
            
            if (cname != null)
            {
                int custId = int.Parse(HttpContext.Session.GetString("cID"));
                return RedirectToAction("Checkout", "Booking", new { @id = custId });

            }
            else
            {
                return View("Index");
            }
            
        }

        [Route("mylogin")]
        [HttpPost]
        public IActionResult MyLogin(string username, string password)
        {
            var user = context.Customers.Where(x => x.CustomerFirstName == username).SingleOrDefault();
            if (user == null)
            {
                ViewBag.Error = "Invalid Credentials";
                return View("Index");
            }
            else
            {
                var userName = user.CustomerFirstName;
                int custId = user.CustomerId;
                var passWord = user.CustomerPassword;
                if (username != null && password != null && username.Equals(userName) && password.Equals(passWord))
                {
                    HttpContext.Session.SetString("uname", username);
                    HttpContext.Session.SetString("cID", custId.ToString());
                    return RedirectToAction("Checkout","Booking",new { @id = custId });
                }
                else
                {
                    ViewBag.Error = "Invalid Credentials";
                    return View("Index");
                }
            }
        }

        [Route("logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("uname");
            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Customers c1)
        {
            context.Customers.Add(c1);
            context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }
    }
}