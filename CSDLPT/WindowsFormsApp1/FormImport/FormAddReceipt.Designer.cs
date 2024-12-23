namespace WindowsFormsApp1.FormImport
{
    partial class FormAddReceipt
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
            this.tb_sanpham = new System.Windows.Forms.TextBox();
            this.tb_manv = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_addreceipt = new System.Windows.Forms.Button();
            this.tb_dongia = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_soluong = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbx_maddh = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbx_TenKho = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tb_sanpham);
            this.panel1.Controls.Add(this.tb_manv);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btn_addreceipt);
            this.panel1.Controls.Add(this.tb_dongia);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tb_soluong);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbx_maddh);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cbx_TenKho);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 445);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // tb_sanpham
            // 
            this.tb_sanpham.Enabled = false;
            this.tb_sanpham.Location = new System.Drawing.Point(138, 262);
            this.tb_sanpham.Name = "tb_sanpham";
            this.tb_sanpham.Size = new System.Drawing.Size(199, 22);
            this.tb_sanpham.TabIndex = 22;
            this.tb_sanpham.TextChanged += new System.EventHandler(this.tb_sanpham_TextChanged);
            // 
            // tb_manv
            // 
            this.tb_manv.Enabled = false;
            this.tb_manv.Location = new System.Drawing.Point(561, 260);
            this.tb_manv.Name = "tb_manv";
            this.tb_manv.Size = new System.Drawing.Size(199, 22);
            this.tb_manv.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(392, 260);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 22);
            this.label6.TabIndex = 20;
            this.label6.Text = "Mã Nhân Viên";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(37, 264);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 22);
            this.label5.TabIndex = 18;
            this.label5.Text = "Sản Phẩm";
            // 
            // btn_addreceipt
            // 
            this.btn_addreceipt.Location = new System.Drawing.Point(313, 320);
            this.btn_addreceipt.Name = "btn_addreceipt";
            this.btn_addreceipt.Size = new System.Drawing.Size(135, 46);
            this.btn_addreceipt.TabIndex = 17;
            this.btn_addreceipt.Text = "Thêm";
            this.btn_addreceipt.UseVisualStyleBackColor = true;
            this.btn_addreceipt.Click += new System.EventHandler(this.btn_addreceipt_Click);
            // 
            // tb_dongia
            // 
            this.tb_dongia.Location = new System.Drawing.Point(561, 179);
            this.tb_dongia.Name = "tb_dongia";
            this.tb_dongia.Size = new System.Drawing.Size(199, 22);
            this.tb_dongia.TabIndex = 16;
            this.tb_dongia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_dongia_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(392, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 22);
            this.label3.TabIndex = 15;
            this.label3.Text = "Đơn Giá";
            // 
            // tb_soluong
            // 
            this.tb_soluong.Location = new System.Drawing.Point(138, 178);
            this.tb_soluong.Name = "tb_soluong";
            this.tb_soluong.Size = new System.Drawing.Size(199, 22);
            this.tb_soluong.TabIndex = 14;
            this.tb_soluong.TextChanged += new System.EventHandler(this.tb_soluong_TextChanged);
            this.tb_soluong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_soluong_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 22);
            this.label2.TabIndex = 13;
            this.label2.Text = "Số Lượng";
            // 
            // cbx_maddh
            // 
            this.cbx_maddh.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_maddh.FormattingEnabled = true;
            this.cbx_maddh.Location = new System.Drawing.Point(561, 91);
            this.cbx_maddh.Name = "cbx_maddh";
            this.cbx_maddh.Size = new System.Drawing.Size(199, 24);
            this.cbx_maddh.TabIndex = 12;
            this.cbx_maddh.SelectedIndexChanged += new System.EventHandler(this.cbx_maddh_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(392, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 22);
            this.label4.TabIndex = 11;
            this.label4.Text = "Mã Đơn Đặt Hàng";
            // 
            // cbx_TenKho
            // 
            this.cbx_TenKho.FormattingEnabled = true;
            this.cbx_TenKho.Location = new System.Drawing.Point(138, 93);
            this.cbx_TenKho.Name = "cbx_TenKho";
            this.cbx_TenKho.Size = new System.Drawing.Size(199, 24);
            this.cbx_TenKho.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(37, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 22);
            this.label7.TabIndex = 9;
            this.label7.Text = "Tên Kho";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(170, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(501, 58);
            this.label1.TabIndex = 3;
            this.label1.Text = "Thêm Phiếu Nhập Mới";
            // 
            // FormAddReceipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "FormAddReceipt";
            this.Text = "FormAddReceipt";
            this.Load += new System.EventHandler(this.FormAddReceipt_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_addreceipt;
        private System.Windows.Forms.TextBox tb_dongia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_soluong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbx_maddh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbx_TenKho;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_manv;
        private System.Windows.Forms.TextBox tb_sanpham;
    }
}