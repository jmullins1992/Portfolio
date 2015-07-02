using System.Configuration;

namespace SWCLMS.Data
{
    public class Settings
    {
        private static string _connectionString;
        private static string _mode;

        public static string GetConnectionString()
        {
            if (string.IsNullOrEmpty(_connectionString))
                _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            return _connectionString;
        }

        public static string GetMode()
        {
            if (string.IsNullOrEmpty(_mode))
                _mode = ConfigurationManager.AppSettings["Mode"];

            return _mode;
        }
    }
}
