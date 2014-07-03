using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FLine.Models
{
    public class CoachRepository : ICoachRepository
    {
         private FLDataDataContext db;

        public CoachRepository(FLDataDataContext context)
        {
            db = context;
        }
        public List<Coach> getAllCoaches()
        {
            var coaches = db.Coaches.ToList();
            return coaches;
        }

        public Coach getCoach(int id)
        {
            try
            {
                var cl = db.Coaches.Single(c => c.CoachId == id);

                return cl;
            }
            catch
            {
                Coach cla = new Coach();
                cla.CoachId = -1;
                return cla;
            }
        }
        public int addCoach(Coach coach)
        {
            db.Coaches.InsertOnSubmit(coach);
            db.SubmitChanges();
            return coach.CoachId;
        }
        public bool updateCoach(Coach coach)
        {
            return true;
        }
    }
}