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
using System.Xml.Linq;
using WindowsFormsApp1.CRUD;
using WindowsFormsApp1.Object;
using static WindowsFormsApp1.FormStaff.FormAddLogin;

namespace WindowsFormsApp1
{
    public partial class FormWareHouse : Form
    {
        private DataHelper dataHelper;
        private String connection;
        DataTable result;
        private Timer updateTimer;
        private DataGridViewRow pendingRow;
        String mk, tk;
        int rowcount;
        String nhomquyen;
        String macn;
        public FormWareHouse(String connection,String nhomquyen,String macn)
        {
            InitializeComponent();
            this.connection = connection;
            this.nhomquyen = nhomquyen;
            this.macn = macn;
            btn_lock();
            cbx_chuyenchinhanh_load();
        }
        private void cbx_chuyenchinhanh_load()
        {
            cbx_chuyenchinhanh.Enabled = false;
            if (nhomquyen == "CONGTY")
            {
                cbx_chuyenchinhanh.Enabled = true;
            }
            List<Role> roles = new List<Role>
            {
                new Role { DisplayText = "Chi Nhánh 1", Value = "CN1" },
                new Role { DisplayText = "Chi Nhánh 2", Value = "CN2" },

            };

            // Gán dữ liệu vào ComboBox
            cbx_chuyenchinhanh.DataSource = roles;
            cbx_chuyenchinhanh.DisplayMember = "DisplayText"; // Hiển thị
            cbx_chuyenchinhanh.ValueMember = "Value";
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void btn_lock()
        {
            if (nhomquyen == "CONGTY")
            {
                btn_addwarehouse.Enabled = false;
                btn_editwarehouse.Enabled = false;
                btn_deletewarehouse.Enabled = false;
                btn_undo.Enabled = false;
                tb_nhaptenkho.Enabled = false;
                dgv_warehouse.ReadOnly = true;
            }
        }
        private void FormWareHouse_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;

            // Phóng to toàn màn hình
            this.WindowState = FormWindowState.Maximized;

            // Đưa form lên trên cùng (nếu cần che Taskbar)
            this.TopMost = true;
            GetWareHouse();
        }
        private void GetWareHouse()
        {
            try
            {


                dataHelper = new DataHelper(connection);
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MACN_CBX", macn),

                };
                // Gọi Stored Procedure
                result = dataHelper.ExecuteStoredProcedure("SP_GETWAREHOUSE",parameters);
                // Hiển thị dữ liệu lên DataGridView
                if (result != null && result.Rows.Count > 0)
                {
                    dgv_warehouse.DataSource = result;
                    dgv_warehouse.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgv_warehouse.Columns["MaKho"].HeaderText = "Mã Kho";
                    dgv_warehouse.Columns["TenKho"].HeaderText = "Tên Kho";
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgv_warehouse.DataSource = null;
                }
                dgv_warehouse.Columns["MaKho"].ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            rowcount = dgv_warehouse.Rows.Count;
        }

        private void tb_find_TextChanged(object sender, EventArgs e)
        {
            string keyword = tb_find.Text.Trim();
            DataView dv = result.DefaultView;

            // Tạo biểu thức lọc
            string filter = string.Join(" OR ",
                result.Columns.Cast<DataColumn>()
                    .Select(col => $"{col.ColumnName} LIKE '%{keyword}%'"));

            dv.RowFilter = filter;

            // Gắn lại dữ liệu lọc vào DataGridView
            dgv_warehouse.DataSource = dv;
        }

        private void btn_deletewarehouse_Click(object sender, EventArgs e)
        {

        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }





        private void RefreshDataGridView()
        {
            DataTable dt = dataHelper.ExecuteStoredProcedure("SP_GETWAREHOUSE"); // Lấy lại dữ liệu từ cơ sở dữ liệu
            dgv_warehouse.DataSource = dt;
        }

        private void dgvwarehouse_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgv_warehouse.Rows.Count <= rowcount)
            {

                DataGridViewRow row = dgv_warehouse.Rows[e.RowIndex];
                DataGridViewCell cell = row.Cells[e.ColumnIndex];

                // Lấy giá trị cũ và mới
                string originalValue = cell.Tag?.ToString();
                string newValue = cell.Value?.ToString();

                if (originalValue != newValue)
                {
                    string TenKho = row.Cells["TenKho"].Value.ToString();
                    int MaKho = Convert.ToInt32(row.Cells["MaKho"].Value);
                    try
                    {
                        SqlParameter[] parameters = new SqlParameter[]
                        {
                            new SqlParameter("@MaKho", MaKho),
                            new SqlParameter("@TenKho", TenKho),
                        };

                        try
                        {
                            DataHelper dataHelper = new DataHelper(connection);
                            int res = dataHelper.ExecuteStoredProcedureNonQuery("SP_UPDATEWAREHOUSE", parameters);
                            if (res > 0)
                            {
                                MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo");
                                dgv_warehouse.CurrentCell = row.Cells["MaKho"];

                                //RefreshDataGridView(); // Cập nhật lại DataGridView nếu cần
                            }
                            else
                            {
                                MessageBox.Show("Cập nhật dữ liệu thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                RefreshDataGridView();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Lỗi khi cập nhật dữ liệu: {ex.Message}");
                            RefreshDataGridView();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi cập nhật dữ liệu: {ex.Message}");
                        dgv_warehouse.CurrentCell = row.Cells["MaKho"];
                    }


                }
            }
        }



        private void dgv_warehouse_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridViewRow row = dgv_warehouse.Rows[e.RowIndex];
            DataGridViewCell cell = row.Cells[e.ColumnIndex];

            if (cell.Value != null)
            {
                cell.Tag = cell.Value.ToString(); // Lưu giá trị ban đầu vào Tag
            }
        }




