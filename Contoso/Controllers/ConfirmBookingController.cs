using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Contoso.Models;
using System.Web.Mvc;

namespace Contoso.Controllers
{
    public class ConfirmBookingController : Controller
    {
        // GET: ConfirmBooking
      

        [HttpGet]
        public ActionResult Index(AppointmentModel app)
        {
            /*DoctorService doc = new DoctorService();
            User us = doc.GetUserCustomer(app);
            ViewBag.user = us;
            return View("Index", app);*/
            return View();

        }
    }
}