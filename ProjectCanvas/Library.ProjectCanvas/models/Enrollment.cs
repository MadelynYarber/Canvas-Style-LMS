using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProjectCanvas.Models
{
    public class Enrollment
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        public string CourseName { get; set; }

        //Where(c => c?.Name?.ToUpper()?.Contains(Query?.ToUpper() ?? string.Empty
        public override string ToString()
        {
            return $"CourseId: {CourseId}";
        }

        public Enrollment()
        {
         
        }
    }
}
