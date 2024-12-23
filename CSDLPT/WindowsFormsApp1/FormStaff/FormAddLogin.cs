using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.CRUD;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1.FormStaff
{
    public partial class FormAddLogin : Form
    {
        private DataHelper dataHelper;
        
        private String connection, UserName;
        String nhomquyen;
        String role;
        public FormAddLogin(String connection,String UserName, String nhomquyen)
        {
            InitializeComponent();
            this.connection = connection;
            this.UserName = UserName;
            this.nhomquyen = nhomquyen;
            cbx_nhomquyen_load();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

            if (String.IsNullOrEmpty(tb_mk.Text) || String.IsNullOrEmpty(tb_tk.Text))
            {
                MessageBox.Show("Vui Lòng Nhập Thông Tin");
            }
            if (nhomquyen == "CONGTY")
            {
                role = nhomquyen;
            }
            else
            {
                role = cbx_nhomquyen.SelectedValue.ToString();
            }
            String mk = tb_mk.Text;
            String tk = tb_tk.Text;
            
            String b = UserName.ToString().Trim();
            SqlParameter[] parameters = new SqlParameter[]
            {
                   new SqlParameter("@LGNAME", tk),
                   new SqlParameter("@PASS", mk),
                   new SqlParameter("@USERNAME", b),
                   new SqlParameter("@ROLE",role),
                   
           };



            dataHelper = new DataHelper(connection);
            int result = dataHelper.ExecuteStoredProcedureReturnValue("SP_TAOLOGIN", parameters);

            if (result == 0)
            {
                MessageBox.Show("Tạo login thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

            }
            else if (result == 1)
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (result == 2)
            {
                MessageBox.Show("Tên người dùng đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra trong quá trình tạo login.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void cbx_nhomquyen_load()
        {
            if (nhomquyen == "CONGTY")
            {
                cbx_nhomquyen.Enabled = false;
            }
            List<Role> roles = new List<Role>
            {
                new Role { Value = "USER", DisplayText = "Người dùng" },
                new Role { Value = "CHINHANH", DisplayText = "Chi nhánh" },
               
            };

            // Gắn dữ liệu vào ComboBox
            cbx_nhomquyen.DataSource = roles;       // Gắn danh sách làm nguồn dữ liệu
            cbx_nhomquyen.DisplayMember = "DisplayText";  // Thuộc tính hiển thị
            cbx_nhomquyen.ValueMember = "Value";
        }
        public class Role
        {
            public string DisplayText { get; set; }
            public string Value { get; set; }
        }
    }
}
