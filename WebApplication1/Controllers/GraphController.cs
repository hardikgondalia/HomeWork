using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class GraphController : Controller
    {
        // GET: Graph
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Demo()
        {
            return View();
        }

        [HttpPost]
        public JsonResult setCheqVendorSearchEntry(vendorEntry[] vendorEntrys)
        {

            //here I will write the code to store the records in database

            return Json("Success");  //for testing I return this string
        }

        public class vendorEntry
        {
            public string billno { get; set; }
            public string amount { get; set; }
        }
    }
}