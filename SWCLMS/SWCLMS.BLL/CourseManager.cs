using System;
using System.Collections.Generic;
using SWCLMS.Models.Interfaces;
using SWCLMS.Models.Queries;
using SWCLMS.Models.Responses;
using SWCLMS.Models.Tables;

namespace SWCLMS.BLL
{
    public class CourseManager
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ISubjectRepository _subjectRepository;
        private readonly IGradeLevelRepository _gradeLevelRepository;


        public CourseManager(ICourseRepository cRepo, IGradeLevelRepository gradeLevelRepository, ISubjectRepository subjectRepository)
        {
            _courseRepository = cRepo;
            _gradeLevelRepository = gradeLevelRepository;
            _subjectRepository = subjectRepository;
        }

        public DataResponse<List<GradedCourse>> GetCoursesByStudentId(int id)
        {
            var response = new DataResponse<List<GradedCourse>>();

            try
            {
                response.Data = _courseRepository.GetCoursesByStudentId(id);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }

        public DataResponse<Course> GetCourseById(int id)
        {
            var response = new DataResponse<Course>();

            try
            {
                response.Data = _courseRepository.GetCourseById(id);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public DataResponse<CourseDetails> GetCourseDetailsById(int id)
        {
            var response = new DataResponse<CourseDetails>();

            try
            {
                response.Data = _courseRepository.GetCourseDetailsById(id);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        } 

        public CourseSubjectsGradelevelsResponse GetCourseByIdAndSubjectsAndGradelevels(int courseId)
        {
            var response = new CourseSubjectsGradelevelsResponse();

            try
            {
                response.CourseDetails = _courseRepository.GetCourseDetailsById(courseId);
                response.GradeLevels = _gradeLevelRepository.GetAllGradeLevels();
                response.Subjects = _subjectRepository.GetAllSubjects();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public GradeLevelsAndSubjects GetGradeLevelsAndSubjects()
        {
            var response = new GradeLevelsAndSubjects();

            try
            {
                response.GradeLevels = _gradeLevelRepository.GetAllGradeLevels();
                response.Subjects = _subjectRepository.GetAllSubjects();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }

        public Response UpdateCourseInfo(Course course)
        {
            var response = new Response();
            try
            {
                _courseRepository.UpdateCourseInfo(course);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
        
        public CourseRosterResponse GetRosterResponse(int id)
        {
            var response = new CourseRosterResponse();
            try
            {
                response.CourseDetails = _courseRepository.GetCourseDetailsById(id);
                response.GradeLevels = _gradeLevelRepository.GetAllGradeLevels();
                response.StudentsInCourse = _courseRepository.GetStudentsInCourse(id);
                response.StudentsNotInCourse = _courseRepository.GetStudentsNotInCourse(id);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public Response AddStudentToCourse(int studentId, int courseId)
        {
            var response = new Response();

            try
            {
                _courseRepository.AddStudentToCourse(studentId, courseId);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public Response DeleteStudentFromCourse(int studentId, int courseId)
        {
            var response = new Response();

            try
            {
                _courseRepository.DeleteStudentFromCourse(studentId, courseId);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public DataResponse<List<CourseFront>> GetCoursesByTeacherId(int id)
        {
            var response = new DataResponse<List<CourseFront>>();

            try
            {
                response.Data = _courseRepository.GetCoursesByTeacherId(id);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }

        public Response AddCourse(Course c)
        {
            var response = new Response();

            try
            {
                _courseRepository.AddCourse(c);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }
    }
}
