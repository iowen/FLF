using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FLine.Models;
namespace FLine.Controllers
{
    public class ClassesController : Controller
    {
        //
        // GET: /Classes/

        public ActionResult Index()
        {
            var cRepo = new ClassRepository(new FLDataDataContext());
            var classes = cRepo.getAllClasses();
            ViewBag.classes = classes;
            return View();
        }

        [HttpPost]
    public Class Get(int id)
    {
        IClassRepository cRepo = new ClassRepository(new FLDataDataContext());
        var cl = cRepo.getClass(id);
        return cl;
    }

        public ActionResult ViewClass(int id)
        {
            var cRepo = new ClassRepository(new FLDataDataContext());
            var cl = cRepo.getClass(id);
            ViewBag.dow = new List<string>() { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
            ViewBag.cl = cl;
            return View();
        }

        [HttpPost]
        public string Add(string sTitle, string sDesc, string sPic, List<string> sDays, List<string> sStarts, List<string> sEnds, string sTeacher)
        {
            var sCopy = sPic;
            sCopy = sCopy.Replace("/temp","");

            sPic = Server.MapPath(sPic);
            string loc = sPic.Replace("\\temp","");
            try
            {
                System.IO.File.Move(sPic, loc);
           
                 //       HttpCookie cookie = Request.Cookies.Get("flfit");
           // int id = int.Parse(cookie["accountId"]);
            Photo photo = new Photo(){Location = sCopy,Title=sTitle,AccountId = 1};
            IPhotoRepository pRepo = new PhotoRepository(new FLDataDataContext());
            var pId = pRepo.addPhoto(photo);

            IAccountRepository aRepo = new AccountRepository(new FLDataDataContext());
            var t = sTeacher.Split(' ');
            var account = aRepo.getAccountByName(t[0], t[1]);
            if (account.AccountId > 0)
            {
                IClassRepository cRepo = new ClassRepository(new FLDataDataContext());
                Class c = new Class() { AccountId = account.AccountId, Description = sDesc, Name = sTitle, PhotoId = pId };
                var cId = cRepo.addClass(c);

                IClassTimeRepository ctRepo = new ClassTimeRepository(new FLDataDataContext());

                for (var i = 0; i < sDays.Count(); i++)
                {
                    ClassTime ct = new ClassTime() { ClassId = cId, Day = int.Parse(sDays[i]), StartTime = sStarts[i], EndTime = sEnds[i], };
                    ctRepo.addClassTime(ct);

                }
            }
            return "true";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "false";
            }
        }
    }
}
