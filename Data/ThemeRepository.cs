using EmployeeM.Models;
using System.Data;
using System.Data.SqlClient;


namespace EmployeeM.Data
{
    public class ThemeRepository
    {
        private SqlConnection _connection;

        public ThemeRepository()
        {
            string coonStr = "server=LAPTOP-NTBOS8PM\\SQLEXPRESS;database=EmployeeM;Integrated Security=true;TrustServerCertificate=true;";

            _connection = new SqlConnection(coonStr);
        }

        public ThemeEntity GetTheme(string UserId)
        {
            ThemeEntity ThemeEntity = new ThemeEntity();

            SqlCommand cmd = new SqlCommand("GetTheme", _connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("UserId", UserId);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            dataAdapter.Fill(dt);

            foreach (DataRow dr in dt.Rows)

                ThemeEntity = new ThemeEntity
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    BodyBGColor = dr["BodyBGColor"].ToString(),
                    BodyColor = dr["BodyColor"].ToString(),
                    HeaderFooterBGColor = dr[" HeaderFooterBGColor"].ToString(),
                    HeaderFooterColor = dr["HeaderFooterColor"].ToString(),
                };

            return ThemeEntity;

        }
        public bool updateDepartmentTheme(ThemeEntity Theme)
        {
            SqlCommand cmd = new SqlCommand("updateDepartmentTheme", _connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Theme.Id);
            cmd.Parameters.AddWithValue("@BodyBGColor", Theme.BodyBGColor);
            cmd.Parameters.AddWithValue("@BodyColor", Theme.BodyColor);
            cmd.Parameters.AddWithValue("@HeaderFooterBGColor", Theme.HeaderFooterBGColor);
            cmd.Parameters.AddWithValue("@HeaderFooterColor", Theme.HeaderFooterColor);



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