using System;
using NUnit.Framework;
using SWCLMS.Data.SQL;
using SWCLMS.Models.Interfaces;
using SWCLMS.Models.Tables;

namespace SWCLMS.Tests.RepoTests
{
    [TestFixture]
    public class CoursesRepoTests
    {
        private ICourseRepository _courseRepo = new SqlCourseRepository();

        [Test]
        public void GetStudentsInCourseReturnsNonEmptyList()
        {
            var results = _courseRepo.GetStudentsInCourse(1);

            Assert.IsTrue(results.Count > 0);
        }

        [Test]
        public void GetStudentsNotInCourseReturnsNonEmptyList()
        {
            var results = _courseRepo.GetStudentsNotInCourse(1);

            Assert.IsTrue(results.Count > 0);
        }

        [Test]
        public void CanRemoveStudentFromCourse()
        {
            var count = _courseRepo.GetStudentsInCourse(1).Count;
            _courseRepo.DeleteStudentFromCourse(2, 1);
            Assert.IsTrue(count > _courseRepo.GetStudentsInCourse(1).Count);
        }

        [Test]
        public void CanAddStudentToCourse()
        {
            var count = _courseRepo.GetStudentsInCourse(1).Count;
            _courseRepo.AddStudentToCourse(2, 1);
            Assert.IsTrue(count < _courseRepo.GetStudentsInCourse(1).Count);
        }

        [Test]
        public void CanAddCourse()
        {
            var c = new Course()
            {
                TeacherId = 5,
                SubjectId = 1,
                CourseName = "Java+++",
                CourseDescription = "Prepare for the 31st century with the basics of the Java+++ scripting language",
                GradeLevelId = 12,
                StartDate = new DateTime(3029, 08, 05),
                EndDate = new DateTime(3029, 12, 10)
            };

            var count = _courseRepo.GetCoursesByTeacherId(5).Count;

            _courseRepo.AddCourse(c);

            Assert.AreEqual(_courseRepo.GetCoursesByTeacherId(5).Count, count+1);
        }
    }
}
