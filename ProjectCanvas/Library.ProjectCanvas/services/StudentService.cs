using ProjectCanvas.Models;

namespace ProjectCanvas.Services
{
    public class StudentService
    {
        private IList<Student> students;

        private int LastId
        {
            get
            {
                return students.Select(s => s.Id).Max();
            }
        }
        private string? query;
        private static object _lock = new object();
        private static StudentService? instance;
        public static StudentService Current
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new StudentService();
                    }
                }
                return instance;
            }
        }

        public IEnumerable<Student> Students
        {
            get
            {
                return students.Where(
                    s =>
                        s.Name.ToUpper().Contains(query ?? string.Empty));
            }
        }
        private StudentService()
        {
            students = new List<Student>
            {
                new Student{Name = "Test Student 1", Id = 1},
                new Student{Name = "Test Student 2", Id = 2},
                new Student{Name = "Test Student 3", Id = 3},
                new Student{Name = "Test Student 4", Id = 4},
                new Student{Name = "Test Student 5", Id = 5},
            };
        }

        public Student? Get(int id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }
        public IEnumerable<Student> Search(string query)
        {
            this.query = query;
            return Students;

        }
        public void AddOrUpdate(Student student)
        {
            if(student.Id <= 0)
            {
                student.Id = LastId + 1;
                students.Add(student);
            }
        }

        public void Remove(Student student)
        {
            students.Remove(student);
        }

        public void Delete(Student studentToDelete)
        {

            students.Remove(studentToDelete);
        }

    }
}