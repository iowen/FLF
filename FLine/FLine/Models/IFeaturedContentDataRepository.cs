using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FLine.Models
{
    public interface IFeaturedContentDataRepository 
    {
        List<FeaturedContentData> getAllFeaturedContentData();
        FeaturedContentData getFeaturedContentData(int fc);

        int addFeaturedContentData(FeaturedContentData fc);
        bool updateFeaturedContentData(FeaturedContentData fc);
    }
}