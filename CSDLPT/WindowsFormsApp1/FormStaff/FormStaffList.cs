using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.CRUD;
using WindowsFormsApp1.FormOrder;
using WindowsFormsApp1.Object;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using static WindowsFormsApp1.FormStaff.FormAddLogin;

namespace WindowsFormsApp1
{
    public partial class FormStaffList : Form
    {
        Info info = new Info();
        InfoObject io = new InfoObject();
        private DataHelper dataHelper;
        private String connection;
        FormEditStaff formeditstaff;
        StaffObject staff;
        String nhomquyen;
        String login;
        FormAddStaff formaddstaff;
        DataTable result;
        FormStaff.FormAddLogin formaddlogin;
        String manv;
        String macn;
        public FormStaffList(String connection, String login, String nhomquyen, String manv, String macn)
        {
            InitializeComponent();
            this.connection = connection;
            this.nhomquyen = nhomquyen;
            this.login = login;
            this.manv = manv;
            this.macn = macn;
            dataHelper = new DataHelper(connection);
            Disabl_addbutton();
            cbx_chuyenchinhanh_load();
            if (nhomquyen == "USER")
            {
                btn_ccn.Enabled = false;
                btn_addlogin.Enabled = false;
                btn_xoa.Enabled = false;
            }
            else
            {
                btn_ccn.Enabled = true;
                btn_addlogin.Enabled = true;
            }
            btn_lock();
        }
        private void btn_lock()
        {
            if (nhomquyen == "CONGTY")
            {
                btn_addstaff.Enabled = false;
                btn_editstaff.Enabled = false;
                btn_xoa.Enabled = false;
                //btn_ccn.Enabled=false;
                //btn_ext.Enabled = false;
                dgv_stafflist.ReadOnly = true;
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormStaffList_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;

            // Phóng to toàn màn hình
            this.WindowState = FormWindowState.Maximized;

            // Đưa form lên trên cùng (nếu cần che Taskbar)
            this.TopMost = true;

            try
            {


                dataHelper = new DataHelper(connection);

                // Gọi Stored Procedure
                result = dataHelper.ExecuteStoredProcedure("GET_STAFFLIST");
                // Hiển thị dữ liệu lên DataGridView
                if (result != null && result.Rows.Count > 0)
                {

                    dgv_stafflist.DataSource = result;
                    dgv_stafflist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    dgv_stafflist.Columns["MaNV"].HeaderText = "Mã Nhân Viên";
                    dgv_stafflist.Columns["Ho"].HeaderText = "Họ";
                    dgv_stafflist.Columns["Ten"].HeaderText = "Tên";
                    dgv_stafflist.Columns["SoDienThoai"].HeaderText = "Số Điện Thoại";
                    dgv_stafflist.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
                    dgv_stafflist.Columns["Phai"].HeaderText = "Giới Tính";
                    dgv_stafflist.Columns["DiaChi"].HeaderText = "Địa Chỉ";
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgv_stafflist.DataSource = null;
                }
                dgv_stafflist.Columns["MaNV"].ReadOnly = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        public List<StaffObject> ConvertDataTableToList(DataTable table)
        {
            List<StaffObject> staffList = new List<StaffObject>();

            foreach (DataRow row in table.Rows)
            {
                StaffObject staff = new StaffObject
                {
                    manv = row["MANV"].ToString(),
                    ho = row["Ho"].ToString(),
                    ten = row["Ten"].ToString(),
                    phai = row["PHAI"].ToString(),
                    sodienthoai = row["SODIENTHOAI"].ToString(),
                    ngaysinh = Convert.ToDateTime(row["NgaySinh"]).ToString("yyyy/MM/dd"),
                    diachi = row["DIACHI"].ToString(),
                };

                staffList.Add(staff);
            }

            return staffList;
        }



        private void btn_editstaff_Click(object sender, EventArgs e)
        {
            if (dgv_stafflist.SelectedRows.Count > 0)
            {
                var selectedRow = dgv_stafflist.SelectedRows[0];
                var ho = selectedRow.Cells["Ho"].Value.ToString();
                var ngaysinh = selectedRow.Cells["NgaySinh"].Value.ToString();
                var ten = selectedRow.Cells["Ten"].Value.ToString();
                var sodienthoai = selectedRow.Cells["SoDienThoai"].Value.ToString();
                var diachi = selectedRow.Cells["DiaChi"].Value.ToString();
                var phai = selectedRow.Cells["Phai"].Value.ToString(); ;
                string manv = selectedRow.Cells["MaNV"].Value.ToString();

                formeditstaff = new FormEditStaff(connection, selectedRow);
                formeditstaff.DataEdited += formeditorder_DataEdited;
                formeditstaff.Show();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên để chỉnh sửa");
            }

        }

        private void formeditorder_DataEdited(DataGridViewRow editedRow)
        {
            // Khi nhận dữ liệu đã chỉnh sửa từ Form B, cập nhật lại dòng trong DataGridView
            foreach (DataGridViewColumn column in dgv_stafflist.Columns)
            {
                // Cập nhật lại giá trị của các cột trong dòng tương ứng
                dgv_stafflist.SelectedRows[0].Cells[column.Name].Value = editedRow.Cells[column.Name].Value;
            }

            // Nếu cần, bạn có thể lưu dữ liệu này vào database hoặc làm gì đó với dữ liệu đã cập nhật
        }

        private void dgv_stafflist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void btn_addstaff_Click(object sender, EventArgs e)
        {
            if (formaddstaff == null)
            {
                formaddstaff = new FormAddStaff(this.connection);
                formaddstaff.RecordAddedStaff += formaddproduct_RecordAdded;
                formaddstaff.FormClosed += formaddproduct_FormClosed;
                formaddstaff.Show();
            }
            else
            {
                formaddstaff.Activate();
            }
        }
        private void formaddproduct_RecordAdded(object sender, AddSTAFFRecordEventArgs e)
        {
            // Access e.Quantity, e.Description and e.Price
            // and add new row in grid using these values.
            result.Rows.Add(e.Manv, e.Ho, e.Ten, e.Phai, e.NgaySinh, e.DiaChi, e.Sdt);
            dgv_stafflist.DataSource = result;
            dgv_stafflist.Refresh();

        }
        private void formaddproduct_FormClosed(object sender, FormClosedEventArgs e)
        {
            formaddstaff = null;


            //RefreshDataGridView();
        }
        private void Disabl_addbutton()
        {

        }

        private void dgv_stafflist_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 || e.RowIndex >= dgv_stafflist.Rows.Count)
            {

                DataGridViewRow row = dgv_stafflist.Rows[e.RowIndex];
                DataGridViewCell cell = row.Cells[e.ColumnIndex];

                // Lấy giá trị cũ và mới
                string originalValue = cell.Tag?.ToString();
                string newValue = cell.Value?.ToString();

                if (originalValue != newValue)
                {
                    DataGridViewRow selectedRow = dgv_stafflist.Rows[e.RowIndex];
                    String manv = selectedRow.Cells["MaNV"].Value.ToString();
                    String ho = selectedRow.Cells["Ho"].Value.ToString();
                    String ten = selectedRow.Cells["Ten"].Value.ToString();
                    String phai = selectedRow.Cells["Phai"].Value.ToString();
                    String sodienthoai = selectedRow.Cells["SoDienThoai"].Value.ToString();
                    string ngaySinhStr = selectedRow.Cells["NgaySinh"].Value.ToString();

                    DateTime ngaySinh = DateTime.ParseExact(ngaySinhStr, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    String a = ngaySinh.ToString("yyyy-MM-dd");
                    String diachi = selectedRow.Cells["DiaChi"].Value.ToString();
                    MessageBox.Show(row.Cells["MaNV"].ToString(), row.Cells["Ho"].ToString());
                    try
                    {
                        SqlParameter[] parameters = new SqlParameter[]
                        {
                            new SqlParameter("@MaNv", manv),
                            new SqlParameter("@Ho", ho),
                            new SqlParameter("@Ten", ten),
                            new SqlParameter("@Phai", phai),
                            new SqlParameter("@SoDienThoai", sodienthoai),
                            new SqlParameter("@DiaChi", diachi),
                            new SqlParameter("@NgaySinh",a.ToString()),
                        };

                        try
                        {
                            DataHelper dataHelper = new DataHelper(connection);
                            int res = dataHelper.ExecuteStoredProcedureNonQuery("SP_UPDATESTAFF", parameters);
                            if (res > 0)
                            {
                                MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo");
                                dgv_stafflist.CurrentCell = row.Cells["MaNV"];

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
                        dgv_stafflist.CurrentCell = row.Cells["MaNV"];
                    }


                }
            }
        }

        private void dgv_stafflist_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridViewRow row = dgv_stafflist.Rows[e.RowIndex];
            DataGridViewCell cell = row.Cells[e.ColumnIndex];

            if (cell.Value != null)
            {
                cell.Tag = cell.Value.ToString(); // Lưu giá trị ban đầu vào Tag
            }
        }


        private void dgv_stafflist_KeyDown(object sender, KeyEventArgs e)
        {
            dgv_stafflist.AllowUserToDeleteRows = (nhomquyen != "CONGTY");
            DataGridViewRow selectedRow = dgv_stafflist.SelectedRows[0];
            String MaNV = selectedRow.Cells["MaNV"].Value.ToString();
            if (this.manv.Trim() == MaNV.Trim())
            {
                MessageBox.Show("Bạn đang đăng nhập. Không thể xóa");
                return;
            }
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (nhomquyen == "CONGTY")
                    {
                        MessageBox.Show("Bạn không có quyền xóa");
                        return;
                    }

                    // Kiểm tra xem có dòng nào được chọn hay không
                    if (dgv_stafflist.SelectedRows.Count > 0)
                    {
                        // Lấy dòng đã chọn

                        // Xác nhận xóa
                        DialogResult dialogResult = MessageBox.Show(
                            "Bạn có chắc chắn muốn xóa nhân viên này?",
                            "Xác nhận xóa",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);

                        if (dialogResult == DialogResult.Yes)
                        {
                            SqlParameter[] parameters = new SqlParameter[]
                            {
                                new SqlParameter("@USRNAME", MaNV)
                            };

                            DataHelper dataHelper = new DataHelper(connection);

                            // Thực hiện xóa trong cơ sở dữ liệu
                            int result = dataHelper.ExecuteStoredProcedureNonQuery("Xoa_Login", parameters);

                            if (result > 0)
                            {
                                // Xóa dòng trong DataGridView nếu xóa thành công
                                dgv_stafflist.Rows.Remove(selectedRow);
                                MessageBox.Show("Xóa nhân viên thành công!");
                            }
                            else
                            {
                                MessageBox.Show("Xóa nhân viên thất bại!");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn nhân viên để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                // Thông báo lỗi, không xóa dòng trong DataGridView
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_addlogin_Click(object sender, EventArgs e)
        {
            if (formaddlogin == null)
            {
                if (dgv_stafflist.SelectedRows.Count > 0)
                {
                    // Lấy dòng đã chọn
                    DataGridViewRow selectedRow = dgv_stafflist.SelectedRows[0];

                    // Lấy giá trị của MaKho (Mã kho - khóa chính)
                    String MaNV = (selectedRow.Cells["MaNV"].Value.ToString());

                    // Xác nhận người dùng có muốn xóa không

                    formaddlogin = new FormStaff.FormAddLogin(this.connection, MaNV, nhomquyen);
                    formaddlogin.FormClosed += formaddlogin_FormClosed;
                    formaddlogin.Show();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn 1 nhân viên");
                    return;
                }

            }
            else
            {
                formaddlogin.Activate();
            }
        }
        private void formaddlogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            formaddlogin = null;


            //RefreshDataGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgv_stafflist.SelectedRows.Count > 0)
            {
                // Lấy dòng đã chọn
                DataGridViewRow selectedRow = dgv_stafflist.SelectedRows[0];

                // Lấy giá trị của MaKho (Mã kho - khóa chính)
                String MaNV = (selectedRow.Cells["MaNV"].Value.ToString());
                if (this.manv.Trim() == MaNV.Trim())
                {
                    MessageBox.Show("Bạn đang đăng nhập. Không thể chuyển chi nhánh");
                    return;
                }
                DateTime now = DateTime.Now;
                String today = now.ToString("yyyy-MM-dd");
                String ngaylap = now.ToString("dd_MM-yyyy");
                SqlParameter[] parameters = new SqlParameter[]
                {
                       new SqlParameter("@MaNV",MaNV),
                       new SqlParameter("@NGAYCHUYEN", today),


                };
                dataHelper = new DataHelper(connection);
                int res = dataHelper.ExecuteStoredProcedureNonQuery("sp_ChuyenChiNhanh", parameters);

                if (res > 0)
                {
                    MessageBox.Show("Chuyển chi nhánh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (this.manv == MaNV)
                    {
                        MessageBox.Show("Phiên đăng nhập hết hạn. Vui lòng đăng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        this.MdiParent.Close();
                    }
                    foreach (DataRow row in result.Rows)
                    {
                        if (row["MaNV"].ToString() == MaNV)
                        {
                            row.Delete(); // Đánh dấu là đã xóa
                        }
                    }
                    result.AcceptChanges();
                    dgv_stafflist.DataSource = result;
                }
                else
                {
                    MessageBox.Show("Chuyển chi nhánh thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            else
            {
                MessageBox.Show("Vui lòng chọn 1 nhân viên");
                return;
            }
        }

        private void cbx_chuyenchinhanh_SelectionChangeCommitted(object sender, EventArgs e)
        {


        }

        private void btn_ext_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbx_chuyenchinhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            String a = cbx_chuyenchinhanh.SelectedValue.ToString();
            SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MACN_CBX", a),
                };
            dataHelper = new DataHelper(connection);
            result = dataHelper.ExecuteStoredProcedure("sp_CHUYENCHINHANH2", parameters);
            //int res = dataHelper.ExecuteStoredProcedureNonQuery("sp_CHUYENCHINHANH2", parameters);
            dgv_stafflist.DataSource = result;
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            try
            {
                dgv_stafflist.AllowUserToDeleteRows = (nhomquyen != "CONGTY");
                DataGridViewRow selectedRow = dgv_stafflist.SelectedRows[0];
                String MaNV = selectedRow.Cells["MaNV"].Value.ToString();
                if (nhomquyen == "CONGTY")
                {
                    MessageBox.Show("Bạn không có quyền xóa");
                    return;
                }
                if (this.manv.Trim() == MaNV.Trim())
                {
                    MessageBox.Show("Bạn đang đăng nhập. Không thể xóa");
                    return;
                }
                // Kiểm tra xem có dòng nào được chọn hay không
                if (dgv_stafflist.SelectedRows.Count > 0)
                {
                    // Lấy dòng đã chọn

                    // Xác nhận xóa
                    DialogResult dialogResult = MessageBox.Show(
                        "Bạn có chắc chắn muốn xóa nhân viên này?",
                        "Xác nhận xóa",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (dialogResult == DialogResult.Yes)
                    {
                        SqlParameter[] parameters = new SqlParameter[]
                        {
                                new SqlParameter("@USRNAME", MaNV)
                        };

                        DataHelper dataHelper = new DataHelper(connection);

                        // Thực hiện xóa trong cơ sở dữ liệu
                        int result = dataHelper.ExecuteStoredProcedureReturnValue("Xoa_Login", parameters);

                        if (result == 0 || result == 1 || result == 2)
                        {
                            // Xóa dòng trong DataGridView nếu xóa thành công
                            dgv_stafflist.Rows.Remove(selectedRow);
                            MessageBox.Show("Xóa nhân viên thành công!");
                        }
                        else
                        {
                            MessageBox.Show("Xóa nhân viên thất bại!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn nhân viên để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                // Thông báo lỗi, không xóa dòng trong DataGridView
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
