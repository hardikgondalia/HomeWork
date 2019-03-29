using System;
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

    public static class PersonList
    {
        public static List<Person> list()
        {
            return new List<Person> {
                new Person() { id = 1, firstName = "Hardik", lastName ="Gondalia"},
                new Person() { id = 2, firstName = "John", lastName = "Cena"},
                new Person() { id = 3, firstName = "Vivek", lastName= "Oberoi"}
            };
        }
    }

    public class P
    {
        public Person person { get; set; }
        public List<Person> list { get; set; }
    }
}