namespace WindowsFormsApp1
{
    partial class FormHome
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.slidebar = new System.Windows.Forms.FlowLayoutPanel();
            this.MenuContainer = new System.Windows.Forms.Panel();
            this.btn_stafflist = new System.Windows.Forms.Button();
            this.btn_MenuNhanVien = new System.Windows.Forms.Button();
            this.OrderContainer = new System.Windows.Forms.Panel();
            this.btn_Order = new System.Windows.Forms.Button();
            this.ImportContainer = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.btn_import = new System.Windows.Forms.Button();
            this.BillContainer = new System.Windows.Forms.Panel();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.btn_bill = new System.Windows.Forms.Button();
            this.btn_warehouse = new System.Windows.Forms.Button();
            this.btn_Product = new System.Windows.Forms.Button();
            this.btn_report = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.MenuTransition = new System.Windows.Forms.Timer(this.components);
            this.OrderTransition = new System.Windows.Forms.Timer(this.components);
            this.ImportTransition = new System.Windows.Forms.Timer(this.components);
            this.BillTransition = new System.Windows.Forms.Timer(this.components);
            this.slidebar.SuspendLayout();
            this.MenuContainer.SuspendLayout();
            this.OrderContainer.SuspendLayout();
            this.ImportContainer.SuspendLayout();
            this.BillContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // slidebar
            // 
            this.slidebar.BackColor = System.Drawing.Color.Black;
            this.slidebar.Controls.Add(this.MenuContainer);
            this.slidebar.Controls.Add(this.OrderContainer);
            this.slidebar.Controls.Add(this.ImportContainer);
            this.slidebar.Controls.Add(this.BillContainer);
            this.slidebar.Controls.Add(this.btn_warehouse);
            this.slidebar.Controls.Add(this.btn_Product);
            this.slidebar.Controls.Add(this.btn_report);
            this.slidebar.Controls.Add(this.button2);
            this.slidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.slidebar.ForeColor = System.Drawing.Color.White;
            this.slidebar.Location = new System.Drawing.Point(0, 0);
            this.slidebar.Name = "slidebar";
            this.slidebar.Padding = new System.Windows.Forms.Padding(1);
            this.slidebar.Size = new System.Drawing.Size(300, 675);
            this.slidebar.TabIndex = 2;
            // 
            // MenuContainer
            // 
            this.MenuContainer.Controls.Add(this.btn_stafflist);
            this.MenuContainer.Controls.Add(this.btn_MenuNhanVien);
            this.MenuContainer.Location = new System.Drawing.Point(4, 4);
            this.MenuContainer.Name = "MenuContainer";
            this.MenuContainer.Size = new System.Drawing.Size(296, 72);
            this.MenuContainer.TabIndex = 4;
            this.MenuContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.MenuContainer_Paint);
            // 
            // btn_stafflist
            // 
            this.btn_stafflist.BackColor = System.Drawing.Color.DimGray;
            this.btn_stafflist.ForeColor = System.Drawing.Color.Yellow;
            this.btn_stafflist.Location = new System.Drawing.Point(4, 72);
            this.btn_stafflist.Name = "btn_stafflist";
            this.btn_stafflist.Size = new System.Drawing.Size(289, 63);
            this.btn_stafflist.TabIndex = 1;
            this.btn_stafflist.Text = "Danh sách nhân viên";
            this.btn_stafflist.UseVisualStyleBackColor = false;
            this.btn_stafflist.Click += new System.EventHandler(this.btn_stafflist_Click);
            // 
            // btn_MenuNhanVien
            // 
            this.btn_MenuNhanVien.BackColor = System.Drawing.Color.Gray;
            this.btn_MenuNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_MenuNhanVien.ForeColor = System.Drawing.Color.Yellow;
            this.btn_MenuNhanVien.Location = new System.Drawing.Point(3, 3);
            this.btn_MenuNhanVien.Name = "btn_MenuNhanVien";
            this.btn_MenuNhanVien.Size = new System.Drawing.Size(287, 63);
            this.btn_MenuNhanVien.TabIndex = 0;
            this.btn_MenuNhanVien.Text = "Nhân Viên";
            this.btn_MenuNhanVien.UseVisualStyleBackColor = false;
            this.btn_MenuNhanVien.Click += new System.EventHandler(this.btn_MenuNhanVien_Click);
            // 
            // OrderContainer
            // 
            this.OrderContainer.Controls.Add(this.btn_Order);
            this.OrderContainer.Location = new System.Drawing.Point(4, 82);
            this.OrderContainer.Name = "OrderContainer";
            this.OrderContainer.Size = new System.Drawing.Size(293, 66);
            this.OrderContainer.TabIndex = 5;
            // 
            // btn_Order
            // 
            this.btn_Order.BackColor = System.Drawing.Color.DimGray;
            this.btn_Order.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Order.ForeColor = System.Drawing.Color.Yellow;
            this.btn_Order.Location = new System.Drawing.Point(3, 3);
            this.btn_Order.Name = "btn_Order";
            this.btn_Order.Size = new System.Drawing.Size(287, 63);
            this.btn_Order.TabIndex = 0;
            this.btn_Order.Text = "Đơn Đặt Hàng";
            this.btn_Order.UseVisualStyleBackColor = false;
            this.btn_Order.Click += new System.EventHandler(this.btn_Order_Click);
            // 
            // ImportContainer
            // 
            this.ImportContainer.Controls.Add(this.button6);
            this.ImportContainer.Controls.Add(this.button7);
            this.ImportContainer.Controls.Add(this.btn_import);
            this.ImportContainer.Location = new System.Drawing.Point(4, 154);
            this.ImportContainer.Name = "ImportContainer";
            this.ImportContainer.Size = new System.Drawing.Size(290, 68);
            this.ImportContainer.TabIndex = 6;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(4, 138);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(236, 63);
            this.button6.TabIndex = 2;
            this.button6.Text = "Thêm nhân viên";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(6, 69);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(236, 63);
            this.button7.TabIndex = 1;
            this.button7.Text = "Danh sách nhân viên";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // btn_import
            // 
            this.btn_import.BackColor = System.Drawing.Color.DimGray;
            this.btn_import.ForeColor = System.Drawing.Color.Yellow;
            this.btn_import.Location = new System.Drawing.Point(3, 3);
            this.btn_import.Name = "btn_import";
            this.btn_import.Size = new System.Drawing.Size(287, 63);
            this.btn_import.TabIndex = 0;
            this.btn_import.Text = "Phiếu Nhập";
            this.btn_import.UseVisualStyleBackColor = false;
            this.btn_import.Click += new System.EventHandler(this.btn_import_Click);
            // 
            // BillContainer
            // 
            this.BillContainer.Controls.Add(this.button9);
            this.BillContainer.Controls.Add(this.button10);
            this.BillContainer.Controls.Add(this.btn_bill);
            this.BillContainer.Location = new System.Drawing.Point(4, 228);
            this.BillContainer.Name = "BillContainer";
            this.BillContainer.Size = new System.Drawing.Size(293, 68);
            this.BillContainer.TabIndex = 7;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(4, 138);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(236, 63);
            this.button9.TabIndex = 2;
            this.button9.Text = "Thêm nhân viên";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(6, 69);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(236, 63);
            this.button10.TabIndex = 1;
            this.button10.Text = "Danh sách nhân viên";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // btn_bill
            // 
            this.btn_bill.BackColor = System.Drawing.Color.DimGray;
            this.btn_bill.ForeColor = System.Drawing.Color.Yellow;
            this.btn_bill.Location = new System.Drawing.Point(3, 3);
            this.btn_bill.Name = "btn_bill";
            this.btn_bill.Size = new System.Drawing.Size(287, 63);
            this.btn_bill.TabIndex = 0;
            this.btn_bill.Text = "Hóa Đơn";
            this.btn_bill.UseVisualStyleBackColor = false;
            this.btn_bill.Click += new System.EventHandler(this.btn_bill_Click);
            // 
            // btn_warehouse
            // 
            this.btn_warehouse.BackColor = System.Drawing.Color.DimGray;
            this.btn_warehouse.ForeColor = System.Drawing.Color.Yellow;
            this.btn_warehouse.Location = new System.Drawing.Point(4, 302);
            this.btn_warehouse.Name = "btn_warehouse";
            this.btn_warehouse.Size = new System.Drawing.Size(290, 66);
            this.btn_warehouse.TabIndex = 8;
            this.btn_warehouse.Text = "Kho";
            this.btn_warehouse.UseVisualStyleBackColor = false;
            this.btn_warehouse.Click += new System.EventHandler(this.btn_warehouse_Click);
            // 
            // btn_Product
            // 
            this.btn_Product.BackColor = System.Drawing.Color.DimGray;
            this.btn_Product.ForeColor = System.Drawing.Color.Yellow;
            this.btn_Product.Location = new System.Drawing.Point(4, 374);
            this.btn_Product.Name = "btn_Product";
            this.btn_Product.Size = new System.Drawing.Size(290, 66);
            this.btn_Product.TabIndex = 9;
            this.btn_Product.Text = "Vật tư";
            this.btn_Product.UseVisualStyleBackColor = false;
            this.btn_Product.Click += new System.EventHandler(this.btn_Product_Click);
            // 
            // btn_report
            // 
            this.btn_report.BackColor = System.Drawing.Color.DimGray;
            this.btn_report.ForeColor = System.Drawing.Color.Yellow;
            this.btn_report.Location = new System.Drawing.Point(4, 446);
            this.btn_report.Name = "btn_report";
            this.btn_report.Size = new System.Drawing.Size(290, 66);
            this.btn_report.TabIndex = 10;
            this.btn_report.Text = "Báo Cáo";
            this.btn_report.UseVisualStyleBackColor = false;
            this.btn_report.Click += new System.EventHandler(this.btn_report_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DimGray;
            this.button2.ForeColor = System.Drawing.Color.Yellow;
            this.button2.Location = new System.Drawing.Point(4, 518);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(290, 66);
            this.button2.TabIndex = 12;
            this.button2.Text = "Đăng xuất";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MenuTransition
            // 
            this.MenuTransition.Interval = 10;
            this.MenuTransition.Tick += new System.EventHandler(this.MenuTransition_Tick);
            // 
            // OrderTransition
            // 
            this.OrderTransition.Interval = 10;
            // 
            // FormHome
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(931, 675);
            this.Controls.Add(this.slidebar);
            this.ForeColor = System.Drawing.Color.Firebrick;
            this.Name = "FormHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormHome_Load);
            this.slidebar.ResumeLayout(false);
            this.MenuContainer.ResumeLayout(false);
            this.OrderContainer.ResumeLayout(false);
            this.ImportContainer.ResumeLayout(false);
            this.BillContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel slidebar;
        private System.Windows.Forms.Button btn_MenuNhanVien;
        private System.Windows.Forms.Panel MenuContainer;
        private System.Windows.Forms.Button btn_stafflist;
        private System.Windows.Forms.Timer MenuTransition;
        private System.Windows.Forms.Panel OrderContainer;
        private System.Windows.Forms.Button btn_Order;
        private System.Windows.Forms.Panel ImportContainer;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button btn_import;
        private System.Windows.Forms.Panel BillContainer;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button btn_bill;
        private System.Windows.Forms.Timer OrderTransition;
        private System.Windows.Forms.Timer ImportTransition;
        private System.Windows.Forms.Timer BillTransition;
        private System.Windows.Forms.Button btn_warehouse;
        private System.Windows.Forms.Button btn_Product;
        private System.Windows.Forms.Button btn_report;
        private System.Windows.Forms.Button button2;
    }
}