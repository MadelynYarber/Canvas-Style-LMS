using ProjectCanvas.Models;
using ProjectCanvas.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.Canvas.viewmodels
{
    internal class CourseDialogViewModel
    {
        private Course? course;

        public string Name
        {
            get { return course?.Name ?? string.Empty; }
            set
            {
                if (course == null) course = new Course();
                course.Name = value;
            }
        }

        public string Code
        {
            get { return course?.Code ?? string.Empty; }
            set
            {
                if (course == null) course = new Course();
                course.Code = value;
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

        public CourseDialogViewModel(int cId)
        {
            if (cId == 0)
            {
                course = new Course();
            }
            else
            {
                course = CourseService.Current.Get(cId) ?? new Course();
            }
        }

        public CourseDialogViewModel()
        {
            course = new Course();
        }

        public void AddCourse()
        {
            if (course != null)
            {
                CourseService.Current.AddOrUpdate(course);
                //CourseService.Current.Add(course);
            }
        }
    }
}

