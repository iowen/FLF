using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

    }
}
