using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using SWCLMS.Models.Interfaces;
using SWCLMS.Models.Tables;

namespace SWCLMS.Data.SQL
{
    public class SqlGradeLevelRepository : IGradeLevelRepository
    {
        public List<GradeLevel> GetAllGradeLevels()
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var gradeLevels = cn.Query<GradeLevel>("spGetAllGradeLevels", commandType: CommandType.StoredProcedure).ToList();

                return gradeLevels;
            }
        }
    }
}
