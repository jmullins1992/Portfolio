﻿namespace SWCLMS.Models.Tables
{
    public class LmsUser
    {
        public int UserId { get; set; }
        public string AspId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte? GradeLevelId { get; set; }
        public string SuggestedRole { get; set; }
    }
}
