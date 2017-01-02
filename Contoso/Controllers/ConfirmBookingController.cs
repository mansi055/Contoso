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
      

        [HttpPost]
        public ActionResult Index(AppointmentModel app)
        {
            User us = app.UserCustomer;
            ViewBag.user = us;
            return View("Index", app);

        }
    }
}