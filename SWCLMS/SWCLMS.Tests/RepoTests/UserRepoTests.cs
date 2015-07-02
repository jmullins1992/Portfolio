using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SWCLMS.Data.SQL;
using SWCLMS.Models.Interfaces;
using SWCLMS.Models.Requests;
using SWCLMS.Models.Tables;
using SWCLMS.Tests.Base;

namespace SWCLMS.Tests.RepoTests
{
    public class UserRepoTests : SqlDbResetter
    {
        private ILmsUserRepository _repo = new SqlLmsUserRepository();

        [Test]
        public void CanFindUserById()
        {
            var result = _repo.GetLmsUserById(1);

            Assert.IsNotNull(result);
        }

        [Test]
        public void CanFindUserRolesById()
        {
            var result = _repo.GetUserRolesById(1);

            Assert.IsNotNull(result);
        }

        [Test]
        public void CanEditUser()
        {
            var userId = 1;
            var user = _repo.GetLmsUserById(userId);

            Assert.IsTrue(_repo.GetUserRolesById(userId).Contains("Student"));

            _repo.EditUser(new EditUserRequest() {LmsUser = user, IsParent = true});

            user = _repo.GetLmsUserById(userId);
            Assert.IsTrue(_repo.GetUserRolesById(userId).Contains("Parent"));
            Assert.IsTrue(!_repo.GetUserRolesById(userId).Contains("Student"));

            _repo.EditUser(new EditUserRequest() { LmsUser = user, IsStudent = true });

        }

        [Test]
        public void CanCreateUser()
        {
            var user = new LmsUser()
            {
                FirstName = "Deedee",
                LastName = "Dee",
                Email = "d@d.com",
                GradeLevelId = 3,
                SuggestedRole = "Student"
            };

            var newId = _repo.CreateUser(user);

            Assert.IsTrue(newId > 0);

            var afterResult = _repo.GetLmsUserById(newId);

            Assert.IsTrue(afterResult.FirstName == "Deedee");


        }

        [Test]
        public void CanFindUserByAspId()
        {
            var result = _repo.GetUserByAspId("1a41c074-2b2a-4813-83d9-34f86269c179");

            Assert.IsNotNull(result);
        }

        [Test]
        public void CanRemoveParentChildRelationships()
        {
            var parentId = 4;
            var children = _repo.GetStudentsByParentId(parentId);

            Assert.AreNotEqual(0, children.Count);

            _repo.UpdateParentRelationships(parentId, new List<int>());

            children = _repo.GetStudentsByParentId(parentId);
            Assert.AreEqual(0, children.Count);
        }

        [Test]
        public void CanUpdateParentChildRelationships()
        {
            var parentId = 4;
            var children = _repo.GetStudentsByParentId(parentId);

            Assert.AreNotEqual(0, children.Count);

            _repo.UpdateParentRelationships(parentId, new List<int>{1});

            children = _repo.GetStudentsByParentId(parentId);
            Assert.AreEqual(1, children.Count);
            Assert.IsTrue(children.First().UserId == 1);

        }       
    }
}
