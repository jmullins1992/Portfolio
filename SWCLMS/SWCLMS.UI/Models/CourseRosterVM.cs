using System.Collections.Generic;
using System.Web.Mvc;
using SWCLMS.Models.Responses;
using SWCLMS.Models.Tables;
using SWCLMS.UI.Models.Base;

namespace SWCLMS.UI.Models
{
    public class CourseRosterVM : CourseRelatedVM
    {
        public CourseRosterResponse RosterResponse { get; set; }
        public List<SelectListItem> GradeLevelList { get; set; }

        public string SearchLastName { get; set; }
        public int? SearchGradelevelId { get; set; }

        public void PopulateSelectLists(List<GradeLevel> gradeLevels)
        {
            GradeLevelList = new List<SelectListItem>();

            foreach (var g in gradeLevels)
            {
                GradeLevelList.Add(new SelectListItem { Text = g.GradeLevelName, Value = g.GradeLevelId.ToString() });
            }
        }

    }
}