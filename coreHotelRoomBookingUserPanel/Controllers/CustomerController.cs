using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreHotelRoomBookingUserPanel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            HttpContext.Session.Remove("Search");
            HttpContext.Session.Remove("CheckIn");
            HttpContext.Session.Remove("CheckOut");
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

        [Route("details")]
        public ViewResult Details()
        {
            int custId = int.Parse(HttpContext.Session.GetString("cID"));
            Customers cust = context.Customers.Where(x => x.CustomerId == custId).SingleOrDefault();
            return View(cust);
        }

        [Route("edit")]
        [HttpGet]
        public IActionResult Edit()
        {
            int custId = int.Parse(HttpContext.Session.GetString("cID"));
            Customers cust = context.Customers.Where(x => x.CustomerId == custId ).SingleOrDefault();
            return View(cust);
        }
        [Route("edit")]
        [HttpPost]
        public IActionResult Edit(Customers e1)
        {
            int custId = int.Parse(HttpContext.Session.GetString("cID"));

            Customers cust = context.Customers.Where(x => x.CustomerId == custId).SingleOrDefault();

            cust.CustomerFirstName = e1.CustomerFirstName;
            cust.CustomerLastName = e1.CustomerLastName;
            cust.CustomerAddress = e1.CustomerAddress;
            cust.CustomerContactNumber = e1.CustomerContactNumber;
            cust.CustomerEmailId = e1.CustomerEmailId;
            cust.Country = e1.Country;
            cust.State = e1.State;
            cust.Zip = e1.Zip;
            cust.CustomerPassword = e1.CustomerPassword;
            context.SaveChanges();
            return RedirectToAction("Details","Customer");
        }

        [Route("feedback")]
        [HttpGet]
        public ViewResult Feedback()
        {
            ViewBag.hotel = new SelectList(context.Hotels, "HotelId", "HotelName");
            return View();
        }
        [Route("feedback")]
        [HttpPost]
        public ActionResult Feedback(Feedbacks e1)
        {
            context.Feedbacks.Add(e1);
            context.SaveChanges();
            return RedirectToAction("Index","Home");
        }
    }
}