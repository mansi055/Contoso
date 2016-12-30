using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Contoso.Models;

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

            return AvailableSlots(app.DoctorId, slots);
        }

        public List<TimeSpan> AvailableSlots(int docid, List<TimeSpan> slots)
        {
            List<TimeSpan> available = new List<TimeSpan>();

            foreach (TimeSpan st in slots)
            {
                var result = (from s in sv.Slots
                              where s.DoctorId == docid
                              where s.StartTime == st
                              select s);
                if(result != null && result.Count() > 0)
                {
                    available.Add(st);
                }
            }
            
           return available;
        }
    }
}