using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FLine.Models
{
    public interface IFeaturedContentRepository
    {
        List<FeaturedContent> getAllFeaturedContent();
        FeaturedContent getFeaturedContent(int fc);

        int addFeaturedContent(FeaturedContent fc);
        bool updateFeaturedContent(FeaturedContent fc);
    }
}