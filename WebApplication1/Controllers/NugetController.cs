using JohnOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace WebApplication1.Controllers
{
    public class NugetController : Controller
    {
        JohnClass j = new JohnClass();
        // GET: Nuget
        public ActionResult Index()
        {
            var a = j.Sum(1, 2);
            var b = j.Sub(2, 1);
            return View(); 
        }
    }
}