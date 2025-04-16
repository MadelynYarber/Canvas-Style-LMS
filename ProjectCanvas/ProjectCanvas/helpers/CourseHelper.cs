using ProjectCanvas.Services;
using ProjectCanvas.Models;

namespace ProjectCanvas.helpers
{
    public class CourseHelper
    {
        private StudentService studentSvc = StudentService.Current;
        private CourseService courseService = CourseService.Current;

        public CourseHelper() { }

        public void AddCourse()
        {
            Console.WriteLine("Choose a student to add to a course:");
            studentSvc.Students.ToList().ForEach(Console.WriteLine);

            var chosenStudent = studentSvc.Students.FirstOrDefault();
            Console.WriteLine("Name:");
            var name = Console.ReadLine();

            //courseService.Add(new Course { StudentId = chosenStudent?.Id ?? Guid.Empty, Name = name });

        }
    }
}