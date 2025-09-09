using EmployeeM.Models;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace EmployeeM.Data
{
    public class DepartmentRepository
    {
        private readonly SqlConnection _connection; 

        public DepartmentRepository(IConfiguration configuration)
        {
            // Get the connection string from appsettings.json
            string connStr = configuration.GetConnectionString("EmployeeM");
            _connection = new SqlConnection(connStr);
        }

        public List<DepartmentEntity> GetAllDepartments()
        {
            List<DepartmentEntity> DepartmentListEntity = new List<DepartmentEntity>();

            SqlCommand cmd = new SqlCommand("GetAllDepartments", _connection);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            dataAdapter.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                AddDepartmentToList(DepartmentListEntity, dr);
            }

            return DepartmentListEntity;
        }

        private static void AddDepartmentToList(List<DepartmentEntity> DepartmentListEntity, DataRow dr)
        {
            DepartmentListEntity.Add(
                new DepartmentEntity
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Name = dr["Name"].ToString(),
                });
        }
    }
}
