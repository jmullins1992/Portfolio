using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SWCLMS.BLL;
using SWCLMS.UI.Models;
using SWCLMS.UI.Helpers;

namespace SWCLMS.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly LmsUserManager _lmsUserManager;
        private readonly ApplicationUserManager _appUserManager;

        public HomeController(LmsUserManager lmsUserManager, ApplicationUserManager appUserManager)
        {
            _lmsUserManager = lmsUserManager;
            _appUserManager = appUserManager;
        }

        public ActionResult Index()
        {
            Session["CURRENT_USER"] = null;


            if (User.Identity.IsAuthenticated)
            {
                var aspUser = _appUserManager.FindByName(User.Identity.Name);
                var roles = _appUserManager.GetRoles(aspUser.Id);

                if (roles.Count > 1)
                {
                    var vm = new MultiDashboardVM();
                    vm.LmsUser = IdentityHelper.GetLmsUserForCurrentUser(this);
                    vm.IsAdmin = roles.Contains("Admin");
                    vm.IsTeacher = roles.Contains("Teacher");
                    vm.IsParent = roles.Contains("Parent");
                    vm.IsStudent = roles.Contains("Student");
                    return View("MultiDashboard", vm);
                }
                
                if (User.IsInRole("Admin"))
                {
                    return RedirectToAction("Index", "Admin");
                }
                else if (User.IsInRole("Teacher"))
                {
                    return RedirectToAction("Index", "Teachers");
                }
                else if (User.IsInRole("Parent"))
                {
                    return RedirectToAction("Index", "Parents");
                }
                else if (User.IsInRole("Student"))
                {
                    return RedirectToAction("Index", "Students");
                }
                else
                {
                    return RedirectToAction("NotApprovedYet", "Home");
                }
            }
            var gradeLevelResponse = _lmsUserManager.GetAllGradeLevels();
            if (gradeLevelResponse.Success)
            {
                var vm = new LoginRegistrationVM();
                vm.RegisterViewModel.PopulateLists(gradeLevelResponse.Data);
                return View(vm);
            }
            else
            {
                ViewBag.ErrorMsg = gradeLevelResponse.Message;
                return View("Error");
            }

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Error(string message)
        {
            ViewBag.ErrorMessage = message;
            return View("Error");
        }

        public ActionResult NotApprovedYet()
        {
            return View();
        }

        
    }
}