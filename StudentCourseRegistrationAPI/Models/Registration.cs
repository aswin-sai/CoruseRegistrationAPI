namespace StudentCourseRegistrationAPI.Models
{
    public class Registration
    {
        public int Id { get; set; }

        public int StudentId { get; set; } // FK to Student.Roll
        public Student Student { get; set; }

        public int CourseId { get; set; } // FK to Course.Id
        public Course Course { get; set; }
    }
}