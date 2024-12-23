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
using WindowsFormsApp1.Object;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static WindowsFormsApp1.FormStaff.FormAddLogin;

namespace WindowsFormsApp1
{
    public partial class FormInfo : Form
    {
        Info info = new Info();
        InfoObject io = new InfoObject();
        private DataHelper dataHelper;
        private String connection;
        private DateTime? selectedFromDate = null;
        private DateTime? selectedToDate = null;
        String cbxCNselect;
        public FormInfo(String connection, InfoObject io )
        {
            InitializeComponent();
            this.connection = connection;
            dataHelper = new DataHelper(connection);
            this.io = io;
            dgv_hdnv.ReadOnly = true;
            Form1_Load();
        }
        private void Form1_Load()
        {
            tb_manv.Text = io.manv;
            tb_hoten.Text = io.hoten;
            tb_phai.Text = io.phai;
            tb_ngaysinh.Text = io.ngaysinh;
            tb_sodienthoai.Text = io.sodienthoai;
            tb_diachi.Text = io.diachi;
            tb_chinhanh.Text = io.macn;
            tb_nhomquyen.Text = io.nhomquyen;
            cbx_manv_load();
            cbx_chuyenchinhanh_load();
            btnlock();
        }
       
        private void btnlock()
        {
            tb_manv.Enabled = false;
            tb_hoten.Enabled = false;
            tb_phai.Enabled = false;    
            tb_ngaysinh.Enabled = false;
            tb_sodienthoai.Enabled = false;
            tb_diachi.Enabled = false;
            tb_chinhanh.Enabled = false;
            tb_nhomquyen.Enabled = false;

        }
        private void cbx_manv_load()
        {
            dataHelper = new DataHelper(connection);
            String macn = io.macn;
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MACN_CBX", io.macn.ToString()),
                };
                // Gọi stored procedure bằng DataHelper
                DataTable data = dataHelper.ExecuteStoredProcedure("SP_GETSTAFFLIST", parameters);
                
                // Kiểm tra dữ liệu và gắn vào ComboBox
                if (data != null && data.Rows.Count > 0)
                {
                    cbx_nhanvien.DataSource = data;
                    cbx_nhanvien.DisplayMember = "HOTEN"; // Hiển thị tên loại hàng
                    cbx_nhanvien.ValueMember = "MaNV"; // Giá trị tương ứng là mã loại hàng
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
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormInfo_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;

            // Phóng to toàn màn hình
            this.WindowState = FormWindowState.Maximized;

            // Đưa form lên trên cùng (nếu cần che Taskbar)
            this.TopMost = true;
        }

