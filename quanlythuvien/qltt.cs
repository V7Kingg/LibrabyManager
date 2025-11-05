using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace quanlythuvien
{
    public class qltt
    {
        protected static String _connectString = "server=.;database=QuanLyThuVien;integrated security=SSPI";
        public static DataTable ExecuteQuery(String sql, params SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            SqlConnection connect = new SqlConnection(_connectString);
            connect.Open();
            SqlCommand command = connect.CreateCommand();
            command.CommandText = sql;
            if (parameters != null && parameters.Length > 0)
            {
                command.Parameters.AddRange(parameters);
            }
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            return dt;
        }
        public static void ExecuteNonQuery(String sql)
        {
            SqlConnection connect = new SqlConnection(_connectString);
            connect.Open();
            SqlCommand command = connect.CreateCommand();
            command.CommandText = sql;
            command.ExecuteNonQuery();
        }
        public static int ExecuteNonQuery(String sql, params SqlParameter[] parameters)
        {
            using (SqlConnection connect = new SqlConnection(_connectString))
            {
                connect.Open();
                using (SqlCommand command = connect.CreateCommand())
                {
                    command.CommandText = sql;
                    if (parameters != null && parameters.Length > 0)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    return command.ExecuteNonQuery();
                }
            }
        }
    }
}