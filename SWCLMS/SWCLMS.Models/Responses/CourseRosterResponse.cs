using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWCLMS.Models.Queries;
using SWCLMS.Models.Tables;

namespace SWCLMS.Models.Responses
{
    public class CourseRosterResponse : Response
    {
        public CourseDetails CourseDetails { get; set; }
        public List<GradeLevel> GradeLevels { get; set; }
        public List<LmsUserDetails> StudentsInCourse { get; set; }
        public List<LmsUserDetails> StudentsNotInCourse { get; set; }
    }
}
