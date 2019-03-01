using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class DemoEntityController : Controller
    {
        DemoDatabaseEntities db = new DemoDatabaseEntities();
        // GET: DemoEntity
        public ActionResult Index()
        {
            try
            {
                var students = db.GetStudentByID(1).ToList();

                Student_Mast model = new Student_Mast();
                model.First_Name = "John";
                model.Last_Name = "Abraham";
                model.Roll_No = 2;
                db.Student_Mast.Add(model);
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return View();
        }
    }
}