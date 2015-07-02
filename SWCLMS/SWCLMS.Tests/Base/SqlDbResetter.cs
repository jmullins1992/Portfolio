using System.Data;
using System.Data.SqlClient;
using Dapper;
using NUnit.Framework;
using SWCLMS.Data;

namespace SWCLMS.Tests.Base
{
    [TestFixture]
    public class SqlDbResetter
    {

        [TestFixtureSetUp]
        public void ResetDbOnSetup()
        {
            ResetDb();
        }

        [TearDown]
        public void ResetDbOnTeardown()
        {
            ResetDb();
        }
        
        private static void ResetDb()
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                cn.Execute("spRebuildDataBase", commandType: CommandType.StoredProcedure);
            }
        }
    }
}
