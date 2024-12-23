using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Connect;
using WindowsFormsApp1.CRUD;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class FormLogin : Form
    {

        public String servername;
        public static string database = "QLVT";
        public static string login;
        public static string password;
        public String connection;
        public SqlConnection conn;
        public FormHome formhome;
        public FormLogin()
        {
            InitializeComponent();
            cbx_Load();
            
            
        }
        private void cbx_Load()
        {
            String cbx = "Data Source= LAPTOP-E0FD0UKT\\CN; Initial Catalog= QLVT; Integrated Security=True";
            DataHelper dataHelper = new DataHelper(cbx);
            try
            {
                // Gọi stored procedure bằng DataHelper
                DataTable data = dataHelper.ExecuteQuery("SELECT * FROM Get_Subscribes");

                // Kiểm tra dữ liệu và gắn vào ComboBox
                if (data != null && data.Rows.Count > 0)
                {
                    cbx_chinhanh.DataSource = data;
                    cbx_chinhanh.DisplayMember = "TENCN"; // Hiển thị tên loại hàng
                    cbx_chinhanh.ValueMember = "TENSERVER"; // Giá trị tương ứng là mã loại hàng
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu để hiển thị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void login_other_site(String login, String servername)
        {
            DataHelper dataHelper = new DataHelper(connection);
            SqlParameter[] parameters = new SqlParameter[]
               {
                    new SqlParameter("@TENLOGIN", SqlDbType.Char, 10) { Value = login }
               };

            // Gọi Stored Procedure
            DataTable result = dataHelper.ExecuteStoredProcedure("sp_DangNhap", parameters);
            if (result.Rows.Count > 0)
            {
                DataRow row = result.Rows[0]; // Lấy dòng đầu tiên
                if (row["nhomquyen"].ToString() == "CONGTY")
                {
                    String cbx = "Data Source="+ servername + "; Initial Catalog= QLVT; Integrated Security=True";
                }
            }
        }

        private void Connection()
        {
            
            int index = cbx_chinhanh.SelectedIndex;
            if(index == 0)
            {
                servername = "LAPTOP-E0FD0UKT\\CN1";
            }if(index == 1)
            {
                servername = "LAPTOP-E0FD0UKT\\CN2";
            }if(index == -1)
            {
                MessageBox.Show("Vui lòng chọn chi nhánh");
            }
            login = tb_tendangnhap.Text;
            password = tb_matkhau.Text;
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập thông tin");
                return;
            }
            connection = "Data Source=" + servername + ";Initial Catalog=" + database + ";User ID=" + login + ";Password=" + password;

            using (conn = new SqlConnection(connection))
            {
                try
                {
                    conn.Open();
                    formhome = new FormHome(connection,login);
                    formhome.Show();

                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"SQL Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"General Error: {ex.Message}");
                }
                
            }
        }

        private void btn_dangnhap_Click(object sender, EventArgs e)
        {
            Connection();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void tb_tendangnhap_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
