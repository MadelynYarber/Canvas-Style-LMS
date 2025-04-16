using ProjectCanvas.Models;
using ProjectCanvas.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.Canvas.viewmodels
{
    internal class ViewCourseDialogViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



        private EnrollmentService enrollmentSvc;
        private CourseService courseSvc;
        private AssignmentService assignmentSvc;
        private ModuleService moduleSvc;

        private Student? student;
        private Course? course;
        private Enrollment? enrollment;
        private Assignment? assignment;
        private ClassModule? module;

        public string Name
        {
            get { return course?.Name ?? string.Empty; }
            set
            {
                if (course == null) course = new Course();
                course.Name = value;
            }
        }

        public string Description
        {
            get { return course?.Description ?? string.Empty; }
            set
            {
                if (course == null) course = new Course();
                course.Description = value;
            }
        }






        public string Query { get; set; }


        public ViewCourseDialogViewModel(int cId)
        {
            courseSvc = CourseService.Current;
            enrollmentSvc = EnrollmentService.Current;
            assignmentSvc = AssignmentService.Current;
            moduleSvc = ModuleService.Current;
            if (cId == 0)
            {
                course = new Course();
            }
            else
            {
                course = CourseService.Current.Get(cId) ?? new Course();

            }
        }

        public ViewCourseDialogViewModel()
        {
            enrollmentSvc = EnrollmentService.Current;
            courseSvc = CourseService.Current;
            assignmentSvc = AssignmentService.Current;
            moduleSvc = ModuleService.Current;
        }



        public ObservableCollection<Assignment> assignments
        {
            get
            {
                return new ObservableCollection<Assignment>(assignmentSvc.Assignments
                    .Where(a => a.CourseId == (course?.Id ?? 0)).ToList());
            }

        }


        public ObservableCollection<ClassModule> modules
        {
            get
            {
                return new ObservableCollection<ClassModule>(moduleSvc.Modules
                    .Where(m => m.CourseId == (course?.Id ?? 0)).ToList());
            }

        }


        public ObservableCollection<Enrollment> Enrollments
        {
            get
            {
                return new ObservableCollection<Enrollment>(enrollmentSvc.Enrollments
                    .Where(e => e.CourseId == (course?.Id ?? 0)).ToList());

            }

        }


    }
}
