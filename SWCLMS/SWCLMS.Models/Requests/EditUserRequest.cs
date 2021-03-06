﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWCLMS.Models.Tables;

namespace SWCLMS.Models.Requests
{
    public class EditUserRequest
    {
        public LmsUser LmsUser { get; set; }
        public bool IsStudent { get; set; }
        public bool IsParent { get; set; }
        public bool IsTeacher { get; set; }
        public bool IsAdmin { get; set; }
    }
}
