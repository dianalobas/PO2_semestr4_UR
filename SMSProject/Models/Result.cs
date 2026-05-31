using System;

namespace SMSProject.Models
{
    public class Result
    {
        public int ResultId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public string Grade { get; set; } = string.Empty;
        public DateTime DateAdded { get; set; } = DateTime.Today;

        // Dla wyświetlania w DataGrid
        public string StudentName { get; set; } = string.Empty;
        public string CourseName { get; set; } = string.Empty;
    }
}
