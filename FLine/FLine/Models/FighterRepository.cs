using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FLine.Models
{
    public class FighterRepository : IFighterRepository
    {
         private FLDataDataContext db;

        public FighterRepository(FLDataDataContext context)
        {
            db = context;
        }
        public List<Fighter> getAllFighters()
        {
            var fighteres = db.Fighters.ToList();
            return fighteres;
        }

        public Fighter getFighter(int id)
        {
            try
            {
                var cl = db.Fighters.Single(c => c.FighterId == id);

                return cl;
            }
            catch
            {
                Fighter cla = new Fighter();
                cla.FighterId = -1;
                return cla;
            }
        }
        public int addFighter(Fighter fighter)
        {
            db.Fighters.InsertOnSubmit(fighter);
            db.SubmitChanges();
            return fighter.FighterId;
        }
        public bool updateFighter(Fighter fighter)
        {
            return true;
        }
    }
}