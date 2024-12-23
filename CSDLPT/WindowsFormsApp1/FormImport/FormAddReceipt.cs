using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.CRUD;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace WindowsFormsApp1.FormImport
{
    public partial class FormAddReceipt : Form
    {
        private DataHelper dataHelper;
        private String connection;
        DataTable result;
        String maddh, today, hoten, tenkho, tenncc, hovaten, mahh, tenhh, sopn,ngaylap;
        int soluong;
        float dongia;
        String Manv;
        public event EventHandler<AddRECEIPTRecordEventArgs> RecordReceiptAdded;
        private int firstsoluong;
        String macn;
        private void tb_sanpham_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
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

        private void tb_soluong_TextChanged(object sender, EventArgs e)
        {

        }

        private float firstdongia;


        DataTable data;
        public FormAddReceipt(String connection, String manv, String hoten, String macn)
        {
            InitializeComponent();
            this.connection = connection;
            this.hovaten = hoten;
            this.Manv = manv;
            this.macn = macn;
            tb_manv.Text = Manv;
            cbx_TenKho_Load();
            tb_sanpham.Enabled = false;
            cbx_maddh_Load();
        }

        private void cbx_maddh_Load()
        {
            dataHelper = new DataHelper(connection);
            try
            {
                // Gọi stored procedure bằng DataHelper
                data = dataHelper.ExecuteStoredProcedure("KiemTraDonDatHang");

                // Kiểm tra dữ liệu và gắn vào ComboBox
                if (data != null && data.Rows.Count > 0)
                {
                    cbx_maddh.DataSource = data;
                    cbx_maddh.DisplayMember = "MaDDh"; // Hiển thị tên loại hàng
                    cbx_maddh.ValueMember = "MaDDH"; // Giá trị tương ứng là mã loại hàng
                    DataRow firstRow = data.Rows[0];
                    tb_soluong.Text = firstRow["soluongcannhap"].ToString();
                    tb_dongia.Text = float.Parse(firstRow["DonGia"].ToString()).ToString("N0");
                    tb_sanpham.Text = firstRow["TenHH"].ToString();
                    mahh = firstRow["MaHH"].ToString();
                    firstsoluong = int.Parse(firstRow["soluongcannhap"].ToString());
                    firstdongia = float.Parse(firstRow["DonGia"].ToString());
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
        private void cbx_TenKho_Load()
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

       

        private void FormAddReceipt_Load(object sender, EventArgs e)
        {
            //OnRecordAdded();
        }
        
        private void cbx_maddh_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = cbx_maddh.SelectedValue?.ToString();
            string displayText = cbx_maddh.Text;

            foreach (DataRow row in data.Rows)
            {
                
                if (selectedValue.Trim() == row["MaDDH"].ToString().Trim())
                {
                    tb_soluong.Text = (row["soluongcannhap"].ToString());
                    tb_dongia.Text = row["DonGia"].ToString();
                    tb_sanpham.Text = row["TenHH"].ToString();
                    mahh = row["MaHH"].ToString();
                    firstsoluong = int.Parse(row["soluongcannhap"].ToString());
                    firstdongia = float.Parse(row["DonGia"].ToString());
                }
                 
                
            }
            
        }

        private void btn_addreceipt_Click(object sender, EventArgs e)
        {
            try
            {
                
                soluong = int.Parse(tb_soluong.Text);
                if (soluong > firstsoluong)
                {
                    MessageBox.Show("Số lượng không hợp lệ. Vui lòng nhập nhỏ hơn " + firstsoluong.ToString());
                    return;
                }
                dongia = float.Parse(tb_dongia.Text);
                if (dongia > firstdongia)
                {
                    MessageBox.Show("Số lượng không hợp lệ. Vui lòng nhập nhỏ hơn " + firstdongia.ToString());
                    return;
                }
                DataRowView selectedRow1 = cbx_TenKho.SelectedItem as DataRowView;
                String makho = cbx_TenKho.SelectedValue.ToString();
                DateTime now = DateTime.Now;
                today = now.ToString("yyyy-MM-dd");
                ngaylap = now.ToString("dd-MM-yyyy");
                maddh = cbx_maddh.SelectedValue.ToString();

                tenkho = selectedRow1["TenKho"].ToString();
                tenhh = tb_sanpham.Text;
                DataTable res = dataHelper.ExecuteStoredProcedure("SP_GETNEWIDIMOPRT");
                if (res.Rows.Count > 0)
                {
                    DataRow row = res.Rows[0]; // Lấy hàng đầu tiên
                    sopn = row["NEWMAPN"].ToString();


                }

                SqlParameter[] parameters = new SqlParameter[]
                        {
                    new SqlParameter("@NgayLap", today.ToString()),
                    new SqlParameter("@MaNV", this.Manv),
                    new SqlParameter("@MaDDH", maddh),
                    new SqlParameter("@MaKho", makho),
                    new SqlParameter("@MaHH", mahh),
                    new SqlParameter("@SoLuong", soluong),
                    new SqlParameter("@DonGia", dongia),
                        };
                int result = dataHelper.ExecuteStoredProcedureNonQuery("SP_ADDIMPORT", parameters);

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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void OnRecordAdded()
        {
            var handler = RecordReceiptAdded;
            if (RecordReceiptAdded != null)
            {
                RecordReceiptAdded.Invoke(this, new AddRECEIPTRecordEventArgs(sopn, mahh ,tenhh, ngaylap, Manv, hovaten, tenkho,
                                                                            maddh, soluong, soluong ,dongia));
            }
        }
    }
}
