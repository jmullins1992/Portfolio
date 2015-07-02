using System;

namespace SWCLMS.Models.Tables
{
    public class Course
    {
        public int CourseId { get; set; }
        public int TeacherId { get; set; }
        public int SubjectId { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public int GradeLevelId { get; set; }
        public bool IsArchived { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
