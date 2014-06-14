using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FLine.Controllers
{
    public class TeamController : Controller
    {
        //
        // GET: /Team/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Trainers()
        {
            return View();
        }

        public ActionResult Fighters()
        {
            return View();
        }

        public ActionResult Trainer(string name)
        {
            return View();
        }

        public ActionResult Fighter(string name)
        {
            return View();
        }

    }
}
