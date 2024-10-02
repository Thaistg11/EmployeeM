using EmployeeM.Models;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Reflection;
namespace EmployeeM.Data
{
    public class DepartmentRepository
    {
        private SqlConnection _connection;

        public DepartmentEntity DepartmentEntity { get; private set; }

        public DepartmentRepository()
        {
            string connStr = "server=LAPTOP-NTBOS8PM\\SQLEXPRESS;database=EmployeeM;" +
            "Integrated Security = true; TrustServerCertificate = True;";

            _connection = new SqlConnection(connStr);
        }
        public List<DepartmentEntity> GetAllDepartments()
        {
            List<DepartmentEntity> DepartmentListEntity = new List<DepartmentEntity>();

            SqlCommand cmd = new SqlCommand("GetAllDepartments", _connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
           
            DataTable dt = new DataTable();


          
            dataAdapter.Fill(dt);
             
            foreach (DataRow dr in dt.Rows)
            {
                DepartmentListEntity.Add(
                    new DepartmentEntity
                    {
                        Name = dr["Name"].ToString()

                    });
            }
            return DepartmentListEntity;
        }
    }
}
