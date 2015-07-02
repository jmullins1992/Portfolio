using System;
using System.Collections.Generic;
using SWCLMS.Models.Interfaces;
using SWCLMS.Models.Queries;
using SWCLMS.Models.Tables;

namespace SWCLMS.Data.Mocks
{
    public class MockAssignmentRepository : IAssignmentRepository
    {
        public List<GradedAssignment> GetGradedAssignments(int courseId, int studentId)
        {
            return new List<GradedAssignment>()
            {
                new GradedAssignment()
                {
                    CourseId = 1,
                    CourseName = "Algebra I",
                    AssignmentName = "Intro to Functions",
                    PointsEarned = 10,
                    Percentage = 100,
                    Grade = "A",
                    StudentId = 5,
                    DueDate = new DateTime(2015, 09, 05)
                },
                new GradedAssignment()
                {
                    CourseId = 1,
                    CourseName = "Algebra I",
                    AssignmentName = "Functions Cont",
                    PointsEarned = 8.5M,
                    Percentage = 85,
                    Grade = "B",
                    StudentId = 5,
                    DueDate = new DateTime(2015, 09, 07)
                },
                new GradedAssignment()
                {
                    CourseId = 1,
                    CourseName = "Algebra I",
                    AssignmentName = "Intro to Graphs",
                    PointsEarned = 7,
                    Percentage = 70,
                    Grade = "C",
                    StudentId = 5,
                    DueDate = new DateTime(2015, 08, 05)
                },
                new GradedAssignment()
                {
                    CourseId = 1,
                    CourseName = "Algebra I",
                    AssignmentName = "Intro to Parabolas",
                    PointsEarned = 10,
                    Percentage = 100,
                    Grade = "A",
                    StudentId = 5,
                    DueDate = new DateTime(2015, 10, 05)
                },
                new GradedAssignment()
                {
                    CourseId = 1,
                    CourseName = "Algebra I",
                    AssignmentName = "Intro to Polynomials",
                    PointsEarned = 10,
                    Percentage = 100,
                    Grade = "A",
                    StudentId = 5,
                    DueDate = new DateTime(2015, 11, 05)
                }
            };
        }


        public void AddAssignment(Assignment newAssignment)
        {
            return;
        }


        public List<GradebookListItem> GetGradebookForCourseId(int courseId)
        {
            return new List<GradebookListItem>()
            {
                new GradebookListItem()
                {
                    FirstName = "Bobby",
                    LastName = "Tables",
                    CurrentGrade = "A",
                    AssignmentName = "Fractions Worksheet",
                    PointsEarned = 10,
                    Percentage = 100,
                    RosterAssignmentId = 2,
                    DueDate = new DateTime(2015, 7, 15),
                    AssignmentId = 1,
                    RosterId = 1
                },
                new GradebookListItem()
                {
                    FirstName = "Rachel",
                    LastName = "Maddow",
                    CurrentGrade = "B",
                    AssignmentName = "Fractions Worksheet",
                    PointsEarned = 8,
                    Percentage = 80,
                    RosterAssignmentId = 3,
                    DueDate = new DateTime(2015, 7, 15),
                    AssignmentId = 1,
                    RosterId = 2
                },
                new GradebookListItem()
                {
                    FirstName = "John",
                    LastName = "Krasinksy",
                    CurrentGrade = "C",
                    AssignmentName = "Fractions Worksheet",
                    PointsEarned = 7,
                    Percentage = 70,
                    RosterAssignmentId = 3,
                    DueDate = new DateTime(2015, 7, 15),
                    AssignmentId = 1,
                    RosterId = 3
                }
            };
        }

        public void GradeAssignment(int rosterAssignmentId, decimal? pointsEarned, decimal? percentage, string grade)
        {
            return;
        }


        public void GradeAssignment(Models.Requests.GradeAssignmentRequest request)
        {
            throw new NotImplementedException();
        }

        public List<GradedAssignment> GetGradedAssignments(int rosterId)
        {
            throw new NotImplementedException();
        }


        public void UpdateOverallGrade(int rosterId, string currentGrade)
        {
            throw new NotImplementedException();
        }


        public void DeleteAssignment(int assignmentId)
        {
            throw new NotImplementedException();
        }


        public Assignment GetAssignmentById(int assignmentId)
        {
            throw new NotImplementedException();
        }
    }
}
