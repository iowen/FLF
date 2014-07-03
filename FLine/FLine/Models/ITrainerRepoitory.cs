using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FLine.Models
{
    public interface ITrainerRepository
    {
        List<Trainer> getAllTrainers();
        Trainer getTrainer(int id);


        int addTrainer(Trainer trainer);
        bool updateTrainer(Trainer trainer);
    }
}