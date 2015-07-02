using System.Collections.Generic;
using SWCLMS.Models.Interfaces;
using SWCLMS.Models.Requests;
using SWCLMS.Models.Tables;

namespace SWCLMS.Data.Mocks
{
    public class MockLmsUserRepository : ILmsUserRepository
    {
        public List<LmsUser> GetUnassignedUsers()
        {
            return new List<LmsUser>()
            {
                new LmsUser()
                {
                    Email = "eric@swcguild.com",
                    FirstName = "Eric",
                    LastName = "Wise",
                    SuggestedRole = "Admin",
                    GradeLevelId = null,
                    AspId = "1",
                    UserId = 1
                },
                new LmsUser()
                {
                    Email = "alincoln@swcguild.com",
                    FirstName = "Abraham",
                    LastName = "Lincoln",
                    SuggestedRole = "Teacher",
                    GradeLevelId = null,
                    AspId = "2",
                    UserId = 2
                },
                new LmsUser()
                {
                    Email = "joe.schmoe@swcguild.com",
                    FirstName = "Joe",
                    LastName = "Schmoe",
                    SuggestedRole = "Student",
                    GradeLevelId = null,
                    AspId = "3",
                    UserId = 3
                },
                new LmsUser()
                {
                    Email = "jane.schmoe@swcguild.com",
                    FirstName = "Jane",
                    LastName = "Schmoe",
                    SuggestedRole = "Parent",
                    GradeLevelId = null,
                    AspId = "4",
                    UserId = 4
                }
            };
        }

        public List<LmsUser> GetStudentsByParentId(int id)
        {
            return new List<LmsUser>()
            {
                new LmsUser()
                {
                    Email = "joe.schmoe@swcguild.com",
                    FirstName = "Joe",
                    LastName = "Schmoe",
                    SuggestedRole = "Student",
                    GradeLevelId = 10,
                    AspId = "3",
                    UserId = 3
                },
                new LmsUser()
                {
                    Email = "janet.schmoe@swcguild.com",
                    FirstName = "Janet",
                    LastName = "Schmoe",
                    SuggestedRole = "Student",
                    GradeLevelId = 11,
                    AspId = "4",
                    UserId = 4
                }
            };
        }

        public List<LmsUser> SearchUsers(SearchRequest request)
        {
            return new List<LmsUser>()
            {
                new LmsUser()
                {
                    Email = "joe.schmoe@swcguild.com",
                    FirstName = "Joe",
                    LastName = "Schmoe",
                    SuggestedRole = "Student",
                    GradeLevelId = 10,
                    AspId = "3",
                    UserId = 3
                },
                new LmsUser()
                {
                    Email = "janet.schmoe@swcguild.com",
                    FirstName = "Janet",
                    LastName = "Schmoe",
                    SuggestedRole = "Student",
                    GradeLevelId = 11,
                    AspId = "4",
                    UserId = 4
                }
            };
        }


        public LmsUser GetLmsUserById(int id)
        {
            throw new System.NotImplementedException();
        }


        public List<string> GetUserRolesById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void EditUser(EditUserRequest editUser)
        {
            throw new System.NotImplementedException();
        }


        public int CreateUser(LmsUser user)
        {
            throw new System.NotImplementedException();
        }


        public LmsUser GetUserByAspId(string aspId)
        {
            throw new System.NotImplementedException();
        }


        public void UpdateParentRelationships(int parentId, List<int> childIdList)
        {
            throw new System.NotImplementedException();
        }
    }
}
