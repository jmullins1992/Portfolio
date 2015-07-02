using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWCLMS.Models.Queries;
using SWCLMS.Models.Requests;
using SWCLMS.Models.Tables;

namespace SWCLMS.Models.Interfaces
{
    public interface ILmsUserRepository
    {
        List<LmsUser> GetUnassignedUsers();

        List<LmsUser> GetStudentsByParentId(int id);

        List<LmsUser> SearchUsers(SearchRequest request);

        LmsUser GetLmsUserById(int id);

        List<string> GetUserRolesById(int id);

        void EditUser(EditUserRequest editUser);

        int CreateUser(LmsUser user);

        LmsUser GetUserByAspId(string aspId);

        void UpdateParentRelationships(int parentId, List<int> childIdList);



    }
}
