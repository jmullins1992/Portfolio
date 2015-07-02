using System;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using SWCLMS.BLL;
using SWCLMS.Models.Responses;
using SWCLMS.Models.Tables;
using SWCLMS.UI.Models;

namespace SWCLMS.UI.Controllers
{
    [Authorize(Roles = "Teacher, Admin")]
    public class CoursesController : Controller
    {

        private readonly CourseManager _courseManager;
        private readonly AssignmentManager _assignmentManager;

        public CoursesController(CourseManager courseManager, AssignmentManager assignmentManager)
        {
            _assignmentManager = assignmentManager;
            _courseManager = courseManager;
        }

        public ActionResult AddAssignment(int id)
        {
            var courseId = id;
            var courseResponse = _courseManager.GetCourseDetailsById(courseId);
            if (courseResponse.Success)
            {
                var vm = new AddAssignmentVM()
                {
                    CourseDetails = courseResponse.Data,
                    CourseId = courseResponse.Data.CourseId,
                    DueDate = DateTime.Today
                };
                return View(vm);
            }
            else
            {
                ViewBag.ErrorMsg = courseResponse.Message;
                return View("Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddAssignment(AddAssignmentVM vm)
        {

            if (vm.DueDate > vm.CourseDetails.EndDate || vm.DueDate < vm.CourseDetails.StartDate)
            {
                ModelState.AddModelError("DateRange", "The due date must be between the start date and end date of the course.");
            }

            if (!ModelState.IsValid)
            {
                var courseResponse = _courseManager.GetCourseDetailsById(vm.CourseId);
                if (courseResponse.Success)
                {
                    vm.CourseDetails = courseResponse.Data;                    
                    return View(vm);
                }
                else
                {
                    ViewBag.ErrorMsg = courseResponse.Message;
                    return View("Error");
                }                
            }

            

            var newAssignment = new Assignment()
            {
                AssignmentDescription = vm.AssignmentDescription,
                AssignmentName = vm.AssignmentName,
                CourseId = vm.CourseId,
                DueDate = vm.DueDate,
                PossiblePoints = vm.PossiblePoints
            };

            var response = _assignmentManager.AddAssignment(newAssignment);
            if (response.Success)
            {
                return RedirectToAction("Gradebook", new { id = newAssignment.CourseId });
            }
            else
            {
                ViewBag.ErrorMsg = response.Message;
                return View("Error");
            }
        }

        public ActionResult Information(int id)
        {
            var response = _courseManager.GetCourseByIdAndSubjectsAndGradelevels(id);
            if (response.Success)
            {
                var vm = new CourseInfoVM();
                vm.CourseDetails = response.CourseDetails;
                vm.PopulateCourseData(response.CourseDetails);
                vm.PopulateLists(response.Subjects, response.GradeLevels);
                return View(vm);
            }
            else
            {
                ViewBag.ErrorMsg = response.Message;
                return View("Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Information(CourseInfoVM vm)
        {
            if (vm.EndDate <= vm.StartDate)
            {
                ModelState.AddModelError("InvalidTimespan", "End date must be after start date.");
            }

            if (!ModelState.IsValid)
            {
                var response = _courseManager.GetCourseByIdAndSubjectsAndGradelevels(vm.CourseId);
                if (response.Success)
                {
                    vm.CourseDetails = response.CourseDetails;
                    vm.PopulateLists(response.Subjects, response.GradeLevels);
                    return View(vm);
                }
                else
                {
                    ViewBag.ErrorMsg = response.Message;
                    return View("Error");
                }
            }

            var updateResponse = _courseManager.UpdateCourseInfo(vm.GetCourseFromVM());
            if (updateResponse.Success)
            {
                return RedirectToAction("Information", new { id = vm.CourseId });
            }
            else
            {
                ViewBag.ErrorMsg = updateResponse.Message;
                return View("Error");
            }
        }        

        public ActionResult Roster(int id, string searchLastName, int? searchGradeLevelId)
        {
            var response = _courseManager.GetRosterResponse(id);
            if (!response.Success)
            {
                ViewBag.ErrorMsg = response.Message;
                return View("Error");
            }

            var vm = new CourseRosterVM
            {
                CourseDetails = response.CourseDetails,
                SearchGradelevelId = searchGradeLevelId,
                SearchLastName = searchLastName,
                RosterResponse = response
            };
            vm.PopulateSelectLists(response.GradeLevels);


            var filteredList = vm.RosterResponse.StudentsNotInCourse;

            if (!string.IsNullOrEmpty(vm.SearchLastName))
            {
                var searchTerm = vm.SearchLastName.ToUpper();
                filteredList =
                    vm.RosterResponse.StudentsNotInCourse.Where(
                        s => s.LastName.ToUpper().Contains(searchTerm)).ToList();
            }
            if (vm.SearchGradelevelId != null)
            {
                filteredList =
                    filteredList.Where(
                    s => s.GradeLevelId == vm.SearchGradelevelId.Value).ToList();
            }

            vm.RosterResponse.StudentsNotInCourse = filteredList;

            return View(vm);

        }

        [HttpPost]
        public ActionResult AddStudentToCourse(int id, int studentId, CourseRosterVM vm)
        {            
            var response = _courseManager.AddStudentToCourse(studentId, id);
            if (response.Success)
            {
                //return Roster(id, vm.SearchLastName, vm.SearchGradelevelId);
                return RedirectToAction("Roster", new { id, searchLastName = vm.SearchLastName, searchGradeLevelId = vm.SearchGradelevelId });

            }
            else
            {
                ViewBag.ErrorMsg = response.Message;
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult DeleteStudentFromCourse(int id, int studentId, CourseRosterVM vm)
        {
            var response = _courseManager.DeleteStudentFromCourse(studentId, id);
            if (response.Success)
            {
                //return Roster(id, vm.SearchLastName, vm.SearchGradelevelId);
                return RedirectToAction("Roster", new { id, searchLastName = vm.SearchLastName, searchGradeLevelId = vm.SearchGradelevelId });
            }
            else
            {
                ViewBag.ErrorMsg = response.Message;
                return View("Error");
            }
        }

        public ActionResult Gradebook(int id)
        {
            var response = _assignmentManager.GetGradebook(id);

            if (!response.Success)
            {
                ViewBag.ErrorMsg = response.Message;
                return View("Error");
            }

            var vm = new CourseGradebookVM();
            vm.CourseDetails = response.CourseDetails;
            vm.GradebookList = response.GradebookListItems;           

            //todo move this to VM
            vm.AllAssignments =
                response.GradebookListItems
                .OrderBy(a => a.DueDate)
                .Select(a => new GradebookAssignment()
                {
                    PossiblePoints = a.PossiblePoints,
                    AssignmentId = a.AssignmentId,
                    AssignmentName = a.AssignmentName
                }).DistinctBy(b => b.AssignmentId).ToList();

            vm.AllStudents =
                response.GradebookListItems
                .OrderBy(a => a.LastName)
                .Select(a => new GradebookStudent()
                {
                    RosterId = a.RosterId,
                    CurrentGrade = a.CurrentGrade,
                    StudentFirstName = a.FirstName,
                    StudentLastName = a.LastName

                }).DistinctBy(b => b.RosterId).ToList();

            return View(vm);
        }

        public JsonResult GradeAssignment(int rosterAssignmentId, int rosterId, decimal? pointsEarned, int possiblePoints)
        {
            //int rosterAssignmentId = int.Parse(stringId.Substring(2));
            var response = _assignmentManager.GradeAssignment(rosterId, rosterAssignmentId, pointsEarned, possiblePoints);
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AssignmentInformation(int Id, int assignmentId)
        {
            var courseId = Id;
            var assignmentResponse = _assignmentManager.GetAssignmentById(assignmentId);
            var courseResponse = _courseManager.GetCourseDetailsById(courseId);

            if (courseResponse.Success && assignmentResponse.Success)
            {
                var assignmentDetails = assignmentResponse.Data;

                var vm = new AddAssignmentVM()
                {
                    AssignmentId = assignmentId,
                    CourseDetails = courseResponse.Data,
                    CourseId = courseResponse.Data.CourseId,
                    AssignmentName = assignmentDetails.AssignmentName,
                    PossiblePoints =  assignmentDetails.PossiblePoints,
                    AssignmentDescription = assignmentDetails.AssignmentDescription,
                    DueDate = assignmentDetails.DueDate
                };
                return View(vm);
            }
            else
            {
                ViewBag.ErrorMsg = courseResponse.Message + assignmentResponse.Message;
                return View("Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AssignmentInformation(AddAssignmentVM vm)
        {
            if (!ModelState.IsValid)
            {
                
                var courseResponse = _courseManager.GetCourseDetailsById(vm.CourseId);
                
                if (courseResponse.Success)
                {
                    vm.CourseDetails = courseResponse.Data;
                    return View(vm);
                }
                else
                {
                    ViewBag.ErrorMsg = courseResponse.Message;
                    return View("Error");
                }
            }

            var deleteResponse = _assignmentManager.DeleteAssignment(vm.AssignmentId, _assignmentManager.GetGradebook(vm.CourseId).GradebookListItems);

            if (!deleteResponse.Success)
            {
                ViewBag.ErrorMsg = deleteResponse.Message;
                return View("Error");
            }

            var newAssignment = new Assignment()
            {
                AssignmentDescription = vm.AssignmentDescription,
                AssignmentName = vm.AssignmentName,
                CourseId = vm.CourseId,
                DueDate = vm.DueDate,
                PossiblePoints = vm.PossiblePoints
            };

            var response = _assignmentManager.AddAssignment(newAssignment);
            if (response.Success)
            {
                return RedirectToAction("Gradebook", new { id = newAssignment.CourseId });
            }
            else
            {
                ViewBag.ErrorMsg = response.Message;
                return View("Error");
            }
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteAssignment(int id, int assignmentId)
        {
            var courseId = id;
            var gbList = _assignmentManager.GetGradebook(courseId).GradebookListItems;

            var response = _assignmentManager.DeleteAssignment(assignmentId, gbList);

            if (response.Success)
            {
                return RedirectToAction("Gradebook", new {id = courseId});
            }
            else
            {
                ViewBag.ErrorMsg = response.Message;
                return View("Error");
            }
        }
    }
}