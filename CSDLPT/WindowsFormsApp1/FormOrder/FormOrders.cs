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
using WindowsFormsApp1.FormOrder;
using WindowsFormsApp1.Object;
using static WindowsFormsApp1.FormStaff.FormAddLogin;
namespace WindowsFormsApp1
{
    public partial class FormOrders : Form
    {
        private DataHelper dataHelper;
        private String connection;
        String login;
        DataTable result;
        String manv;
        FormAddOrder formaddorder;
        String hoten;
        int rowcount;
        FormEditOrder formeditorder;
        String nhomquyen;
        String macn;
        public FormOrders(String connection,String manv, string hoten, string nhomquyen,String macn)
        {
            InitializeComponent();
            this.connection = connection;
            this.manv = manv;
            this.hoten = hoten;
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
        private void btn_lock()
        {
            if (nhomquyen == "CONGTY")
            {
                btn_addorder.Enabled = false;
                btn_editorder.Enabled = false;
                btn_deleteorder.Enabled = false;
                btn_undo.Enabled = false;
                dgv_order.ReadOnly = true;
            }
        }
        private void FormOrder_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;

            // Phóng to toàn màn hình
            this.WindowState = FormWindowState.Maximized;

            // Đưa form lên trên cùng (nếu cần che Taskbar)
            this.TopMost = true;
            getOrder();
        }

