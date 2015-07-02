using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWCLMS.Models.Queries
{
    public class GradebookListItem
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CurrentGrade { get; set; }
        public string AssignmentName { get; set; }
        public decimal? PointsEarned { get; set; }
        public decimal? Percentage { get; set; }
        public int RosterAssignmentId { get; set; }
        public DateTime DueDate { get; set; }
        public int AssignmentId { get; set; }
        public int RosterId { get; set; }
        public int PossiblePoints { get; set; }
    }
}
