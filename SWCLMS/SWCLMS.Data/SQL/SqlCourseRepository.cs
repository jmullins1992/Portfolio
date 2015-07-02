using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using SWCLMS.Models.Interfaces;
using SWCLMS.Models.Queries;
using SWCLMS.Models.Tables;

namespace SWCLMS.Data.SQL
{
    public class SqlCourseRepository : ICourseRepository
    {
        public List<GradedCourse> GetCoursesByStudentId(int id)
        {
            using (SqlConnection cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@StudentId", id);

                var courses = cn.Query<GradedCourse>("spGetCoursesByStudentId", p, commandType: CommandType.StoredProcedure).OrderBy(c=>c.CourseName).ToList();

                return courses;
            }
        }

        public List<CourseFront> GetCoursesByTeacherId(int id)
        {
            using (SqlConnection cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@TeacherId", id);
                var courses = cn.Query<CourseFront>("spGetCoursesByTeacherId", p, commandType: CommandType.StoredProcedure).OrderBy(c => c.CourseName).ToList();

                return courses;
            }
        }

        public Course GetCourseById(int id)
        {
            using (SqlConnection cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@CourseId", id);

                var courses = cn.Query<Course>("spGetCourseById", p, commandType: CommandType.StoredProcedure).First();

                return courses;
            }
        }

        public CourseDetails GetCourseDetailsById(int id)
        {
            using (SqlConnection cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@CourseId", id);
                var courses = cn.Query<CourseDetails>("spGetCourseDetailsById", p, commandType: CommandType.StoredProcedure).First();

                return courses;
            }
        }

        public void AddCourse(Course newCourse)
        {
            using (SqlConnection cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@TeacherId", newCourse.TeacherId);
                p.Add("@SubjectId", newCourse.SubjectId);
                p.Add("@CourseName", newCourse.CourseName);
                p.Add("@CourseDescription", newCourse.CourseDescription);
                p.Add("@GradeLevelId", newCourse.GradeLevelId);
                p.Add("@StartDate", newCourse.StartDate);
                p.Add("@EndDate", newCourse.EndDate);

                cn.Execute("spAddCourse", p, commandType: CommandType.StoredProcedure);
            }
        }


        public void UpdateCourseInfo(Course updatedCourse)
        {
            using (SqlConnection cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var p = new DynamicParameters();

                p.Add("@CourseId", updatedCourse.CourseId);
                p.Add("@TeacherId", updatedCourse.TeacherId);
                p.Add("@SubjectId", updatedCourse.SubjectId);
                p.Add("@CourseName", updatedCourse.CourseName);
                p.Add("@CourseDescription", updatedCourse.CourseDescription);
                p.Add("@GradeLevelId", updatedCourse.GradeLevelId);
                p.Add("@IsArchived", updatedCourse.IsArchived);
                p.Add("@StartDate", updatedCourse.StartDate);
                p.Add("@EndDate", updatedCourse.EndDate);

                cn.Execute("spUpdateCourseInformation", p, commandType: CommandType.StoredProcedure);
            }
        }


        public List<LmsUserDetails> GetStudentsInCourse(int courseId)
        {
            using (SqlConnection cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@CourseId", courseId);
                var results = cn.Query<LmsUserDetails>("spGetStudentsByCourseId", p, commandType: CommandType.StoredProcedure).ToList();
                return results;
            }
        }

        public List<LmsUserDetails> GetStudentsNotInCourse(int courseId)
        {
            using (SqlConnection cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@CourseId", courseId);
                var results = cn.Query<LmsUserDetails>("spFindStudentsNotEnrolledInCourse", p, commandType: CommandType.StoredProcedure).ToList();
                return results;
            }
        }

        public void AddStudentToCourse(int studentId, int courseId)
        {
            using (SqlConnection cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@StudentId", studentId);
                p.Add("@CourseId", courseId);
                cn.Execute("spAddStudentToCourse", p, commandType: CommandType.StoredProcedure);
            }
        }


        


        public void DeleteStudentFromCourse(int studentId, int courseId)
        {
            using (SqlConnection cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@StudentId", studentId);
                p.Add("@CourseId", courseId);
                cn.Execute("spRemoveStudentFromCourse", p, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
