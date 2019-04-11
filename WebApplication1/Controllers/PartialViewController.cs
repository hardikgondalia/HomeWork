using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PartialViewController : Controller
    {
        // GET: PartialView
        public ActionResult Index()
        {
            Person p = new Person();
            return View(p);
        }

        [ChildActionOnly]
        public PartialViewResult GetList()
        {
            return PartialView("_PartialEmployeeList", PersonList.list());
        }
    }
}