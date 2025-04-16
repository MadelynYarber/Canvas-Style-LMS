using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

using ProjectCanvas.Models;
using ProjectCanvas.Services;

namespace MAUI.Canvas.viewmodels
{
    public class StudentDialogViewModel
    {

        private Student? student;

        public string Name
        {
            get { return student?.Name ?? string.Empty; }
            set {
                if (student == null) student = new Student();
                student.Name = value; 
                }
        }

        public string Classification
        {
            get {  return student?.Classification ?? string.Empty; }
            set {
                if (student == null) student = new Student();
                student.Classification = value;    
                }
        }

        public StudentDialogViewModel(int sId)
        {
            if (sId == 0)
            {
                student = new Student();
            }
            else
            {
                student = StudentService.Current.Get(sId) ?? new Student();
            }
        }

        public void AddStudent()
        {
            if(student != null)
            {
                StudentService.Current.AddOrUpdate(student);   
            }
        }
    }
}
