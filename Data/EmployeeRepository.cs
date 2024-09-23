using EmpolyeeM.Models;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
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

        public List<EmployeeEntity> GetAllEmployeeM ()
        {
            List<EmployeeEntity> EmployeeListEntity=new List<EmployeeEntity>();

            SqlCommand cmd = new SqlCommand("GetAllEmployeeM", _connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            
            dataAdapter.Fill(dt);

            foreach (DataRow dr in dt.Rows)
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

            return EmployeeListEntity;
        }

    
    }
} 
