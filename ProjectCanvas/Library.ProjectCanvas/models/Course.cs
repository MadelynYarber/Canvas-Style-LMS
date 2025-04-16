using System.Diagnostics;
using System.Security.Permissions;

namespace ProjectCanvas.Models{

public class Course {

    public string? Code{get; set;}
    public string? Name{get; set;}
    public string? Description{get; set;}

    public int Id { get; set; } //changed
    
    public List<Student> Roster {  get; set; }

        public override string ToString()
        {
            return $"({Id}) {Name} {Code}";
        }
    }
}