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
    public class SlotInfo
    {
        SlotBooking sv = new SlotBooking();
        BookingSystem db = new BookingSystem();

        public List<TimeSpan> GetAvailableSlots(AppointmentModel app)
        {
            TimeSpan startTime = app.StartTime;
            TimeSpan endTime = app.EndTime;
            TimeSpan span = endTime - startTime;
            TimeSpan half = new TimeSpan(span.Ticks / 15);
            List<TimeSpan> slots = new List<TimeSpan>();

            for(int i =0; i < half.Minutes; ++i)
            {
                slots.Add(startTime);
                startTime = startTime.Add(new TimeSpan(0, 15, 0));
            }
            return slots;
            //return AvailableSlots(app.DoctorId, slots);
        }

        public Dictionary<int, Dictionary<TimeSpan, string>> AvailableSlots(int docid, List<TimeSpan> slots)
        {
            Dictionary<int, Dictionary<TimeSpan, string>> available = new Dictionary<int, Dictionary<TimeSpan, string>>();
            Dictionary<TimeSpan, string> availableslot = new Dictionary<TimeSpan, string>();
            
            foreach (TimeSpan st in slots)
            {
                var result = (from s in sv.Slots
                              where s.DoctorId == docid
                              where s.StartTime == st
                              select s);
                if(result.Count() == 0)
                {
                    availableslot.Add(st, "Available");
                }
                else
                {
                    availableslot.Add(st, "Booked");
                }
            }

            available.Add(docid, availableslot);
            return available;
        }

        public int GetScheduleId(AppointmentModel app)
        {
            int scheduleid = (from sc in db.Schedules
                              where sc.DoctorId == app.UserId
                              select sc.Id).FirstOrDefault();

            return scheduleid;
        }

    

     }
}