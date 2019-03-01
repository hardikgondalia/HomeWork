using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DataTableController : Controller
    {
        // GET: DataTable
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        {
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = getAllEvent().Count(),
                iTotalDisplayRecords = getAllEvent().Count(),
                aaData = getAllEvent()
            }, JsonRequestBehavior.AllowGet);
        }

        private List<EventModel> getAllEvent()
        {
            List<EventModel> model = new List<EventModel>();

            EventModel model1 = new EventModel { EventID = 1, EventName = "Event 1", EventType = 1, EventTypeTitle = "General" };
            model1.EventScheduleList = new List<EventScheduleModel> { new EventScheduleModel {EventScheduleID = 1 }, new EventScheduleModel { EventScheduleID = 2 } };
            model.Add(model1);
            return model;
        }
    }
}