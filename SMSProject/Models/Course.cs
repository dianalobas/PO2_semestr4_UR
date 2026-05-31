namespace SMSProject.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; } = string.Empty;
        public int Ects { get; set; }
        public string Semester { get; set; } = string.Empty;
        public string Lecturer { get; set; } = string.Empty;
    }
}
