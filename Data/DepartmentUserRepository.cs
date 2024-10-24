using EmployeeM.Models;
using System.Data;
using System.Data.SqlClient;


namespace EmployeeM.Data
{
    public class DepartmentUserRepository
    {
        private SqlConnection _connection;

        public DepartmentUserRepository()
        {
            string coonStr = "server=LAPTOP-NTBOS8PM\\SQLEXPRESS;database=EmployeeM;Integrated Security=true;TrustServerCertificate=true;";

            _connection = new SqlConnection(coonStr);
        }

        public bool AddDepartmentUser(string userId, int departmentId)
        {
            SqlCommand cmd = new SqlCommand("AddDepartmentUser", _connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@UserId", userId);
            cmd.Parameters.AddWithValue("@DepartmentId", departmentId);

            _connection.Open();

            int i = cmd.ExecuteNonQuery();
            _connection.Close();

            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}