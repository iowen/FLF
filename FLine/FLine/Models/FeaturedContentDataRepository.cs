using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FLine.Models
{
    public class FeaturedContentDataRepository : IFeaturedContentDataRepository
    {
         private FLDataDataContext db;

        public FeaturedContentDataRepository(FLDataDataContext context)
        {
            db = context;
        }


        public List<FeaturedContentData> getAllFeaturedContentData()
        {
            return db.FeaturedContentDatas.ToList();
        }

        public FeaturedContentData getFeaturedContentData(int fc)
        {
            try
            {
                var f = db.FeaturedContentDatas.Single(a => a.FeaturedContentDataId == fc);
                return f;
            }
            catch(Exception e)
            {
                var f = new FeaturedContentData();
                f.FeatureContentId = -1;
                return f;
            }
        }

        public int addFeaturedContentData(FeaturedContentData fc)
        {
            db.FeaturedContentDatas.InsertOnSubmit(fc);
            db.SubmitChanges();
            return fc.FeatureContentId;
        }

        public bool updateFeaturedContentData(FeaturedContentData fc)
        {
            return true;
        }
    }
}