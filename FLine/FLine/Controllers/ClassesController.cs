using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FLine.Controllers
{
    public class ClassesController : Controller
    {
        //
        // GET: /Classes/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewClass(string name)
        {
            return View();
        }

    }
}
