namespace SMSProject.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string AlbumNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public int GroupId { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}
