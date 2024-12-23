using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.CRUD
{
    public class DataHelper
    {
        private string connectionString;

        public DataHelper(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DataTable ExecuteStoredProcedure(string storedProcedureName, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(storedProcedureName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }

                }
            }
        }

        // Gọi Stored Procedure không trả về dữ liệu
        public int ExecuteStoredProcedureNonQuery(string storedProcedureName, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(storedProcedureName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    try
                    {
                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        // Log lỗi
                        MessageBox.Show(ex.Message);
                        return -1; // Thất bại
                    }
                }
            }
        }
        public int ExecuteStoredProcedureReturnValue(string storedProcedureName, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(storedProcedureName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Thêm tham số nếu có
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    // Thêm tham số trả về (RETURN VALUE)
                    SqlParameter returnParameter = new SqlParameter
                    {
                        ParameterName = "@returnvalue",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.ReturnValue
                    };
                    cmd.Parameters.Add(returnParameter);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();

                        // Trả về giá trị từ RETURN VALUE của stored procedure
                        return (int)returnParameter.Value;
                    }
                    catch (SqlException ex)
                    {
                        // Ghi log lỗi
                        MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return -1; // Thất bại
                    }
                }
            }
        }

        public bool CheckExists(string query, SqlParameter[] parameters = null, CommandType commandType = CommandType.Text)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = commandType;
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        return reader.HasRows; // Trả về true nếu có bản ghi
                    }
                }
            }
        }
        public DataTable ExecuteQuery(string query)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                connection.Open();
                adapter.Fill(dataTable);
            }

            return dataTable;
        }
    }
}
