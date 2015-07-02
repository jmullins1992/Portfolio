using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SWCLMS.Models.Tables;

namespace SWCLMS.UI.Models
{
    public class ParentChildChecklistVM
    {
        public int ParentId { get; set; }
        public string ParentName { get; set; }
        public List<int> SelectedIds { get; set; }
        public List<UserCheckboxItem> AllUsersSelectList { get; set; }

        public ParentChildChecklistVM()
        {
            SelectedIds = new List<int>();
            AllUsersSelectList = new List<UserCheckboxItem>();
        }

        public void PopulateList(List<LmsUser> allUsers, List<LmsUser> selectedUsers)
        {
            foreach (var user in selectedUsers)
            {
                SelectedIds.Add(user.UserId);
            }

            foreach (var user in allUsers)
            {
                var item = new UserCheckboxItem()
                {
                    IsChecked = selectedUsers.Any(x => x.UserId == user.UserId),
                    Name = user.LastName +", "+ user.FirstName,
                    UserId = user.UserId
                };

                AllUsersSelectList.Add(item);
            }
        }
    }

    public class UserCheckboxItem
    {
        public bool IsChecked { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
    }
}