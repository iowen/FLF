using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FLine.Models;

namespace FLine.Controllers
{
    public class CoachesController : Controller
    {
        //
        // GET: /Coaches/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string Add(string firstName, string lastName, string profilePic, string bGrnd)
        {
            var sCopy = profilePic;
            sCopy = sCopy.Replace("/temp", "");
            profilePic = Server.MapPath(profilePic);
            string loc = profilePic.Replace("\\temp", "");
            try
            {
                System.IO.File.Move(profilePic, loc);

                //       HttpCookie cookie = Request.Cookies.Get("flfit");
                // int id = int.Parse(cookie["accountId"]);
                Photo photo = new Photo() { Location = sCopy, Title = firstName+" "+lastName, AccountId = 1 };
                IPhotoRepository pRepo = new PhotoRepository(new FLDataDataContext());
                var pId = pRepo.addPhoto(photo);

                IAccountRepository aRepo = new AccountRepository(new FLDataDataContext());
                Account a = new Account() { FirstName = firstName, LastName = lastName, Email="na",Password="notset"};
                var aId = aRepo.addAccount(a);

                ICoachRepository cRepo = new CoachRepository(new FLDataDataContext());

                Coach coach = new Coach() { AccountId = aId, PhotoId = pId,Background=bGrnd };
                var cId = cRepo.addCoach(coach);

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
