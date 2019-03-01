using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class data
    {
        public int key { get; set; }
        public string title { get; set; }
        public string value { get; set; }
    }

    public class GeneralData
    {
        public int AppointmentID { get; set; }
        public List<data> DataList { get; set; }
    }
}