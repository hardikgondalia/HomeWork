using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class RemoteValidationController : Controller
    {
        // GET: RemoteValidation
        public ActionResult Index()
        {
            return View();
        }
       
        public JsonResult UserNameExist(string UserName)
        {
            return Json(false, JsonRequestBehavior.AllowGet);
        }
    }
}