using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCanvas.Models
{
    public class Assignment
    {

        public int StudentId { get; set; }
        public int CourseId { get; set; }

        public int AssignId { get; set; }

        public string? Name { get; set; }
        public string? Desc { get; set; }
        public string? TotalPoints { get; set; } //int?
        public string? DueDate { get; set; }

        public string? Grade {  get; set; }

        public string? Submission {  get; set; }


        public List<Assignment> Assignments { get; set; }

        public override string ToString()
        {
            return $"({AssignId}) {Name} Description: {Desc} Total Points:{TotalPoints} " +
                   $"Due Date: {DueDate} CourseId {CourseId} StudentId {StudentId}";

            //return $"({AssignId}) {Name} Description: {Desc} Total Points:{TotalPoints} " +
            //       $"Due Date: {DueDate} CourseId {CourseId} StudentId {StudentId} Submission {Submission}";
        }

        public Assignment()
        {

        }
    }
}
