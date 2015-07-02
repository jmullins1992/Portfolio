using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWCLMS.Models.Tables;

namespace SWCLMS.Models.Queries
{
    public class GradedCourse
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CurrentGrade { get; set; }
    }
}
