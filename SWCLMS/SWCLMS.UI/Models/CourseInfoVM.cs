using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using SWCLMS.Models.Queries;
using SWCLMS.Models.Tables;
using SWCLMS.UI.Models.Base;

namespace SWCLMS.UI.Models
{
    public class CourseInfoVM : CourseRelatedVM
    {
        public List<SelectListItem> SubjectList { get; set; }
        public List<SelectListItem> GradeLevelList { get; set; }

        [Required]
        public int CourseId { get; set; }

        [Required]
        public int TeacherId { get; set; }

        [Required]
        public int SubjectId { get; set; }

        [Required]
        public string CourseName { get; set; }

        public string CourseDescription { get; set; }

        [Required]
        public int GradeLevelId { get; set; }

        [Required]
        public bool IsArchived { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateTime), "1/1/1800", "1/1/9000", ErrorMessage = "Date is out of Range")]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateTime), "1/1/1800", "1/1/9000", ErrorMessage = "Date is out of Range")]
        public DateTime EndDate { get; set; }

        public void PopulateLists(List<Subject> subjects, List<GradeLevel> gradeLevels)
        {
            SubjectList = new List<SelectListItem>();
            GradeLevelList = new List<SelectListItem>();

            foreach (var g in gradeLevels)
            {
                GradeLevelList.Add(new SelectListItem {Text = g.GradeLevelName, Value = g.GradeLevelId.ToString()});
            }

            foreach (var s in subjects)
            {
                SubjectList.Add(new SelectListItem {Text = s.SubjectName, Value = s.SubjectId.ToString()});                
            }
        }


        public void PopulateCourseData(CourseDetails courseDetails)
        {
            CourseId = courseDetails.CourseId;
            TeacherId = courseDetails.TeacherId;
            SubjectId = courseDetails.SubjectId;
            CourseName = courseDetails.CourseName;
            CourseDescription = courseDetails.CourseDescription;
            GradeLevelId = courseDetails.GradeLevelId;
            IsArchived = courseDetails.IsArchived;
            StartDate = courseDetails.StartDate;
            EndDate = courseDetails.EndDate;
        }

        public Course GetCourseFromVM()
        {
            var output = new Course();

            output.CourseId = this.CourseId;
            output.TeacherId = this.TeacherId;
            output.SubjectId = this.SubjectId;
            output.CourseName = this.CourseName;
            output.CourseDescription = this.CourseDescription;
            output.GradeLevelId = this.GradeLevelId;
            output.IsArchived = this.IsArchived;
            output.StartDate = this.StartDate;
            output.EndDate = this.EndDate;
            
            return output;
        }
    }
}