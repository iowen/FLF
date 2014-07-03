using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FLine.Models
{
    public interface ICrossfitRepository
    {
        Crossfit getCrossfit();
        bool updateCrossfit(Crossfit crossfit);
    }
}