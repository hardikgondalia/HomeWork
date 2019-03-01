using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DemoController : Controller
    {
        private const string initVector = "pemgail9uzpgzl88";
        private const int keysize = 256;
        WebApplication1Entities db = new WebApplication1Entities();
        // GET: Demo
        public ActionResult Index()
        {
            DropDownModel model = new DropDownModel();

            var _str = Url.Encode(Encrypt("1"));

            return View(model);
        }

        public string Encrypt(string str)
        {
            byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(str);
            PasswordDeriveBytes password = new PasswordDeriveBytes("PM", null);
            byte[] keyBytes = password.GetBytes(keysize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] cipherTextBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            return Convert.ToBase64String(cipherTextBytes);
        }

        public ActionResult Test1(string P)
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public ActionResult Test1(Test1 model, string P)
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public ActionResult Toastr()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        public ActionResult MultipleSelect()
        {
            try
            {
                Multiselect model = new Multiselect();
                return View(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult MultipleSelect(Multiselect model)
        {
            try
            {
                return View(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public ActionResult ShowProgressbar()
        {
            return View();
        }

        public ActionResult ProductAjax()
        {
            ProductModel model = new ProductModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult ProductAjax(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("Product Name :" + model.Name + "</br/>");
                sb.Append("Description :" + model.Description + "</br/>");
                sb.Append("Manufacturer :" + model.Manufacturer + "</br/>");
                sb.Append("Price :" + model.BasePrice + "</br/>");
                sb.Append("Category :" + model.Category[model.CategoryId - 1].Text);
                return Content(sb.ToString());
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult SendMail()
        {
            String[] mailto = new string[] { "hardik.gondalia@binaryrepublik].com" };
            SendMessage("Testing", "Hello");
            return View();
        }

        public static void SendMessage(string subject, string body)
        {
            try
            {
                using (SmtpClient client = new SmtpClient("smtpout.secureserver.net"))
                {

                    client.EnableSsl = false;
                    client.Port = 80;
                    //client.Credentials = CredentialCache.DefaultNetworkCredentials;
                    //client.DeliveryMethod = SmtpDeliveryMethod.Network;

                    client.UseDefaultCredentials = true;
                    client.Credentials = new NetworkCredential("support@csh-solutions.com", "Hardik@123$");
                    MailMessage mail = new MailMessage();

                    mail.From = new MailAddress("support@csh-solutions.com", "CSH-Projects");
                    mail.To.Add("hardik.gondalia@binaryrepublik.com");


                    mail.Subject = subject;
                    mail.Body = body.Replace(Environment.NewLine, "<BR>");
                    mail.IsBodyHtml = true;

                    client.Send(mail);
                }
            }
            catch (Exception ex)
            {
                // exception handling
            }
        }

        public ActionResult AutoCompleteDemo()
        {
            return View();
        }

        public ActionResult DynamicFilterDatatable()
        {
            return View();
        }

        public ActionResult GeneralData()
        {
            GeneralData model = new GeneralData();
            model.DataList = db.Tbl_Configuration.Where(i => i.Option_Title == "GeneralData").Select(i => new data { title = i.Option_Value, key = i.ConfigureID }).ToList();
            return View(model);
        }

        public ActionResult DataManager()
        {
            data model = new data();
            return PartialView("_GeneralDataPartial", model);
        }

        [HttpPost]
        public ActionResult SaveData(GeneralData model)
        {
            return RedirectToAction("GeneralData","Demo");
        }

        [HttpPost]
        public JsonResult getSource(string firstname, string lastname)
        {
            List<user> userlist = new List<user>();
            user user1 = new user();
            user1.firstname = "Hardik";
            user1.lastname = "Gondalia";
            userlist.Add(user1);

            user user2 = new user();
            user2.firstname = "John";
            user2.lastname = "Abraham";
            userlist.Add(user2);

            user user3 = new user();
            user3.firstname = "Will";
            user3.lastname = "Smith";
            userlist.Add(user3);

            user user4 = new user();
            user4.firstname = "Martin";
            user4.lastname = "Luthor";
            userlist.Add(user4);

            //var myRegex = new Regex(".*\\b" + firstname + "\\b.*");
            //var u = userlist.Where(i => myRegex.IsMatch(i.firstname)).ToList();
            CultureInfo culture = CultureInfo.CurrentCulture;
            var filterlist = userlist.Where(i => culture.CompareInfo.IndexOf(i.firstname, firstname, CompareOptions.IgnoreCase) >= 0).ToList();
            filterlist = filterlist.Where(i => culture.CompareInfo.IndexOf(i.lastname, lastname, CompareOptions.IgnoreCase) >= 0).ToList();
            List<valueTextPair> firstnamelist = new List<valueTextPair>();
            List<valueTextPair> Lastnamelist = new List<valueTextPair>();
            firstnamelist = filterlist.Select(i => new valueTextPair { value = i.firstname, key = filterlist.IndexOf(i) + 1 }).ToList();
            Lastnamelist = filterlist.Select(i => new valueTextPair { value = i.lastname, key = filterlist.IndexOf(i) + 1 }).ToList();

            U u = new U();
            u.u1 = firstnamelist;
            u.u2 = Lastnamelist;
            return Json(u, JsonRequestBehavior.AllowGet);
        }
        public class user
        {
            public string firstname { get; set; }
            public string lastname { get; set; }
            public int value { get; set; }
        }

        public class U
        {
            public List<valueTextPair> u1 { get; set; }
            public List<valueTextPair> u2 { get; set; }
        }
        public class valueTextPair
        {
            public string value { get; set; }
            public int key { get; set; }
        }
    }
}