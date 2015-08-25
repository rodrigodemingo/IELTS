using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net;
using IELTSDataLayer;
using Newtonsoft.Json;
using System.Net.Mime;

namespace IELTS_Portal.Controllers
{
    public class RegisterTestController : Controller
    {
        //
        // GET: /RegisterTest/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewApplication()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewApplication(TestInfo testInfo)
        {
            string response = "";
            if (ModelState.IsValid)
            {
                response = new RegisterRepository().RegisterTest(testInfo);

                MailMessage message = new MailMessage();
                string username = "nbsmadhusudanan@gmail.com";
                string password = "1ndustries";
                string receiverEmail = testInfo.StudentInfo.AddressInfo.Email;
                ContentType mimeType = new ContentType("text/html");
                AlternateView alternate = AlternateView.CreateAlternateViewFromString("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\"> <html><head><META http-equiv=Content-Type content=\"text/html; charset=iso-8859-1\"></head><body><b>Dear " + testInfo.StudentInfo.FirstName + testInfo.StudentInfo.LastName + "</b>, <br /><br /><br />Greetings from IELTS !!! <br/><br/><br/> Your registration was successful. Thank You for registering IELTS Examination. <br/> <br/> <br/> Please see below the registration details <br/> <b>&nbsp;&nbsp;&nbsp;&nbsp;Your Receipt Number  :</b> " + testInfo.ReceiptNumber + ".<br /><b>&nbsp;&nbsp;&nbsp;&nbsp;Registered Date Time  :</b> " + testInfo.CreatedDate.ToString() + "<br /><br /> <b>Note: </b> Receipt Number and Passport or National Identity Card is mandatory to check your test results. <br /><br /><br /> Thank You,<br/><br/><br/> IELTS Admin</body></html>.", mimeType);
                message.From = new MailAddress(username);
                message.To.Add(receiverEmail);
                message.Subject = "IELTS Registration - Congrats, " + testInfo.StudentInfo.FirstName + " " + testInfo.StudentInfo.LastName + "!";
                //message.Body = "<html><head></head><body><b>Dear " + testInfo.StudentInfo.FirstName + testInfo.StudentInfo.LastName + "</b>, <br /><br /><br />Greetings from IELTS !!! <br/> Your registration was successful. Thank You for registering IELTS Examination. <br/> Please see below the registration details <br/> <dd /><b>Your Receipt Number  :</b> " + testInfo.ReceiptNumber + ".<br /><dd /><b>Registered Date Time  :</b> "+testInfo.CreatedDate.ToString()+"<br /><br /> <b>Note: </b> Receipt Number is mandatory to check your test results. <br /><br /><br /> Thank You, IELTS Admin</body></html>.";
                message.AlternateViews.Add(alternate);
                message.IsBodyHtml = true;
                message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.EnableSsl = true;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(username, password);
                smtpClient.Send(message);
                RedirectToAction("SubmitApplicationForm");
            }
            return View(testInfo);
        }
        public ActionResult SubmitApplicationForm()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetTestDetails(string identity, string receiptNumber)
        {
            try { 
                
                return Json(new RegisterRepository().GetTestDetails(identity, receiptNumber)); 

            }catch (Exception ex)
            {
                return Json("Candidate information not found", JsonRequestBehavior.AllowGet);
            }
        }
    }
}