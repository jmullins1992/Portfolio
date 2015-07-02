using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWCLMS.Models.Tables;

namespace SWCLMS.Models.Responses
{
    public class GradeLevelsAndSubjects : Response
    {
        public List<GradeLevel> GradeLevels;
        public List<Subject> Subjects;
    }
}
