using System.Collections.Generic;
using System.Web.Mvc;
using SWCLMS.Models.Requests;
using SWCLMS.Models.Tables;
using SWCLMS.UI.Models.Base;

namespace SWCLMS.UI.Models
{
    public class UserSearchVM
    {
        public SearchRequest Request { get; set; }
        public List<LmsUser> Results { get; set; } 

        public List<SelectListItem> Roles = new List<SelectListItem>()
        {
            new SelectListItem() {Text = "Admin", Value = "Admin"},
            new SelectListItem() {Text = "Teacher", Value = "Teacher"},
            new SelectListItem() {Text = "Student", Value = "Student"},
            new SelectListItem() {Text = "Parent", Value = "Parent"}
        };

        public UserSearchVM()
        {
            Results = new List<LmsUser>();
        }
    }
}