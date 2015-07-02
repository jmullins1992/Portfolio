using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SWCLMS.BLL;
using SWCLMS.UI.Helpers;
using SWCLMS.UI.Models;

namespace SWCLMS.UI.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class TeachersController : Controller
    {
        private readonly CourseManager _courseManager;

        public TeachersController(CourseManager courseManager)
        {
            _courseManager = courseManager;
        }

        // GET: Teachers
        public ActionResult Index()
        {
            var user = IdentityHelper.GetLmsUserForCurrentUser(this);
            var response = _courseManager.GetCoursesByTeacherId(user.UserId);

            if (response.Success)
            {
                return View(response);
                
            }
            else
            {
                ViewBag.ErrorMsg = response.Message;
                return View("Error");
            }
            

        }

        public ActionResult AddCourse()
        {
            var user = IdentityHelper.GetLmsUserForCurrentUser(this);
            var vm = new CourseInfoVM();
            var response = _courseManager.GetGradeLevelsAndSubjects();
            
            vm.TeacherId = user.UserId;
            vm.PopulateLists(response.Subjects, response.GradeLevels);
            vm.StartDate = DateTime.Today;
            vm.EndDate = DateTime.Today.AddMonths(6);
            
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCourse(CourseInfoVM vm)
        {
            if (vm.EndDate <= vm.StartDate)
            {
                ModelState.AddModelError("InvalidTimespan", "End date must be after start date.");
            }

            if (!ModelState.IsValid)
            {               
                var response = _courseManager.GetGradeLevelsAndSubjects();
                if (response.Success)
                {
                    vm.PopulateLists(response.Subjects, response.GradeLevels);
                    return View(vm);
                }
                else
                {
                    ViewBag.ErrorMsg = response.Message;
                    return View("Error");
                }
                
            }

            var updateResponse = _courseManager.AddCourse(vm.GetCourseFromVM());
            if (updateResponse.Success)
            {
                return RedirectToAction("Index", "Teachers");
            }
            else
            {
                ViewBag.ErrorMsg = updateResponse.Message;
                return View("Error");
            }
        }        
    }
}