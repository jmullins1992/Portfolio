using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWCLMS.Models.Queries;
using SWCLMS.Models.Tables;

namespace SWCLMS.Models.Interfaces
{
    public interface ICourseRepository
    {
        List<GradedCourse> GetCoursesByStudentId(int id);
        List<CourseFront> GetCoursesByTeacherId(int id);
        Course GetCourseById(int id);
        CourseDetails GetCourseDetailsById(int id);
        void AddCourse(Course newCourse);
        void UpdateCourseInfo(Course updatedCourse);

        List<LmsUserDetails> GetStudentsInCourse(int courseId);
        List<LmsUserDetails> GetStudentsNotInCourse(int courseId);

        void AddStudentToCourse(int studentId, int courseId);
        void DeleteStudentFromCourse(int studentId, int courseId);


    }
}
