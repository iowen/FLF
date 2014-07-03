using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FLine.Models
{
    public class ClassTimeRepository : IClassTimeRepository
    {
                private FLDataDataContext db;

        public ClassTimeRepository(FLDataDataContext context)
        {
            db = context;
        }

       public List<ClassTime> getAllClassTimes()
        {
            var ct = db.ClassTimes.ToList();
            return ct;
        }

       public int addClassTime(ClassTime time)
        {
            db.ClassTimes.InsertOnSubmit(time);
            db.SubmitChanges();
            return time.ClassTimeId;
        }
    }
}