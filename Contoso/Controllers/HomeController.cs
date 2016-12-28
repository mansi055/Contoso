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
        BookingSystem db = new BookingSystem();
        
        //Getting initial values
        public ActionResult Index()
        {
            AppointmentModel app = new AppointmentModel();

            var specialites = GetAllSpeciality();

            app.Specialities = GetSelectListItems(specialites);
            return View(app);
        }

        private IEnumerable<string> GetAllSpeciality()
        {
            return new List<string>
            {
                "ENT",
                "Cardio",
                "Dietian",
                "Dental Care",
                "Psychiatry"
            };
        }

        private IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<string> elements)
        {
            // Create an empty list to hold result of the operation
            var selectList = new List<SelectListItem>();

            // For each string in the 'elements' variable, create a new SelectListItem object
            // that has both its Value and Text properties set to a particular value.
            // This will result in MVC rendering each item as:
            //     <option value="State Name">State Name</option>
            foreach (var element in elements)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element,
                    Text = element
                });
            }

            return selectList;
        }

        [HttpPost]
        public ActionResult Index(AppointmentModel app)
        {
            var specialities = GetAllSpeciality();
            app.Specialities = GetSelectListItems(specialities);

            return RedirectToAction("Done");


           // return View("Index", app);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Done()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}