using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepEfCoreIntroduction.DomainModel
{
    internal class Repository
    {
        public void AddCourse(Course course)
        {
            var dbContext = new PepContex();

            dbContext.Courses.Add(course);

            dbContext.SaveChanges();
        }

        public void UpdateCourse(int id,string name)
        {
            var dbContext = new PepContex();

            var course = dbContext.Courses.FirstOrDefault(c=>c.CourseId == id);
           
            course.Name = name;
            dbContext.SaveChanges();
        }

        public void PrintCourses()
        {
            var dbContext = new PepContex();
            var courses = dbContext.Courses.Include(c=>c.Teacher).AsNoTracking().ToList();


            foreach (var course in courses)
            {
                Console.WriteLine($"{course.CourseId}-{course.Name}\t\t{course.Teacher.FirstName},{course.Teacher.LastName}");
            }
        }
    }
}
