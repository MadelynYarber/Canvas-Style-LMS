using ProjectCanvas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCanvas.Models
{
    public class ClassModule
    {
        public string? Name { get; set; }
        public string? Desc { get; set; }

        public int Id { get; set; } 

        public int CourseId { get; set; }

        public int StudentId { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}    Description: {Desc}    ModuleId: {Id}     " +
                $"CourseId: {CourseId} StudentId: {StudentId}";
        }

        public ClassModule()
        {

        }
    }
}
