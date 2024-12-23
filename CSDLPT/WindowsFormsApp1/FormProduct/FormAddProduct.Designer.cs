namespace WindowsFormsApp1
{
    partial class FormAddProduct
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_nameproduct = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_dvt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbx_producttype = new System.Windows.Forms.ComboBox();
            this.btn_addproduct = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(79, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(501, 74);
            this.label1.TabIndex = 1;
            this.label1.Text = "Thêm Sản Phẩm Mới";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(113, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên Sản Phẩm";
            // 
            // tb_nameproduct
            // 
            this.tb_nameproduct.Location = new System.Drawing.Point(290, 108);
            this.tb_nameproduct.Name = "tb_nameproduct";
            this.tb_nameproduct.Size = new System.Drawing.Size(189, 22);
            this.tb_nameproduct.TabIndex = 8;
            this.tb_nameproduct.TextChanged += new System.EventHandler(this.tb_manv_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(138, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 22);
            this.label5.TabIndex = 9;
            this.label5.Text = "Đơn Vị Tính";
            // 
            // tb_dvt
            // 
            this.tb_dvt.Location = new System.Drawing.Point(290, 195);
            this.tb_dvt.Name = "tb_dvt";
            this.tb_dvt.Size = new System.Drawing.Size(189, 22);
            this.tb_dvt.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(151, 282);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 22);
            this.label3.TabIndex = 12;
            this.label3.Text = "Loại Hàng";
            // 
            // cbx_producttype
            // 
            this.cbx_producttype.FormattingEnabled = true;
            this.cbx_producttype.Location = new System.Drawing.Point(290, 282);
            this.cbx_producttype.Name = "cbx_producttype";
            this.cbx_producttype.Size = new System.Drawing.Size(189, 24);
            this.cbx_producttype.TabIndex = 13;
            this.cbx_producttype.SelectedIndexChanged += new System.EventHandler(this.cbx_producttype_SelectedIndexChanged);
            // 
            // btn_addproduct
            // 
            this.btn_addproduct.Location = new System.Drawing.Point(223, 346);
            this.btn_addproduct.Name = "btn_addproduct";
            this.btn_addproduct.Size = new System.Drawing.Size(113, 40);
            this.btn_addproduct.TabIndex = 14;
            this.btn_addproduct.Text = "Thêm ";
            this.btn_addproduct.UseVisualStyleBackColor = true;
            this.btn_addproduct.Click += new System.EventHandler(this.btn_addproduct_Click);
            // 
            // FormAddProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 450);
            this.Controls.Add(this.btn_addproduct);
            this.Controls.Add(this.cbx_producttype);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_dvt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tb_nameproduct);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormAddProduct";
            this.Text = "FormAddProduct";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_nameproduct;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_dvt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbx_producttype;
        private System.Windows.Forms.Button btn_addproduct;
    }
}