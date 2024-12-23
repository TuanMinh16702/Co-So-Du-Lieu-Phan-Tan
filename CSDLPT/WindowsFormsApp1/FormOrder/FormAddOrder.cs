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

namespace WindowsFormsApp1.FormOrder
{
    public partial class FormAddOrder : Form
    {
        private DataHelper dataHelper;
        private String connection;
        String Manv;
        String maddh,today,tenkho,tenncc,hovaten,mahh,tenhh;
        int soluong;
        float dongia;
        String macn;
        public event EventHandler<CRUD.AddORDERRecordEventArgs> RecordOrderAdded;
        public FormAddOrder(String connection,String manv, String hoten ,String macn)
        {
            InitializeComponent();
            this.connection = connection;
            this.Manv = manv;
            this.hovaten = hoten;
            this.macn = macn;
            cbx_TenKho_Load();
            cbx_NCC_Load();
            cbx_sanpham_Load();
            tb_manv.Enabled = false;
            tb_manv.Text = Manv.ToString();
        }

        private void cbx_TenKho_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbx_NCC_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tb_soluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Chặn ký tự không hợp lệ
            }
        }

        private void tb_dongia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Chặn ký tự không hợp lệ
            }
        }

        private void cbx_TenKho_Load()
        {
            dataHelper = new DataHelper(connection);
            SqlParameter[] parameters = new SqlParameter[]
                {
                            new SqlParameter("@MACN_CBX", macn),

                 };
            // Gọi Stored Procedure
            try
            {
                // Gọi stored procedure bằng DataHelper
                DataTable data = dataHelper.ExecuteStoredProcedure("SP_GETWAREHOUSE", parameters);
               
                // Kiểm tra dữ liệu và gắn vào ComboBox
                if (data != null && data.Rows.Count > 0)
                {
                    cbx_TenKho.DataSource = data;
                    cbx_TenKho.DisplayMember = "TenKho"; // Hiển thị tên loại hàng
                    cbx_TenKho.ValueMember = "MaKho"; // Giá trị tương ứng là mã loại hàng
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
        private void cbx_sanpham_Load()
        {
            dataHelper = new DataHelper(connection);
            
            try
            {
                // Gọi stored procedure bằng DataHelper
                DataTable data = dataHelper.ExecuteStoredProcedure("SP_GETPRODUCT");
                
                // Kiểm tra dữ liệu và gắn vào ComboBox
                if (data != null && data.Rows.Count > 0)
                {
                    cbx_sanpham.DataSource = data;
                    cbx_sanpham.DisplayMember = "TenHH"; // Hiển thị tên loại hàng
                    cbx_sanpham.ValueMember = "MaHH"; // Giá trị tương ứng là mã loại hàng
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

        private void cbx_NCC_Load()
        {
            dataHelper = new DataHelper(connection);
            try
            {
                // Gọi stored procedure bằng DataHelper
                DataTable data = dataHelper.ExecuteStoredProcedure("SP_GETSUPPLIER");

                // Kiểm tra dữ liệu và gắn vào ComboBox
                if (data != null && data.Rows.Count > 0)
                {
                    cbx_NCC.DataSource = data;
                    cbx_NCC.DisplayMember = "TenNCC"; // Hiển thị tên loại hàng
                    cbx_NCC.ValueMember = "MaNCC"; // Giá trị tương ứng là mã loại hàng
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_addorder_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb_dongia.Text == "" || tb_soluong.Text =="")
                {
                    MessageBox.Show($"Vui Lòng Nhập Đầy Đủ Thông Tin");
                    return;
                }
                soluong = int.Parse(tb_soluong.Text); 
                dongia = float.Parse(tb_dongia.Text);
                
                DataRowView selectedRow1 = cbx_TenKho.SelectedItem as DataRowView;
                DataRowView selectedRow2 = cbx_NCC.SelectedItem as DataRowView;
                DataRowView selectedRow3 = cbx_sanpham.SelectedItem as DataRowView;
                String makho = cbx_TenKho.SelectedValue.ToString();
                String mancc = cbx_NCC.SelectedValue.ToString();
                DateTime now = DateTime.Now;
                today = now.ToString("yyyy-MM-dd");
                mahh = cbx_sanpham.SelectedValue.ToString();

                tenkho = selectedRow1["TenKho"].ToString();
                tenncc = selectedRow2["TenNCC"].ToString();
                tenhh = selectedRow3["TenHH"].ToString();
                DataTable res = dataHelper.ExecuteStoredProcedure("SP_GETNEWIDORDER");

                if (res.Rows.Count > 0)
                {
                    DataRow row = res.Rows[0]; // Lấy hàng đầu tiên
                    maddh = row["NEWMADDH"].ToString();


                }

                SqlParameter[] parameters = new SqlParameter[]
                    {
                    new SqlParameter("@NgayLap", today.ToString()),
                    new SqlParameter("@MaNV", this.Manv),
                    new SqlParameter("@MaNCC", mancc),
                    new SqlParameter("@MaKho", makho),
                    new SqlParameter("@SoLuong", soluong),
                    new SqlParameter("@DonGia", dongia),
                    new SqlParameter("@MaHH", mahh),

                    };
                int result = dataHelper.ExecuteStoredProcedureNonQuery("SP_ADDORDER", parameters);

                if (result > 0)
                {
                    MessageBox.Show("Thêm dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    OnRecordAdded();
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Thêm dữ liệu thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void OnRecordAdded()
        {
            var handler = RecordOrderAdded;
            if (RecordOrderAdded != null)
            {

                RecordOrderAdded.Invoke(this, new CRUD.AddORDERRecordEventArgs(maddh, tenhh ,today, this.Manv ,hovaten, tenkho, tenncc,
                                                                            soluong,dongia));
            }
        }
    }
}
