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

namespace WindowsFormsApp1.FormBill
{
    public partial class FormRedInvoice : Form
    {
        private DataHelper dataHelper;
        private String connection;
        DataTable result;
        FormAddInvoice formaddinvoice;
        String manv, hoten;
        String macn;
        String nhomquyen;
        public FormRedInvoice(String connection,String manv,String hoten,String macn, String nhomquyen)
        {
            InitializeComponent();
            this.connection = connection;
            this.manv = manv;
            this.hoten = hoten;
            this.macn = macn;
            this.nhomquyen = nhomquyen;
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
                btn_addinvoice.Enabled = false;
                dgv_invoice.ReadOnly = true;
                btn_undo.Enabled = false;
            }
        }
        private void FormRedInvoice_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;

            // Phóng to toàn màn hình
            this.WindowState = FormWindowState.Maximized;

            // Đưa form lên trên cùng (nếu cần che Taskbar)
            this.TopMost = true;
            GetBill();
        }

        private void GetBill()
        {
            try
            {
                dataHelper = new DataHelper(connection);
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MACN_CBX", macn),

                };
                // Gọi Stored Procedure
                result = dataHelper.ExecuteStoredProcedure("SP_GETBILL", parameters);
                // Hiển thị dữ liệu lên DataGridView
                if (result != null && result.Rows.Count > 0)
                {
                    dgv_invoice.DataSource = result;
                    dgv_invoice.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgv_invoice.Columns["SoHD"].HeaderText = "Mã Hóa Đơn";
                    dgv_invoice.Columns["NgayLap"].HeaderText = "Ngày Lập";
                    dgv_invoice.Columns["HOTENNV"].HeaderText = "Họ Tên Nhân Viên";
                    dgv_invoice.Columns["TenKho"].HeaderText = "Tên Kho";
                    dgv_invoice.Columns["TenKH"].HeaderText = "Tên Khách Hàng ";
                    dgv_invoice.Columns["DonGia"].HeaderText = "Tổng Tiền";

                }
                else
                {
                    MessageBox.Show("Không có dữ liệu phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgv_invoice.DataSource = null;
                }
                dgv_invoice.Columns["SoHD"].ReadOnly = true;
                dgv_invoice.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgv_invoice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_addinvoice_Click(object sender, EventArgs e)
        {
            if (formaddinvoice == null)
            {
                formaddinvoice = new FormAddInvoice(this.connection, manv, hoten, macn);
                formaddinvoice.FormClosed += formaddinvoice_FormClosed;
                formaddinvoice.RecordBillAdded += formaddinvoice_RecordBillAdded;
                formaddinvoice.Show();
            }
            else
            {
                formaddinvoice.Activate();
            }
        }

        private void formaddinvoice_RecordBillAdded(object sender, AddBillRecordEventArgs e)
        {
            // Access e.Quantity, e.Description and e.Price
            // and add new row in grid using these values.
            result.Rows.Add(e.Sohd, e.NgayLap, e.hoten, e.TenKho, e.tenkh, e.Total);
            dgv_invoice.DataSource = result;
            dgv_invoice.Refresh();

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
            result = dataHelper.ExecuteStoredProcedure("SP_GETBILL", parameters);
            //int res = dataHelper.ExecuteStoredProcedureNonQuery("sp_CHUYENCHINHANH2", parameters);
            dgv_invoice.DataSource = result;
        }

        private void formaddinvoice_FormClosed(object sender, FormClosedEventArgs e)
        {
            formaddinvoice = null;
        }
    }
}
