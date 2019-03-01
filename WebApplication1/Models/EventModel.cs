using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class EventModel
    {
        public Int64 EventID { get; set; }
        public string EventName { get; set; }
        public Int64 EventType { get; set; }
        public string EventTypeTitle { get; set; }
        public List<EventScheduleModel> EventScheduleList { get; set; }
    }

    public class EventScheduleModel
    {
        public Int64 EventScheduleID { get; set; }
        public DateTime EventStartDate { get; set; } = System.DateTime.Now;
        public DateTime EventEndDate { get; set; } = System.DateTime.Now.AddDays(7);
    }
}