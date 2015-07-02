using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWCLMS.Models.Queries;
using SWCLMS.Models.Requests;
using SWCLMS.Models.Tables;

namespace SWCLMS.Models.Interfaces
{
    public interface IAssignmentRepository
    {
        List<GradedAssignment> GetGradedAssignments(int rosterId);
        List<GradedAssignment> GetGradedAssignments(int courseId, int studentId);
        void AddAssignment(Assignment newAssignment);
        List<GradebookListItem> GetGradebookForCourseId(int courseId);
        void GradeAssignment(GradeAssignmentRequest request);
        void UpdateOverallGrade(int rosterId, string currentGrade);
        void DeleteAssignment(int assignmentId);
        Assignment GetAssignmentById(int assignmentId);
    }
}
