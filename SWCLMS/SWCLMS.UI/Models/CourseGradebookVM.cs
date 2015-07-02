using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SWCLMS.Models.Queries;
using SWCLMS.UI.Models.Base;

namespace SWCLMS.UI.Models
{
    public class CourseGradebookVM : CourseRelatedVM
    {
        public List<GradebookListItem> GradebookList { get; set; }
        public List<GradebookAssignment> AllAssignments { get; set; }
        public List<GradebookStudent> AllStudents { get; set; }


    }

    public class GradebookAssignment
    {
        public int PossiblePoints { get; set; }
        public int AssignmentId { get; set; }
        public string AssignmentName { get; set; }
    }

    public class GradebookStudent
    {
        public int RosterId { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        public string CurrentGrade { get; set; }
    }
}