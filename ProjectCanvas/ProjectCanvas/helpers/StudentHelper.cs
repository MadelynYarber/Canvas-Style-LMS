using ProjectCanvas.Models;
using ProjectCanvas.Services;

namespace ProjectCanvas.helpers
{
    public class StudentHelper
    {

        private StudentService studentSvc = StudentService.Current;
        public void AddStudent()
        {

            Console.WriteLine("Name:");
            var name = Console.ReadLine();

            Console.WriteLine("Classification: ");
            var classification = Console.ReadLine();

            Console.WriteLine("Grade: ");
            var grade = Console.ReadLine();

            Student myStudent;
            myStudent = new Student { Name = name, Classification = classification, Grade = grade };

            studentSvc.AddOrUpdate(myStudent);

        }

        public void UpdateStudent()
        {
            int count = 0;
            StudentService.Current.Students.ToList().ForEach(s => Console.WriteLine($"{++count}. {s}"));

            var choice = Console.ReadLine();

            if (int.TryParse(choice, out int intChoice)) {
                var studentToUpdate = StudentService.Current.Students.ElementAt(intChoice);

                Console.WriteLine("What is the new name?");
                studentToUpdate.Name = Console.ReadLine();

                Console.WriteLine("What is the new classification?");
                studentToUpdate.Classification = Console.ReadLine();

                Console.WriteLine("What is the new Grade?");
                studentToUpdate.Grade = Console.ReadLine();

            }
        }

        public void DeleteStudent()
        {
            int count = 0;
            StudentService.Current.Students.ToList().ForEach(s => Console.WriteLine($"{++count}. {s}"));

            var choice = Console.ReadLine();

            if (int.TryParse(choice, out int intChoice))
            {
                var studentToDelete = StudentService.Current.Students.ElementAt(intChoice);

                studentSvc.Delete(studentToDelete);
            }
        }
            public void ListStudents()
            {
                studentSvc.Students.ToList().ForEach(Console.WriteLine);
            }

    }
}