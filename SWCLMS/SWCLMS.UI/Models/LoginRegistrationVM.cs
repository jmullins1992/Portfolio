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
    public class LoginRegistrationVM 
    {
        public LoginViewModel LoginViewModel { get; set; }
        public RegisterViewModel RegisterViewModel { get; set; }

        public LoginRegistrationVM()
        {
            LoginViewModel = new LoginViewModel();
            RegisterViewModel = new RegisterViewModel();
        }
    }

    public class LoginViewModel 
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }


    public class RegisterViewModel 
    {
        [Required]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "LastName")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "I am a...")]
        public string SuggestedRole { get; set; }

        [Display(Name = "Grade Level")]
        public byte? GradeLevelId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password",
            ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }


        public List<SelectListItem> GradeLevels { get; set; }
        public List<SelectListItem> Roles { get; set; }

        public void PopulateLists(List<GradeLevel> gradeLevels)
        {
            GradeLevels = new List<SelectListItem>();

            foreach (var g in gradeLevels)
            {
                GradeLevels.Add(new SelectListItem {Text = g.GradeLevelName, Value = g.GradeLevelId.ToString()});
            }

            Roles = new List<SelectListItem>()
            {
                new SelectListItem() {Text = "Admin", Value = "Admin"},
                new SelectListItem() {Text = "Teacher", Value = "Teacher"},
                new SelectListItem() {Text = "Student", Value = "Student"},
                new SelectListItem() {Text = "Parent", Value = "Parent"}

            };
        }
    }
}