using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.CRUD;

namespace WindowsFormsApp1
{
    public partial class FormAddStaff : Form
    {
        private DataHelper dataHelper;
        private String connection;
        public event EventHandler<AddSTAFFRecordEventArgs> RecordAddedStaff;
        String ho, ten, phai, ngaysinhtr, diachi, sdt, manv;
        String birthday;
        private void dtp_ngaysinh_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tb_sdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Chặn ký tự không hợp lệ
            }
        }

        DateTime ngaySinh;
        private void tb_ngaysinh_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_ho_TextChanged(object sender, EventArgs e)
        {

        }

        public FormAddStaff(String connection)
        {
            InitializeComponent();
            this.connection = connection;
        }

        private void btn_addstaff_Click(object sender, EventArgs e)
        {
            dtp_ngaysinh.Format = DateTimePickerFormat.Custom;
            dtp_ngaysinh.CustomFormat = "dd/MM/yyyy"; // Định dạng ngày giờ
            ho = tb_ho.Text;
            ten = tb_ten.Text;
            sdt = tb_sdt.Text;
          
            DateTime selectedNgaySinh = dtp_ngaysinh.Value;
            diachi = tb_diachi.Text;
            phai = tb_phai.Text;
            if (string.IsNullOrEmpty(ho) ||
                string.IsNullOrEmpty(ten) ||
                string.IsNullOrEmpty(sdt) ||
                
                string.IsNullOrEmpty(diachi) ||
                string.IsNullOrEmpty(phai))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                return;
            }
            else
            {
                // Xử lý logic khi tất cả các trường đều hợp lệ
                MessageBox.Show("Dữ liệu hợp lệ!");
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(sdt, @"^\d+$"))
            {
                MessageBox.Show("Số điện thoại chỉ được chứa số.", "Lỗi");
                return;
            }
            
            //String strDateFormat = "yyyy-MM-dd";//change accordingly if format is something different
            //DateTime ns= DateTime.ParseExact(ngaysinhtr, strDateFormat, CultureInfo.InvariantCulture);

            DataHelper dh = new DataHelper(connection);
            DataTable res = dh.ExecuteStoredProcedure("SP_GETNEWIDSTAFF");
            if (res.Rows.Count > 0)
            {
                DataRow row = res.Rows[0]; // Lấy hàng đầu tiên
                manv = row["NEWMANV"].ToString();


            }


            ngaysinhtr = selectedNgaySinh.ToString("yyyy-MM-dd");
            birthday = selectedNgaySinh.ToString("dd-MM-yyyy");
            SqlParameter[] parameters = new SqlParameter[]
               {
                   new SqlParameter("@HO", ho),
                   new SqlParameter("@TEN", ten),
                   new SqlParameter("@PHAI", phai),
                   new SqlParameter("@SODIENTHOAI", sdt),
                   new SqlParameter("@DIACHI", diachi),
                   new SqlParameter("@NGAYSINH", ngaysinhtr ) 
            };
            
            
            
            dataHelper = new DataHelper(connection);
            int result = dataHelper.ExecuteStoredProcedureNonQuery("SP_ADDSTAFF", parameters);

            if (result > 0)
            {
                MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                OnRecordAdded();
                this.Close();

            }
            else
            {
                MessageBox.Show("Thêm sản phẩm thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            

        }
        private void OnRecordAdded()
        {
            var handler = RecordAddedStaff;
            if (RecordAddedStaff != null)
            {

                RecordAddedStaff.Invoke(this, new AddSTAFFRecordEventArgs(manv,ho, ten, sdt, birthday, diachi, phai));
            }
        }

    }
}
