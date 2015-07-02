using System;
using System.Collections.Generic;
using System.Linq;
using Ninject;
using NUnit.Framework;
using SWCLMS.BLL;
using SWCLMS.Models.Queries;
using SWCLMS.Models.Tables;
using SWCLMS.Tests.Base;

namespace SWCLMS.Tests.BLLTests
{
    [TestFixture]
    public class AssignmentManagerTests : SqlDbResetter
    {
        private IKernel _ninjectKernel;
        private AssignmentManager _assignmentManager;
        private CourseManager _courseManager;

        [TestFixtureSetUp]
        public void SetUpNinject()
        {
            _ninjectKernel = new StandardKernel();

            _ninjectKernel.Load(DependencyLoader.LoadModule());

            _assignmentManager = _ninjectKernel.Get<AssignmentManager>();
            _courseManager = _ninjectKernel.Get<CourseManager>();
        }

        [Test]
        public void AddValidAssignmentIsSuccess()
        {
            var newAssignment = new Assignment()
            {
                CourseId = 1,
                AssignmentName = "MegaTest",
                PossiblePoints = 30,
                DueDate = DateTime.Parse("7/7/2015"),
                AssignmentDescription = "This was added via a test."
            };

            var response = _assignmentManager.AddAssignment(newAssignment);
            Assert.IsTrue(response.Success);
        }

        [Test]
        public void AddInvalidAssignmentFails()
        {
            var newAssignment = new Assignment()
            {
                //No assignment name! Ahhhhhh!!!
                PossiblePoints = 30,
                DueDate = DateTime.Parse("7/7/2015"),
                AssignmentDescription = "This was added via a test."
            };

            var response = _assignmentManager.AddAssignment(newAssignment);
            Assert.IsFalse(response.Success);
        }

        [Test]
        public void GetGradebookIsSuccess()
        {
            var response = _assignmentManager.GetGradebook(1);
            Assert.IsTrue(response.Success);
            Assert.IsTrue(response.CourseDetails.CourseId == 1);
            Assert.IsTrue(response.GradebookListItems.Count > 0);
        }

        [Test]
        public void GetGradedAssignmentsIsSuccess()
        {
            var response = _assignmentManager.GetGradedAssignments(1, 6);
            Assert.IsTrue(response.Success);
        }

        [Test]
        public void CanGradeAssignment()
        {
            var response = _assignmentManager.GradeAssignment(1, 1, 10M, 10);

            Assert.AreEqual(100M, response.Percentage);
            Assert.IsTrue(response.Success);
        }

        [Test]
        public void CanGradeAssignmentReturnsCorrectPercentage()
        {
            var response = _assignmentManager.GradeAssignment(1, 1, 6.5M, 10);

            Assert.AreEqual(65M, response.Percentage);
            Assert.IsTrue(response.Success);
        }

        [Test]
        public void CanDeleteAssignment()
        {
            var gbList = new List<GradebookListItem>()
            {
                new GradebookListItem() {RosterId = 1},
                new GradebookListItem() {RosterId = 2}
            };
            
            Assert.AreEqual(_courseManager.GetCoursesByStudentId(1).Data.First(c => c.CourseId==1).CurrentGrade, "B");

            _assignmentManager.DeleteAssignment(1, gbList);

            Assert.AreEqual(_courseManager.GetCoursesByStudentId(1).Data.First(c=>c.CourseId == 1).CurrentGrade, "C");
        }

        [Test]
        public void CanGetAssignment()
        {
            var assignmentId = 1;

            var result = _assignmentManager.GetAssignmentById(assignmentId);

            Assert.AreEqual(result.Data.AssignmentName, "Quiz 1");
        }
    }
}
