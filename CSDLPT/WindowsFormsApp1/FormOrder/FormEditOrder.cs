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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace WindowsFormsApp1.FormOrder
{
    public partial class FormEditOrder : Form
    {
        public delegate void DataEditedHandler(DataGridViewRow editedRow);
        public event DataEditedHandler DataEdited;
        private DataGridViewRow selectedRow;
        private DataHelper dataHelper;
        private String connection;
        String Manv;
        String maddh, ngaylap, tenkho, tenncc, hovaten, mahh, tenhh;
        int soluong,soluongfirst;
        float dongia,dongiafirst;
        String macn;
        private void tb_dongia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Chặn ký tự không hợp lệ
            }
        }

        private void tb_soluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Chặn ký tự không hợp lệ
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        public FormEditOrder(String connection, DataGridViewRow row, string macn)
        {
            InitializeComponent();
            this.connection = connection;
            this.selectedRow = row;
            this.macn = macn;
            dtp_ngaylap_load();
            cbx_tenkho_load();
            cbx_sanpham_load();
            cbx_ncc_load();
            this.maddh = row.Cells["MaDDH"].Value.ToString();
            tb_soluong.Text = row.Cells["SoLuong"].Value.ToString();
            tb_dongia.Text = float.Parse(row.Cells["DonGia"].Value.ToString()).ToString("N0");
            soluongfirst = int.Parse(row.Cells["SoLuong"].Value.ToString());
            dongiafirst = float.Parse(row.Cells["DonGia"].Value.ToString());
           
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            try
            {
                
                soluong = int.Parse(tb_soluong.Text);
                dongia = float.Parse(tb_dongia.Text);
                
                DataRowView selectedRow1 = cbx_tenkho.SelectedItem as DataRowView;
                DataRowView selectedRow2 = cbx_ncc.SelectedItem as DataRowView;
                DataRowView selectedRow3 = cbx_tensanpham.SelectedItem as DataRowView;
                String makho = cbx_tenkho.SelectedValue.ToString();
                String mancc = cbx_ncc.SelectedValue.ToString();
                String mahh = cbx_tensanpham.SelectedValue.ToString();

                tenkho = selectedRow1["TenKho"].ToString();
                tenncc = selectedRow2["TenNCC"].ToString();
                tenhh = selectedRow3["TenHH"].ToString();

                DateTime selectedNgaySinh = dtp_ngaylap.Value;
                ngaylap = selectedNgaySinh.ToString("yyyy-MM-dd");

                

                SqlParameter[] parameters = new SqlParameter[]
                    {
                    new SqlParameter("@MaDDH", maddh),
                    new SqlParameter("@MaHH", mahh),
                    new SqlParameter("@NgayLap", ngaylap.ToString()),
                    new SqlParameter("@MaNCC", mancc),
                    new SqlParameter("@MaKho", makho),
                    new SqlParameter("@SoLuong", soluong),
                    new SqlParameter("@DonGia", dongia),
                    

                    };
                int result = dataHelper.ExecuteStoredProcedureNonQuery("SP_UPDATEORDER", parameters);

                if (result > 0)
                {
                    MessageBox.Show("Sửa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    
                    selectedRow.Cells["TenHH"].Value = tenhh;
                    selectedRow.Cells["NgayLap"].Value = selectedNgaySinh.ToString("dd-MM-yyyy");
                    selectedRow.Cells["TenKho"].Value = tenkho;
                    selectedRow.Cells["TenNCC"].Value = tenncc;
                    selectedRow.Cells["SoLuong"].Value = soluong;
                    selectedRow.Cells["DonGia"].Value = dongia;

                    DataEdited?.Invoke(selectedRow);
                    //OnRecordAdded();
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Sửa dữ liệu thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dtp_ngaylap_load()
        {
            string format = "dd-MM-yyyy";
            try
            {
                DateTime parsedDate = DateTime.ParseExact(selectedRow.Cells["NgayLap"].Value.ToString(), format, null); // Chuyển đổi theo định dạng
                dtp_ngaylap.Value = parsedDate;
                Console.WriteLine($"Kết quả: {parsedDate.ToString("yyyy-MM-dd")}");
                dtp_ngaylap.Enabled = false;
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Định dạng ngày không hợp lệ: {ex.Message}");
            }
            
        }

        private void cbx_ncc_load()
        {
            dataHelper = new DataHelper(connection);
            try
            {
                // Gọi stored procedure bằng DataHelper
                DataTable data = dataHelper.ExecuteStoredProcedure("SP_GETSUPPLIER");

                // Kiểm tra dữ liệu và gắn vào ComboBox
                if (data != null && data.Rows.Count > 0)
                {
                    cbx_ncc.DataSource = data;
                    cbx_ncc.DisplayMember = "TenNCC"; // Hiển thị tên loại hàng
                    cbx_ncc.ValueMember = "MaNCC"; // Giá trị tương ứng là mã loại hàng
                    foreach (DataRow row in data.Rows)
                    {
                        if (row["TenNCC"].ToString() == selectedRow.Cells["TenNCC"].Value.ToString()) // So sánh tên nhà cung cấp
                        {
                            cbx_ncc.SelectedValue = row["MaNCC"]; // Đặt giá trị mặc định theo mã nhà cung cấp
                            break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu để hiển thị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                cbx_ncc.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cbx_sanpham_load()
        {
            dataHelper = new DataHelper(connection);
            try
            {
                // Gọi stored procedure bằng DataHelper
                DataTable data = dataHelper.ExecuteStoredProcedure("SP_GETPRODUCT");
                
                // Kiểm tra dữ liệu và gắn vào ComboBox
                if (data != null && data.Rows.Count > 0)
                {
                    cbx_tensanpham.DataSource = data;
                    cbx_tensanpham.DisplayMember = "TenHH"; // Hiển thị tên loại hàng
                    cbx_tensanpham.ValueMember = "MaHH"; // Giá trị tương ứng là mã loại hàng
                    foreach (DataRow row in data.Rows)
                    {
                        if (row["TenHH"].ToString() == selectedRow.Cells["TenHH"].Value.ToString()) 
                        {
                            cbx_tensanpham.SelectedValue = row["MaHH"]; 
                            break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu để hiển thị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                cbx_ncc.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cbx_tenkho_load()
        {
            dataHelper = new DataHelper(connection);
            SqlParameter[] parameters = new SqlParameter[]
                {
                            new SqlParameter("@MACN_CBX", macn),

                 };
            try
            {
                // Gọi stored procedure bằng DataHelper
                DataTable data = dataHelper.ExecuteStoredProcedure("SP_GETWAREHOUSE", parameters);

                // Kiểm tra dữ liệu và gắn vào ComboBox
                if (data != null && data.Rows.Count > 0)
                {
                    cbx_tenkho.DataSource = data;
                    cbx_tenkho.DisplayMember = "TenKho"; // Hiển thị tên loại hàng
                    cbx_tenkho.ValueMember = "MaKho"; // Giá trị tương ứng là mã loại hàng
                    foreach (DataRow row in data.Rows)
                    {
                        if (row["TenKho"].ToString() == selectedRow.Cells["TenKho"].Value.ToString())
                        {
                            cbx_tenkho.SelectedValue = row["MaKho"];
                            break;
                        }
                    }
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
