﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FLine.Models
{
    public class ClassRepository :IClassRepository
    {
         private FLDataDataContext db;

        public ClassRepository(FLDataDataContext context)
        {
            db = context;
        }

        public List<Class> getAllClasses()
        {
            var classess = db.Classes.ToList();
            return classess;
        }

        public Class getClass(int id)
        {
            try
            {
                var cl = db.Classes.Single(c => c.ClassId == id);

                return cl;
            }
            catch
            {
                Class cla = new Class();
                cla.ClassId = -1;
                return cla;
            }
        }

        public Class getClass(string name)
        {
            try
            {
                var cl = db.Classes.Single(c => c.Name == name);

                return cl;
            }
            catch
            {
                Class cla = new Class();
                cla.ClassId = -1;
                return cla;
            }
        }

        public int addClass(Class classToAdd)
        {
            db.Classes.InsertOnSubmit(classToAdd);
            db.SubmitChanges();
            return classToAdd.ClassId;
        }

        public bool updateClass(Class classToUpdate)
        {
            return true;
        }
    }
}