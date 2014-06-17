using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            return View();
        }
        public ActionResult Coach(string name)
        {
            return View();
        }

    }
}
