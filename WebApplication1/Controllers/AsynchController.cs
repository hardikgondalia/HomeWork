using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class AsynchController : Controller
    {
        string Baseurl = "http://dummy.restapiexample.com/api/v1/";
        // GET: Asynch
        public ActionResult Index()
        {
            var watch = new Stopwatch();
            watch.Start();
            var Res = getEmployee();
            watch.Stop();
            ViewBag.timer = watch.ElapsedMilliseconds;
            return View("Index", Res);
        }

        public List<EmployeeModel> getEmployee()
        {
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
               
                var EmpResponse = new List<EmployeeModel>();
                var Res = client.GetAsync("employees");
                var result = Res.Result;
                //Checking the response is successful or not which is sent using HttpClient  
                if (result.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var r = result.Content.ReadAsStringAsync().Result;


                    EmpResponse = JsonConvert.DeserializeObject<List<EmployeeModel>>(r);

                    //Deserializing the response recieved from web api and storing into the Employee list  
                }
                //returning the employee list to view  
                return EmpResponse;
            }

        }

        public ActionResult GetList()
        {
            //Create a stopwatch for getting excution time  
            var watch = new Stopwatch();
            watch.Start();
            var country = GetCountry();
            var state = GetState();
            var city = GetCity();
            watch.Stop();
            ViewBag.WatchMilliseconds = watch.ElapsedMilliseconds;
            return View();
        }

        public async Task<ActionResult> GetListAsync()
        {
           
            //Create a stopwatch for getting excution time  
            var watch = new Stopwatch();
            watch.Start();
            var country = GetCountryAsync();
            var state = GetStateAsync();
            var city = GetCityAsync();
            var content = await country;
            var count = await state;
            var name = await city;

            ViewBag.response = content + count + name;
            watch.Stop();
            ViewBag.WatchMilliseconds = watch.ElapsedMilliseconds;
            return View();
        }

        public string GetCountry()
        {
            Thread.Sleep(3000); //Use - when you want to block the current thread.  
            return "India";
        }

        public string GetState()
        {
            Thread.Sleep(5000); //Use - when you want to block the current thread.  
            return "Gujarat";
        }

        public string GetCity()
        {
            Thread.Sleep(6000); //Use - when you want to block the current thread.  
            return "Junagadh";
        }

        public async Task<string> GetCountryAsync()
        {
            await Task.Delay(3000); //Use - when you want a logical delay without blocking the current thread.  
            return "India";
        }

        public async Task<string> GetStateAsync()
        {
            await Task.Delay(5000); //Use - when you want a logical delay without blocking the current thread.  
            return "Gujarat";
        }

        public async Task<string> GetCityAsync()
        {
            await Task.Delay(6000); //Use - when you want a logical delay without blocking the current thread.  
            return "Junagadh";
        }
    }
}