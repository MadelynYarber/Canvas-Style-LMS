using ProjectCanvas.Models;
using ProjectCanvas.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProjectCanvas.Services
{
    public class EnrollmentService
    {
        private IList<Enrollment> enrollments;

        private static EnrollmentService? instance;
        private string? query;
        private static object _lock = new object();
        public static EnrollmentService Current
        {
            get
            {
                if (instance == null)
                {
                    instance = new EnrollmentService();
                }

                return instance;
            }
        }
        //private int LastId
        //{
        //    get
        //    {
        //        return enrollments.Select(e => e.CourseId).Max();
        //    }
        //}

        public Enrollment? Get(int id)
        {
            return enrollments.FirstOrDefault(s => s.StudentId == id);
        }

 
        


        //public int courseId { get; set; }
        //public string? CourseName
        //{
        //    get
        //    {
        //        return CourseService.courses.ToList().Where(c => c.Id == courseId)
        //    }
        //    set
        //    {
        //    }
        //}
        //studentSvc.Students.ToList().Where(s=>s?.Name?.ToUpper()?.Contains(Query?.ToUpper() ?? string.Empty) ?? false))

        public IEnumerable<Enrollment> Enrollments
        {
            get
            {
                //var courseIds = enrollments.Where(e => e.StudentId == studentId).Select(e => e.CourseId);
                //return CourseService.Current.Courses.Where(c => courseIds.Contains(c.Id)).ToList();
                return enrollments;
            }
        }

        private EnrollmentService()
        {
            enrollments = new List<Enrollment>
            {
                //Call Add function here, but put add function in view model
                new Enrollment {CourseId = 1, StudentId = 1},
                new Enrollment {CourseId = 1, StudentId = 2},
                new Enrollment {CourseId = 2, StudentId = 2},
                new Enrollment {CourseId = 2, StudentId = 3},

            };
        }

        public void LinkStudent(Enrollment courseId)
        {
            enrollments.Add(courseId);

        }


        public List<Student> GetRoster(int courseId)
        {
            var studentIds = enrollments.Where(e => e.CourseId == courseId).Select(e => e.StudentId);
            return StudentService.Current.Students.Where(s => studentIds.Contains(s.Id)).ToList();
        }

        public List<Course> GetCourses(int studentId)
        {
            var courseIds = enrollments.Where(e => e.StudentId == studentId).Select(e => e.CourseId);
            return CourseService.Current.Courses.Where(c => courseIds.Contains(c.Id)).ToList();
        }

       
    }
}
