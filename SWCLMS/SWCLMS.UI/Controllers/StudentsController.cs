using System.Web.Mvc;
using SWCLMS.BLL;
using SWCLMS.UI.Helpers;

namespace SWCLMS.UI.Controllers
{
    [Authorize(Roles = "Student")]
    public class StudentsController : Controller
    {
        private readonly AssignmentManager _assignmentManager;
        private readonly CourseManager _courseManager;

        public StudentsController(AssignmentManager assignmentMan, CourseManager courseMan)
        {
            _assignmentManager = assignmentMan;
            _courseManager = courseMan;
        }

        // GET: Students
        public ActionResult Index()
        {
            var user = IdentityHelper.GetLmsUserForCurrentUser(this);

            var model = _courseManager.GetCoursesByStudentId(user.UserId);
            return View(model);
        }

        public ActionResult Grades(int id)
        {
            var user = IdentityHelper.GetLmsUserForCurrentUser(this);

            var gradeResponse = _assignmentManager.GetGradedAssignments(id, user.UserId);

            if (gradeResponse.Success)
            {
                return View(gradeResponse);
            }
            else
            {
                ViewBag.ErrorMsg = gradeResponse.Message;
                return View("Error");
            }
        }
    }
}