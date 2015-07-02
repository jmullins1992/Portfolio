

namespace SWCLMS.Models.Requests
{
    public class GradeAssignmentRequest
    {
        public int RosterAssignmentId { get; set; }
        public decimal? PointsEarned { get; set; }
        public decimal? Percentage { get; set; }
        public string AssignmentGrade { get; set; }
        public int RosterId { get; set; }
    }
}
