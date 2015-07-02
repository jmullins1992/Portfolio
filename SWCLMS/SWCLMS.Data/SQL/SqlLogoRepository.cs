using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using SWCLMS.Models.Interfaces;
using SWCLMS.Models.Tables;

namespace SWCLMS.Data.SQL
{
    public class SqlLogoRepository
    {
        public void SetLogo(string filePath)
        {
            using (SqlConnection cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@FilePath", filePath);

                cn.Execute("spUpdateLogo", p, commandType: CommandType.StoredProcedure);
            }
        }

        public string GetLogo()
        {
            using (SqlConnection cn = new SqlConnection(Settings.GetConnectionString()))
            {
               return  cn.Query<string>("spGetLogo", commandType: CommandType.StoredProcedure).First();
            }
        }
    }
}
