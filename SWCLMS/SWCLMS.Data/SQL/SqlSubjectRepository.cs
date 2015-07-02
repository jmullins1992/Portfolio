using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using SWCLMS.Models.Interfaces;
using SWCLMS.Models.Tables;

namespace SWCLMS.Data.SQL
{
    public class SqlSubjectRepository : ISubjectRepository
    {
        public List<Subject> GetAllSubjects()
        {
            using (SqlConnection cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var Subjects = cn.Query<Subject>("spGetAllSubject", commandType: CommandType.StoredProcedure).ToList();

                return Subjects;
            }
        }
    }
}
