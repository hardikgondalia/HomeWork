using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CompanyEmployeeController : Controller
    {
        WebApplication1Entities db = new WebApplication1Entities();
        // GET: CompanyEmployee
        public ActionResult Index()
        {
            var newCompanyEmployee = new CompanyEmployee();
            newCompanyEmployee.employees = db.employees.Select(i => new Employee { id = i.id, address = i.address, jobtitle = i.jobtitle, name = i.name, number = i.number }).ToList();
            return View(newCompanyEmployee);
        }


        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var employee = db.employees.Find(id);
            db.employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index", "CompanyEmployee");
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "id,name,jobtitle,number,address")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee model = new employee();
                model.id = employee.id;
                model.name = employee.name;
                model.jobtitle = employee.jobtitle;
                model.number = employee.number;
                model.address = employee.address;
                db.employees.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index", "CompanyEmployee");
            }

            return View(employee);
        }
    }
}