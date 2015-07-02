using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SWCLMS.Models.Queries;
using SWCLMS.Models.Responses;
using SWCLMS.Models.Tables;
using SWCLMS.UI.Models.Base;

namespace SWCLMS.UI.Models
{
    public class ParentDashboardVM
    {
        public List<ParentStudentInfo> ChildList { get; set; }        
    }
}