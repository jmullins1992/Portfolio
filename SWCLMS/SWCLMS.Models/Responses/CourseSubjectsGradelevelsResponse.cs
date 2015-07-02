using System.Collections.Generic;
using SWCLMS.Models.Queries;
using SWCLMS.Models.Tables;

namespace SWCLMS.Models.Responses
{
    public class CourseSubjectsGradelevelsResponse : Response
    {
        public CourseDetails CourseDetails { get; set; }
        public List<GradeLevel> GradeLevels { get; set; }
        public List<Subject> Subjects { get; set; }
    }
}
