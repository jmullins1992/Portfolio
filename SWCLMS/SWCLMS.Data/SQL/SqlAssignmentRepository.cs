using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using SWCLMS.Models.Interfaces;
using SWCLMS.Models.Queries;
using SWCLMS.Models.Requests;
using SWCLMS.Models.Tables;

namespace SWCLMS.Data.SQL
{
    public class SqlAssignmentRepository : IAssignmentRepository
    {
        public List<GradedAssignment> GetGradedAssignments(int rosterId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("RosterId", rosterId);
                var results = cn.Query<GradedAssignment>("spGetGradedAssignmentsByRosterId", p,
                    commandType: CommandType.StoredProcedure).ToList();

                return results;
            }
        }

        public List<GradedAssignment> GetGradedAssignments(int courseId, int studentId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("CourseId", courseId);
                p.Add("StudentId", studentId);
                var results = cn.Query<GradedAssignment>("spGetGradedAssignmentsForStudentInCourse", p,
                    commandType: CommandType.StoredProcedure).ToList();

                return results;
            }
        }

        public void AddAssignment(Assignment newAssignment)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("CourseId", newAssignment.CourseId);
                p.Add("AssignmentName", newAssignment.AssignmentName);
                p.Add("PossiblePoints", newAssignment.PossiblePoints);
                p.Add("DueDate", newAssignment.DueDate);
                p.Add("AssignmentDescription", newAssignment.AssignmentDescription);

                var result = cn.Execute("spAddAssignment", p, commandType: CommandType.StoredProcedure);
            }
        }

        public List<GradebookListItem> GetGradebookForCourseId(int courseId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("CourseId", courseId);

                var results = cn.Query<GradebookListItem>("spGetGradebookForCourseId", p,
                    commandType: CommandType.StoredProcedure).ToList();

                return results;
            }
        }

        public void GradeAssignment(GradeAssignmentRequest request)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
               var p = new DynamicParameters();
               p.Add("RosterAssignmentId", request.RosterAssignmentId);

                if (request.PointsEarned.HasValue)
                {
                    p.Add("PointsEarned", request.PointsEarned);
                    p.Add("Percentage", request.Percentage);
                    p.Add("Grade", request.AssignmentGrade);
                }                

                cn.Execute("spUpdateRosterAssignment", p, commandType: CommandType.StoredProcedure);
            }
        }



        public void UpdateOverallGrade(int rosterId, string currentGrade)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("RosterId", rosterId);
                p.Add("CurrentGrade", currentGrade);

                cn.Execute("spUpdateStudentCourseGrade", p, commandType: CommandType.StoredProcedure);

            }
        }


        public void DeleteAssignment(int assignmentId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("AssignmentId", assignmentId);

                cn.Execute("spDeleteAssignment", p, commandType: CommandType.StoredProcedure);
            }
        }


        public Assignment GetAssignmentById(int assignmentId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("AssignmentId", assignmentId);

                var result = cn.Query<Assignment>("spGetAssignment", p,
                    commandType: CommandType.StoredProcedure).ToList().FirstOrDefault();

                return result;
            }
        }
    }
}
