using EmployeeM.Models;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
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
                ConvertDepartmentIdToName(EmployeeListEntity, dr);
            }

            return EmployeeListEntity;


        }

        public List<EmployeeEntity> GetEmployeeByDepartment(string userId)
        {
            List<EmployeeEntity> EmployeeListEntity = new List<EmployeeEntity>();

            SqlCommand cmd = new SqlCommand("GetEmployeeByDepartment", _connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserId", userId);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            dataAdapter.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                ConvertDepartmentIdToName(EmployeeListEntity, dr);
            }


            return EmployeeListEntity;

        }

        void ConvertDepartmentIdToName(List<EmployeeEntity> EmployeeListEntity, DataRow dr)
        {
            var EmployeeToReturn = new EmployeeEntity
            {
                Id = Convert.ToInt32(dr["Id"]),
                FirstName = dr["FirstName"].ToString(),
                LastName = dr["LastName"].ToString(),
                Email = dr["Email"].ToString(),
                Mobile = dr["Mobile"].ToString(),
                DOB = Convert.ToDateTime(dr["DOB"]).ToString("yyyy-MM-dd"),
                DepartmentId = Convert.ToInt32(dr["DepartmentId"])
            };

            EmployeeToReturn.Department = new DepartmentEntity
            {
                Name = GetDepartmentNameById(EmployeeToReturn.DepartmentId)
            };

            EmployeeListEntity.Add(EmployeeToReturn);

        }
    


        public string GetDepartmentNameById(int DepartmentId)
        {
            string DepartmentName = string.Empty;

            SqlCommand cmd = new SqlCommand("GetDepartmentNameById", _connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DepartmentId", DepartmentId);

            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }

            object result = cmd.ExecuteScalar();  

            if (result != null)
            {
                DepartmentName = result.ToString();
            }
            else
            {
                DepartmentName = string.Empty;
            }

            return DepartmentName;
        }



        public List<EmployeeEntity> GetEmployeeByFilter(string SearchString)
        {
            List<EmployeeEntity> EmployeeListEntity = new List<EmployeeEntity>();

            SqlCommand cmd = new SqlCommand("GetEmployeeByFilter", _connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter param;

            // Adding each parameter separately


            cmd.Parameters.Add(new SqlParameter("@FirstName", SearchString));
            cmd.Parameters.Add(new SqlParameter("@LastName", SearchString));

            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            dataAdapter.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                ConvertDepartmentIdToName(EmployeeListEntity, dr);
            }

            return EmployeeListEntity;

       

        }

        public List<EmployeeEntity> GetEmployeeByDepartmentFilter(string userId, string searchString)
        {
            List<EmployeeEntity> EmployeeListEntity = new List<EmployeeEntity>();

            SqlCommand cmd = new SqlCommand("GetEmployeeByDepartmentFilter", _connection);
            cmd.CommandType = CommandType.StoredProcedure;

            // Add parameters for UserId and SearchString
            cmd.Parameters.Add(new SqlParameter("@UserId", userId));
            cmd.Parameters.Add(new SqlParameter("@SearchString", string.IsNullOrEmpty(searchString) ? (object)DBNull.Value : searchString));

            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                ConvertDepartmentIdToName(EmployeeListEntity, dr);
            }

            return EmployeeListEntity;


        }



        public EmployeeEntity GetEmployeeById(int Id)
        {
            EmployeeEntity EmployeeListEntity = new EmployeeEntity();

            SqlCommand cmd = new SqlCommand("GetEmployeeDetailsById", _connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter param;

            cmd.Parameters.Add(new SqlParameter("Id", Id));

            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            dataAdapter.Fill(dt);

            foreach (DataRow dr in dt.Rows)

                EmployeeListEntity = new EmployeeEntity
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    FirstName = dr["FirstName"].ToString(),
                    LastName = dr["LastName"].ToString(),
                    Email = dr["Email"].ToString(),
                    Mobile = dr["Mobile"].ToString(),
                    DOB = Convert.ToDateTime(dr["DOB"]).ToString(),
                    DepartmentId = Convert.ToInt32(dr["DepartmentId"]),

                };

            return EmployeeListEntity;
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
            cmd.Parameters.AddWithValue("@DepartmentId", Employee.DepartmentId);

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
            cmd.Parameters.AddWithValue("@DepartmentId", Employee.DepartmentId);
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

        public bool DeleteEmployeeDetails(int Id)
        {
            SqlCommand cmd = new SqlCommand("DeleteEmployeeDetails", _connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);

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