        private void tb_ngaysinh_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_manv_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_hoten_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_phai_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void dtp_tungay_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cbx_loaiphieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void dgv_hdnv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtp_denngay_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btn_loc_Click(object sender, EventArgs e)
        {
            try
            {


                dtp_tungay.Format = DateTimePickerFormat.Custom;
                dtp_tungay.CustomFormat = "dd/MM/yyyy"; // Định dạng ngày giờ

                dtp_denngay.Format = DateTimePickerFormat.Custom;
                dtp_denngay.CustomFormat = "dd/MM/yyyy";

                DateTime selectedFromDate = dtp_tungay.Value;
                DateTime selectedToDate = dtp_denngay.Value;
                if (selectedFromDate == null || selectedToDate == null)
                {
                    MessageBox.Show("Vui lòng chọn lại thông tin");
                    return;
                }
                
                String cbxselect = cbx_nhanvien.SelectedValue.ToString();
                Console.WriteLine("From Date: " + selectedFromDate.ToString("dd/MM/yyyy"));
                Console.WriteLine("To Date: " + selectedToDate.ToString("dd/MM/yyyy"));
                Console.WriteLine("Loại: " + cbxselect);
                dataHelper = new DataHelper(connection);
                if (io.nhomquyen.Trim() == "CONGTY")
                {
                    cbxCNselect = cbx_chuyenchinhanh.SelectedValue.ToString();
                }
                else
                {
                    cbxCNselect = io.macn;
                }
                
                SqlParameter[] parameters = new SqlParameter[]
                   {
                     new SqlParameter("@MANV", SqlDbType.Char, 10) { Value = cbxselect }
                    ,new SqlParameter("@DATEFROM", SqlDbType.Date) { Value =  selectedFromDate }
                    ,new SqlParameter("@DATETO", SqlDbType.Date) { Value = selectedToDate }
                    ,new SqlParameter("@MACN_CBX", SqlDbType.Char) { Value = cbxCNselect }
                   };

                // Gọi Stored Procedure
                DataTable result = dataHelper.ExecuteStoredProcedure("sp_HoatDongNhanVien2", parameters);
                // Hiển thị dữ liệu lên DataGridView
                if (result != null && result.Rows.Count > 0)
                {
                    dgv_hdnv.DataSource = result;
                    dgv_hdnv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgv_hdnv.Columns["THANGNAM"].HeaderText = "Tháng năm";
                    dgv_hdnv.Columns["LOAI"].HeaderText = "Loại phiếu";
                    dgv_hdnv.Columns["NGAYLAP"].HeaderText = "Ngày lập";
                    dgv_hdnv.Columns["MAPHIEU"].HeaderText = "Mã phiếu";
                    dgv_hdnv.Columns["TENHH"].HeaderText = "Tên hàng hóa";
                    dgv_hdnv.Columns["TENKHO"].HeaderText = "Tên kho";
                    dgv_hdnv.Columns["SOLUONG"].HeaderText = "Số lượng";
                    dgv_hdnv.Columns["DONGIA"].HeaderText = "Đơn giá";
                    dgv_hdnv.Columns["TRIGIA"].HeaderText = "Tổng tiền";
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgv_hdnv.DataSource = null;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private decimal TinhTongGiaTri()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgv_hdnv.Rows)
            {
                if (row.Cells["TRIGIA"].Value != null)
                {
                    total += Convert.ToDecimal(row.Cells["TRIGIA"].Value);
                }
            }
            return total;
        }
        private void dgv_hdnv_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            // Kiểm tra nếu là dòng cuối cùng
            if (e.RowIndex == dgv_hdnv.Rows.Count - 1)
            {
                var grid = sender as DataGridView;
                var row = grid.Rows[e.RowIndex];
                var rect = grid.GetRowDisplayRectangle(e.RowIndex, true);

                // Tính tổng chiều rộng của các cột cần gộp (trừ cột cuối cùng)
                int totalWidth = 0;
                for (int i = 0; i < grid.Columns.Count - 1; i++)
                {
                    totalWidth += grid.GetColumnDisplayRectangle(i, true).Width;
                }
                totalWidth = totalWidth +10;
                // Vị trí và kích thước vùng để gộp
                Rectangle mergedRect = new Rectangle(
                    rect.Left + 2,                 // Lề trái
                    rect.Top,                      // Vị trí dòng
                    totalWidth - 4,                // Tổng chiều rộng (trừ lề)
                    rect.Height                    // Chiều cao dòng
                );

                // Vẽ nền màu xám nhạt cho vùng gộp
                e.Graphics.FillRectangle(new SolidBrush(Color.AntiqueWhite), mergedRect);

                // Nội dung hiển thị trong vùng gộp
                string totalText = "Tổng cộng: ";
                using (var brush = new SolidBrush(Color.Black))
                {
                    e.Graphics.DrawString(
                        totalText,
                        grid.Font,
                        brush,
                        mergedRect,
                        new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        }
                    );
                }

                // Vẽ nội dung riêng cho cột cuối cùng
                Rectangle lastColumnRect = grid.GetColumnDisplayRectangle(grid.Columns.Count - 1, true);
                Rectangle cellRect = new Rectangle(
                    lastColumnRect.Left,
                    rect.Top,
                    lastColumnRect.Width,
                    rect.Height
                );

                e.Graphics.FillRectangle(new SolidBrush(Color.White), cellRect);
                e.Graphics.DrawString(
                    TinhTongGiaTri().ToString("N0"),  // Nội dung tổng cho cột cuối
                    grid.Font,
                    Brushes.Black,
                    cellRect,
                    new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    }
                );
            }
        }

        private void dgv_hdnv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void cbx_chuyenchinhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void cbx_chuyenchinhanh_load()
        {
            cbx_chuyenchinhanh.Enabled = false;
            if (io.nhomquyen == "CONGTY")
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

        private void cbx_chuyenchinhanh_DropDownClosed(object sender, EventArgs e)
        {
            String a = cbx_chuyenchinhanh.SelectedValue.ToString();
            SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MACN_CBX", a),
                };
            dataHelper = new DataHelper(connection);
            try
            {
                // Gọi stored procedure bằng DataHelper
                DataTable data = dataHelper.ExecuteStoredProcedure("SP_GETSTAFFLIST", parameters);

                // Kiểm tra dữ liệu và gắn vào ComboBox
                if (data != null && data.Rows.Count > 0)
                {
                    cbx_nhanvien.DataSource = data;
                    cbx_nhanvien.DisplayMember = "HOTEN"; // Hiển thị tên loại hàng
                    cbx_nhanvien.ValueMember = "MaNV"; // Giá trị tương ứng là mã loại hàng
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
    }
}
