using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using SendGrid;
using SendGrid.Helpers.Mail;
using SendgridMVCDemo.Models;

namespace SendgridMVCDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new ContactUsModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ContactUsModel formData)
        {
            Execute(formData).Wait();
            // re-display the web page
            return View(formData);
        }

        static async Task Execute(ContactUsModel formData)
        {
            var apiKey = "<<YOUR API KEY GOES HERE>>";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(formData.PersonEmail, formData.PersonName);
            var subject = formData.EmailSubject;
            var to = new EmailAddress("<<YOUR TO EMAIL ADDRESS HERE>>", "Example User");
            var plainTextContent = formData.EmailMessage;
            var htmlContent = formData.EmailMessage;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }

    }

}