namespace ProjectCanvas.Models {
public class Student {
    
    public int Id { get; set; } //changed
    public int CourseId { get; set; }
    public string? Name{get; set;}
    public string? Classification{get; set;}
    public string? Grade{get; set;}

        public Student()
        {
            
        }
        public override string ToString()
        {
            return $" ({Id}) {Name} {Classification} {Grade}";
        }
    }
}
