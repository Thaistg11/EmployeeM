using EmployeeM.Models;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace EmployeeM.Data
{
    public class DepartmentUserRepository
    {
        private readonly SqlConnection _connection;

        // Accept IConfiguration via constructor
        public DepartmentUserRepository(IConfiguration configuration)
        {
            // Get connection string from appsettings.json
            string connStr = configuration.GetConnectionString("EmployeeM");
            _connection = new SqlConnection(connStr);
        }

        public bool AddDepartmentUser(string userId, int departmentId)
        {
            SqlCommand cmd = new SqlCommand("AddDepartmentUser", _connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UserId", userId);
            cmd.Parameters.AddWithValue("@DepartmentId", departmentId);

            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }

            int i = cmd.ExecuteNonQuery();
            _connection.Close();

            return i > 0;
        }
    }
}
