using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    [Table("Mobiles")]
    public class Mobile
    {
        public int Model { get; set; }
        public string Type { get; set; }
        public String Cost { get; set; }
    }
}