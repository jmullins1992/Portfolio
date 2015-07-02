using System.Web.Mvc;
using SWCLMS.BLL;
using SWCLMS.UI.Helpers;
using SWCLMS.UI.Models;

namespace SWCLMS.UI.Controllers
{
    [Authorize(Roles = "Parent")]
    public class ParentsController : Controller
    {
        private LmsUserManager _lmsUserManager;
        private readonly AssignmentManager _assignmentMgr;

        public ParentsController(LmsUserManager userMan, AssignmentManager assignmentMgr)
        {
            _lmsUserManager = userMan;
            _assignmentMgr = assignmentMgr;
        }

        // GET: Parents
        public ActionResult Index()
        {
            var user = IdentityHelper.GetLmsUserForCurrentUser(this);

            var studentResponse = _lmsUserManager.GetAllStudentInfoByParentId(user.UserId);

            if (studentResponse.Success)
            {
                var vm = new ParentDashboardVM();
                vm.ChildList = studentResponse.Data;
                return View(vm);
            }
            else
            {
                ViewBag.ErrorMsg = studentResponse.Message;
                return View("Error");
            }
        }

        public ActionResult Grades(int studentId, int courseId)
        {
            var gradeResponse = _assignmentMgr.GetGradedAssignments(courseId, studentId);

            if (gradeResponse.Success)
            {
                return PartialView("_StudentGradedAssignments", gradeResponse);
            }
            else
            {
                ViewBag.ErrorMsg = gradeResponse.Message;
                return View("Error");
            }
        }
    }
}