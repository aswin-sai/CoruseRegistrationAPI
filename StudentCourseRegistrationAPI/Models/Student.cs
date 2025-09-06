namespace StudentCourseRegistrationAPI.Models
{
    public class Student
    {
        public int Roll { get; set; } // PK, identity
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
