using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FLine.Models
{
    public class WODRepository : IWODRepository
    {
                         private FLDataDataContext db;

        public WODRepository(FLDataDataContext context)
        {
            db = context;
        }
        public void deleteWods()
        {
            db.WODs.DeleteAllOnSubmit(db.WODs);
            db.SubmitChanges();
        }
        public void addWods(List<string> wod)
        {
            foreach (var w in wod)
            {
                if (!string.IsNullOrWhiteSpace(w))
                    db.WODs.InsertOnSubmit(new WOD() { Text = w, CrossfitId = 1 });
            }
            db.SubmitChanges();
        }
    }
}