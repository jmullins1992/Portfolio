
using SWCLMS.Models.Tables;

namespace SWCLMS.UI.Models
{
    public class MultiDashboardVM
    {
        public LmsUser LmsUser { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsTeacher { get; set; }
        public bool IsParent { get; set; }
        public bool IsStudent { get; set; }
    }
}