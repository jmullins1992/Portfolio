using System.Collections.Generic;
using SWCLMS.Models.Interfaces;
using SWCLMS.Models.Tables;

namespace SWCLMS.Data.Mocks
{
    public class MockGradeLevelRepository : IGradeLevelRepository
    {
        public List<GradeLevel> GetAllGradeLevels()
        {
            return new List<GradeLevel>
            {
                new GradeLevel(){ GradeLevelId = 1, GradeLevelName = "K"},
                new GradeLevel(){ GradeLevelId = 2, GradeLevelName = "1"},
                new GradeLevel(){ GradeLevelId = 3, GradeLevelName = "2"},
                new GradeLevel(){ GradeLevelId = 4, GradeLevelName = "3"},
                new GradeLevel(){ GradeLevelId = 5, GradeLevelName = "4"},
                new GradeLevel(){ GradeLevelId = 6, GradeLevelName = "5"},
                new GradeLevel(){ GradeLevelId = 7, GradeLevelName = "6"},
                new GradeLevel(){ GradeLevelId = 8, GradeLevelName = "7"},
                new GradeLevel(){ GradeLevelId = 9, GradeLevelName = "8"},
                new GradeLevel(){ GradeLevelId = 10, GradeLevelName = "9"},
                new GradeLevel(){ GradeLevelId = 11, GradeLevelName = "10"},
                new GradeLevel(){ GradeLevelId = 12, GradeLevelName = "11"},
                new GradeLevel(){ GradeLevelId = 12, GradeLevelName = "12"}
            };
        }
    }
}
