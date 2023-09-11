using System.Configuration;

namespace ClassLibraryMysql
{
    public class Database
    {
        public int SQL_TIMEOUT_EXECUTION_COMMAND = 60;

        protected string GetSettingsConenction()
        {
            string setting = ConfigurationManager.ConnectionStrings["mysql"].ConnectionString;
            return setting;
        }
    }
}