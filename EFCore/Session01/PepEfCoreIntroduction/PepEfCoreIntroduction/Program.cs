// See https://aka.ms/new-console-template for more information
using PepEfCoreIntroduction.DomainModel;

Repository repository = new Repository();

//Course course = new Course();
//course.Name = "Asp.NET CORE 6";
//course.Description = "Pep ASP.NET Core 6";
//course.Teacher = new Teacher
//{
//    FirstName = "Alrieza",
//    LastName = "Oroumand"
//};
//repository.AddCourse(course);

//repository.UpdateCourse(1, "Entity framework core 6.0");
repository.PrintCourses();
//repository.PrintCourses();
//repository.PrintCourses();
Console.ReadLine();
