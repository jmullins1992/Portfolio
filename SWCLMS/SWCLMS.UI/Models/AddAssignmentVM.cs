using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Http.Results;
using SWCLMS.UI.Models.Base;

namespace SWCLMS.UI.Models
{
    public class AddAssignmentVM : CourseRelatedVM
    {
        [Required]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "The Name Field is required")]
        [MaxLength(50)]
        public string AssignmentName { get; set; }

        [Required(ErrorMessage = "The Required Points Field is required")]
        [Range(1, 100000000, ErrorMessage = "Possible points must be at between 1 and 100000000.")]
        public int PossiblePoints { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DueDate { get; set; }

        [Required(ErrorMessage = "The Description Field is required")]
        [MaxLength(255)]
        public string AssignmentDescription { get; set; }

        public int AssignmentId { get; set; }

    }
}