using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SWCLMS.Models.Tables;
using SWCLMS.UI.Models.Base;

namespace SWCLMS.UI.Models
{
    public class UserDetailsVM
    {
        public List<SelectListItem> GradeLevelList { get; set; }
        public List<RoleCheckbox> AllRoles { get; set; }
        //public List<string> UserRoles { get; set; }

        public int UserId { get; set; }

        [Required(ErrorMessage = "Users need a name!")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Users need a name!")]
        public string FirstName { get; set; }

        public string UserName { get; set; }

        public byte? GradeLevelId { get; set; }

        public string SuggestedRole { get; set; }

        public void PopulateVM(List<GradeLevel> gradeLevels, List<string> userRoles, LmsUser user)
        {
            //UserRoles = userRoles;
            GradeLevelList = new List<SelectListItem>();

            foreach (var g in gradeLevels)
            {
                GradeLevelList.Add(new SelectListItem { Text = g.GradeLevelName, Value = g.GradeLevelId.ToString() });
            }

            AllRoles = new List<RoleCheckbox>()
            {
                new RoleCheckbox() { RoleName = "Admin", IsChecked = userRoles.Contains("Admin")},
                new RoleCheckbox() { RoleName = "Teacher", IsChecked = userRoles.Contains("Teacher")},
                new RoleCheckbox() { RoleName = "Parent", IsChecked = userRoles.Contains("Parent")},
                new RoleCheckbox() { RoleName = "Student", IsChecked = userRoles.Contains("Student")}
            };

            FirstName = user.FirstName;
            LastName = user.LastName;
            UserName = user.Email;
            SuggestedRole = user.SuggestedRole;
            GradeLevelId = user.GradeLevelId;
            UserId = user.UserId;
        }
    }
}