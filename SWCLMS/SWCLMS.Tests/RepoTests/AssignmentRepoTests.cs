using System;
using System.Data.SqlClient;
using System.Linq;
using NUnit.Framework;
using SWCLMS.Data.SQL;
using SWCLMS.Models.Interfaces;
using SWCLMS.Models.Requests;
using SWCLMS.Models.Tables;
using SWCLMS.Tests.Base;

namespace SWCLMS.Tests.RepoTests
{
    public class AssignmentRepoTests : SqlDbResetter
    {
        private IAssignmentRepository _repo = new SqlAssignmentRepository();

        [Test]
        public void CanGetGradedAssignmentByRosterId()
        {
            var response = _repo.GetGradedAssignments(1);

            Assert.AreNotEqual(response.Count, 0);
        }

        [Test]
        public void CanAddValidAssignment()
        {

            var assignment = new Assignment()
            {
                CourseId = 1,
                AssignmentName = "Busy Work",
                PossiblePoints = 30,
                DueDate = DateTime.Parse("7/7/2015"),
                AssignmentDescription = "You should do this stuff."
            };

            _repo.AddAssignment(assignment);
        }

        [Test]     
        [ExpectedException(typeof(SqlException))]
        public void CannotAddInvalidAssignment()
        {

            var assignment = new Assignment()
            {
                CourseId = 1,
                //No assignment name! Oh no!
                PossiblePoints = 30,
                DueDate = DateTime.Parse("7/7/2015"),
                AssignmentDescription = "Do it do it!."
            };

            _repo.AddAssignment(assignment);
        }

        [Test]
        public void GetGradebookReturnsNonEmptyList()
        {
            var results = _repo.GetGradebookForCourseId(1);

            Assert.IsTrue(results.Count > 0);
        }

        [Test]
        public void CanGradeAssignment()
        {
            var gradebook = _repo.GetGradebookForCourseId(1);
            var target = gradebook.First();

            var pointsBefore = target.PointsEarned;

            var request = new GradeAssignmentRequest()
            {
                AssignmentGrade = "A",
                Percentage = 100.00M,
                PointsEarned = 10,
                RosterAssignmentId = target.RosterAssignmentId,
                RosterId = target.RosterId
            };

            _repo.GradeAssignment(request);

            gradebook = _repo.GetGradebookForCourseId(1);
            target = gradebook.First(a => a.RosterAssignmentId == target.RosterAssignmentId);

            Assert.AreNotEqual(pointsBefore, target.PointsEarned);
            Assert.IsTrue(target.PointsEarned == 10);
        }

        [Test]
        public void CanDeleteAssignment()
        {
            var assignment = new Assignment()
            {
                CourseId = 1,
                AssignmentName = "Busy Work",
                PossiblePoints = 30,
                DueDate = DateTime.Parse("7/7/2015"),
                AssignmentDescription = "You should do this stuff."
            };

            var x = _repo.GetGradebookForCourseId(1).GroupBy(a=>a.AssignmentId).ToList().Count;

            _repo.AddAssignment(assignment); // should be 14 according to sample data 

            _repo.DeleteAssignment(14);

            Assert.AreEqual(_repo.GetGradebookForCourseId(1).GroupBy(a=>a.AssignmentId).ToList().Count, x);
        }

        [Test]
        public void CanGetAssignment()
        {
            var assignment = _repo.GetAssignmentById(1);

            Assert.AreEqual(assignment.AssignmentName, "Quiz 1"); //per sample data
        }
    }
}
