namespace WindowsFormsApp1.FormBill
{
    partial class FormAddInvoice
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_addhd = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.dgv_danhsach = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_addkh = new System.Windows.Forms.Button();
            this.btn_check = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_diachi = new System.Windows.Forms.TextBox();
            this.tb_tenkhachhang = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tb_sdt = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.nud_soluongmua = new System.Windows.Forms.NumericUpDown();
            this.tb_sohd = new System.Windows.Forms.TextBox();
            this.btn_them = new System.Windows.Forms.Button();
            this.tb_soluong = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_dongia = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbx_sanpham = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbx_TenKho = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_danhsach)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_soluongmua)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_addhd);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.dgv_danhsach);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(0, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1540, 761);
            this.panel1.TabIndex = 1;
            // 
            // btn_addhd
            // 
            this.btn_addhd.Location = new System.Drawing.Point(1294, 432);
            this.btn_addhd.Name = "btn_addhd";
            this.btn_addhd.Size = new System.Drawing.Size(152, 35);
            this.btn_addhd.TabIndex = 36;
            this.btn_addhd.Text = "Xuất hóa đơn";
            this.btn_addhd.UseVisualStyleBackColor = true;
            this.btn_addhd.Click += new System.EventHandler(this.btn_addhd_Click);
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(481, 395);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(788, 58);
            this.label11.TabIndex = 35;
            this.label11.Text = "Danh Sách Sản Phẩm Trong Hóa Đơn";
            // 
            // dgv_danhsach
            // 
            this.dgv_danhsach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_danhsach.Location = new System.Drawing.Point(5, 481);
            this.dgv_danhsach.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgv_danhsach.Name = "dgv_danhsach";
            this.dgv_danhsach.RowHeadersWidth = 51;
            this.dgv_danhsach.RowTemplate.Height = 24;
            this.dgv_danhsach.Size = new System.Drawing.Size(1533, 265);
            this.dgv_danhsach.TabIndex = 32;
            this.dgv_danhsach.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgv_danhsach_UserDeletedRow);
            this.dgv_danhsach.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_danhsach_KeyDown);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(655, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(501, 58);
            this.label1.TabIndex = 3;
            this.label1.Text = "Thêm Hóa Đơn Mới";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btn_addkh);
            this.panel2.Controls.Add(this.btn_check);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.tb_diachi);
            this.panel2.Controls.Add(this.tb_tenkhachhang);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.tb_sdt);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Location = new System.Drawing.Point(5, 70);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(375, 299);
            this.panel2.TabIndex = 33;
            // 
            // btn_addkh
            // 
            this.btn_addkh.Location = new System.Drawing.Point(190, 238);
            this.btn_addkh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_addkh.Name = "btn_addkh";
            this.btn_addkh.Size = new System.Drawing.Size(151, 34);
            this.btn_addkh.TabIndex = 30;
            this.btn_addkh.Text = "Tạo Khách Hàng";
            this.btn_addkh.UseVisualStyleBackColor = true;
            this.btn_addkh.Click += new System.EventHandler(this.btn_addkh_Click);
            // 
            // btn_check
            // 
            this.btn_check.Location = new System.Drawing.Point(11, 239);
            this.btn_check.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_check.Name = "btn_check";
            this.btn_check.Size = new System.Drawing.Size(144, 33);
            this.btn_check.TabIndex = 29;
            this.btn_check.Text = "Kiểm Tra";
            this.btn_check.UseVisualStyleBackColor = true;
            this.btn_check.Click += new System.EventHandler(this.btn_check_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(7, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(146, 22);
            this.label8.TabIndex = 23;
            this.label8.Text = "Tên Khách Hàng";
            // 
            // tb_diachi
            // 
            this.tb_diachi.Location = new System.Drawing.Point(165, 110);
            this.tb_diachi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_diachi.Name = "tb_diachi";
            this.tb_diachi.Size = new System.Drawing.Size(199, 22);
            this.tb_diachi.TabIndex = 26;
            // 
            // tb_tenkhachhang
            // 
            this.tb_tenkhachhang.Location = new System.Drawing.Point(165, 39);
            this.tb_tenkhachhang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_tenkhachhang.Name = "tb_tenkhachhang";
            this.tb_tenkhachhang.Size = new System.Drawing.Size(199, 22);
            this.tb_tenkhachhang.TabIndex = 28;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(7, 108);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 22);
            this.label10.TabIndex = 25;
            this.label10.Text = "Địa chỉ";
            // 
            // tb_sdt
            // 
            this.tb_sdt.Location = new System.Drawing.Point(164, 190);
            this.tb_sdt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_sdt.Name = "tb_sdt";
            this.tb_sdt.Size = new System.Drawing.Size(199, 22);
            this.tb_sdt.TabIndex = 27;
            this.tb_sdt.TextChanged += new System.EventHandler(this.tb_sdt_TextChanged);
            this.tb_sdt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_sdt_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(7, 187);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(125, 22);
            this.label9.TabIndex = 24;
            this.label9.Text = "Số Điện Thoại";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.nud_soluongmua);
            this.panel3.Controls.Add(this.tb_sohd);
            this.panel3.Controls.Add(this.btn_them);
            this.panel3.Controls.Add(this.tb_soluong);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.tb_dongia);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.cbx_sanpham);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.cbx_TenKho);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Location = new System.Drawing.Point(387, 70);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1141, 299);
            this.panel3.TabIndex = 34;
            // 
            // nud_soluongmua
            // 
            this.nud_soluongmua.Location = new System.Drawing.Point(820, 192);
            this.nud_soluongmua.Name = "nud_soluongmua";
            this.nud_soluongmua.Size = new System.Drawing.Size(190, 22);
            this.nud_soluongmua.TabIndex = 24;
            // 
            // tb_sohd
            // 
            this.tb_sohd.Location = new System.Drawing.Point(331, 192);
            this.tb_sohd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_sohd.Name = "tb_sohd";
            this.tb_sohd.Size = new System.Drawing.Size(199, 22);
            this.tb_sohd.TabIndex = 23;
            // 
            // btn_them
            // 
            this.btn_them.Location = new System.Drawing.Point(563, 238);
            this.btn_them.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(101, 34);
            this.btn_them.TabIndex = 22;
            this.btn_them.Text = "Thêm";
            this.btn_them.UseVisualStyleBackColor = true;
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // tb_soluong
            // 
            this.tb_soluong.Enabled = false;
            this.tb_soluong.Location = new System.Drawing.Point(811, 108);
            this.tb_soluong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_soluong.Name = "tb_soluong";
            this.tb_soluong.Size = new System.Drawing.Size(199, 22);
            this.tb_soluong.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(667, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 22);
            this.label2.TabIndex = 13;
            this.label2.Text = "Số Lượng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(179, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 22);
            this.label4.TabIndex = 11;
            this.label4.Text = "Số Hóa Đơn";
            // 
            // tb_dongia
            // 
            this.tb_dongia.Location = new System.Drawing.Point(331, 108);
            this.tb_dongia.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_dongia.Name = "tb_dongia";
            this.tb_dongia.Size = new System.Drawing.Size(199, 22);
            this.tb_dongia.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(667, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 22);
            this.label6.TabIndex = 20;
            this.label6.Text = "Số lượng mua";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(179, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 22);
            this.label3.TabIndex = 15;
            this.label3.Text = "Đơn Giá";
            // 
            // cbx_sanpham
            // 
            this.cbx_sanpham.FormattingEnabled = true;
            this.cbx_sanpham.Location = new System.Drawing.Point(332, 36);
            this.cbx_sanpham.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbx_sanpham.Name = "cbx_sanpham";
            this.cbx_sanpham.Size = new System.Drawing.Size(199, 24);
            this.cbx_sanpham.TabIndex = 19;
            this.cbx_sanpham.SelectionChangeCommitted += new System.EventHandler(this.cbx_sanpham_SelectionChangeCommitted);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(179, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 22);
            this.label5.TabIndex = 18;
            this.label5.Text = "Sản Phẩm";
            // 
            // cbx_TenKho
            // 
            this.cbx_TenKho.FormattingEnabled = true;
            this.cbx_TenKho.Location = new System.Drawing.Point(811, 36);
            this.cbx_TenKho.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbx_TenKho.Name = "cbx_TenKho";
            this.cbx_TenKho.Size = new System.Drawing.Size(199, 24);
            this.cbx_TenKho.TabIndex = 10;
            this.cbx_TenKho.SelectedIndexChanged += new System.EventHandler(this.cbx_TenKho_SelectedIndexChanged);
            this.cbx_TenKho.SelectionChangeCommitted += new System.EventHandler(this.cbx_TenKho_SelectionChangeCommitted);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(667, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 22);
            this.label7.TabIndex = 9;
            this.label7.Text = "Tên Kho";
            // 
            // FormAddInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1539, 767);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormAddInvoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormAddInvoice";
            this.Load += new System.EventHandler(this.FormAddInvoice_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_danhsach)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_soluongmua)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbx_sanpham;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_dongia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_soluong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbx_TenKho;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_tenkhachhang;
        private System.Windows.Forms.TextBox tb_sdt;
        private System.Windows.Forms.TextBox tb_diachi;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgv_danhsach;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btn_check;
        private System.Windows.Forms.Button btn_them;
        private System.Windows.Forms.TextBox tb_sohd;
        private System.Windows.Forms.Button btn_addkh;
        private System.Windows.Forms.NumericUpDown nud_soluongmua;
        private System.Windows.Forms.Button btn_addhd;
    }
}