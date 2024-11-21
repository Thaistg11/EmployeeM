using EmployeeM.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace EmployeeM.Data
{
    public class ThemeRepository
    {
        private readonly SqlConnection _connection;
        
        public ThemeRepository()
        {
            // Initialize the database connection
            string connStr = "server=LAPTOP-NTBOS8PM\\SQLEXPRESS;database=EmployeeM;Integrated Security=true;TrustServerCertificate=true;";
            _connection = new SqlConnection(connStr);
        }

        public ThemeEntity GetTheme(string userId)
        {
            ThemeEntity themeEntity = null;

            SqlCommand cmd = new SqlCommand("GetTheme", _connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserId", userId);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            dataAdapter.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                themeEntity = new ThemeEntity
                {
                    Id = dr["Id"] != DBNull.Value ? Convert.ToInt32(dr["Id"]) : 0,
                    BodyBGColor = dr["BodyBGColor"]?.ToString() ?? string.Empty,
                    BodyColor = dr["BodyColor"]?.ToString() ?? string.Empty,
                    HeaderFooterBGColor = dr["HeaderFooterBGColor"]?.ToString() ?? string.Empty,
                    HeaderFooterColor = dr["HeaderFooterColor"]?.ToString() ?? string.Empty,
                };
            }

            return themeEntity;
        }



        public string GetDepartmentByUserId(string userId)
        {
            string departmentId = string.Empty;

            SqlCommand cmd = new SqlCommand("GetDepartmentByUserId", _connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserId", userId);

            try
            {
                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }

                object result = cmd.ExecuteScalar();
                departmentId = result?.ToString() ?? string.Empty;
            }
            finally
            {
                _connection.Close();
            }

            return departmentId;
        }

        public bool CreateDepartmentTheme(ThemeEntity theme, string userId)
        {
            string departmendId = GetDepartmentByUserId(userId);

            int parsedDepartmentId = Convert.ToInt32(departmendId);

            SqlCommand cmd = new SqlCommand("CreateDepartmentTheme", _connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@DepartmentId", parsedDepartmentId);
            cmd.Parameters.AddWithValue("@BodyBGColor", theme.BodyBGColor ?? string.Empty);
            cmd.Parameters.AddWithValue("@BodyColor", theme.BodyColor ?? string.Empty);
            cmd.Parameters.AddWithValue("@HeaderFooterBGColor", theme.HeaderFooterBGColor ?? string.Empty);
            cmd.Parameters.AddWithValue("@HeaderFooterColor", theme.HeaderFooterColor ?? string.Empty);
            

            try
            {
                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            finally
            {
                _connection.Close();
            }
        }

        public bool UpdateDepartmentTheme(ThemeEntity theme)
        {

            SqlCommand cmd = new SqlCommand("UpdateDepartmentTheme", _connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", theme.Id); 
            cmd.Parameters.AddWithValue("@BodyBGColor", theme.BodyBGColor ?? string.Empty);
            cmd.Parameters.AddWithValue("@BodyColor", theme.BodyColor ?? string.Empty);
            cmd.Parameters.AddWithValue("@HeaderFooterBGColor", theme.HeaderFooterBGColor ?? string.Empty);
            cmd.Parameters.AddWithValue("@HeaderFooterColor", theme.HeaderFooterColor ?? string.Empty);


            try
            {
                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            finally
            {
                _connection.Close();
            }



        }
    }
}
