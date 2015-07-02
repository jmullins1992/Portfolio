using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using SWCLMS.BLL;
using SWCLMS.Models.Requests;
using SWCLMS.Models.Tables;
using SWCLMS.UI.Models;

namespace SWCLMS.UI.Controllers

{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private LmsUserManager _lmsUserManager;
        private LogoManager _logoManager;

        public AdminController(LmsUserManager lmsUserManager)
        {
            _lmsUserManager = lmsUserManager;
            _logoManager = new LogoManager();
        }

        public ActionResult Index()
        {
            var model = new AdminIndexVM();
            var response = _lmsUserManager.GetUnassignedUsers();
            
            if (response.Success)
                model.LmsUsers = response.Data;

            return View(model);
        }

        public ActionResult Search()
        {
            var model = new UserSearchVM();
            return View(model);
        }

        [HttpPost]
        public ActionResult Search(UserSearchVM vm)
        {
            var response = _lmsUserManager.UserSearch(vm.Request);
            if (response.Success)
            {
                vm.Results = response.Data.DistinctBy(u=>u.UserId).ToList();
                return View(vm);
            }
            else
            {
                return HttpNotFound(response.Message);
            }
        }

        public ActionResult UserDetails(int id)
        {
            var response = _lmsUserManager.GetUserDetailsById(id);

            if (response.Success)
            {
                var vm = new UserDetailsVM();
                vm.PopulateVM(response.GradeLevels, response.UserRoles, response.User);
                return View(vm);
            }
            else
            {
                ViewBag.ErrorMsg = response.Message;
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult UserDetails(UserDetailsVM model)
        {
            if (model.AllRoles.First(r => r.RoleName == "Student").IsChecked && !model.GradeLevelId.HasValue)
            {
                ModelState.AddModelError("Gradeless", "Students must have a grade level.");
            }

            if (!ModelState.IsValid)
            {
                var r = _lmsUserManager.GetUserDetailsById(model.UserId); 
                model.PopulateVM(r.GradeLevels, r.UserRoles, r.User);
                return View(model);
            }

            var editUserRequest = new EditUserRequest();
            editUserRequest.LmsUser = new LmsUser()
            {
                UserId = model.UserId,
                Email = model.UserName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                GradeLevelId = model.GradeLevelId,
                SuggestedRole = model.SuggestedRole
            };
            editUserRequest.IsStudent = model.AllRoles.First(x => x.RoleName == "Student").IsChecked;
            editUserRequest.IsParent = model.AllRoles.First(x => x.RoleName == "Parent").IsChecked;
            editUserRequest.IsTeacher = model.AllRoles.First(x => x.RoleName == "Teacher").IsChecked;
            editUserRequest.IsAdmin = model.AllRoles.First(x => x.RoleName == "Admin").IsChecked;

            var response = _lmsUserManager.EditUser(editUserRequest);

            if (response.Success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMsg = response.Message;
                return View("Error");
            }
            
        }

        public ActionResult UploadLogo()
        {
            var vm = new LogoUploadVM();
            return View(vm);
        }

        [HttpPost]
        public ActionResult UploadLogo(LogoUploadVM vm)
        {
            var fn = vm.Logo.FileName;
            var length = fn.Length;

            if (vm.Logo != null && vm.Logo.ContentLength > 0 && fn.Substring(length-4) == ".png")
                try
                {
                    var path = Path.Combine(Server.MapPath("~/Uploads"), "Logo.png");
                    vm.Logo.SaveAs(path);
                    //_logoManager.SetLogo(vm.Logo.FileName);
                    ViewBag.Message = "File Uploaded Successfully";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "Error: " + ex.Message;
                }
            else
            {
                ViewBag.Message = "You have not specified a valid file.";
            }

            vm = new LogoUploadVM();
            return View(vm);
        }

        public ActionResult UpdateChildren(int id)
        {
            var vm = new ParentChildChecklistVM();
            vm.ParentId = id;
            var searchRequest = new SearchRequest
            {
                RoleName = "Student"
            };

            var searchResponse = _lmsUserManager.UserSearch(searchRequest);

            if (!searchResponse.Success)
            {
                ViewBag.ErrorMsg = searchResponse.Message;
                return View("Error");
            }

            var studentResponse = _lmsUserManager.GetStudentsByParentId(id);

            if (studentResponse.Success)
            {
                vm.PopulateList(searchResponse.Data, studentResponse.Data);
                return View("SelectUserChildren", vm);
            }
            else
            {
                ViewBag.ErrorMsg = studentResponse.Message;
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult UpdateChildren(ParentChildChecklistVM model)
        {
            var childIdList = new List<int>();
            foreach (var item in model.AllUsersSelectList)
            {
                if (item.IsChecked)
                {
                    childIdList.Add(item.UserId);
                }
            }

            var response = _lmsUserManager.UpdateParentChildRelationship(model.ParentId, childIdList);
            if (response.Success)
            {
                return RedirectToAction("UserDetails", new {id = model.ParentId});
            }
            else
            {
                ViewBag.ErrorMsg = response.Message;
                return View("Error");
            }

        }
    }
}