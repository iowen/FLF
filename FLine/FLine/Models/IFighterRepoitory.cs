using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FLine.Models
{
    public interface IFighterRepository
    {
        List<Fighter> getAllFighters();
        Fighter getFighter(int id);


        int addFighter(Fighter fighter);
        bool updateFighter(Fighter fighter);
    }
}