        private void getOrder()
        {
            try
            {
                dataHelper = new DataHelper(connection);
                SqlParameter[] parameters = new SqlParameter[]
                {
                            new SqlParameter("@MACN_CBX", macn),
                            
                       };
                // Gọi Stored Procedure
                result = dataHelper.ExecuteStoredProcedure("SP_GETORDER", parameters);
                // Hiển thị dữ liệu lên DataGridView
                if (result != null && result.Rows.Count > 0)
                {
                    dgv_order.DataSource = result;
                    dgv_order.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgv_order.Columns["MaDDH"].HeaderText = "Mã Đơn Đặt Hàng";
                    dgv_order.Columns["NgayLap"].HeaderText = "Ngày Lập";
                    dgv_order.Columns["MaNV"].HeaderText = "Mã Nhân Viên";
                    dgv_order.Columns["HOTEN"].HeaderText = "Họ Tên Nhân Viên";
                    dgv_order.Columns["TenKho"].HeaderText = "Tên Kho";
                    dgv_order.Columns["TenNCC"].HeaderText = "Nhà Cung Cấp";
                    dgv_order.Columns["SoLuong"].HeaderText = "Số Lượng";
                    dgv_order.Columns["DonGia"].HeaderText = "Đơn Giá";

                }
                else
                {
                    MessageBox.Show("Không có dữ liệu phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgv_order.DataSource = null;
                }
                dgv_order.Columns["MaDDH"].ReadOnly = true;
                dgv_order.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            rowcount = dgv_order.Rows.Count;
        }

        private void dgv_order_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_addorder_Click(object sender, EventArgs e)
        {
            if (formaddorder == null)
            {
                formaddorder = new FormAddOrder(this.connection,manv,hoten,macn);
                formaddorder.FormClosed += formaddorder_FormClosed;
                formaddorder.RecordOrderAdded += formaddorder_RecordOrderAdded;
                formaddorder.Show();
            }
            else
            {
                formaddorder.Activate();
            }
        }
        private void formaddorder_RecordOrderAdded(object sender, AddORDERRecordEventArgs e)
        {
            // Access e.Quantity, e.Description and e.Price
            // and add new row in grid using these values.
            result.Rows.Add(e.MaDDH, e.TenHH, e.NgayLap, e.manv ,e.hoten, e.TenKho, e.TenNCC,e.SoLuong,e.DonGia);
            dgv_order.DataSource = result;
            dgv_order.Refresh();

        }
        private void formaddorder_FormClosed(object sender, FormClosedEventArgs e)
        {
            formaddorder = null;
        }

        private void dgv_order_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgv_order.Rows.Count <= rowcount)
            {

                DataGridViewRow row = dgv_order.Rows[e.RowIndex];
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
                                dgv_order.CurrentCell = row.Cells["MaKho"];

                                //RefreshDataGridView(); // Cập nhật lại DataGridView nếu cần
                            }
                            else
                            {
                                MessageBox.Show("Cập nhật dữ liệu thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //RefreshDataGridView();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Lỗi khi cập nhật dữ liệu: {ex.Message}");
                            //RefreshDataGridView();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi cập nhật dữ liệu: {ex.Message}");
                        dgv_order.CurrentCell = row.Cells["MaKho"];
                    }


                }
            }
        }

        private void dgv_order_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridViewRow row = dgv_order.Rows[e.RowIndex];
            DataGridViewCell cell = row.Cells[e.ColumnIndex];

            if (cell.Value != null)
            {
                cell.Tag = cell.Value.ToString(); // Lưu giá trị ban đầu vào Tag
            }
        }

        private void btn_editorder_Click(object sender, EventArgs e)
        {
            if (dgv_order.SelectedRows.Count > 0)
            {


                // Lấy dữ liệu của dòng được chọn
                var selectedRow = dgv_order.SelectedRows[0];
                var tenhh = selectedRow.Cells["TenHH"].Value.ToString();
                var ngaylap = selectedRow.Cells["NgayLap"].Value.ToString();
                int soluong = Convert.ToInt32(selectedRow.Cells["SoLuong"].Value.ToString());
                float dongia = Convert.ToSingle(selectedRow.Cells["DonGia"].Value.ToString());
                var tenkho = selectedRow.Cells["TenKho"].Value.ToString();
                var tenncc = selectedRow.Cells["TenNcc"].Value.ToString();
                var maddh = selectedRow.Cells["MaDDH"].Value.ToString();
                string manv = selectedRow.Cells["MaNV"].Value.ToString();
                if (this.manv.Trim() != manv.Trim())
                {
                    MessageBox.Show("Bạn không phải là người lập phiếu");
                    return;
                }
                // Tạo instance của Form2 và truyền dữ liệu qua
                if (formeditorder == null)
                {
                    formeditorder = new FormEditOrder(this.connection, selectedRow,macn);
                    formeditorder.FormClosed += formeditorder_FormClosed;
                    formeditorder.DataEdited += formeditorder_DataEdited;
                    formeditorder.Show();
                }
                else
                {
                    formeditorder.Activate();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xem chi tiết!", "Thông báo");
            }
        }

        private void formeditorder_DataEdited(DataGridViewRow editedRow)
        {
            // Khi nhận dữ liệu đã chỉnh sửa từ Form B, cập nhật lại dòng trong DataGridView
            foreach (DataGridViewColumn column in dgv_order.Columns)
            {
                // Cập nhật lại giá trị của các cột trong dòng tương ứng
                dgv_order.SelectedRows[0].Cells[column.Name].Value = editedRow.Cells[column.Name].Value;
            }

            // Nếu cần, bạn có thể lưu dữ liệu này vào database hoặc làm gì đó với dữ liệu đã cập nhật
        }
        private void formeditorder_FormClosed(object sender, FormClosedEventArgs e)
        {
            formeditorder = null;
        }

        private void dgv_order_KeyDown(object sender, KeyEventArgs e)
        {
            dgv_order.AllowUserToDeleteRows = (nhomquyen != "CONGTY");
            if (nhomquyen == "CONGTY")
            {
                MessageBox.Show("Bạn không có quyền xóa");
                return;
            }
            if (e.KeyCode == Keys.Delete)
            {
                // Kiểm tra xem có dòng nào được chọn hay không
                if (dgv_order.SelectedRows.Count > 0)
                {
                    // Lấy dòng đã chọn
                    DataGridViewRow row = dgv_order.SelectedRows[0];

                    // Lấy giá trị của MaKho (Mã kho - khóa chính)
                    String maddh = row.Cells["MaDDH"].Value.ToString();

                    // Xác nhận người dùng có muốn xóa không
                    DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (dialogResult == DialogResult.Yes)
                    {
                        // Xóa dữ liệu trong cơ sở dữ liệu
                        SqlParameter[] parameters = new SqlParameter[]
                        {
                            new SqlParameter("@MaDDH", maddh)
                        };

                        DataHelper dataHelper = new DataHelper(connection);
                        int res = dataHelper.ExecuteStoredProcedureNonQuery("SP_DELETEORDER", parameters);

                        if (res > 0)
                        {
                            // Xóa dòng trong DataGridView
                            dgv_order.Rows.Remove(row);
                            //RefreshDataGridView();
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

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbx_chuyenchinhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            String a = cbx_chuyenchinhanh.SelectedValue.ToString();
            SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MACN_CBX", a),
                };
            dataHelper = new DataHelper(connection);
            result = dataHelper.ExecuteStoredProcedure("SP_GETORDER", parameters);
            //int res = dataHelper.ExecuteStoredProcedureNonQuery("sp_CHUYENCHINHANH2", parameters);
            dgv_order.DataSource = result;
        }
    }
}
