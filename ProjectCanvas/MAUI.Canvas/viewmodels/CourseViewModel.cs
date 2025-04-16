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
    internal class CourseViewModel : INotifyPropertyChanged
    {

        private CourseService courseSvc;

        private EnrollmentService enrollmentSvc;

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Query { get; set; }
        public ObservableCollection<Course> Courses
        {
            get
            {
                return new ObservableCollection<Course>(courseSvc.Courses
                    .ToList().Where(c => c?.Name?.ToUpper()?.Contains(Query?.ToUpper() ?? string.Empty) ?? false));

            }

        }

        //public ObservableCollection<Course> Courses
        //{
        //    get
        //    {
        //        return new ObservableCollection<Course>(courseSvc.Courses
        //            .ToList().Where(c => c?.Code?.ToUpper()?.Contains(Query?.ToUpper() ?? string.Empty) ?? false));

        //    } //SEARCHING BY CODE ????

        //}
        public Course SelectedCourse
        {
            get; set;
        }

        public void AddCourse()
        {
            courseSvc.AddOrUpdate(new Course { Name = "This is a new course" });
            NotifyPropertyChanged(nameof(Courses));
        }
        public void Refresh()
        {
            NotifyPropertyChanged(nameof(Courses));
        }

        public void Remove()
        {
            courseSvc.Remove(SelectedCourse);
            Refresh();
        }

        public void LinkStudents()
        {
            //enrollmentSvc.LinkStudent(new Enrollment { CourseId = 0, StudentId = 0});
            //courseSvc.AddOrUpdate(new Course { Name = "This is a new course" });
            //NotifyPropertyChanged(nameof(Courses));
        }

        public CourseViewModel()
        {
            courseSvc = CourseService.Current;
            enrollmentSvc = EnrollmentService.Current;
        }

    }
}