        private void dgv_warehouse_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {


        }

        private void btn_editwarehouse_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

       

        private void btn_addwarehouse_Click(object sender, EventArgs e)
        {
            DataHelper dh = new DataHelper(connection);
            DataTable res = dh.ExecuteStoredProcedure("SP_GETNEWIDWAREHOUSE");

            if (res.Rows.Count > 0)
            {
                DataRow roww = res.Rows[0];
                mk = roww["NewMaKho"].ToString();

            }
            else
            {
                MessageBox.Show("Không thể tạo mã kho mới.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }        // Lấy giá trị từ ô "TenKho"
            tk = tb_nhaptenkho.Text;
            if (string.IsNullOrWhiteSpace(tk))
            {
                MessageBox.Show("Tên kho không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
                return;
            }
    
            
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                            new SqlParameter("@TenKho", tk),
                };

                DataHelper dataHelper = new DataHelper(connection);
                int a = dataHelper.ExecuteStoredProcedureNonQuery("SP_ADDWAREHOUSE", parameters);
                if (a > 0)
                {
                    MessageBox.Show("Thêm dữ liệu thành công!");
                    result.Rows.Add(mk,tk);
                    // Cập nhật lại DataGridView nếu cần
                    //RefreshDataGridView();
                }
                else
                {
                    MessageBox.Show("Thêm dữ liệu thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm dữ liệu: {ex.Message}");
            }
        }

        private void cbx_chuyenchinhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            String a = cbx_chuyenchinhanh.SelectedValue.ToString();
            SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MACN_CBX", a),
                };
            dataHelper = new DataHelper(connection);
            result = dataHelper.ExecuteStoredProcedure("SP_GETWAREHOUSE", parameters);
            //int res = dataHelper.ExecuteStoredProcedureNonQuery("sp_CHUYENCHINHANH2", parameters);
            dgv_warehouse.DataSource = result;
        }





        //private void dgv_warehouse_NewRowNeeded(object sender, DataGridViewRowEventArgs e)
        //{
        //    if (e.Row.Index == dgv_warehouse.Rows.Count - 1)
        //    {
        //        // Kiểm tra nếu đang ở dòng cuối và muốn thêm dòng mới
        //        DataGridViewRow newRow = e.Row; // Dòng cuối cùng
        //                                        // Có thể đặt giá trị mặc định cho các ô trong dòng mới
        //                                        // Ví dụ, bạn có thể tự động tạo mã kho
        //                                        // Tạo mã kho 
        //        DataHelper dh = new DataHelper(connection);
        //        DataTable res = dh.ExecuteStoredProcedure("SP_GETNEWIDWAREHOUSE");

        //        if (res.Rows.Count > 0)
        //        {
        //            DataRow roww = res.Rows[0]; // Lấy hàng đầu tiên
        //            mk = roww["NewMaKho"].ToString();
        //            MessageBox.Show(mk);

        //        }
        //        // Gọi stored procedure hoặc thêm dữ liệu vào cơ sở dữ liệu
        //        tk = newRow.Cells["TenKho"].Value.ToString();



        //        // Gọi stored procedure hoặc thêm dữ liệu vào cơ sở dữ liệu
        //        SqlParameter[] parameters = new SqlParameter[]
        //        {
        //            new SqlParameter("@TenKho", tk),
        //        };


        //        DataHelper dataHelper = new DataHelper(connection);
        //        int result = dataHelper.ExecuteStoredProcedureNonQuery("SP_ADDWAREHOUSE", parameters);

        //        if (result > 0)
        //        {
        //            MessageBox.Show("Thêm dữ liệu thành công!");
        //            // Cập nhật lại DataGridView nếu cần
        //            RefreshDataGridView();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Thêm dữ liệu thất bại!");
        //        }

        //    }
        //}

        private void dgv_warehouse_KeyDown(object sender, KeyEventArgs e)
        {
            dgv_warehouse.AllowUserToDeleteRows = (nhomquyen != "CONGTY");
            if (nhomquyen =="CONGTY")
            {
                MessageBox.Show("Bạn không có quyền xóa");
                return;
            }
            if (e.KeyCode == Keys.Tab)
            {
                e.Handled = true;  // Ngừng di chuyển đến ô tiếp theo khi nhấn Tab
            }
            if (e.KeyCode == Keys.Delete)
            {
                // Kiểm tra xem có dòng nào được chọn hay không
                if (dgv_warehouse.SelectedRows.Count > 0)
                {
                    // Lấy dòng đã chọn
                    DataGridViewRow selectedRow = dgv_warehouse.SelectedRows[0];

                    // Lấy giá trị của MaKho (Mã kho - khóa chính)
                    int MaKho = Convert.ToInt32(selectedRow.Cells["MaKho"].Value);

                    // Xác nhận người dùng có muốn xóa không
                    DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa kho này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (dialogResult == DialogResult.Yes)
                    {
                        // Xóa dữ liệu trong cơ sở dữ liệu
                        SqlParameter[] parameters = new SqlParameter[]
                        {
                            new SqlParameter("@MaKho", MaKho)
                        };

                        DataHelper dataHelper = new DataHelper(connection);
                        int result = dataHelper.ExecuteStoredProcedureNonQuery("SP_DELETEWAREHOUSE", parameters);

                        if (result > 0)
                        {
                            // Xóa dòng trong DataGridView
                            dgv_warehouse.Rows.Remove(selectedRow);
                            RefreshDataGridView();
                            MessageBox.Show("Xóa kho thành công!");
                        }
                        else
                        {
                            MessageBox.Show("Xóa kho thất bại!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn kho để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }


        }
    }
}
