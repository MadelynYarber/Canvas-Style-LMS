using ProjectCanvas.Models;
using ProjectCanvas.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCanvas.Services
{
    public class AssignmentService
    {
        private int LastId
        {
            get
            {
                return assignments.Select(a => a.AssignId).Max();
            }
        }

        private static AssignmentService? instance;
        private static object _lock = new object();
        private string? query;
        public static AssignmentService Current
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new AssignmentService();
                    }
                }
                return instance;
            }
        }

        private IList<Assignment> assignments;

        public IEnumerable<Assignment> Assignments
        {
            get
            {
                return assignments.Where(
                    a =>
                        a.Name.ToUpper().Contains(query ?? string.Empty));
            }

        }


        private AssignmentService()
        {
            assignments = new List<Assignment>
            {
                //new Assignment{Name = "Math Test", Desc = "What does 2+2 equal?", TotalPoints = "50", 
                //                DueDate="Apr 29", AssignId = 1, CourseId = 1},
                //new Assignment{Name = "Color", Desc = "What is your favorite color?", TotalPoints = "100", 
                //                DueDate="May 01", AssignId = 2, CourseId = 2},
                //new Assignment{Name = "Animal", Desc = "What is your favorite animal?", TotalPoints = "80",
                //                DueDate="Feb 20", AssignId = 3, CourseId = 1},

                //new Assignment{Name = "Math Test", Desc = "What does 2+2 equal?", TotalPoints = "50",
                //                DueDate="Apr 29", AssignId = 1, StudentId = 1, CourseId = 1},
                //new Assignment{Name = "Color", Desc = "What is your favorite color?", TotalPoints = "100",
                //                DueDate="May 01", AssignId = 2, StudentId = 2, CourseId = 2},
                //new Assignment{Name = "Animal", Desc = "What is your favorite animal?", TotalPoints = "80",
                //                DueDate="Feb 20", AssignId = 3, StudentId = 2, CourseId = 1},

                new Assignment{Name = "Math Test", Desc = "What does 2+2 equal?", TotalPoints = "50",
                                DueDate="Apr 29", AssignId = 1, StudentId = 1, CourseId = 1},
                new Assignment{Name = "Color", Desc = "What is your favorite color?", TotalPoints = "100",
                                DueDate="May 01", AssignId = 2, StudentId = 2, CourseId = 2},
                new Assignment{Name = "Animal", Desc = "What is your favorite animal?", TotalPoints = "80",
                                DueDate="Feb 20", AssignId = 3, StudentId = 2, CourseId = 1},
            };

        }
        public void AddSub(Assignment assignment)
        {
            if (assignment.AssignId <= 0)
            {
                assignment.AssignId = LastId + 1;
                assignments.Add(assignment);
                //needed?
            }
        }

        //public void Adding(Assignment assignment)
        //{
        //    assignments.Add(assignment);
        //}

        public Assignment? Get(int id)
        {
            return assignments.FirstOrDefault(a => a.AssignId == id);
        }

        //public Course? GetName(courseId)
        //{
        //    return courses.Where(c => c.Id == courseId);
        //}
        public void AddAssign(Assignment assignment)
        {
            if (assignment.AssignId <= 0)
            {
                assignment.AssignId = LastId + 1;
                assignments.Add(assignment);
            }
        }

        public void Add(Assignment assignment)
        {
            assignments.Add(assignment);
        }
    }

}
