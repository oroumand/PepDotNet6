using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqSamples
{
    public class LinqQueries
    {
        public void FilterNamesWithoutLinq()
        {
            List<string> names = new List<string>
            {
                "Alireza Oroumand",
                "Farid Taheri",
                "Masoud Taheri",
                "Mohammad Abbasi",
                "Amir Almasi",
                "Hossein Azhdari",
                "Ahmad Rezaie",
                "Amirali Hosseini"
            };

            List<string> resul = new List<string>();

            foreach (string name in names)
            {
                if (name.StartsWith("A"))
                {
                    resul.Add(name);
                }
            }

            resul.Sort();

            foreach (var item in resul)
            {
                Console.WriteLine(item);
            }
        }
        public void FilterNamesWithLinqQuery()
        {
            List<string> names = new List<string>
            {
                "Alireza Oroumand",
                "Farid Taheri",
                "Masoud Taheri",
                "Mohammad Abbasi",
                "Amir Almasi",
                "Hossein Azhdari",
                "Ahmad Rezaie",
                "Amirali Hosseini"
            };

            var resul = 
                    from name in names 
                    where name.StartsWith("A") 
                    orderby name
                    select name;

            foreach (var item in resul)
            {
                Console.WriteLine(item);
            }
        }
        public void FilterNamesWithLinqMethod()
        {
            List<string> names = new List<string>
            {
                "Alireza Oroumand",
                "Farid Taheri",
                "Masoud Taheri",
                "Mohammad Abbasi",
                "Amir Almasi",
                "Hossein Azhdari",
                "Ahmad Rezaie",
                "Amirali Hosseini"
            };

            var resul = names.Where(c=>c.StartsWith("A")).OrderBy(c=>c).ToList();                    

            foreach (var item in resul)
            {
                Console.WriteLine(item);
            }
        }
        public void PrintDiffData()
        {
            List<int> numbers = new List<int>
            {
                1,
                2,
                3,
                4,
                5,
                6,
                7,
                10
            };

            var result = numbers.Where(c => c < 6);

            foreach (var number in result)
            {
                Console.WriteLine(number);
            }
            numbers.Add(1);
            numbers.Add(-100);
            numbers.Add(2);
          Console.WriteLine("".PadLeft(100,'-'));

            foreach (var number in result)
            {
                Console.WriteLine(number);
            }

        }

        public void WhereSampleMethoSyntax()
        {
            var students = Student.GetStudents();

            var aStudents = students.Where(c=>c.FirstName.StartsWith("A")).ToList();
            Student.PrintStudentList(aStudents);
        }

        public void WhereSampleMethoSyntaxAndIndex()
        {
            var students = Student.GetStudents();

            var aStudents = students.Where((c,index) => c.FirstName.StartsWith("A") && c.Grade > index).ToList();
            Student.PrintStudentList(aStudents);
        }

        public void WhereSampleQuerySyntax()
        {
            var students = Student.GetStudents();

            var aStudents = (from student in students 
                            where student.FirstName.StartsWith("A")
                            select student).ToList();
            Student.PrintStudentList(aStudents);
        }
   
        public void FilterByType()
        {
            List<object> objects = new List<object>
            {
                1,2,3,false,4,5,6,7,8,9,"Alrieza",false,true
            };

            var numbers = objects.OfType<int>().ToList();

            foreach (var item in numbers)
            {
                Console.WriteLine(item);
            }
        }
       
        public void OrderBySample()
        {
            var students = Student.GetStudents();

            var result = students.OrderBy(c=>c.Grade).ToList();

            Student.PrintStudentList(result);
        }

        public void OrderByDescSample()
        {
            var students = Student.GetStudents();

            var result = students.OrderByDescending(c => c.Grade).ThenBy(c=>c.FirstName).ToList();

            Student.PrintStudentList(result);
        }

        public void GroupingSample()
        {
            var students = Student.GetStudents();

            var result = students.GroupBy(c => c.Grade);
            foreach (var item in result)
            {
                Console.WriteLine(item.Key);
                foreach (var student in item)
                {
                    Console.WriteLine($"{student.Id}\t\t { student.FirstName},{student.LastName}");
                }
            }

           
        }

        public void InnerJoin()
        {
            var students = Student.GetStudents();
            var course = StudentCourse.GetStudentCourses();

            var joinResult = students.Join(course, c => c.Id, c => c.StudentId, (s, c) => new
            {
                StudentId = s.Id,
                CourseId = c.Id,
                FullName = $"{s.FirstName}, {s.LastName}",
                CourseName = c.Name
            }).ToList();

            foreach (var item in joinResult)
            {
                Console.WriteLine($"{item.StudentId}\t {item.CourseId}\t {item.FullName}\t{item.CourseName}");
            }
        }

        public void GroupJoin()
        {
            var students = Student.GetStudents();
            var course = StudentCourse.GetStudentCourses();

            var joinResult = students.GroupJoin(course, c => c.Id, c => c.StudentId, (s, c) => new
            {
                StudentId = s.Id,
                FullName = $"{s.FirstName}, {s.LastName}",
                Courses = c
            }).ToList();

            foreach (var item in joinResult)
            {
                Console.WriteLine($"{item.StudentId}\t{item.FullName}");
                foreach (var c in item.Courses)
                {
                    Console.WriteLine($"\t\t{c.Id}, {c.Name}");
                }
                if(item.Courses.Count() == 0)
                {
                    Console.WriteLine("\t\t -------No Course-------");
                }
            }
        }

        public void OuterJoin()
        {
            var students = Student.GetStudents();
            var course = StudentCourse.GetStudentCourses();

            var joinResult = students.GroupJoin(course, c => c.Id, c => c.StudentId, (s, c) => new
            {
                StudentId = s.Id,
                FullName = $"{s.FirstName}, {s.LastName}",
                Courses = c
            }).SelectMany(c => c.Courses.DefaultIfEmpty(), (s, c) =>
            {
                return new
                {
                    s.StudentId,
                    s.FullName,
                    Course = c?.Name ?? "---"
                };
            }).ToList();

            foreach (var item in joinResult)
            {
                Console.WriteLine($"{item.StudentId}\t{item.FullName}\t\t {item.Course}");
                
            }
        }

        public void Distinct()
        {
            List<int> num01 = new List<int> { 1, 2, 3, 4,4, 5, 6,7, 7 };

            var distinct = num01.Distinct();

            foreach (var item in distinct)
            {

                Console.WriteLine(item);
            }

        }


        public void Union()
        {
            List<int> num01 = new List<int> { 1, 2, 3, 4, 5, 6, 7 };
            List<int> num02 = new List<int> { 8,9,10 };

            var distinct = num01.Union(num02).ToList();

            foreach (var item in distinct)
            {

                Console.WriteLine(item);
            }

        }

        public void UnionBy()
        {
            var students = new List<Student>
            {
                new Student { Id = 1,FirstName = "Alireza"},
                new Student { Id = 2,FirstName ="HammidReza"}
            };

            var defaultStudens = Student.GetStudents();

            var unionResult = students.UnionBy(defaultStudens,c=>c.FirstName).ToList();
            
            Student.PrintStudentList(unionResult);
        }

        public void Intersect()
        {
            List<int> num01 = new List<int> { 1, 2, 3, 4, 5, 6, 7 };
            List<int> num02 = new List<int> { 1,7,8, 9, 10 };

            var distinct = num01.Intersect(num02).ToList();

            foreach (var item in distinct)
            {

                Console.WriteLine(item);
            }

        }
        public void IntersectBy()
        {
            var defaultStudens = Student.GetStudents();

            var unionResult = defaultStudens.IntersectBy(new int[] {1,2,3}, c => c.Id).ToList();

            Student.PrintStudentList(unionResult);
        }
        public void Except()
        {
            List<int> num01 = new List<int> { 1, 2, 3, 4, 5, 6, 7 };
            List<int> num02 = new List<int> { 1, 7, 8, 9, 10 };

            var except = num01.Except(num02).ToList();

            foreach (var item in except)
            {

                Console.WriteLine(item);
            }

        }

        public void ExceptBy()
        {
            var defaultStudens = Student.GetStudents();

            var unionResult = defaultStudens.ExceptBy(new int[] { 1, 2, 3 }, c => c.Id).ToList();

            Student.PrintStudentList(unionResult);
        }


        public void Zip()
        {
            List<int> num01 = new List<int> { 1, 2, 3, 4, 5, 6, 7 };
            List<int> num02 = new List<int> { 8, 9, 10 };
            List<int> num03 = new List<int> { 11,12 };

            var distinct = num01.Zip(num02,num03).ToList();

            foreach (var item in distinct)
            {

                Console.WriteLine(item);
            }

        }

        public void Paging(int pageIndex,int pageSize)
        {
            List<int> num01 = new List<int> { 1,2,3,4,5,6,7,8,9,10 };

            var result2 = num01.Take(2..6);

            var partition = num01.Skip(pageIndex * pageSize).Take(pageSize).ToList();

            foreach (var item in partition)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("".PadLeft(100,'-'));
        }

        public void Chunk(int chunkSize)
        {
            List<int> num01 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,11,12,13,14,15 };

            var partition = num01.Chunk(chunkSize).ToList();

            foreach (var item in partition)
            {
                foreach (var num in item)
                {
                    Console.WriteLine(num);
                }
                Console.WriteLine("".PadLeft(100, '-'));
            }
           
        }

        public void AggregateFunctions()
        {
            List<int> num01 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            var sum = num01.Sum();
            var min = num01.Min();
            var max = num01.Max();
            var avg = num01.Average();
            var count = num01.Count();

            Console.WriteLine($"sum:{sum}, min: {min}, max: {max}, avg:{avg}, count:{count}");

        }
        public void MinMaxBy()
        {
            var students = Student.GetStudents();
            var min = students.MinBy(c=>c.Grade);
            var max = students.MaxBy(c=>c.Grade);
            Console.WriteLine($" min: {min.FirstName}, max: {max.FirstName}");

        }

        public void Generators()
        {
            var result01 = Enumerable.Range(500, 600);
            var result02 = Enumerable.Empty<string>();
            var result03 = Enumerable.Repeat(10, 100);
            Console.ReadLine();

        }
    }
}
