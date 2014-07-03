using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FLine.Models;
namespace FLine.Controllers
{
    public class CrossfitController : Controller
    {
        //
        // GET: /Crossfit/

        public ActionResult Index()
        {
            var cRepo = new CrossfitRepository(new FLDataDataContext());
            ViewBag.crossfit = cRepo.getCrossfit();
            return View();
        }
        public string UpdateWorkoutImage(string workoutImage)
        {
            var sCopy = workoutImage;
            sCopy = sCopy.Replace("/temp", "");
            workoutImage = Server.MapPath(workoutImage);
            string loc = workoutImage.Replace("\\temp", "");
            try
            {
                System.IO.File.Move(workoutImage, loc);
                var pRepo = new PhotoRepository(new FLDataDataContext());
                var photo = new Photo() { AccountId = 1, Title = "crossfit", Location = sCopy };
                var pId = pRepo.addPhoto(photo);
                var cRepo = new CrossfitRepository(new FLDataDataContext());
                var c = cRepo.getCrossfit();
                c.PhotoId = pId;
                cRepo.updateCrossfit(c);
            }
            catch
            {
            }
            return "true";
        }
        public string Updatedescription(string Description)
        {
            var cRepo = new CrossfitRepository(new FLDataDataContext());
            var c = cRepo.getCrossfit();
            c.Description = Description;
            cRepo.updateCrossfit(c);
            return "true";
        }
        public string UpdateWOD(string Title, string Instructions, List<string> WODS)
        {
            var cRepo = new CrossfitRepository(new FLDataDataContext());
            var wRepo = new WODRepository(new FLDataDataContext());
            var c = cRepo.getCrossfit();
            c.Title = Title;
            c.WODDescription = Instructions;
            cRepo.updateCrossfit(c);
            wRepo.deleteWods();
            wRepo.addWods(WODS);
            return "true";
        }
        public string Updatecaption(string Caption)
        {
            var cRepo = new CrossfitRepository(new FLDataDataContext());
            var c = cRepo.getCrossfit();
            c.Caption = Caption;
            cRepo.updateCrossfit(c);
            return "true";
        }
    }
}
