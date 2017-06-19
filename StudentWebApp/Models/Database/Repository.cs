using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentWebApp.Models.Database
{
    public class Repository
    {
        StudentModelContainer db = new StudentModelContainer();

        public List<Student> GetStudents()
        {
            return db.Students.ToList();
        }
        public List<Course> GetCourses()
        {
            return db.Courses.ToList();
        }
    }
}