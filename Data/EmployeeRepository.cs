using EmpolyeeM.Models;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
namespace EmpolyeeM.Data
{
    public class EmployeeRepository
    {
        private SqlConnection _connection;
        public EmployeeRepository()
        {
            string connStr = "server=LAPTOP-NTBOS8PM\\SQLEXPRESS;database=EmployeeM;" +
            "Integrated Security = true; TrustServerCertificate = True;";

            _connection = new SqlConnection(connStr);
        }

        public List<EmployeeEntity> GetAllEmployee()
        {
            List<EmployeeEntity> EmployeeListEntity = new List<EmployeeEntity>();

            SqlCommand cmd = new SqlCommand("GetAllEmployee", _connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            dataAdapter.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                NewMethod(EmployeeListEntity, dr);
            }

            return EmployeeListEntity;

            static void NewMethod(List<EmployeeEntity> EmployeeListEntity, DataRow dr)
            {
                EmployeeListEntity.Add(
                    new EmployeeEntity
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        FirstName = dr["FirstName"].ToString(),
                        LastName = dr["LastName"].ToString(),
                        Email = dr["Email"].ToString(),
                        Mobile = dr["Mobile"].ToString(),
                        DOB = dr["DOB"].ToString(),
                    });
            }
        }


        public bool AddEmployee(EmployeeEntity Employee)
        {
            SqlCommand cmd = new SqlCommand("AddEmployee", _connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", Employee.Id);
            cmd.Parameters.AddWithValue("@FirstName", Employee.FirstName);
            cmd.Parameters.AddWithValue("@LastName", Employee.LastName);
            cmd.Parameters.AddWithValue("@Email", Employee.Email);
            cmd.Parameters.AddWithValue("@Mobile", Employee.Mobile);
            cmd.Parameters.AddWithValue("@DOB", Employee.DOB);

            _connection.Open();

            int i = cmd.ExecuteNonQuery();
            _connection.Close();

            if (i == 0)
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
