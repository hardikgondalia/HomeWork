﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Register
    {
        public int id { get; set; }
        public List<Person> teachers { get; set; }
        public List<Person> students { get; set; }
        public string to { get; set; }
      //  string receiver, string subject, string message
    }

    public class Person
    {
        [Required]
        public int id { get; set; }

        [Required]
        public string firstName { get; set; }

        [Required]
        public string lastName { get; set; }
    }
}