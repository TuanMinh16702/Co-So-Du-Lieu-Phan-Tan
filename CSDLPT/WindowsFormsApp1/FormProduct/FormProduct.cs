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
using static WindowsFormsApp1.FormStaff.FormAddLogin;


namespace WindowsFormsApp1
{
    public partial class FormProduct : Form
    {
        private DataHelper dataHelper;
        private String connection;
        DataTable result;
        FormEditProduct formeditproduct;
        FormAddProduct formaddproduct;
        String nhomquyen;
        String macn;
        public FormProduct(String connection, string nhomquyen,String macn)
        {
            InitializeComponent();
            this.connection = connection;
            this.nhomquyen = nhomquyen;
            this.macn = macn;
            btn_lock();
           
        }
        
        private void btn_lock()
        {
            if (nhomquyen == "CONGTY")
            {
                btn_addProduct.Enabled = false;
                btn_editProduct.Enabled = false;
                btn_deleteProduct.Enabled = false;
                btn_undo.Enabled = false;
                dgv_product.ReadOnly = true;

            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormProduct_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;

            // Phóng to toàn màn hình
            this.WindowState = FormWindowState.Maximized;

            // Đưa form lên trên cùng (nếu cần che Taskbar)
            this.TopMost = true;
            try
            {


                dataHelper = new DataHelper(connection);
                
                // Gọi Stored Procedure
                result = dataHelper.ExecuteStoredProcedure("SP_GETPRODUCT");
                // Hiển thị dữ liệu lên DataGridView
                if (result != null && result.Rows.Count > 0)
                {
                    dgv_product.DataSource = result;
                    dgv_product.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgv_product.Columns["MaHH"].HeaderText = "Mã Hàng Hóa";
                    dgv_product.Columns["TenHH"].HeaderText = "Tên Hàng Hóa";
                    dgv_product.Columns["DonViTinh"].HeaderText = "Đơn Vị Tính";
                    dgv_product.Columns["TenLH"].HeaderText = "Loại Hàng";

                }
                else
                {
                    MessageBox.Show("Không có dữ liệu phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgv_product.DataSource = null;
                }
                dgv_product.Columns["MaHH"].ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            dgv_product.DataSource = dv;
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_product_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_editProduct_Click(object sender, EventArgs e)
        {
          
        }

        

        private void dgv_product_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridViewRow row = dgv_product.Rows[e.RowIndex];
            DataGridViewCell cell = row.Cells[e.ColumnIndex];

            if (cell.Value != null)
            {
                cell.Tag = cell.Value.ToString(); // Lưu giá trị ban đầu vào Tag
            }
        }

        private void dgv_product_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0 || e.RowIndex >= dgv_product.Rows.Count)
            {
                MessageBox.Show("Chỉ số dòng không hợp lệ!");
                return;
            }
            DataGridViewRow row = dgv_product.Rows[e.RowIndex];
            DataGridViewCell cell = row.Cells[e.ColumnIndex];

            // Lấy giá trị ban đầu từ Tag và giá trị mới từ Value
            string originalValue = cell.Tag?.ToString();
            string newValue = cell.Value?.ToString();

            if (originalValue != newValue)
            {
                string TenHH = row.Cells["TenHH"].Value.ToString();
                string DonViTinh = row.Cells["DonViTinh"].Value.ToString();
                string TenLH = row.Cells["TenLH"].Value.ToString(); // Cột Name
                String MaHH = row.Cells["MaHH"].Value.ToString();

                SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@MaHH", MaHH),
                new SqlParameter("@TenHH", TenHH),
                new SqlParameter("@DonViTinh", DonViTinh),
                new SqlParameter("@TenLH", TenLH),

                };

                // Gọi stored procedure
                DataHelper dataHelper = new DataHelper(connection); // Khởi tạo lớp DataHelper (có hàm ExecuteStoredProcedureNonQuery)
                int res = dataHelper.ExecuteStoredProcedureNonQuery("SP_UPDATEPRODUCT", parameters);

                if (res > 0)
                {
                    MessageBox.Show("Cập nhật dữ liệu thành công!");
                    dgv_product.CurrentCell = row.Cells["MaHH"];
                    RefreshDataGridView();
                    
                }
                else
                {
                    MessageBox.Show("Cập nhật dữ liệu thất bại!");
                }
            }
        }
        public void RefreshDataGridView()
        {
            DataTable dt = dataHelper.ExecuteStoredProcedure("SP_GETPRODUCT"); // Lấy lại dữ liệu từ cơ sở dữ liệu
            dgv_product.DataSource = dt;
        }

        private void dgv_product_KeyDown(object sender, KeyEventArgs e)
        {
            dgv_product.AllowUserToDeleteRows = (nhomquyen != "CONGTY");
            if (nhomquyen == "CONGTY")
            {
                MessageBox.Show("Bạn không có quyền xóa");
                return;
            }
            if (e.KeyCode == Keys.Delete)
            {
                // Kiểm tra xem có dòng nào được chọn hay không
                if (dgv_product.SelectedRows.Count > 0)
                {
                    // Lấy dòng đã chọn
                    DataGridViewRow row = dgv_product.SelectedRows[0];

                    // Lấy giá trị của MaKho (Mã kho - khóa chính)
                    String MaHH = row.Cells["MaHH"].Value.ToString();

                    // Xác nhận người dùng có muốn xóa không
                    DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (dialogResult == DialogResult.Yes)
                    {
                        // Xóa dữ liệu trong cơ sở dữ liệu
                        SqlParameter[] parameters = new SqlParameter[]
                        {
                            new SqlParameter("@MaHH", MaHH)
                        };

                        DataHelper dataHelper = new DataHelper(connection);
                        int res = dataHelper.ExecuteStoredProcedureNonQuery("SP_DELETEPRODUCT", parameters);

                        if (res > 0)
                        {
                            // Xóa dòng trong DataGridView
                            dgv_product.Rows.Remove(row);
                            RefreshDataGridView();
                            MessageBox.Show("Xóa sản phẩm thành công!");
                        }
                        else
                        {
                            MessageBox.Show("Xóa sản phẩm thất bại!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btn_addProduct_Click(object sender, EventArgs e)
        {
            
            if (formaddproduct == null)
            {
                formaddproduct = new FormAddProduct(this.connection);
                formaddproduct.RecordAdded += formaddproduct_RecordAdded;
                formaddproduct.FormClosed += formaddproduct_FormClosed;
                formaddproduct.Show();
            }
            else
            {
                formaddproduct.Activate();
            }

        }
        private void formaddproduct_RecordAdded(object sender, AddRecordEventArgs e)
        {
            // Access e.Quantity, e.Description and e.Price
            // and add new row in grid using these values.
            result.Rows.Add(e.maHH, e.tenHH, e.dvt, e.tenlh);
            dgv_product.DataSource = result;
            dgv_product.Refresh();

        }

        private void formaddproduct_FormClosed(object sender, FormClosedEventArgs e)
        {
            formaddproduct = null;
            
       
            //RefreshDataGridView();
        }

        public DataGridView GetDataGridView()
        {
            return this.dgv_product; // dgv_product là DataGridView trên Form B
        }
        public void AddValueToDataGridViewFromAdd(string maHH, string tenHH, string dvt, string maLH)
        {
            dgv_product.Rows.Add(maHH, tenHH, dvt, maLH);
            result.Rows.Add(maHH, tenHH, dvt, maLH);
            dgv_product.DataSource = result;
            dgv_product.Refresh();
            
        }

        
    }
}
