using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult Demo()
        {
            HomeModel model = (HomeModel)TempData["home"];
            return View(model);
        }

        [HttpPost]
        public ActionResult Demo(HomeModel model)
        {
            TempData["home"] = model;
            return RedirectToAction("Demo", "Home");
        }

        public ActionResult MorrisJS()
        {
            return View();
        }


        // GET: OrdersPerYears
        public ActionResult getData()
        {
            List<Detail> c = new List<Detail>();
            Detail c1 = new Detail();
            c1.Id = 1;
            c1.Year = 2000;
            c1.Product = "coffee";
            c1.TotalSales = 200;

            Detail c2 = new Detail();
            c1.Id = 2;
            c1.Year = 2000;
            c1.Product = "Tea";
            c1.TotalSales = 100;

            c.Add(c1);
            c.Add(c2);
            c.ToArray();
            return Json(c, JsonRequestBehavior.AllowGet);
        }

        public class Detail
        {
            public int Id { get; set; }
            public int Year { get; set; }
            public string Product { get; set; }
            public float TotalSales { get; set; }
        }

        public ActionResult LINQQuery()
        {
            List<LINQDATA> data = new List<LINQDATA>();
            LINQDATA data1 = new LINQDATA();
            data1.SID = 1;
            data1.RID = 1;
            data1.Schema_Name = "Franklin";
            data1.SType = "Equity";
            data1.InvestmentType = "Diversify";
            data1.Allocation = 50;
            data1.Lum_Sum_Amount = 25000;

            LINQDATA data2 = new LINQDATA();
            data2.SID = 2;
            data2.RID = 1;
            data2.Schema_Name = "Franklin";
            data2.SType = "Equity";
            data2.InvestmentType = "Diversify";
            data2.Allocation = 20;
            data2.Lum_Sum_Amount = 25000;

            LINQDATA data3 = new LINQDATA();
            data3.SID = 10;
            data1.RID = 1;
            data1.Schema_Name = "ICICI";
            data1.SType = "Debt";
            data1.InvestmentType = "Ultra Sort Term";
            data1.Allocation = 30;
            data1.Lum_Sum_Amount = 25000;

            data.Add(data1);
            data.Add(data2);
            data.Add(data3);

            var x = data.Select(i => new LINQDATA2 { Total = (i.Allocation / 100) * i.Lum_Sum_Amount }).ToList();

            return View();
        }

        public class LINQDATA
        {
            public Int64 SID { get; set; }
            public Int64 RID { get;set;}
            public string Schema_Name { get; set; }
            public string SType { get; set; }
            public string InvestmentType { get; set; }
            public int Allocation { get; set; }
            public int Lum_Sum_Amount { get; set; }
        }

        public class LINQDATA2
        {
            public Int64 SID { get; set; }
            public Int64 RID { get; set; }
            public string Schema_Name { get; set; }
            public string SType { get; set; }
            public string InvestmentType { get; set; }
            public int Allocation { get; set; }
            public int Lum_Sum_Amount { get; set; }
            public float Total { get; set; }
        }
    }
}