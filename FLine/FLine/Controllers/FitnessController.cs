using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FLine.Models;

namespace FLine.Controllers
{
    public class FitnessController : Controller
    {
        //
        // GET: /Fitness/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Coaches()
        {
            var cRepo = new CoachRepository(new FLDataDataContext());
            var coaches = cRepo.getAllCoaches();
            ViewBag.coaches = coaches;
            return View();
        }
        public ActionResult Coach(int id)
        {
            var cRepo = new CoachRepository(new FLDataDataContext());
            var coach = cRepo.getCoach(id);
            ViewBag.coach = coach;
            return View();
        }

    }
}
