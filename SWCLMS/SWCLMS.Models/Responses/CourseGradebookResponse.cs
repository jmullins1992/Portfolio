using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWCLMS.Models.Queries;

namespace SWCLMS.Models.Responses
{
    public class CourseGradebookResponse : Response
    {
        public CourseDetails CourseDetails { get; set; }
        public List<GradebookListItem> GradebookListItems { get; set; }

    }
}
