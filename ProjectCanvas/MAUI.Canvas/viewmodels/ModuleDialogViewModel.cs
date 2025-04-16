
using ProjectCanvas.Models;
using ProjectCanvas.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.Canvas.viewmodels
{
    internal class ModuleDialogViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ClassModule? modules;
        //private Course? course;
        private ModuleService ModuleSvc;



        public string Name
        {
            get { return modules?.Name ?? string.Empty; }
            set
            {
                if (modules == null) modules = new ClassModule();
                modules.Name = value;
            }
        }

        public string Desc
        {
            get { return modules?.Desc ?? string.Empty; }
            set
            {
                if (modules == null) modules = new ClassModule();
                modules.Desc = value;
            }
        }

        //public int Id
        //{
        //    get { return modules.Id; }
        //    set
        //    {
        //        if (modules == null) modules = new ClassModule();
        //        modules.Id = value;
        //    }
        //}


        public int CourseId
        {
            get { return modules.CourseId; }
            set
            {
                if (modules == null) modules = new ClassModule();
                modules.CourseId = value;
            }
        }

        public int StudentId
        {
            get { return modules.StudentId; }
            set
            {
                if (modules == null) modules = new ClassModule();
                modules.StudentId = value;
            }
        }

        public ModuleDialogViewModel(int mId)
        {
            if (mId == 0)
            {
                modules = new ClassModule();
            }
            else
            {
                modules = ModuleService.Current.Get(mId) ?? new ClassModule();
            }
        }

        public string Query { get; set; }

        //public ObservableCollection<ClassModule> Modules
        //{
        //    get
        //    {
        //        return new ObservableCollection<ClassModule>(ModuleSvc.Modules
        //         .ToList().Where(m => m?.Name?.ToUpper()?.Contains(Query?.ToUpper() ?? string.Empty) ?? false));

        //        //return new ObservableCollection<ClassModule>(ModuleSvc.Modules
        //        //    .ToList().Where(m => m.CourseId == (course?.Id ?? 0)).ToList());
        //    }

        //}

        //public void Refresh()
        //{
        //    NotifyPropertyChanged(nameof(Modules));
        //}

        public void AddModule()
        {
            if (modules != null)
            {
                ModuleService.Current.AddingModule(modules);
            }
        }

        public ModuleDialogViewModel()
        {
            ModuleSvc = ModuleService.Current;
        }


    }
}
