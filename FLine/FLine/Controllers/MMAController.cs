using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FLine.Models;

namespace FLine.Controllers
{
    public class MMAController : Controller
    {
        //
        // GET: /Team/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Trainers()
        {
            var tRepo = new TrainerRepository(new FLDataDataContext());
            var trainers = tRepo.getAllTrainers();
            ViewBag.trainers = trainers;
            return View();
        }

        public ActionResult Fighters()
        {
            var fRepo = new FighterRepository(new FLDataDataContext());
            var fighters = fRepo.getAllFighters();
            ViewBag.fighters = fighters;
            return View();
        }

        public ActionResult Trainer(int id)
        {
            var tRepo = new TrainerRepository(new FLDataDataContext());
            var trainer = tRepo.getTrainer(id);
            ViewBag.trainer = trainer;
            return View();
        }

        public ActionResult Fighter(int id)
        {
            var fRepo = new FighterRepository(new FLDataDataContext());
            var fighter = fRepo.getFighter(id);
            ViewBag.fighter = fighter;
            return View();
        }

    }
}
