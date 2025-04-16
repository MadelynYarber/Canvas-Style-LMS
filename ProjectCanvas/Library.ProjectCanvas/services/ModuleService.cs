
using ProjectCanvas.Models;
using ProjectCanvas.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCanvas.Services
{
    public class ModuleService
    {

        private static ModuleService? instance;
        private string? query;
        private static object _lock = new object();
      
        public static ModuleService Current
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new ModuleService();
                    }
                }
                return instance;
            }
        }

        private int LastId
        {
            get
            {
                return modules.Select(m => m.Id).Max();
            }
        }

        public void AddingModule(ClassModule module)
        {
            if (module.Id <= 0)
            {
                module.Id = LastId + 1;
                modules.Add(module);
                //modules.Add(courseId);
            }
        }
     


        public void Add(ClassModule module)
        {
            modules.Add(module);
        }

        public ClassModule? Get(int id)
        {
            return modules.FirstOrDefault(m => m.StudentId == id);
            //return modules.FirstOrDefault(m => m.Id == id);
        }

        private IList<ClassModule> modules;
        public IEnumerable<ClassModule> Modules
        {
            get
            {
                //return modules.Where(
                //    m =>
                //        m.Name.ToUpper().Contains(query ?? string.Empty));
                return modules;

            }
        }

        private ModuleService()
        {
            modules = new List<ClassModule>
            {
                //Call Add function here, but put add function in view model
                new ClassModule {Name = "Derivatives", Desc = "The Derivative Rules", Id = 1, CourseId = 1, StudentId = 1},
                new ClassModule {Name = "Spanish Quiz", Desc = "Test of Spanish Vocab", Id = 2, CourseId = 2, StudentId = 2},
                new ClassModule {Name = "Anti-Derivatives", Desc = "Anti-Derivative Rules", Id = 3, CourseId = 1, StudentId=3}
            };
        }

    }
}
