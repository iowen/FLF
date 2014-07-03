using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FLine.Models
{
    public interface ICoachRepository
    {
        List<Coach> getAllCoaches();
        Coach getCoach(int id);


        int addCoach(Coach coach);
        bool updateCoach(Coach coach);
    }
}