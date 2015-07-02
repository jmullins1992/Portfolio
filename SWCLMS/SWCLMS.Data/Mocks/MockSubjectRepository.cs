using System.Collections.Generic;
using SWCLMS.Models.Interfaces;
using SWCLMS.Models.Tables;

namespace SWCLMS.Data.Mocks
{
    public class MockSubjectRepository : ISubjectRepository
    {
        public List<Subject> GetAllSubjects()
        {
            return new List<Subject>()
            {
                new Subject()
                {
                    SubjectId = 1,
                    SubjectName = "Math"
                },

                new Subject()
                {
                    SubjectId = 2,
                    SubjectName = "Science"
                },

                new Subject()
                {
                    SubjectId = 3,
                    SubjectName = "History"
                },

                new Subject()
                {
                    SubjectId = 4,
                    SubjectName = "Literature"
                }
            };
        }
    }
}
