using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.App_Start;

namespace WebApplication1.Controllers
{
    
    public class MobileController : Controller
    {
        
        // GET: Mobile
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            WebApplication1Entities db = new WebApplication1Entities();
            MobilesContext pc = new MobilesContext();

            List<Mobile> plist = db.Mobiles.ToList();

            return View(plist);
        }

    }
}