using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWCLMS.Models.Queries;

namespace SWCLMS.Models.Responses
{
    public class StudentGradedAssignmentsResponse : Response
    {
        public CourseDetails CourseDetails { get; set; }
        public List<GradedAssignment> GradedAssignments { get; set; }
    }
}
