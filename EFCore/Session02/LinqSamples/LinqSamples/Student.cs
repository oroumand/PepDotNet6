using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqSamples
{

    public sealed class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Grade { get; set; }


        public static List<Student> GetStudents()
        {
            return new List<Student>
            {
                new Student
                {
                    Id = 1,
                    FirstName = "Faridd",
                    LastName ="Teheri",
                    Grade =18
                },
                new Student
                {
                    Id = 2,
                    FirstName = "Masoud",
                    LastName ="Teheri",
                    Grade =18
                },
                new Student
                {
                    Id = 3,
                    FirstName = "Arasha",
                    LastName ="Azhdari",
                    Grade =0
                },
                new Student
                {
                    Id = 4,
                    FirstName = "Hassan",
                    LastName ="Mohammi",
                    Grade =16
                },
                new Student
                {
                    Id = 5,
                    FirstName = "Alireza",
                    LastName ="Karimi",
                    Grade =4
                }

            };
        }


        public static void PrintStudentList(List<Student> students)
        {
            foreach (var item in students)
            {
                Console.WriteLine($"{item.Id}\t {item.FirstName} \t {item.LastName}\t {item.Grade}");
            }
            
        }


    }

    public class StudentCourse
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }

        public static List<StudentCourse> GetStudentCourses()
        {
            var students = new List<StudentCourse>()
            {
                new StudentCourse
                {
                    Id=1,
                    StudentId=1,
                    Name= "ASP.NET Core",
                    Score=18
                },
                new StudentCourse
                {
                    Id=2,
                    StudentId=1,
                    Name= "Microservice",
                    Score=16
                },
                new StudentCourse
                {
                    Id=3,
                    StudentId=2,
                    Name= "ASP.NET Core",
                    Score=20
                }

            };
            return students;
        }
    }
}
