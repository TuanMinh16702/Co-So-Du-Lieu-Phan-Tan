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
using static WindowsFormsApp1.FormStaff.FormAddLogin;

namespace WindowsFormsApp1.FormImport
{
   
    public partial class FormReceipt : Form
    {

        private DataHelper dataHelper;
        private String connection;
        DataTable result;
        FormAddReceipt formaddreceipt;
        FormEditReceipt formeditreceipt;
        String manv, hoten,nhomquyen;
        String macn;
        public FormReceipt(String connection,String manv, String hoten,String nhomquyen, String macn)
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
                btn_addreceipt.Enabled = false;
                btn_editreceipt.Enabled = false;
                btn_deletereceipt.Enabled = false;
                btn_undo.Enabled = false;
                dgv_receipt.ReadOnly = true;
            }
        }
        private void FormReceipt_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;

            // Phóng to toàn màn hình
            this.WindowState = FormWindowState.Maximized;

            // Đưa form lên trên cùng (nếu cần che Taskbar)
            this.TopMost = true;
            GetReceipt();
        }
        private void GetReceipt()
        {
            try
            {
                dataHelper = new DataHelper(connection);
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MACN_CBX", macn),

                };
                // Gọi Stored Procedure
                result = dataHelper.ExecuteStoredProcedure("SP_GETIMPORT", parameters);
                // Hiển thị dữ liệu lên DataGridView
                if (result != null && result.Rows.Count > 0)
                {
                    dgv_receipt.DataSource = result;
                    dgv_receipt.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgv_receipt.Columns["SoPn"].HeaderText = "Mã Phiếu Nhập";
                    dgv_receipt.Columns["TenHH"].HeaderText = "Tên Sản Phẩm";
                    dgv_receipt.Columns["NgayLap"].HeaderText = "Ngày Lập";
                    dgv_receipt.Columns["MaNV"].HeaderText = "Mã Nhân Viên";
                    dgv_receipt.Columns["HOTEN"].HeaderText = "Họ Tên Nhân Viên";
                    dgv_receipt.Columns["TenKho"].HeaderText = "Tên Kho";
                    dgv_receipt.Columns["MaDDH"].HeaderText = "Mã Đơn Đặt Hàng";
                    dgv_receipt.Columns["SoLuong"].HeaderText = "Số Lượng";
                    dgv_receipt.Columns["SoluongTon"].HeaderText = "Số Lượng Tồn";
                    dgv_receipt.Columns["DonGia"].HeaderText = "Đơn Giá";
                    dgv_receipt.Columns["MaHH"].Visible = false;
                   
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgv_receipt.DataSource = null;
                }
                dgv_receipt.Columns["SoPN"].ReadOnly = true;
                dgv_receipt.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgv_invoice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_addreceipt_Click(object sender, EventArgs e)
        {
            if (formaddreceipt == null)
            {
                formaddreceipt = new FormAddReceipt(this.connection,manv,hoten,macn);
                formaddreceipt.FormClosed += formaddreceipt_FormClosed;
                formaddreceipt.RecordReceiptAdded += formaddreceipt_RecordOrderAdded;
                formaddreceipt.Show();
            }
            else
            {
                formaddreceipt.Activate();
            }
        }
        private void formaddreceipt_RecordOrderAdded(object sender, AddRECEIPTRecordEventArgs e)
        {
            // Access e.Quantity, e.Description and e.Price
            // and add new row in grid using these values.
            result.Rows.Add(e.SoPn, e.maHH ,e.TenHH, e.NgayLap, e.manv ,e.hoten, e.TenKho, e.maddh, e.SoLuong, e.SoLuongTon ,e.DonGia);
            dgv_receipt.DataSource = result;
            dgv_receipt.Refresh();

        }
        private void formaddreceipt_FormClosed(object sender, FormClosedEventArgs e)
        {
            formaddreceipt = null;
        }
        private void btn_editreceipt_Click(object sender, EventArgs e)
        {
            if (dgv_receipt.SelectedRows.Count > 0)
            {

                var selectedRow = dgv_receipt.SelectedRows[0];
                var tenhh = selectedRow.Cells["TenHH"].Value.ToString();
                var ngaylap = selectedRow.Cells["NgayLap"].Value.ToString();
                int soluong = Convert.ToInt32(selectedRow.Cells["SoLuong"].Value.ToString());
                float dongia = Convert.ToSingle(selectedRow.Cells["DonGia"].Value.ToString());
                var tenkho = selectedRow.Cells["TenKho"].Value.ToString();
                var mahh = selectedRow.Cells["MaHH"].Value.ToString();
                var maddh = selectedRow.Cells["MaDDH"].Value.ToString();
                
                var manv = selectedRow.Cells["MaNV"].Value.ToString();
                if(manv.Trim() != this.manv)
                {
                    MessageBox.Show("Bạn không phải người lập phiếu");
                    return;
                }
                if (formeditreceipt == null)
                {
                    formeditreceipt = new FormEditReceipt(this.connection, selectedRow, manv, hoten, macn);
                    formeditreceipt.FormClosed += formeditreceipt_FormClosed;
                    formeditreceipt.DataEdited += formeditorder_DataEdited;
                    formeditreceipt.Show();
                }
                else
                {
                    formeditreceipt.Activate();
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
            foreach (DataGridViewColumn column in dgv_receipt.Columns)
            {
                // Cập nhật lại giá trị của các cột trong dòng tương ứng
                dgv_receipt.SelectedRows[0].Cells[column.Name].Value = editedRow.Cells[column.Name].Value;
            }

            // Nếu cần, bạn có thể lưu dữ liệu này vào database hoặc làm gì đó với dữ liệu đã cập nhật
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
            result = dataHelper.ExecuteStoredProcedure("SP_GETIMPORT", parameters);
            //int res = dataHelper.ExecuteStoredProcedureNonQuery("sp_CHUYENCHINHANH2", parameters);
            dgv_receipt.DataSource = result;
        }

        private void dgv_receipt_KeyDown(object sender, KeyEventArgs e)
        {
            dgv_receipt.AllowUserToDeleteRows = (nhomquyen != "CONGTY");
            if (nhomquyen == "CONGTY")
            {
                MessageBox.Show("Bạn không có quyền xóa");
                return;
            }
            if (e.KeyCode == Keys.Delete)
            {
                // Kiểm tra xem có dòng nào được chọn hay không
                if (dgv_receipt.SelectedRows.Count > 0)
                {
                    // Lấy dòng đã chọn
                    DataGridViewRow row = dgv_receipt.SelectedRows[0];

                    // Lấy giá trị của MaKho (Mã kho - khóa chính)
                    String sopn = row.Cells["SoPN"].Value.ToString();

                    // Xác nhận người dùng có muốn xóa không
                    DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (dialogResult == DialogResult.Yes)
                    {
                        // Xóa dữ liệu trong cơ sở dữ liệu
                        SqlParameter[] parameters = new SqlParameter[]
                        {
                            new SqlParameter("@SoPN", sopn)
                        };

                        DataHelper dataHelper = new DataHelper(connection);
                        int res = dataHelper.ExecuteStoredProcedureNonQuery("SP_DELETERECEIPT", parameters);

                        if (res > 0)
                        {
                            // Xóa dòng trong DataGridView
                            dgv_receipt.Rows.Remove(row);
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

        private void formeditreceipt_FormClosed(object sender, FormClosedEventArgs e)
        {
            formeditreceipt = null;
        }
    }
}
