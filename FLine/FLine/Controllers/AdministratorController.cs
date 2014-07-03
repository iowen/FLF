using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FLine.Models;
namespace FLine.Controllers
{
    public class AdministratorController : Controller
    {
        //
        // GET: /Administrator/

        public ActionResult Index()
        {
            return View("Index", "~/Views/Shared/_LayoutAdmin.cshtml");
        }

        public ActionResult FeaturedContent()
        {
            var fRepo = new FeaturedContentRepository(new FLDataDataContext());
            ViewBag.featuredContent = fRepo.getAllFeaturedContent();
            return View("FeaturedContent", "~/Views/Shared/_LayoutAdmin.cshtml");
        }

        public ActionResult Crossfit()
        {
            var cRepo = new CrossfitRepository(new FLDataDataContext());
            ViewBag.crossfit = cRepo.getCrossfit();
            return View("Crossfit", "~/Views/Shared/_LayoutAdmin.cshtml");
        }

        public ActionResult Classes()
        {
            var cRepo = new ClassRepository(new FLDataDataContext());
            var aRepo = new AccountRepository(new FLDataDataContext());
            var classes = cRepo.getAllClasses();
                var accounts = aRepo.getAllAccounts();
                ViewBag.accounts = accounts;
         
            ViewBag.classes = classes;
            return View("Classes", "~/Views/Shared/_LayoutAdmin.cshtml");
        }

        public ActionResult Coaches()
        {
            var cRepo = new CoachRepository(new FLDataDataContext());
            ViewBag.coaches = cRepo.getAllCoaches();
            return View("Coaches", "~/Views/Shared/_LayoutAdmin.cshtml");
        }
        public ActionResult Fighters()
        {
            var fRepo = new FighterRepository(new FLDataDataContext());
            ViewBag.fighters = fRepo.getAllFighters();
            return View("Fighters", "~/Views/Shared/_LayoutAdmin.cshtml");
        }
        public ActionResult Trainers()
        {
            var tRepo = new TrainerRepository(new FLDataDataContext());
            ViewBag.trainers = tRepo.getAllTrainers();
            return View("Trainers", "~/Views/Shared/_LayoutAdmin.cshtml");
        }
    }
}
