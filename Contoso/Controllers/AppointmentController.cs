using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Contoso.Models;

namespace Contoso.Controllers
{
    public class AppointmentController : Controller
    {
        BookingSystem db = new BookingSystem();

        //Getting initial values
        public ActionResult Index()
        {
            AppointmentModel app = new AppointmentModel();

            var specialites = GetAllSpeciality();
            var branches = GetAllRegion();

            app.BranchNames = GetSelectListBranch(branches);
            app.Specialities = GetSelectListItems(specialites);
            return View(app);
        }


        [HttpPost]
        public ActionResult Index(AppointmentModel app)
        {
            var specialities = GetAllSpeciality();
            app.Specialities = GetSelectListItems(specialities);

            var branches = GetAllRegion();
            app.BranchNames = GetSelectListBranch(branches);

            string selectedSpeciality = app.Speciality;
            string selectedBranch = app.Address;

            DoctorService docser = new DoctorService();

            List<User> usersList = docser.GetSelectedDoctors(selectedSpeciality, selectedBranch);

            ViewBag.DoctorSchedule = docser.GetDoctorSchedule(usersList);

            return View("Index", app);

        }

        [HttpGet]
        public ActionResult Done(AppointmentModel app)
        {
            SlotInfo slot = new SlotInfo();
            ViewBag.slots = slot.GetAvailableSlots(app);
            
            return View();
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

        private IEnumerable<string> GetAllRegion()
        {
            BranchInfo br = new BranchInfo();
            return br.GetAllBranchNames();            
        }
        private IEnumerable<SelectListItem> GetSelectListBranch(IEnumerable<string> elements)
        {
            // Create an empty list to hold result of the operation
            var selectList = new List<SelectListItem>();

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


        private IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<string> elements)
        {
            // Create an empty list to hold result of the operation
            var selectList = new List<SelectListItem>();

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


    }
}