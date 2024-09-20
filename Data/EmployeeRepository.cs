using System.Data.SqlClient;
namespace EmpolyeeM.Data
{
    public class EmployeeRepository
    {
        private  SqlConnection _connection;
        public EmployeeRepository()
        {
            string connStr = "server=LAPTOP-NTBOS8PM\\SQLEXPRESS;database=EmployeeM;" +
            "Integrated Security = true; TrustServerCertificate = True;";

            _connection = new SqlConnection(connStr);
         }

        
    }
}
