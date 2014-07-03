using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FLine.Models
{
    public class FeaturedContentRepository : IFeaturedContentRepository
    {
                 private FLDataDataContext db;

        public FeaturedContentRepository(FLDataDataContext context)
        {
            db = context;
        }


        public List<FeaturedContent> getAllFeaturedContent()
        {
            return db.FeaturedContents.ToList();
        }

        public FeaturedContent getFeaturedContent(int fc)
        {
            try
            {
                var f = db.FeaturedContents.Single(a => a.FeaturedContentId == fc);
                return f;
            }
            catch (Exception e)
            {
                var f = new FeaturedContent();
                f.FeaturedContentId = -1;
                return f;
            }
        }

        public int addFeaturedContent(FeaturedContent fc)
        {
            db.FeaturedContents.InsertOnSubmit(fc);
            db.SubmitChanges();
            return fc.FeaturedContentId;
        }

        public bool updateFeaturedContent(FeaturedContent fc)
        {
            return true;
        }
    }
}