using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FLine.Models;

namespace FLine.Controllers
{
    public class FeaturedContentController : Controller
    {
        //
        // GET: /FeaturedContent/

        public ActionResult Index()
        {
            return View();
        }

        public string Add(List<string> titles, List<string> texts, List<string> links, List<string> linkTexts, List<int> positions, string bGrnd)
        {
            var sCopy = bGrnd;
            sCopy = sCopy.Replace("/temp", "");
            bGrnd = Server.MapPath(bGrnd);
            string loc = bGrnd.Replace("\\temp", "");
            try
            {
                System.IO.File.Move(bGrnd, loc);

                //       HttpCookie cookie = Request.Cookies.Get("flfit");
                // int id = int.Parse(cookie["accountId"]);
                Photo photo = new Photo() { Location = sCopy, Title = titles[0], AccountId = 1 };
                IPhotoRepository pRepo = new PhotoRepository(new FLDataDataContext());
                var pId = pRepo.addPhoto(photo);

                var FRepo = new FeaturedContentRepository(new FLDataDataContext());
                var feature = new FeaturedContent() { PhotoId = pId};
                var fId = FRepo.addFeaturedContent(feature);

                var fcRepo = new FeaturedContentDataRepository(new FLDataDataContext());
                for (var i = 0; i< titles.Count; i++)
                {
                    var fc = new FeaturedContentData(){FeatureContentId = fId, Link = links[i], LinkText = linkTexts[i], Position = positions[i],Text=texts[i], TItle = titles[i]};
                    fcRepo.addFeaturedContentData(fc);
                }
 
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
