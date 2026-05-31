using Microsoft.Data.SqlClient;

namespace SMSProject.Data
{
    public class DBConnection
    {

        private string connectionString =
            "Server=.\\SQLEXPRESS;Database=SMSystem;Trusted_Connection=True;TrustServerCertificate=True;";

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
