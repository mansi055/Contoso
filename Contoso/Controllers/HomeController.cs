using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Contoso.Models;

namespace Contoso.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(AppointmentModel app)
        {
            ViewBag.m = app.DoctorId;
            return RedirectToAction("Book");
        }

        public ActionResult About(AppointmentModel app)
        {
            ViewBag.m = app.DoctorId;
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

       [HttpPost]
        public ActionResult Book(AppointmentModel app)
        {
            ViewBag.m = app.DoctorId;
            return View();
        }
    }
}