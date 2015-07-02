using System;

namespace SWCLMS.Models.Tables
{
    public class Assignment
    {
        public int AssignmentId { get; set; }
        public int CourseId { get; set; }
        public string AssignmentName { get; set; }
        public int PossiblePoints { get; set; }
        public DateTime DueDate { get; set; }
        public string AssignmentDescription { get; set; }
    }
}