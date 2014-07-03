using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FLine.Models
{
    public interface IClassRepository
    {
        List<Class> getAllClasses();
        Class getClass(int id);
        Class getClass(string name);

        int addClass(Class classToAdd);
        bool updateClass(Class classToUpdate);
    }
}