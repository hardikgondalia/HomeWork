using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class AjaxController : Controller
    {
        // GET: Ajax
        public ActionResult Index()
        {
            return View();
        }

        public string UpdateDepartmentNameJSON(DepartmentsBO departmentBO)
        {
            string jsonOutput = null;
            try
            {
                jsonOutput = JsonConvert.SerializeObject("It is Working");
            }
            catch (Exception ex)
            {
            }
            return jsonOutput;
        }

        public class DepartmentsBO
        {
            public string dept_id { get; set; }
            public string dept_name { get; set; }
            public string msg { get; set; }
            public Boolean isException { get; set; }
        }

        public class EmployeeModel
        {
            public int EmpId { get; set; }
            public string EmpName { get; set; }
            public int Age { get; set; }
            public int Salary { get; set; }

        }

        [HttpGet]
        public JsonResult GetAllUser(int EmpId)
        {
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}