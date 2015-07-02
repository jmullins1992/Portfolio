using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SWCLMS.Models.Tables;
using SWCLMS.UI.Models.Base;

namespace SWCLMS.UI.Models
{
    public class AdminIndexVM 
    {
        public List<LmsUser> LmsUsers { get; set; }
    }
}