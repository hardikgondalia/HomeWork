using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            var register = new Register { students = new List<Person> { new Person { firstName = "", lastName = "" }}, teachers = new List<Person> { new Person { lastName = "", firstName = "" }}};
            return View(register);
        }

        public ActionResult StudentManager()
        {
            var Person = new Person();
            return PartialView("_StudentPartial", Person);
        }

        public ActionResult TeacherManager()
        {
            var Person = new Person();
            return PartialView("_TeacherPartial", Person);
        }

        public ActionResult SavePerson(Register model)
        {
            string MailSubject = "mail testing";
            string MailBody = "mail sent to you";
        

            Mail_send("support@binaryrepublik.com" , "binal.rana@binaryrepublik.com", MailSubject, MailBody, String.Empty, String.Empty);
            return View();
        }

        public void Mail_send(string from, string to, string subject, string body, string cc, string bcc)
        {   
                try
                {
                    MailMessage objMail = new MailMessage();
                    SmtpClient client;
                    objMail.From = new MailAddress(from);
                    objMail.SubjectEncoding = Encoding.UTF8;                 
                    client = new SmtpClient();
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["SMTPuser"],
                    ConfigurationManager.AppSettings["SMTPpassword"]);
                    client.Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"]);
                    client.Host = ConfigurationManager.AppSettings["LocalHost"];
                    client.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSSL"]);
                    objMail.To.Add(to);
                    objMail.Subject = subject;
                    objMail.Body = body;
                    objMail.IsBodyHtml = true;
                    client.Send(objMail);
                }
                catch (Exception e)
                {
                 //   LogHelper.Error(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, "CustomError" + e.Message, e);
                }
            
        }

    }
}