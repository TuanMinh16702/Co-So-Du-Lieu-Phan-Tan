using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.CRUD;
using WindowsFormsApp1.Object;

namespace WindowsFormsApp1
{
    public partial class FormEditStaff : Form
    {
        FormEditStaff formeditstaff;
        StaffObject staff;
        private DataHelper dataHelper;
        private String connection;
        private DataGridViewRow selectedRow;
        public delegate void DataEditedHandler(DataGridViewRow editedRow);
        public event DataEditedHandler DataEdited;
        string manv,ngaysinh, ho, ten, phai, sodienthoai,diachi;
        public FormEditStaff(String connection, DataGridViewRow row)
        {
            InitializeComponent();
            this.connection = connection;
            this.selectedRow = row;
            manv = row.Cells["manv"].Value.ToString();
            tb_ho.Text = row.Cells["ho"].Value.ToString();
            tb_ten.Text = row.Cells["ten"].Value.ToString();
            tb_phai.Text = row.Cells["phai"].Value.ToString();
            //tb_ngaysinh.Text = staff.ngaysinh;
            tb_sdt.Text = row.Cells["sodienthoai"].Value.ToString();
            tb_diachi.Text = row.Cells["diachi"].Value.ToString();
            dtp_ngaylap_load();
        }

        private void dtp_ngaylap_load()
        {
            string format = "dd-MM-yyyy";
            try
            {
                DateTime parsedDate = DateTime.ParseExact(selectedRow.Cells["NgaySinh"].Value.ToString(), format, null); // Chuyển đổi theo định dạng
                dtp_ngaysinh.Value = parsedDate;
                Console.WriteLine($"Kết quả: {parsedDate.ToString("yyyy-MM-dd")}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Định dạng ngày không hợp lệ: {ex.Message}");
            }

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            
            
            ho = tb_ho.Text;
            ten = tb_ten.Text;
            phai = tb_phai.Text;
            sodienthoai = tb_sdt.Text;
            string ngaySinhStr = selectedRow.Cells["NgaySinh"].Value.ToString();

            DateTime selectedNgaySinh = dtp_ngaysinh.Value;
            ngaysinh = selectedNgaySinh.ToString("yyyy-MM-dd");
            diachi = tb_diachi.Text;
            
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                            new SqlParameter("@MaNV", manv),
                            new SqlParameter("@Ho", ho),
                            new SqlParameter("@Ten", ten),
                            new SqlParameter("@Phai", phai),
                            new SqlParameter("@SoDienThoai", sodienthoai),
                            new SqlParameter("@DiaChi", diachi),
                            new SqlParameter("@NgaySinh",ngaysinh),
                };

                try
                {
                    DataHelper dataHelper = new DataHelper(connection);
                    int res = dataHelper.ExecuteStoredProcedureNonQuery("SP_UPDATESTAFF", parameters);
                    if (res > 0)
                    {
                        MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo");
                        selectedRow.Cells["Ho"].Value = ho;
                        selectedRow.Cells["NgaySinh"].Value = selectedNgaySinh.ToString("dd-MM-yyyy");
                        selectedRow.Cells["Ten"].Value = ten;
                        selectedRow.Cells["SoDienThoai"].Value = sodienthoai;
                        selectedRow.Cells["Phai"].Value = phai;
                        selectedRow.Cells["DiaChi"].Value = diachi;
                        

                        DataEdited?.Invoke(selectedRow);
                        this.Close();
                        //RefreshDataGridView(); // Cập nhật lại DataGridView nếu cần
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật dữ liệu thất bại!", "Thông báo");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi cập nhật dữ liệu: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật dữ liệu: {ex.Message}");
                
            }

        }

        private void tb_manv_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
