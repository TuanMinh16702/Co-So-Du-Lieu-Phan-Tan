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
using WindowsFormsApp1.Object;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1.FormBill
{
    public partial class FormAddInvoice : Form
    {
        private DataHelper dataHelper;
        private String connection;
        DataTable result;
        String manv, hoten,makho,mahh,ngaylap,tenkho,tenhh,macn,sohd,makh;
        String sdt,tenkh,diachikh;
        string selectedSP;
        int firstsoluong;
        float firstdongia;
        int soluong;
        float dongia;
        DataTable invoiceTable = new DataTable();
        int soluongtam;
        public event EventHandler<AddBillRecordEventArgs> RecordBillAdded;
        float total;
        public FormAddInvoice(String connection, String manv, String hoten,String macn)
        {
            InitializeComponent();
            this.connection = connection;
            this.manv = manv;
            this.hoten = hoten;
            //tb_manv.Text = manv;
            cbx_sanpham_Load();
            newidbill();
            tb_sohd.Text = sohd;
            dgv_danhsach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            invoiceTable.Columns.Add("Mã Hóa Đơn", typeof(string));
            invoiceTable.Columns.Add("Ngày Lập", typeof(string));
            invoiceTable.Columns.Add("Mã Kho", typeof(string));
            invoiceTable.Columns.Add("Tên Kho", typeof(string));
            invoiceTable.Columns.Add("Mã Khách Hàng", typeof(string));
            invoiceTable.Columns.Add("Mã Hàng Hóa", typeof(string));
            invoiceTable.Columns.Add("Tên Hàng Hóa", typeof(string));
            invoiceTable.Columns.Add("Số Lượng", typeof(int));
            invoiceTable.Columns.Add("Đơn Giá", typeof(float));
            dgv_danhsach.DataSource = invoiceTable;
            btn_addkh.Enabled = false;
            tb_sohd.Enabled = false;
            tb_diachi.Enabled = false;
            tb_tenkhachhang.Enabled = false;
            //cbx_TenKho.Enabled = false;
        }

        

        private void FormAddInvoice_Load(object sender, EventArgs e)
        {

        }

       

        private void LoadProductDetails(string mahh, String makho)
        {
            if (string.IsNullOrEmpty(mahh)) return;
            // Tạo tham số cho truy vấn
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaHH", mahh),
                new SqlParameter("@MaKho", makho)
            };

            // Gọi thủ tục để lấy thông tin sản phẩm
            DataHelper dataHelper = new DataHelper(connection);
            DataTable data = dataHelper.ExecuteStoredProcedure("SP_GETPRODUCTINWAREHOUSE2", parameters);

            if (data.Rows.Count > 0)
            {
                // Lấy thông tin sản phẩm từ hàng đầu tiên
                DataRow row = data.Rows[0];
                tb_soluong.Text = row["SoLuong"].ToString();
                tb_dongia.Text = row["DonGia"].ToString();
                firstsoluong = int.Parse(row["SoLuong"].ToString());
                firstdongia = float.Parse(row["DonGia"].ToString());
            }
            else
            {
                // Xóa dữ liệu nếu không tìm thấy sản phẩm
                tb_soluong.Text = "";
                tb_dongia.Text = "";
                //MessageBox.Show("Không tìm thấy thông tin sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        

        private void cbx_TenKho_Load(String mahh)
        {
            if (string.IsNullOrEmpty(mahh)) return;
            dataHelper = new DataHelper(connection);
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaHH", mahh ),
                };
                // Gọi stored procedure bằng DataHelper
                DataTable data = dataHelper.ExecuteStoredProcedure("SP_GETPRODUCTINWAREHOUSE", parameters);

                // Kiểm tra dữ liệu và gắn vào ComboBox
                if (data != null && data.Rows.Count > 0)
                {
                    DataRow roww = data.Rows[0];
                    cbx_TenKho.DataSource = data;
                    cbx_TenKho.DisplayMember = "TenKho"; // Hiển thị tên loại hàng
                    cbx_TenKho.ValueMember = "MaKho"; // Giá trị tương ứng là mã loại hàng
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu để hiển thị thông tin kho!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tb_soluong.Text = "";
                    tb_dongia.Text = "";
                    //cbx_TenKho.DisplayMember = "";
                    cbx_TenKho.DataSource = null;
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void cbx_TenKho_SelectedIndexChanged(object sender, EventArgs e)
        {
            try

            {

                if (cbx_TenKho.SelectedIndex >= 0 && cbx_sanpham.SelectedIndex >= 0)
                {
                    String selectedTK = cbx_TenKho.SelectedValue.ToString();
                    // Lấy giá trị Mã sản phẩm từ ComboBox sản phẩm
                    String selectedSP = cbx_sanpham.SelectedValue.ToString();

                    // Gọi phương thức để tải thông tin chi tiết sản phẩm
                    //LoadProductDetails(selectedSP, selectedTK);
                    if (!string.IsNullOrEmpty(selectedTK) && !string.IsNullOrEmpty(selectedSP))
                    {
                        // Giả sử bạn có phương thức lấy thông tin sản phẩm từ kho
                        var productInfo = GetProductInfoFromWarehouse(selectedTK, selectedSP);

                        if (productInfo != null)
                        {
                            tb_dongia.Text = productInfo.dongia.ToString("N0"); // Đơn giá
                            tb_soluong.Text = productInfo.soluong.ToString(); // Số lượng còn lại
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_danhsach_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            int rowIndex = e.Row.Index;

            // Xóa dòng khỏi DataTable
            if (rowIndex >= 0 && rowIndex < invoiceTable.Rows.Count)
            {
                invoiceTable.Rows[rowIndex].Delete();
                invoiceTable.AcceptChanges(); // Cập nhật thay đổi trong DataTable
            }
        }

        

        private void newidbill()
        {
            try
            {
                dataHelper = new DataHelper(connection);
                DataTable res = dataHelper.ExecuteStoredProcedure("SP_GETNEWIDBILL");
                if (res.Rows.Count > 0)
                {
                    DataRow row = res.Rows[0]; // Lấy hàng đầu tiên
                    sohd = row["NEWMAHD"].ToString();


                }

            }
            catch (Exception ex) {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tb_sdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Chặn ký tự không hợp lệ
            }
        }

        private void btn_check_Click(object sender, EventArgs e)
        {
            sdt = tb_sdt.Text;
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@SDT", sdt ),
            };
            dataHelper = new DataHelper(connection);
            DataTable data = dataHelper.ExecuteStoredProcedure("SP_CHECKCUSTOMER", parameters);
            if (data.Rows.Count > 0)
            {
                MessageBox.Show("Khách hàng đã tồn tại trong hệ thống. Mời nhập thông tin khác");
                DataRow roww = data.Rows[0];
                tb_tenkhachhang.Text = roww["TenKH"].ToString();
                tb_diachi.Text = roww["DiaChi"].ToString();
                tb_sdt.Text = roww["SoDienThoai"].ToString();
                tenkh = roww["TenKH"].ToString();
                diachikh = roww["DiaChi"].ToString();
                sdt = roww["SoDienThoai"].ToString();
                makh = roww["MaKH"].ToString();
                btn_addkh.Enabled = false;
            }
            else
            {
                MessageBox.Show("Khách hàng chưa tồn tại trong hệ thống. Mời nhập thông tin khách hàng");
                tb_tenkhachhang.Enabled = true;
                tb_diachi.Enabled = true;
                tb_tenkhachhang.Text = "";
                tb_diachi.Text = "";
               
                btn_addkh.Enabled = true;
            }
        }

        private void btn_addkh_Click(object sender, EventArgs e)
        {
            tenkh = tb_tenkhachhang.Text;
            diachikh = tb_diachi.Text;
            sdt = tb_sdt.Text;
            if (string.IsNullOrEmpty(tenkh) ||
                   string.IsNullOrEmpty(diachikh) ||
                   string.IsNullOrEmpty(sdt))
            {
                MessageBox.Show("Vui lòng không được để trống thông tin");
                return;
            }

            DataTable res = dataHelper.ExecuteStoredProcedure("SP_GETNEWIDCUSTOMER");

            if (res.Rows.Count > 0)
            {
                DataRow row = res.Rows[0]; // Lấy hàng đầu tiên
                makh = row["NEWMAPN"].ToString();


            }

            tenkh = tb_tenkhachhang.Text;
            diachikh = tb_diachi.Text;
            sdt = tb_sdt.Text;
            SqlParameter[] parameters = new SqlParameter[]
                   {
                    new SqlParameter("@TenKh", tenkh),
                    new SqlParameter("@SoDienThoai",  sdt),
                    new SqlParameter("@DiaChi",diachikh),
                    

                   };
            int result = dataHelper.ExecuteStoredProcedureNonQuery("SP_GETNEWCUSTOMER", parameters);

            if (result > 0)
            {
                MessageBox.Show("Thêm dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Thêm dữ liệu thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tb_sdt_TextChanged(object sender, EventArgs e)
        {
            

        
        }
        private void btn_them_Click(object sender, EventArgs e)
        {
            
            try
            {
                int soLuongMua = int.Parse(nud_soluongmua.Value.ToString());

                soluong = int.Parse(tb_soluong.Text);
                if (soLuongMua > soluong)
                {
                    MessageBox.Show("Số lượng mua vượt quá số lượng trong kho!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                dongia = float.Parse(tb_dongia.Text);
                if (dongia > firstdongia)
                {
                    MessageBox.Show("Số lượng không hợp lệ. Vui lòng nhập nhỏ hơn " + firstdongia.ToString());
                    return;
                }
                DataRowView selectedRow1 = cbx_TenKho.SelectedItem as DataRowView;
                DataRowView selectedRow3 = cbx_sanpham.SelectedItem as DataRowView;
                makho = cbx_TenKho.SelectedValue.ToString();
                DateTime now = DateTime.Now;
                ngaylap = now.ToString("yyyy-MM-dd");
                mahh = cbx_sanpham.SelectedValue.ToString();
                
                tenkho = selectedRow1["TenKho"].ToString();
                tenhh = selectedRow3["TenHH"].ToString();
                if (string.IsNullOrEmpty(tenkh) ||
                   string.IsNullOrEmpty(diachikh) ||
                   string.IsNullOrEmpty(sdt) ||
                   string.IsNullOrEmpty(tenhh) ||
                   string.IsNullOrEmpty(tenkho) ||
                   soLuongMua <= 0 ||
                   dongia <= 0)
                {
                    MessageBox.Show("Cần nhập thông tin chính xác");
                    return;
                }
                bool isExist = false;
                foreach (DataRow row in invoiceTable.Rows)
                {
                    if (row["Mã Hóa Đơn"].ToString() == sohd && row["Mã Hàng Hóa"].ToString() == mahh)
                    {
                        // Nếu đã tồn tại, tăng số lượng
                        row["Số Lượng"] = int.Parse(row["Số Lượng"].ToString()) + soLuongMua;
                        isExist = true;
                        break;
                    }
                }

                if (!isExist)
                {
                    // Nếu không tồn tại, thêm dòng mới
                    DataRow newRow = invoiceTable.NewRow();

                    newRow["Mã Hóa Đơn"] = sohd;
                    newRow["Mã Kho"] = makho;
                    newRow["Tên Kho"] = tenkho;
                    newRow["Mã Hàng Hóa"] = mahh;
                    newRow["Tên Hàng Hóa"] = tenhh;
                    newRow["Mã Khách Hàng"] = makh;
                    newRow["Ngày Lập"] = ngaylap;
                    newRow["Số Lượng"] = soLuongMua;
                    newRow["Đơn Giá"] = dongia.ToString("N0");
                    dgv_danhsach.Columns["Đơn Giá"].DefaultCellStyle.Format = "N0";
                    invoiceTable.Rows.Add(newRow);
                }

                // Hiển thị lại DataGridView

                tb_soluong.Text = (soluong - soLuongMua).ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi");
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
                    MessageBox.Show("Không có dữ liệu để hiển thị thông tin sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void cbx_sanpham_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
               
                // Kiểm tra xem có chọn sản phẩm không
                if (cbx_sanpham.SelectedIndex >= 0)
                {
                   
                    selectedSP = cbx_sanpham.SelectedValue.ToString();
                    //cbx_TenKho.Enabled = true;  // Bật ComboBox kho sau khi chọn sản phẩm
                    cbx_TenKho_Load(selectedSP);  // Tải dữ liệu kho dựa trên sản phẩm đã chọn
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cbx_TenKho_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }
        private ProductInfo GetProductInfoFromWarehouse(string makho, string mahh)
        {
            soluongtam = 0;
            // Tạo tham số cho truy vấn
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaHH", mahh),
                new SqlParameter("@MaKho", makho)
            };

            // Gọi thủ tục để lấy thông tin sản phẩm
            DataHelper dataHelper = new DataHelper(connection);
            DataTable data = dataHelper.ExecuteStoredProcedure("SP_GETPRODUCTINWAREHOUSE2", parameters);

            if (data.Rows.Count > 0)
            {
                // Lấy thông tin sản phẩm từ hàng đầu tiên
                DataRow row = data.Rows[0];
                if (dgv_danhsach.Rows.Count == 0 || (dgv_danhsach.Rows.Count == 1 && dgv_danhsach.Rows[0].IsNewRow))
                {
                    soluongtam = 0;
                }
                else
                {
                    foreach (DataGridViewRow roww in dgv_danhsach.Rows)
                    {
                        var cellKhoValue = roww.Cells["Mã Kho"]?.Value;
                        var cellSPValue = roww.Cells["Mã Hàng Hóa"]?.Value;
                        if(cellKhoValue != null &&
                            cellSPValue != null &&
                            cellKhoValue.ToString() == makho &&
                            cellSPValue.ToString() == mahh)
                        {
                            soluongtam += int.Parse(roww.Cells["Số Lượng"].Value.ToString());
                        }
                        
                    }
                }
                tb_soluong.Text = (int.Parse(row["SoLuong"].ToString()) - soluongtam).ToString();
                tb_dongia.Text = float.Parse(row["DonGia"].ToString()).ToString("N0");
                firstsoluong = int.Parse(row["SoLuong"].ToString()) - soluongtam;
                firstdongia = float.Parse(row["DonGia"].ToString());
            }
            else
            {
                // Xóa dữ liệu nếu không tìm thấy sản phẩm
                tb_soluong.Text = "";
                tb_dongia.Text = "";
                //MessageBox.Show("Không tìm thấy thông tin sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // Truy vấn từ cơ sở dữ liệu hoặc danh sách
            return new ProductInfo
            {
                dongia = float.Parse(firstdongia.ToString("N0")),
                soluong = firstsoluong
            };
        }
        private void dgv_danhsach_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Delete)
            {
                // Kiểm tra xem có dòng nào được chọn hay không
                if (dgv_danhsach.SelectedRows.Count > 0)
                {
                    // Lấy dòng đã chọn
                    DataGridViewRow row = dgv_danhsach.SelectedRows[0];

                    // Lấy giá trị của MaKho (Mã kho - khóa chính)
                    String makho = row.Cells["Mã Kho"].Value.ToString();
                    String mahh = row.Cells["Mã hàng Hóa"].Value.ToString();
                    // Xác nhận người dùng có muốn xóa không
                    DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (dialogResult == DialogResult.Yes)
                    {
                        
                        dgv_danhsach.Rows.Remove(row);
                        invoiceTable.AcceptChanges();
                        //invoiceTable
                        GetProductInfoFromWarehouse(makho, mahh);
                        
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        
        private void btn_addhd_Click(object sender, EventArgs e)
        {
            int soLuongMua = int.Parse(nud_soluongmua.Value.ToString());
            if (string.IsNullOrEmpty(tenkh) ||
                   string.IsNullOrEmpty(diachikh) ||
                   string.IsNullOrEmpty(sdt) ||
                   string.IsNullOrEmpty(tenhh) ||
                   string.IsNullOrEmpty(tenkho) ||
                   soLuongMua <= 0 ||
                   dongia <= 0)
            {
                MessageBox.Show("Cần nhập thông tin chính xác");
                return;
            }
            soluong = int.Parse(tb_soluong.Text);
            dongia = float.Parse(tb_dongia.Text);
            DataRowView selectedRow1 = cbx_TenKho.SelectedItem as DataRowView;
            DataRowView selectedRow3 = cbx_sanpham.SelectedItem as DataRowView;
            makho = cbx_TenKho.SelectedValue.ToString();
            mahh = cbx_sanpham.SelectedValue.ToString();
            DateTime now = DateTime.Now;
            ngaylap = now.ToString("yyyy-MM-dd");
            

            tenkho = selectedRow1["TenKho"].ToString();
            tenhh = selectedRow3["TenHH"].ToString();

            total = 0 ;
            foreach (DataRow roww in invoiceTable.Rows)
            {
                float sl = float.Parse(roww["Số Lượng"].ToString());
                float dg = float.Parse(roww["Đơn Giá"].ToString());
                float s = sl * dg;
                //total = float.Parse(roww["Số Lượng"].ToString()) * float.Parse(roww["Đơn Giá"].ToString());
                total += s;
            }

            SqlParameter[] parameters = new SqlParameter[]
                   {
                    new SqlParameter("@SoHD", sohd),
                    new SqlParameter("@NgayLap", ngaylap),
                    new SqlParameter("@MaNV",manv),
                    new SqlParameter("@MaKho", makho),
                    new SqlParameter("@MaKh", makh),
                    

                   };
            int result = dataHelper.ExecuteStoredProcedureNonQuery("SP_ADDBILL", parameters);

            if (result > 0)
            {
                MessageBox.Show("Thêm hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                OnRecordAdded();
                this.Close();

            }
            else
            {
                MessageBox.Show("Thêm hóa đơn thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

            foreach (DataRow roww in invoiceTable.Rows)
            {
                int a = int.Parse(roww["Số Lượng"].ToString());
                SqlParameter[] parameter = new SqlParameter[]
                {
                    new SqlParameter("@SoHD", sohd),
                    new SqlParameter("@MaHH", roww["Mã Hàng Hóa"].ToString()),
                    new SqlParameter("@MaKho", roww["Mã Kho"].ToString()),
                    new SqlParameter("@SoLuong",int.Parse(roww["Số Lượng"].ToString())),
                    new SqlParameter("@DonGia", float.Parse(roww["Đơn Giá"].ToString())),
                };

                int res = dataHelper.ExecuteStoredProcedureNonQuery("SP_ADDDETAILBILL", parameter);

                if (res > 0)
                {
                    MessageBox.Show("Thêm chi tiết hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //OnRecordAdded();
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Thêm chi tiết thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }
        private void OnRecordAdded()
        {
            var handler = RecordBillAdded;
            if (RecordBillAdded != null)
            {
                RecordBillAdded.Invoke(this, new AddBillRecordEventArgs(sohd, ngaylap, hoten, tenkho,
                                                                            tenkh, total));
            }
        }
    }
}
