using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FLine.Models
{
    public interface IWODRepository
    {
        void deleteWods();
        void addWods(List<string> wod);
    }
}