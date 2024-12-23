using System;
using System.Collections;
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

namespace WindowsFormsApp1.Report
{
    public partial class FormReport : Form
    {
        private DataHelper dataHelper;
        private String connection;
        private string nhomquyen;
        private SqlParameter[] parameters;
        String cbxCNselect;
        String macn;
        public FormReport(String connection, String nhomquyen, String macn)
        {
            InitializeComponent();
            
           
            this.connection = connection;
            this.nhomquyen = nhomquyen;
            this.macn = macn;
            cbx_chuyenchinhanh_load();
            lockfunction();
            string[] items = { "XUAT", "NHAP" };
            cbx_loai.Items.AddRange(items);
            cbx_loai.SelectedIndex = 0;
            dgv_report.ReadOnly = true;
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

        private void cbx_report_load()
        {
            this.FormBorderStyle = FormBorderStyle.None;

            // Phóng to toàn màn hình
            this.WindowState = FormWindowState.Maximized;

            // Đưa form lên trên cùng (nếu cần che Taskbar)
            this.TopMost = true;
            List<Report> reports = new List<Report>
            {
                new Report { Sp = "sp_ChiTietSoLuongTriGiaHangHoaNhapXuat", Name = "Bảng kê chi tiết số lượng – trị giá hàng nhập hoặc xuất " },
                new Report { Sp = "sp_DonHangKhongPhieuNhap", Name = "Danh sách các đơn đặt hàng chưa có phiếu nhập" },
                new Report { Sp = "sp_TongHopNhapXuat", Name = "Tổng Hợp Nhập Xuất" }
            };

            // Gắn dữ liệu vào ComboBox
            comboBox1.DataSource = reports;       // Gắn danh sách làm nguồn dữ liệu
            comboBox1.DisplayMember = "Name";  // Thuộc tính hiển thị
            comboBox1.ValueMember = "Sp";
        }
        private void lockfunction()
        {
            dtp_tungay.Enabled = false;
            dtp_denngay.Enabled = false;
            cbx_loai.Enabled = false;
        }
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
           
            if (comboBox1.SelectedIndex == 0)
            {
                dtp_tungay.Enabled = true;
                dtp_denngay.Enabled = true;
                cbx_loai.Enabled = true;
                
            }
            if (comboBox1.SelectedIndex == 2)
            {
                dtp_tungay.Enabled = true;
                dtp_denngay.Enabled = true;
                cbx_loai.Enabled = false;
            }
            if (comboBox1.SelectedIndex == 1)
            {
                parameters = new SqlParameter[]
                {
                   
                };
            }
            //lockfunction();
        }
        public class Report
        {
            public String Name { get; set; }
            public string Sp { get; set; }
        }

        private void btn_loc_Click(object sender, EventArgs e)
        {
            String a = comboBox1.SelectedValue.ToString();
            int b = comboBox1.SelectedIndex;
            dataHelper = new DataHelper(connection);

            dtp_tungay.Format = DateTimePickerFormat.Custom;
            dtp_tungay.CustomFormat = "dd/MM/yyyy"; // Định dạng ngày giờ

            dtp_denngay.Format = DateTimePickerFormat.Custom;
            dtp_denngay.CustomFormat = "dd/MM/yyyy";

            DateTime selectedFromDate = dtp_tungay.Value;
            DateTime selectedToDate = dtp_denngay.Value;
            String cbxselect = cbx_loai.SelectedItem.ToString();
            if (this.nhomquyen.Trim() =="CONGTY")
            {
                cbxCNselect = cbx_chuyenchinhanh.SelectedValue.ToString();
            }
            else
            {
                cbxCNselect = macn;
            }
           
            if (comboBox1.SelectedIndex == 0)
            {
                
                parameters = new SqlParameter[]
                {
                   new SqlParameter("@MACN_CBX", cbxCNselect),
                   new SqlParameter("@TYPE", cbxselect),
                   new SqlParameter("@DATEFROM", selectedFromDate),
                   new SqlParameter("@DATETO", selectedToDate),
                   
                };
            }
            if (comboBox1.SelectedIndex == 2)
            {
                parameters = new SqlParameter[]
                {
                   new SqlParameter("@MACN_CBX", cbxCNselect.Trim()),
                   new SqlParameter("@FromDate", selectedFromDate),
                   new SqlParameter("@ToDate", selectedToDate),
                   
                };
            }
            if (comboBox1.SelectedIndex == 1)
            {
                parameters = new SqlParameter[]
                {
                    new SqlParameter("@MACN_CBX", cbxCNselect),
                };
            }
            // Gọi Stored Procedure
            DataTable result = dataHelper.ExecuteStoredProcedure(a, parameters);
            if (result != null && result.Rows.Count > 0)
            {
                
                if (b == 2)
                {
                    AddSummaryRowToDataTable(result);
                }
                dgv_report.DataSource = result;
                dgv_report.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                lockfunction();
            }
            else
            {
                MessageBox.Show("Không có dữ liệu phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgv_report.DataSource = null;
            }

        }
        private void AddSummaryRowToDataTable(DataTable dt)
        {
            // Tính toán tổng
            double totalNhap = dt.AsEnumerable().Sum(row => row.Field<double>("NHAP"));
            double totalXuat = dt.AsEnumerable().Sum(row => row.Field<double>("XUAT"));

            // Thêm dòng tổng
            DataRow summaryRow = dt.NewRow();
            summaryRow["Ngay"] = "CỘNG";
            summaryRow["Nhap"] = totalNhap.ToString("N0");
            summaryRow["Xuat"] = totalXuat.ToString("N0");
            dt.Rows.Add(summaryRow);
        }


        private void FormReport_Load_1(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;

            // Phóng to toàn màn hình
            this.WindowState = FormWindowState.Maximized;

            // Đưa form lên trên cùng (nếu cần che Taskbar)
            this.TopMost = true;
            cbx_report_load();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbx_chuyenchinhanh_DropDownClosed(object sender, EventArgs e)
        {

        }
    }
}
