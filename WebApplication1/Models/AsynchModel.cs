using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    
    public class EmployeeModel
    {
        [JsonProperty]
        public string id { get; set; }

        [JsonProperty]
        public string employee_name { get; private set; }

        [JsonProperty]
        public string employee_salary { get; private set; }

        [JsonProperty]
        public string employee_age { get; private set; }

        [JsonProperty]
        public string profile_image { get; private set; }
    }
}