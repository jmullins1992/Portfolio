using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using SWCLMS.Models.Interfaces;
using SWCLMS.Models.Queries;
using SWCLMS.Models.Requests;
using SWCLMS.Models.Responses;
using SWCLMS.Models.Tables;

namespace SWCLMS.BLL
{
    public class AssignmentManager
    {
        private readonly IAssignmentRepository _assignmentRepository;
        private readonly ICourseRepository _courseRepository;

        public AssignmentManager(IAssignmentRepository repo, ICourseRepository courseRepository)
        {
            _assignmentRepository = repo;
            _courseRepository = courseRepository;
        }

        public StudentGradedAssignmentsResponse GetGradedAssignments(int courseId, int studentId)
        {
            var response = new StudentGradedAssignmentsResponse();

            try
            {
                response.CourseDetails = _courseRepository.GetCourseDetailsById(courseId);
                response.GradedAssignments = _assignmentRepository.GetGradedAssignments(courseId, studentId).OrderBy(g=>g.DueDate).ToList();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public Response AddAssignment(Assignment newAssignment)
        {
            var response = new Response();

            var validation = IsValidAssignment(newAssignment);

            if (!validation.Success)
            {
                response.Message = validation.Message;
                return response;
            }

            try
            {
                _assignmentRepository.AddAssignment(newAssignment);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public Response IsValidAssignment(Assignment assignment)
        {
            var response = new Response();
            if (string.IsNullOrEmpty(assignment.AssignmentName))
            {
                response.Message = "Name is required.";
                return response;
            }
            if (assignment.DueDate == DateTime.MinValue)
            {
                response.Message = "Due Date is required.";
                return response;              
            }
            if (string.IsNullOrEmpty(assignment.AssignmentDescription))
            {
                response.Message = "Description is required.";
                return response;              
            }
            response.Success = true;
            return response;
            
        }

        public CourseGradebookResponse GetGradebook(int courseId)
        {
            var response = new CourseGradebookResponse();

            try
            {
                response.CourseDetails = _courseRepository.GetCourseDetailsById(courseId);
                response.GradebookListItems = _assignmentRepository.GetGradebookForCourseId(courseId);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public CourseGradedAssignmentResponse GradeAssignment(int rosterId, int rosterAssignmentId,
            decimal? pointsEarned, int pointsPossible)
        {
            var response = new CourseGradedAssignmentResponse();
            
            //Validation
            if (pointsEarned < 0)
            {
                response.Message = "Points earned cannot be negative.";
                return response;
            }
            
            //Update grade for the assignment

            var request = new GradeAssignmentRequest()
            {
                PointsEarned = pointsEarned,
                RosterAssignmentId = rosterAssignmentId,
                RosterId = rosterId
            };

            if (pointsEarned.HasValue)
            {
                request.Percentage = pointsEarned/pointsPossible*100M;
                response.Percentage = request.Percentage;
                request.AssignmentGrade = ConvertPercentToGrade(request.Percentage.Value);
            }

            if (request.Percentage > 999M)
            {
                response.Message = "Points earned cannot exceed 999% of the possible points";
                return response;
            }

            try
            {
                _assignmentRepository.GradeAssignment(request);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return response;
            }

            //Update overall course grade

            var updateCourseGradeResponse = UpdateOverallGrade(rosterId);

            if (updateCourseGradeResponse.Success)
            {
                response.OverallGrade = updateCourseGradeResponse.Data;
            }
            else
            {
                response.Message = updateCourseGradeResponse.Message;
            }
            
            return response;
        }

        private DataResponse<string> UpdateOverallGrade(int rosterId)
        {
            var response = new DataResponse<string>();
            try
            {
                var results = _assignmentRepository.GetGradedAssignments(rosterId);
                if (results.Count == 0)
                {
                    response.Data = null;
                }
                else
                {
                    var avg = results.Average(a => a.Percentage);
                    var newGrade = ConvertPercentToGrade(avg);
                    response.Data = newGrade;
                    _assignmentRepository.UpdateOverallGrade(rosterId, newGrade);
                }
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public string ConvertPercentToGrade(decimal percentage)
        {
            

            if (percentage >= 90)
            {
                return "A";
            }
            if (percentage >= 80)
            {
                return "B";
            }
            if (percentage >= 70)
            {
                return "C";
            }
            if (percentage >= 60)
            {
                return "D";
            }

            return "F";
        }

        public Response DeleteAssignment(int assignmentId, List<GradebookListItem> gradebookList )
        {
            var response = new Response();
            var rosterIds = new List<int>();

            foreach (var gb in gradebookList)
            {
                rosterIds.Add(gb.RosterId);
            }

            try
            {
                _assignmentRepository.DeleteAssignment(assignmentId);

                foreach (var s in rosterIds.Distinct())
                {
                    UpdateOverallGrade(s);
                }

                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }

        public DataResponse<Assignment> GetAssignmentById(int assignmentId)
        {
            var response = new DataResponse<Assignment>();

            try
            {
                response.Data = _assignmentRepository.GetAssignmentById(assignmentId);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            if (response.Data == null)
            {
                response.Success = false;
                response.Message = "That assignment does not exist";
            }

            return response;
        } 

    }
}
