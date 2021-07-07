using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreHotelRoomBookingAdminPortal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace coreHotelRoomBookingAdminPortal.Controllers
{
    //used to give different name to countroller for routing purpose.

    [Route("account")]

    public class AccountController : Controller
    {
        HotelAdminDbContext context;

        public AccountController(HotelAdminDbContext _context)
        {
            context = _context;
        }


        [Route("")]
        [Route("index")]
        [Route("~/")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [Route("login")]
        [HttpPost]
        public IActionResult Login(string username , string password)
        {
            if (username !=null && password != null && username.Equals("a") && password.Equals("1"))
            {
                HttpContext.Session.SetString("uname", username);
                return View("Home");
            }
            else
            {
                ViewBag.Error = "Invalid Credentials";
                return View("Index");
            }
        }


        [Route("logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("uname");
            return RedirectToAction("Index");
        }


        [Route("mylogin")]
        [HttpPost]
        public IActionResult MyLogin(string username, string password)
        {
            var user = context.UserDetails.Where(x => x.UserName == username).SingleOrDefault(); ;

            if ( user == null)
            {
                ViewBag.Error = "Invalid Credentials";
                return View("Index");
            }
            else
            {
                var userName = user.UserName ;
                var passWord = user.UserPassword;
                if (username != null && password != null && username.Equals(userName) && password.Equals(passWord))
                {
                    HttpContext.Session.SetString("uname", username);
                    return View("Home");
                }
                else
                {
                    ViewBag.Error = "Invalid Credentials";
                    return View("Index");
                }
            }

            
        }
    }
}