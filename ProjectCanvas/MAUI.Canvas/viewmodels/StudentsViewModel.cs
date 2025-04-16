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
//using Xamarin.Google.Crypto.Tink.Signature;

namespace MAUI.Canvas.viewmodels
{
    internal class StudentsViewModel : INotifyPropertyChanged
    {

        private StudentService studentSvc;

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Query { get; set; }

        public ObservableCollection<Student> Students
        {
            get
            {
                return new ObservableCollection<Student>(studentSvc.Students
                    .ToList().Where(s=>s?.Name?.ToUpper()?.Contains(Query?.ToUpper() ?? string.Empty) ?? false));
            }

        }

        public Student SelectedStudent
        {
            get; set;
        }

        public void AddStudent()
        {
            studentSvc.AddOrUpdate(new Student { Name = "This is a new student" });
            NotifyPropertyChanged(nameof(Students));
        }

        public void Refresh()
        {
            NotifyPropertyChanged(nameof(Students));
        }

        public void Remove()
        {
            studentSvc.Remove(SelectedStudent);
            Refresh();
        }


        public StudentsViewModel()
        {
            studentSvc = StudentService.Current;
        }


    }
}
