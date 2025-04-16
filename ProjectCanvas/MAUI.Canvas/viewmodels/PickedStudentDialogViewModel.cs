using Microsoft.Maui.ApplicationModel.Communication;
using ProjectCanvas.Models;
using ProjectCanvas.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MAUI.Canvas.viewmodels
{
    class PickedStudentDialogViewModel //: INotifyPropertyChanged
    {

        private EnrollmentService enrollmentSvc;
        private CourseService courseSvc;
        private AssignmentService assignmentSvc;
        private ModuleService moduleSvc;

        private Student? student;
        private Course? course;
        private Enrollment? enrollment;
        private Assignment? assignment;
        private ClassModule? module;

        public PickedStudentDialogViewModel()
        {
            enrollmentSvc = EnrollmentService.Current;
            courseSvc = CourseService.Current;
            assignmentSvc = AssignmentService.Current;
            moduleSvc = ModuleService.Current;
        }

        public PickedStudentDialogViewModel(int sId)
        {
            enrollmentSvc = EnrollmentService.Current;
            courseSvc = CourseService.Current;
            assignmentSvc = AssignmentService.Current;
            moduleSvc = ModuleService.Current;

            if (sId == 0)
            {
                enrollment = new Enrollment();
                student = new Student();
               
            }
            else
            {
                //enrollmentSvc.GetCourses(sId);
                student = StudentService.Current.Get(sId) ?? new Student();
               

            }
        }

        //public int courseId
        //{
        //    get
        //    {
        //        return enrollment.CourseId;
        //    }
        //    set
        //    {
        //        enrollment.CourseId = value;
        //    }
        //}

        //public ObservableCollection<Course> Courses
        //{
        //    get
        //    {

        //        return new ObservableCollection<Course>(courseSvc.Courses
        //            .Where(c => c.Id == (course?.Id ?? 0)).ToList());
        //    }

        //}
        public ObservableCollection<Assignment> assignments
        {
            get
            {
                return new ObservableCollection<Assignment>(assignmentSvc.Assignments
                    .Where(a => a.StudentId == (student?.Id ?? 0)).ToList());
            }

        }

        public string Query { get; set; }

        public ObservableCollection<ClassModule> modules
        {
            get
            {
                return new ObservableCollection<ClassModule>(moduleSvc.Modules
                    .Where(m => m.StudentId == (student?.Id ?? 0)).ToList());
            }

        }

        //public event PropertyChangedEventHandler? PropertyChanged;

        //private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
        public string Name
        {
            get { return student?.Name ?? string.Empty; }
            set
            {
                if (student == null) student = new Student();
                student.Name = value;
            }
        }

        public string Grade
        {
            get { return student?.Grade ?? string.Empty; }
            set
            {
                if (student == null) student = new Student();
                student.Grade = value;
            }
        }

        public string AssignName
        {
            get { return assignment?.Name ?? string.Empty; }
            set
            {
                if (assignment == null) assignment = new Assignment();
                assignment.Name = value;
            }
        }
        ////public int classname{ 
        ////    set {if (courseId == course.Id)  }
        ////}
        ////public string Class
        ////{
        ////    get
        ////    {
        ////        GetCourse();
        ////        return course?.Name ?? string.Empty;

        ////    }
        ////    set
        ////    {
        ////        if (course == null) course = new Course();
        ////        //else GetCourse();
        ////    }
        ////}

        ////}
        ////Where(c => c?.Name?.ToUpper()?.Contains(Query?.ToUpper() ?? string.Empty
        ////studentSvc.Students.ToList().Where(s=>s?.Name?.ToUpper()?.Contains(Query?.ToUpper() ?? string.Empty) ?? false))

        //    //private Course classname;
        //    //    public Course Classname
        //    //{
        //    //    get
        //    //    {
        //    //        return classname;
        //    //    }
        //    //    set
        //    //    {
        //    //        if (course == null) course = new Course();
        //    //        classname = value;
        //    //        //OnPropertyChanged();
        //    //        bool changedId = int.TryParse(courseId, out int newId);
        //    //        Classname = CourseService.GetName(courseId);
        //    //    }
        //    //}



        //public void GetCourse()
        //{     
        //    CourseService.Current.Get(courseId);
        //}

        //public int courseId { get; set; }

        //public string Query { get; set; }
        public ObservableCollection<Enrollment> Enrollments
        {
            get
            {
                return new ObservableCollection<Enrollment>(enrollmentSvc.Enrollments
                    .Where(e => e.StudentId == (student?.Id ?? 0)).ToList());

            }

        }

        //public string Name
        //{
        //    get { return assignment?.Name ?? string.Empty; }
        //    set
        //    {
        //        if (assignment == null) assignment = new Assignment();
        //        assignment.Name = value;
        //    }
        //}

        //public ObservableCollection<Course> Courses
        //{
        //    get
        //    {

        //        return new ObservableCollection<Course>(courseSvc.Courses
        //            .Where(c => c.Id == (courseId)).ToList());

        //    }

        //}
        ////is null
        ////return new ObservableCollection<Student>(studentSvc.Students.ToList().Where(s=>s?.Name?.ToUpper()?.Contains(Query?.ToUpper() ?? string.Empty) ?? false));


    }
}
