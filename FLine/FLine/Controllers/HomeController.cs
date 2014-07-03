using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FLine.Models;
using System.Net;
using System.Net.Mail;

namespace FLine.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var clRepo = new ClassRepository(new FLDataDataContext());
            var cfRepo = new CrossfitRepository(new FLDataDataContext());
            var fRepo = new FeaturedContentRepository(new FLDataDataContext());
            ViewBag.classes = clRepo.getAllClasses().Take(4);
            ViewBag.crossfit = cfRepo.getCrossfit();
            ViewBag.featured = fRepo.getAllFeaturedContent();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public string Contact(string name, string email, string subject, string message)
        {

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("owen1.watson@gmail.com", "10f14lif3")
            };
            using (var msg = new MailMessage("owen1.watson@gmail.com", "owen1.watson@gmail.com")
            {
                Subject = "Frontline contact: "+name,
                Body = "Message from \n"+email+"\n\nSubject:\n\n"+subject+"\n\nMessage:\n"+message
            })
            {
                smtp.Send(msg);
            }
            return "true";
        }
    }
}
