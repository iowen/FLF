using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FLine.Models
{
    public interface IClassTimeRepository
    {
        List<ClassTime> getAllClassTimes();
        int addClassTime(ClassTime time);
    }
}