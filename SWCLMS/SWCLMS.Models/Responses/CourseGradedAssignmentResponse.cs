
namespace SWCLMS.Models.Responses
{
    public class CourseGradedAssignmentResponse : Response
    {
        public decimal? Percentage { get; set; }
        public string OverallGrade { get; set; }
    }
}
