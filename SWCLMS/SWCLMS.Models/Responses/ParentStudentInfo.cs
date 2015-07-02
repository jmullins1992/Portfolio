using System.Collections.Generic;
using SWCLMS.Models.Queries;
using SWCLMS.Models.Tables;

namespace SWCLMS.Models.Responses
{
    public class ParentStudentInfo
    {
        public LmsUser Student { get; set; }
        public List<GradedCourse> CoursesListItems { get; set; }
    }
}
