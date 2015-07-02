using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWCLMS.Models.Requests;
using SWCLMS.Models.Responses;
using SWCLMS.Models.Tables;

namespace SWCLMS.BLL
{
    public class Validator
    {
        public static Response Validate(LmsUser user)
        {
            var response = new Response();
            if (string.IsNullOrEmpty(user.FirstName))
            {
                response.Message = "First name cannot be empty.";
            }
            else if (string.IsNullOrEmpty(user.LastName))
            {
                response.Message = "Last name cannot be empty.";                
            }
            else if (string.IsNullOrEmpty(user.Email))
            {
                response.Message = "Email cannot be empty.";
            }

            if (string.IsNullOrEmpty(response.Message))
            {
                response.Success = true;
            }
            return response;
        }

        public static Response Validate(EditUserRequest request)
        {
            var response = new Response();

            var userValidation = Validate(request.LmsUser);
            if (!userValidation.Success)
            {
                response.Message = userValidation.Message;
            }
            if (request.IsStudent && request.LmsUser.GradeLevelId == null)
            {
                response.Message = "Students must be assigned a grade level.";
            }
            if (string.IsNullOrEmpty(response.Message))
            {
                response.Success = true;
            }
            return response;
        }
    }
}
