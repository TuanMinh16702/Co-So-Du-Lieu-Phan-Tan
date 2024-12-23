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

namespace WindowsFormsApp1.FormImport
{
    public partial class FormEditReceipt : Form
    {
        public delegate void DataEditedHandler(DataGridViewRow editedRow);
        public event DataEditedHandler DataEdited;
        private DataHelper dataHelper;
        private String connection;
        DataTable result;
        String maddh, today, hoten, tenkho, tenncc, hovaten, mahh, tenhh, sopn, ngaylap,macn;
        int soluong;
        float dongia;
        String Manv;
        private int firstsoluong;
        private float firstdongia;
        DataTable data;
        private DataGridViewRow selectedRow;
        String maddhtemp, soluongtemp;
        int soluongton;

        public FormEditReceipt(String connection, DataGridViewRow row,String hoten ,String manv ,String macn)
        {
            InitializeComponent();
            this.connection = connection;
            this.Manv = manv;
            this.hoten = hoten;
            this.selectedRow = row;
            this.macn = macn;
            dtp_ngaylap_load();
            cbx_tenkho_load();
            sopn = row.Cells["SoPN"].Value.ToString();
            tb_soluong.Text = row.Cells["SoLuong"].Value.ToString();
            tb_dongia.Text = float.Parse(row.Cells["DonGia"].Value.ToString()).ToString("N0");
            tb_sanpham.Text = row.Cells["TenHH"].Value.ToString();
            tb_maddh.Text = row.Cells["MaDDH"].Value.ToString();
            mahh = row.Cells["MaHH"].Value.ToString();
            soluongton = int.Parse(row.Cells["SoLuongTon"].Value.ToString());
        }

        private void dtp_ngaylap_load()
        {
            string format = "dd-MM-yyyy";
            try
            {
                DateTime parsedDate = DateTime.ParseExact(selectedRow.Cells["NgayLap"].Value.ToString(), format, null); // Chuyển đổi theo định dạng
                dtp_ngaylap.Value = parsedDate;
                Console.WriteLine($"Kết quả: {parsedDate.ToString("yyyy-MM-dd")}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Định dạng ngày không hợp lệ: {ex.Message}");
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

        private int soluong_edit(String maddh, int soluong)
        {
            dataHelper = new DataHelper(connection);
            try
            {
                // Gọi stored procedure bằng DataHelper
                DataTable data = dataHelper.ExecuteStoredProcedure("KiemTraToanBoDonDatHang");

                // Kiểm tra dữ liệu và gắn vào ComboBox
                if (data != null && data.Rows.Count > 0)
                {
                    foreach (DataRow row in data.Rows)
                    {
                        if (row["MaDDH"].ToString() == maddh)
                        {
                            if (int.Parse(row["soluongcannhap"].ToString()) == 0)
                            {
                                MessageBox.Show("Số Lượng đã đủ không được nhập thêm");
                                return 1;
                            }
                            if (soluong > int.Parse(row["soluongcannhap"].ToString()))
                            {
                                MessageBox.Show("Số lượng hiện tại là " + row["soluongcannhap"].ToString() + " .Vui lòng nhập nhỏ hơn hoặc bằng");
                                tb_soluong.Text = soluong.ToString();
                                return 1;
                            }
                            
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
            return 0;
        }
        
        private void btn_sua_Click(object sender, EventArgs e)
        {
            if (soluongton < soluong)
            {
                MessageBox.Show("Sản phâm đã bán. Không thể sửa");
                return;
            }
            soluong = int.Parse(tb_soluong.Text);
            dongia = float.Parse(tb_dongia.Text);

            DataRowView selectedRow1 = cbx_tenkho.SelectedItem as DataRowView;
            tenkho = selectedRow1["TenKho"].ToString();

            String makho = cbx_tenkho.SelectedValue.ToString();

            DateTime selectedNgaySinh = dtp_ngaylap.Value;
            ngaylap = selectedNgaySinh.ToString("yyyy-MM-dd");
            maddh = tb_maddh.Text;
            int check = soluong_edit(maddh, soluong);
            if(check == 1)
            {
                return;
            }
            if (soluongton > soluong)
            {
                soluongton = soluong;
            }
            SqlParameter[] parameters = new SqlParameter[]
                    {
                    new SqlParameter("@SoPN", sopn),
                    new SqlParameter("@NgayLap", ngaylap.ToString()),
                    new SqlParameter("@MaDDH", maddh),
                     new SqlParameter("@MaKho", makho),
                    new SqlParameter("@MaHH", mahh),
                    new SqlParameter("@SoLuong", soluong),
                    new SqlParameter("@DonGia", dongia),


                    };
            int result = dataHelper.ExecuteStoredProcedureNonQuery("SP_UPDATERECEIPT", parameters);

            if (result > 0)
            {
                MessageBox.Show("Sửa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                tenhh = tb_sanpham.Text;
                selectedRow.Cells["TenHH"].Value = tenhh;
                selectedRow.Cells["NgayLap"].Value = selectedNgaySinh.ToString("dd-MM-yyyy");
                selectedRow.Cells["TenKho"].Value = tenkho;
                selectedRow.Cells["MaDDH"].Value = maddh;
                selectedRow.Cells["SoLuong"].Value = soluong;
                selectedRow.Cells["SoluongTon"].Value = soluongton;
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

        
    }
}
