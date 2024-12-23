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
using WindowsFormsApp1.FormBill;
using WindowsFormsApp1.Object;

namespace WindowsFormsApp1
{
    public partial class FormHome : Form
    {
        FormInfo forminfo;
        FormStaffList formstafflist;
        FormWareHouse formwarehouse;
        FormProduct formproduct;
        FormOrders formorder;
        FormBill.FormRedInvoice formredinvoice;
        FormImport.FormReceipt formreceipt;
        Report.FormReport formreport;

        private readonly string connection;
        private DataHelper dataHelper;
        private String login;

        InfoObject info;
        DataTable result;
        public FormHome(String connection, String login)
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            this.connection = connection;
            this.login = login;
        }



        private void FormHome_Load(object sender, EventArgs e)
        {
            dataHelper = new DataHelper(connection);
            SqlParameter[] parameters = new SqlParameter[]
               {
                    new SqlParameter("@TENLOGIN", SqlDbType.Char, 10) { Value = login }
               };

            // Gọi Stored Procedure
            result = dataHelper.ExecuteStoredProcedure("sp_DangNhap", parameters);
            info = null;

            if (result.Rows.Count > 0)
            {
                DataRow row = result.Rows[0]; // Lấy dòng đầu tiên
                info = ConvertDataRowToObject(row);

                if (forminfo == null)
                {
                    forminfo = new FormInfo(this.connection, info);
                    forminfo.FormClosed += forminfo_FormClosed;
                    forminfo.MdiParent = this;
                    forminfo.Show();
                }
                else
                {
                    forminfo.Activate();
                }
            }
            else
            {
                Console.WriteLine("Không có dữ liệu trả về!");
            }
        }

        bool menuExpand = false;
        private void MenuTransition_Tick(object sender, EventArgs e)
        {
            if (menuExpand == false)
            {
                MenuContainer.Height += 10;
                if (MenuContainer.Height >= 138)
                {
                    MenuTransition.Stop();
                    menuExpand = true;
                }

            }
            else
            {
                MenuContainer.Height -= 10;
                if (MenuContainer.Height <= 69)
                {
                    MenuTransition.Stop();
                    menuExpand = false;
                }
                {

                }
            }
        }

        private void forminfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            forminfo = null;
        }



        private void btn_MenuNhanVien_Click(object sender, EventArgs e)
        {
            MenuTransition.Start();
        }

      
        public InfoObject ConvertDataRowToObject(DataRow row)
        {
            return new InfoObject
            {
                manv = row["MANV"].ToString(),
                hoten = row["HOTEN"].ToString(),
                phai = row["PHAI"].ToString(),
                sodienthoai = row["SODIENTHOAI"].ToString(),
                ngaysinh = Convert.ToDateTime(row["NgaySinh"]).ToString("dd/MM/yyyy"),
                diachi = row["DIACHI"].ToString(),
                macn = row["MACN"].ToString(),
                nhomquyen = row["TENNHOM"].ToString(),
            };
        }
        
    

        private void btn_Order_Click(object sender, EventArgs e)
        {
            if (formorder == null)
            {
                formorder = new FormOrders(this.connection,info.manv.ToString(),info.hoten.ToString(),info.nhomquyen,info.macn);
                formorder.FormClosed += formorder_FormClosed;
                formorder.MdiParent = this;
                formorder.Show();
            }
            else
            {
                formorder.Activate();
            }
        }
        private void formorder_FormClosed(object sender, FormClosedEventArgs e)
        {
            formorder = null;
        }

        private void btn_stafflist_Click(object sender, EventArgs e)
        {
            if (formstafflist == null)
            {
                formstafflist = new FormStaffList(this.connection,login,info.nhomquyen.ToString(),info.manv,info.macn);
                formstafflist.FormClosed += formstafflsit_FormClosed;
                formstafflist.MdiParent = this;
                formstafflist.Show();
            }
            else
            {
                formstafflist.Activate();
            }
        }
        private void formstafflsit_FormClosed(object sender, FormClosedEventArgs e)
        {
            formstafflist = null;
        }


        private void btn_Product_Click(object sender, EventArgs e)
        {
            if (formproduct == null )
            {
                formproduct = new FormProduct(this.connection,info.nhomquyen, info.macn);
                formproduct.FormClosed += formproduct_FormClosed;
                formproduct.MdiParent = this;
                formproduct.Show();
            }
            else
            {
                formproduct.Activate();
            }
        }
        private void formproduct_FormClosed(object sender, FormClosedEventArgs e)
        {
            formproduct = null;
        }

        private void btn_warehouse_Click(object sender, EventArgs e)
        {
            if (formwarehouse == null)
            {
               formwarehouse = new FormWareHouse(this.connection, info.nhomquyen, info.macn);
               formwarehouse.FormClosed += formwarehouse_FormClosed;
               formwarehouse.MdiParent = this;
               formwarehouse.Show();
            }
           else
           {
               formwarehouse.Activate();
           }
        }
        private void formwarehouse_FormClosed(object sender, FormClosedEventArgs e)
        {
            formwarehouse = null;
        }

        private void btn_bill_Click(object sender, EventArgs e)
        {
            if (formredinvoice == null)
            {
                formredinvoice = new FormRedInvoice(this.connection, info.manv.ToString(), info.hoten.ToString(),info.macn.ToString(),info.nhomquyen);
                formredinvoice.FormClosed += formredinvoice_FormClosed;
                formredinvoice.MdiParent = this;
                formredinvoice.Show();
            }
            else
            {
                formredinvoice.Activate();
            }
        }
        private void formredinvoice_FormClosed(object sender, FormClosedEventArgs e)
        {
            formredinvoice = null;
        }

        private void btn_import_Click(object sender, EventArgs e)
        {
            if (formreceipt == null)
            {
                formreceipt = new FormImport.FormReceipt(this.connection, info.manv.ToString(), info.hoten.ToString(),info.nhomquyen, info.macn);
                formreceipt.FormClosed += formreceipt_FormClosed;
                formreceipt.MdiParent = this;
                formreceipt.Show();
            }
            else
            {
                formreceipt.Activate();
            }

        }
        private void formreceipt_FormClosed(object sender, FormClosedEventArgs e)
        {
            formreceipt = null;
        }

        private void btn_report_Click(object sender, EventArgs e)
        {
            if (formreport == null)
            {
                formreport = new Report.FormReport(connection,info.nhomquyen, info.macn);
                formreport.FormClosed += formreport_FormClosed;
                formreport.MdiParent = this;
                formreport.Show();
            }
            else
            {
                formreport.Activate();
            }
        }
        private void formreport_FormClosed(object sender, FormClosedEventArgs e)
        {
            formreport = null;
        }

        private void MenuContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
