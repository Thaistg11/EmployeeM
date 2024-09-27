using EmployeeM.Models;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Reflection;
namespace EmployeeM.Data
{
    public class EmployeeRepository
    {
        private SqlConnection _connection;

        public EmployeeEntity EmployeeEntity { get; private set; }

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


        public EmployeeEntity GetEmployeeById(int Id)
        {
            EmployeeEntity employeeEntity = null;  // Initialize as null to handle cases where no data is found

            SqlCommand cmd = new SqlCommand("GetEmployeeDetailsById", _connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@Id", Id));  // Use '@' for parameterized queries

            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            dataAdapter.Fill(dt);

            if (dt.Rows.Count > 0)  // Check if there are any rows
            {
                DataRow dr = dt.Rows[0];  // Since ID is unique, expect only one row
                employeeEntity = new EmployeeEntity
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    FirstName = dr["FirstName"].ToString(),
                    LastName = dr["LastName"].ToString(),
                    Email = dr["Email"].ToString(),
                    Mobile = dr["Mobile"].ToString(),
                    DOB = dr["DOB"].ToString(),
                };
            }

            return EmployeeEntity;  // Return the populated object or null if no data was found
        }


        public bool AddEmployee(EmployeeEntity Employee)
        {
            SqlCommand cmd = new SqlCommand("AddEmployee", _connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            
            cmd.Parameters.AddWithValue("@FirstName", Employee.FirstName);
            cmd.Parameters.AddWithValue("@LastName", Employee.LastName);
            cmd.Parameters.AddWithValue("@Email", Employee.Email);
            cmd.Parameters.AddWithValue("@Mobile", Employee.Mobile);
            cmd.Parameters.AddWithValue("@DOB", Employee.DOB);

            _connection.Open();

            int i = cmd.ExecuteNonQuery();
            _connection.Close();

            if (i > 0)
            {
                return true;
            }
            else {
                return false;
                }
        }

        public bool EditEmployeeDetails(int Id, EmployeeEntity Employee)
        {
            SqlCommand cmd = new SqlCommand("EditEmployee", _connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);

            cmd.Parameters.AddWithValue("@FirstName", Employee.FirstName);
            cmd.Parameters.AddWithValue("@LastName", Employee.LastName);
            cmd.Parameters.AddWithValue("@Email", Employee.Email);
            cmd.Parameters.AddWithValue("@Mobile", Employee.Mobile);
            cmd.Parameters.AddWithValue("@DOB", Employee.DOB);

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
