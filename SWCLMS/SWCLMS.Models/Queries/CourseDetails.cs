using System;

namespace SWCLMS.Models.Queries
{
    public class CourseDetails
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int TeacherId { get; set; }
        public string TeacherFirstName { get; set; }
        public string TeacherLastName { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsArchived { get; set; }
        public string CourseDescription { get; set; }
        public int GradeLevelId { get; set; }
        public string GradeLevelName { get; set; }

    }
}
