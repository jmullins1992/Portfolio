using System;

namespace SWCLMS.Models.Queries
{
    public class GradedAssignment
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string AssignmentName { get; set; }
        public decimal PointsEarned { get; set; }
        public decimal Percentage { get; set; }
        public string Grade { get; set; }
        public int StudentId { get; set; }
        public DateTime DueDate { get; set; }
    }
}
