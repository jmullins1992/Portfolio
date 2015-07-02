using System;
using System.Collections.Generic;
using System.Linq;
using SWCLMS.Models.Interfaces;
using SWCLMS.Models.Queries;
using SWCLMS.Models.Tables;

namespace SWCLMS.Data.Mocks
{
    public class MockCourseRepository : ICourseRepository
    {
        private static List<Course> _allCourses = new List<Course>
        {
            new Course()
            {
                CourseId = 1,
                TeacherId = 2,
                SubjectId = 1,
                CourseName = "Algebra I",
                CourseDescription = "Learn the fundamentals of Algebra",
                GradeLevelId = 10,
                IsArchived = false,
                StartDate = new DateTime(2015, 08, 01),
                EndDate = new DateTime(2015, 12, 20)
            },
            new Course()
            {
                CourseId = 2,
                TeacherId = 2,
                SubjectId = 2,
                CourseName = "US History",
                CourseDescription = "Learn about presidents and stuff",
                GradeLevelId = 10,
                IsArchived = false,
                StartDate = new DateTime(2015, 08, 01),
                EndDate = new DateTime(2015, 12, 20)
            },
            new Course()
            {
                CourseId = 3,
                TeacherId = 2,
                SubjectId = 1,
                CourseName = "Geometry",
                CourseDescription = "Learn a bunch of angles and shapes",
                GradeLevelId = 11,
                IsArchived = true,
                StartDate = new DateTime(2015, 08, 01),
                EndDate = new DateTime(2015, 12, 20)
            }
        };

        public List<GradedCourse> GetCoursesByStudentId(int id)
        {
            return new List<GradedCourse>()
            {
                new GradedCourse()
                {
                   CourseId = 1,
                   CourseName = "Algebra I",
                   CurrentGrade = "A"
                },
                new GradedCourse()
                {
                    CourseId = 3,
                    CourseName = "American History I",
                    CurrentGrade = "C"
                }
            };
        }

        public List<CourseFront> GetCoursesByTeacherId(int id)
        {
            var courses = _allCourses.Where(c => c.TeacherId == id).ToList();
            var courseFronts = courses.Select(c => new CourseFront()
            {
                CourseName = c.CourseName, CourseId = c.CourseId, NumOfStudents = 10, IsArchived = c.IsArchived
            }).ToList();

            return courseFronts;
        }

        public Course GetCourseById(int id)
        {
            return _allCourses.FirstOrDefault(c => c.CourseId == id);
        }

        public void AddCourse(Course newCourse)
        {
            newCourse.CourseId = _allCourses.Max(c => c.CourseId) + 1;
            _allCourses.Add(newCourse);
        }


        public void UpdateCourseInfo(Course updatedCourse)
        {
            _allCourses.RemoveAll(c => c.CourseId == updatedCourse.CourseId);
            _allCourses.Add(updatedCourse);
        }

        public List<LmsUserDetails> GetStudentsInCourse(int courseId)
        {
            return new List<LmsUserDetails>()
            {
                new LmsUserDetails()
                {
                    UserId = 10,
                    AspId = "asp1",
                    FirstName = "Jimbles",
                    LastName = "Notronbo",
                    Email = "gorillion@test.com",
                    GradeLevelId = 10,
                    GradeLevelName = "9",
                    SuggestedRole = "Student"
                },
                new LmsUserDetails()
                {
                    UserId = 11,
                    AspId = "asp2",
                    FirstName = "Jenna",
                    LastName = "Fischer",
                    Email = "pambeesly@test.com",
                    GradeLevelId = 10,
                    GradeLevelName = "9",
                    SuggestedRole = "Student"
                },
                new LmsUserDetails()
                {
                    UserId = 12,
                    AspId = "asp3",
                    FirstName = "Rainn",
                    LastName = "Wilson",
                    Email = "dwightkurtschrute@test.com",
                    GradeLevelId = 10,
                    GradeLevelName = "9",
                    SuggestedRole = "Student"
                }
            };
        }

        public List<LmsUserDetails> GetStudentsNotInCourse(int courseId)
        {
            return new List<LmsUserDetails>()
            {
                new LmsUserDetails()
                {
                    UserId = 13,
                    AspId = "asp4",
                    FirstName = "Angela",
                    LastName = "Martin",
                    Email = "catlover79@test.com",
                    GradeLevelId = 10,
                    GradeLevelName = "9",
                    SuggestedRole = "Student"
                },
                new LmsUserDetails()
                {
                    UserId = 14,
                    AspId = "asp5",
                    FirstName = "Oscar",
                    LastName = "Martinez",
                    Email = "origamilife@test.com",
                    GradeLevelId = 10,
                    GradeLevelName = "9",
                    SuggestedRole = "Student"
                },
                new LmsUserDetails()
                {
                    UserId = 15,
                    AspId = "asp6",
                    FirstName = "James",
                    LastName = "Spader",
                    Email = "bobkazamakis@test.com",
                    GradeLevelId = 10,
                    GradeLevelName = "9",
                    SuggestedRole = "Student"
                }
            };
        }


        public CourseDetails GetCourseDetailsById(int id)
        {
            return new CourseDetails()
            {
                CourseDescription = "Learn the fundamentals of the Java+++ scripting language.",
                CourseId = id,
                CourseName = "Intro to Java+++",
                EndDate = new DateTime(3031, 12, 15),
                GradeLevelId = 10,
                GradeLevelName = "9",
                IsArchived = false,
                StartDate = new DateTime(3031, 7, 5),
                SubjectId = 5,
                SubjectName = "Computer Science"
            };
        }


        public void AddStudentToCourse(int studentId, int courseId)
        {
            return;
        }


        public void DeleteStudentFromCourse(int studentId, int courseId)
        {
            return;
        }
    }
}
