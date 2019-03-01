using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class PopupController : Controller
    {
        // GET: Popup
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult OpenHTMLnew(string appID)
        {
            string html = "<p>test</p>";

            return Content(html, "text/html");
        }

        public ActionResult Test()
        {
            @ViewBag.Test = "Hello";
            return View();
        }

        public ActionResult Test1()
        {
            return View();
        }
    }
}