using ProjectCanvas.Models;
namespace ProjectCanvas.Services{
    public class CourseService{


        private int LastId
        {
            get
            {
                return courses.Select(c => c.Id).Max();
            }
        }

        private static CourseService? instance;
        private static object _lock = new object();
        private string? query;
        public static CourseService Current    
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new CourseService();
                    }
                }
                return instance;
            }
        }

        private IList<Course> courses;

        public IEnumerable<Course> Courses
        {
            get
            {
                return courses.Where(
                    c =>
                        c.Name.ToUpper().Contains(query ?? string.Empty));
                //return courses;
            }

        }


        private CourseService()
        {
            courses = new List<Course>
            {
                new Course{Name = "Test Course 1", Id = 1},
                new Course{Name = "Test Course 2", Id = 2},
                new Course{Name = "Test Course 3", Id = 3},
            };
   
        }

        public Course? Get(int id)
        {
            return courses.FirstOrDefault(c => c.Id == id);
        }
     
        //public Course? GetName(courseId)
        //{
        //    return courses.Where(c => c.Id == courseId);
        //}
        public void AddOrUpdate(Course course)
        {
            if (course.Id <= 0)
            {
                course.Id = LastId + 1;
                courses.Add(course);
            }
            //courses.Add(course);
        }

        public void Add(Course course)
        {
            courses.Add(course);
        }
        public void Remove(Course course)
        {
            courses.Remove(course);
        }
    }
}

