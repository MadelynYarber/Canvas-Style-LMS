using ProjectCanvas.Models;
using ProjectCanvas.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.Canvas.viewmodels
{
    internal class CollectionViewModel
    {

        private CourseService courseSvc;

        private EnrollmentService enrollmentSvc;

        private AssignmentService assignmentSvc;

        private Assignment? assignment;
        private Student? student;
        private Course? course;
        private Enrollment? enrollment;

        public int courseId { get; set; }

        public string Query { get; set; }
        //public ObservableCollection<Course> Courses
        //{
        //    get
        //    {
        //        return new ObservableCollection<Course>(courseSvc.Courses
        //            .ToList().Where(c => c?.Name?.ToUpper()?.Contains(Query?.ToUpper() ?? string.Empty) ?? false));

        //    }

        //}

        public ObservableCollection<Course> Courses
        {
            get
            {
                return new ObservableCollection<Course>(courseSvc.Courses
                    .Where(c => c.Id == (courseId)).ToList());

            }

        }
        public ObservableCollection<Assignment> assignments
        {
            get
            {
                return new ObservableCollection<Assignment>(assignmentSvc.Assignments
                    .Where(a => a.StudentId == (student?.Id ?? 0)).ToList());
            }

        }

        public CollectionViewModel()
        {
            courseSvc = CourseService.Current;
            enrollmentSvc = EnrollmentService.Current;
            assignmentSvc = AssignmentService.Current;
        }
    }
}
