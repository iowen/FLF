using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FLine.Models;
namespace FLine.Controllers
{
    public class UploadController : Controller
    {
        //
        // GET: /Upload/
        public  List<string> photoExtensions =new List<string> { "png", "jpeg", "jpg", "gif" };
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UploadPhoto(HttpPostedFileBase FileData)
        {
            var title = Path.GetFileNameWithoutExtension(FileData.FileName);
            var saveName = PhotoNameGen.GetRandomPhotoName() + Path.GetExtension(FileData.FileName);
            var path = Path.Combine(Server.MapPath("~/Images/Uploads/temp"),saveName);
                FileData.SaveAs(path);

            return Content(Url.Content(path));
        }
    }
}
