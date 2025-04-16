using MAUI.Canvas.viewmodels;
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

namespace MAUI.Canvas.viewmodels
{
    class CreateAssignmentViewModel : INotifyPropertyChanged
    {
        private Assignment? assignment;
        private AssignmentService assignmentSvc;
        private Student? student;
        private Course? course;
        private Enrollment? enrollment;

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Query { get; set; }
        public CreateAssignmentViewModel()
        {
            assignmentSvc = AssignmentService.Current;
            //assignment = new Assignment();
        }

  
        public ObservableCollection<Assignment> Assignments
        {
            get
            {
                return new ObservableCollection<Assignment>(assignmentSvc.Assignments
                    .ToList().Where(a => a?.Name?.ToUpper()?.Contains(Query?.ToUpper() ?? string.Empty) ?? false));

            }

        }

        public ObservableCollection<Assignment> assignments
        {
            get
            {
                return new ObservableCollection<Assignment>(assignmentSvc.Assignments
                    .Where(a => a.StudentId == (student?.Id ?? 0)).ToList());

                //return new ObservableCollection<Assignment>(assignmentSvc.Assignments
                //    .Where(a => a.CourseId == (course?.Id ?? 0) && a.StudentId == (student?.Id ?? 0)).ToList());

                //return new ObservableCollection<Assignment>(assignmentSvc.Assignments
                //    .Where(a => a.StudentId == (enrollment?.CourseId ?? 0)).ToList());


                //.ToList().Where(a => a?.Name?.ToUpper()?.Contains(Query?.ToUpper() ?? string.Empty) ?? false));

                //.Where(e => e.StudentId == (student?.Id ?? 0)).ToList());
            }

        }

        //var courseIds = enrollments.Where(e => e.StudentId == studentId).Select(e => e.CourseId);
        //    return CourseService.Current.Courses.Where(c => courseIds.Contains(c.Id)).ToList();

        //public List<Course> GetCourses(int studentId)
        //{
        //    var courseIds = enrollments.Where(e => e.StudentId == studentId).Select(e => e.CourseId);
        //    return CourseService.Current.Courses.Where(c => courseIds.Contains(c.Id)).ToList();
        //}
        public string Name
        {
            get { return assignment?.Name ?? string.Empty; }
            set
            {
                if (assignment == null) assignment = new Assignment();
                assignment.Name = value;
            }
        }

        public string Desc
        {
            get { return assignment?.Desc ?? string.Empty; }
            set
            {
                if (assignment == null) assignment = new Assignment();
                assignment.Desc = value;
            }
        }

        public string TotalPoints
        {
            get { return assignment?.TotalPoints ?? string.Empty; }
            set
            {
                if (assignment == null) assignment = new Assignment();
                assignment.TotalPoints = value;
            }
        }

        public string DueDate
        {
            get { return assignment?.DueDate ?? string.Empty; }
            set
            {
                if (assignment == null) assignment = new Assignment();
                assignment.DueDate = value;
            }
        }

        public int CourseId
        {
            get { return assignment.CourseId; }
            set
            {
                if (assignment == null) assignment = new Assignment();
                assignment.CourseId = value;

            }
        }

        public int StudentId
        {
            get { return assignment?.StudentId ?? 0; }
            set
            {
                if (assignment == null) assignment = new Assignment();
                assignment.StudentId = value;

            }
        }

        public string Submission
        {
            get { return assignment?.Submission ?? string.Empty; }
            set
            {
                if (assignment == null) assignment = new Assignment();
                assignment.Submission = value;
            }
        }

        public void Refresh()
        {
            NotifyPropertyChanged(nameof(Assignments));
        }

        public Assignment SelectedAssignment
        {
            get; set;
        }

        public void AddAssignment()
        {
            if (assignment != null)
            {
                AssignmentService.Current.AddAssign(assignment);
            }
        }

        public CreateAssignmentViewModel(int aId)
        {
            assignmentSvc = AssignmentService.Current;
            if (aId == 0)
            {
                assignment = new Assignment();
                student = new Student();
              
            }
            else
            {
                assignment = AssignmentService.Current.Get(aId) ?? new Assignment();
                student = StudentService.Current.Get(aId) ?? new Student();
             
            }
        }


     

        public void AddSubmission()
        {
            if (assignment != null)
            {
                AssignmentService.Current.AddSub(assignment);
            }
        }

    }
}
