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
    internal class LinkStudentViewModel
    {

        private Enrollment? enrollment;
        private Course? course;

        public int StudentId
        {
            get { return enrollment.StudentId; }
            set
            {
                if (enrollment == null) enrollment = new Enrollment();
                enrollment.StudentId = value;
            }
        }

        public int CourseId
        {
            get { return enrollment.CourseId; }
            set
            {
                if (enrollment == null) enrollment = new Enrollment();
                enrollment.CourseId = value;
            }
        }

        public LinkStudentViewModel(int sId)
        {
            if (sId == 0)
            {
                enrollment = new Enrollment();
            }
            else
            {
                enrollment = EnrollmentService.Current.Get(sId) ?? new Enrollment();
            }
        }

        public void AddEnrollment()
        {
            if (enrollment != null)
            {
                EnrollmentService.Current.LinkStudent(enrollment);
            }
        }

    }
}
