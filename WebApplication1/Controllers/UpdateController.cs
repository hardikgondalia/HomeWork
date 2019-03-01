using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DAL;

namespace WebApplication1.Controllers
{
    public class UpdateController : Controller
    {
        DemoDatabaseEntities db = null;
        Student _bal = null;
        public UpdateController()
        {
            this.db = new DemoDatabaseEntities();
            this._bal = new Student(db);
        }

        // GET: Update
        public ActionResult Index()
        {
            Student_Mast model = new Student_Mast();
            model = _bal.getStudentByID();
            model.First_Name = "Hardik";
            model.Last_Name = "Gondalia";
            db.SaveChanges();
            return View();
        }
    }
}