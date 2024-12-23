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


namespace WindowsFormsApp1
{
    public partial class FormAddProduct : Form
    {
        private DataHelper dataHelper;
        private String connection;
        public string nameproduct ;
        public string dvt ;
        public string productType ;
        string productType2;
        string productType3;
        public string maHH;
        FormProduct formproduct;
        public event EventHandler<AddRecordEventArgs> RecordAdded;
        public FormAddProduct(String connection)
        {
            InitializeComponent();
            this.connection = connection;
            
            cbx_LoaiHang_Load();
        }

        private void tb_manv_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbx_LoaiHang_Load()
        {
            dataHelper = new DataHelper(connection);
            try
            {
                // Gọi stored procedure bằng DataHelper
                DataTable data = dataHelper.ExecuteStoredProcedure("SP_GETPRODUCTTYPE");
               Console.Write($"Số lượng hàng lấy được: {data.Rows.Count}");
                // Kiểm tra dữ liệu và gắn vào ComboBox
                if (data != null && data.Rows.Count > 0)
                {
                    cbx_producttype.DataSource = data;
                    cbx_producttype.DisplayMember = "TenLH"; // Hiển thị tên loại hàng
                    cbx_producttype.ValueMember = "MaLH"; // Giá trị tương ứng là mã loại hàng
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

        private void btn_addproduct_Click(object sender, EventArgs e)
        {
            try
            {
                nameproduct = tb_nameproduct.Text.Trim();
                dvt = tb_dvt.Text.Trim();
                if (string.IsNullOrEmpty(nameproduct) || string.IsNullOrEmpty(dvt))
                {
                    MessageBox.Show($"Vui Lòng Nhập Đầy Đủ Thông Tin");
                    return;
                }
                // Lấy thông tin từ form
                
                productType = cbx_producttype.SelectedValue.ToString();
                DataRowView selectedRow = cbx_producttype.SelectedItem as DataRowView;
                productType2 = selectedRow["TenLH"].ToString(); 
                productType3 = cbx_producttype.Text.Trim();


                SqlParameter[] parameters1 = new SqlParameter[]
                {
                    new SqlParameter("@MaLH", productType),
                };

                DataTable res = dataHelper.ExecuteStoredProcedure("SP_GET_NEWIDPRODUCT", parameters1);
                
                if (res.Rows.Count > 0)
                {
                    DataRow row = res.Rows[0]; // Lấy hàng đầu tiên
                    maHH = row["NewMaHH"].ToString();
                    

                }

                // Tạo mảng tham số
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@TenHH", nameproduct),
                    new SqlParameter("@DonViTinh", dvt),
                    new SqlParameter("@MaLH", productType),
                    
                };
                

                // Gọi stored procedure thêm sản phẩm
                int result = dataHelper.ExecuteStoredProcedureNonQuery("SP_ADDPRODUCT", parameters);

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
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void OnRecordAdded()
        {
            var handler = RecordAdded;
            if (RecordAdded != null)
            {

                RecordAdded.Invoke(this, new AddRecordEventArgs(maHH, nameproduct, dvt, productType2.ToString()));
            }   
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cbx_producttype_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
