using System;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using ProjectCanvas.Models;
using ProjectCanvas.Services;
using ProjectCanvas.helpers;

namespace ProjectCanvas
{
    internal class Program
    {
        private StudentService studentService;
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to Canvas");
            Console.WriteLine("A. Add a Student");
            Console.WriteLine("D. Delete a Student");
            Console.WriteLine("U. Update a Student");
            Console.WriteLine("D. Delete a Student");
            string? choice = Console.ReadLine();
            var studentHlpr = new StudentHelper();

            switch(choice){
            case "A": 
            case "a":
            studentHlpr.AddStudent();
            break;

            case "U":
            case "u":
            studentHlpr.UpdateStudent();
            break;

            case "D":
            case "d":
            studentHlpr.DeleteStudent();
            break;

            }
            
            foreach(Student s in StudentService.Current.Students){
                Console.WriteLine(s); 
            }
        }
    }
}
