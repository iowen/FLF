using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FLine.Models
{
    public class TrainerRepository : ITrainerRepository
    {
         private FLDataDataContext db;

        public TrainerRepository(FLDataDataContext context)
        {
            db = context;
        }
        public List<Trainer> getAllTrainers()
        {
            var coaches = db.Trainers.ToList();
            return coaches;
        }

        public Trainer getTrainer(int id)
        {
            try
            {
                var cl = db.Trainers.Single(c => c.TrainerId == id);

                return cl;
            }
            catch
            {
                Trainer cla = new Trainer();
                cla.TrainerId = -1;
                return cla;
            }
        }
        public int addTrainer(Trainer coach)
        {
            db.Trainers.InsertOnSubmit(coach);
            db.SubmitChanges();
            return coach.TrainerId;
        }
        public bool updateTrainer(Trainer coach)
        {
            return true;
        }
    }
}