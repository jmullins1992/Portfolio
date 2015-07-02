using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWCLMS.Models.Queries
{
    public class CourseFront
    {
        public string CourseName { get; set; }
        public int CourseId { get; set; }
        public int NumOfStudents { get; set; }
        public bool IsArchived { get; set; }
    }
}
