using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWCLMS.Models.Tables;

namespace SWCLMS.Models.Responses
{
    public class UserDetailsResponse : Response
    {
        public LmsUser User { get; set; }
        public List<GradeLevel> GradeLevels { get; set; }
        public List<string> UserRoles { get; set; }
    }
}
