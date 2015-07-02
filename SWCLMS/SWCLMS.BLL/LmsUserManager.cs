using System;
using System.Collections.Generic;
using System.Linq;
using SWCLMS.Models.Interfaces;
using SWCLMS.Models.Requests;
using SWCLMS.Models.Responses;
using SWCLMS.Models.Tables;

namespace SWCLMS.BLL
{
    public class LmsUserManager
    {
        private readonly ILmsUserRepository _lmsUserRepository;
        private readonly IGradeLevelRepository _gradeLevelRepository;
        private readonly ICourseRepository _courseRepository;

        public LmsUserManager(ILmsUserRepository lmsUserRepository, IGradeLevelRepository gradeLevelRepository, 
            ICourseRepository courseRepository)
        {
            _lmsUserRepository = lmsUserRepository;
            _gradeLevelRepository = gradeLevelRepository;
            _courseRepository = courseRepository;
        }

        public DataResponse<List<LmsUser>> GetUnassignedUsers()
        {
            var response = new DataResponse<List<LmsUser>>();

            try
            {
                response.Data = _lmsUserRepository.GetUnassignedUsers();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public DataResponse<List<LmsUser>> GetStudentsByParentId(int id)
        {
            var response = new DataResponse<List<LmsUser>>();

            try
            {
                response.Data = _lmsUserRepository.GetStudentsByParentId(id).OrderBy(s=>s.FirstName).ToList();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public DataResponse<List<ParentStudentInfo>> GetAllStudentInfoByParentId(int id)
        {
            var response = new DataResponse<List<ParentStudentInfo>>();

            try
            {
                var students = _lmsUserRepository.GetStudentsByParentId(id).OrderBy(s => s.FirstName).ToList();
                response.Data = new List<ParentStudentInfo>();
                foreach (var student in students)
                {
                    var item = new ParentStudentInfo();
                    item.Student = student;
                    item.CoursesListItems = _courseRepository.GetCoursesByStudentId(student.UserId);                    

                    response.Data.Add(item);
                }
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public DataResponse<List<LmsUser>> UserSearch(SearchRequest request)
        {
            var response = new DataResponse<List<LmsUser>>();

            try
            {
                response.Data = _lmsUserRepository.SearchUsers(request);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }

        public UserDetailsResponse GetUserDetailsById(int id)
        {
            var response = new UserDetailsResponse();

            try
            {
                response.GradeLevels = _gradeLevelRepository.GetAllGradeLevels();
                response.User = _lmsUserRepository.GetLmsUserById(id);
                response.UserRoles = _lmsUserRepository.GetUserRolesById(id);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }

        public Response EditUser(EditUserRequest editUserRequest)
        {
            var response = new Response();

            var validation = Validator.Validate(editUserRequest);

            if (!validation.Success)
            {
                response.Message = validation.Message;
                return response;
            }

            try
            {
                _lmsUserRepository.EditUser(editUserRequest);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public DataResponse<int> CreateUser(LmsUser user)
        {
            var response = new DataResponse<int>();

            var validation = Validator.Validate(user);
            if (!validation.Success)
            {
                response.Message = validation.Message;
                return response;
            }

            try
            {
                response.Data = _lmsUserRepository.CreateUser(user);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public DataResponse<List<GradeLevel>> GetAllGradeLevels()
        {
            var response = new DataResponse<List<GradeLevel>>();
            try
            {
                response.Data = _gradeLevelRepository.GetAllGradeLevels();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public DataResponse<LmsUser> GetByAspNetId(string aspNetId)
        {
            var response = new DataResponse<LmsUser>();
            try
            {
                response.Data = _lmsUserRepository.GetUserByAspId(aspNetId);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public Response UpdateParentChildRelationship(int parentId, List<int> childIdList)
        {
            var response = new Response();

            try
            {
                _lmsUserRepository.UpdateParentRelationships(parentId, childIdList);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }

}
