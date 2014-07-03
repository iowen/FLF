using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FLine.Models
{
    public class CrossfitRepository :ICrossfitRepository
    {
                 private FLDataDataContext db;

        public CrossfitRepository(FLDataDataContext context)
        {
            db = context;
        }
        public Crossfit getCrossfit()
        {
            return db.Crossfits.First();
        }

        public bool updateCrossfit(Crossfit crossfit)
    {
        var c = db.Crossfits.First();
        c.Caption = crossfit.Caption;
        c.Description = crossfit.Description;
        c.Title = crossfit.Title;
        c.WODDescription = crossfit.WODDescription;
        try
        {
            db.SubmitChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return true;
    }
    }
}