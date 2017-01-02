using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Contoso.Models;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace Contoso.Controllers
{
    public class AppointmentController : Controller
    {
        BookingSystem db = new BookingSystem();
        SlotBooking sb = new SlotBooking();

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
            string slotName = app.SlotName;

            string selectedSpeciality = app.Speciality;
            string selectedBranch = app.Address;

            DoctorService docser = new DoctorService();

            List<User> usersList = docser.GetSelectedDoctors(selectedSpeciality, selectedBranch);

            ViewBag.DoctorSchedule = docser.GetDoctorSchedule(usersList);
            ViewBag.Slotname = slotName;
            return View("Index", app);

        }

       
        public ActionResult Done(AppointmentModel app)
        {
            SlotInfo slots = new SlotInfo();
            List<TimeSpan> slotList = slots.GetAvailableSlots(app);
            ViewBag.availableSlots = slots.AvailableSlots(app.DoctorId, slotList);  // ---


            if (app.SlotSelected == true)
            { 
                try
                {
                    Slot slot = new Slot();
                    slot.DoctorId = app.DoctorId; //user id
                    slot.StartTime = app.SlotTime;
                    TimeSpan endtime = app.EndTime;
                    slot.SlotName = "mni";
                    slot.SlotNumber = 2;
                    app.ScheduleId = slots.GetScheduleId(app);


                    if(ModelState.IsValid)
                    {
                        sb.Slots.Add(slot);
                        sb.SaveChanges();
                        //return RedirectToAction("Thankyou");
                        return RedirectToAction("Index");
                    }
                }

                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
            }

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

        [HttpPost]
        public ActionResult Contact(AppointmentModel app)
        {
            ViewBag.user = app.UserCustomer;
            return View();
        }

        [HttpPost]
        public ActionResult BookingAppointment(AppointmentModel app)
        {
            SlotInfo slotinfo = new SlotInfo();
           // int success = slotinfo.SetSlot(app);
            return View();
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

        public ActionResult Thankyou()
        {
            TempData["alertMessage"] = "Whatever you want to alert the user with";
            return View();
        }


    }
}