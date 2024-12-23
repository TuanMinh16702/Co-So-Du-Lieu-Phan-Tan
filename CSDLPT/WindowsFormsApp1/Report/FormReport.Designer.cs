namespace WindowsFormsApp1.Report
{
    partial class FormReport
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dgv_report = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.dtp_tungay = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.dtp_denngay = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.cbx_loai = new System.Windows.Forms.ComboBox();
            this.btn_loc = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.cbx_chuyenchinhanh = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_report)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(662, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(347, 91);
            this.label2.TabIndex = 1;
            this.label2.Text = "Báo Cáo";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 30);
            this.label1.TabIndex = 3;
            this.label1.Text = "Báo Cáo";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(118, 118);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(248, 24);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
            // 
            // dgv_report
            // 
            this.dgv_report.AllowUserToAddRows = false;
            this.dgv_report.AllowUserToDeleteRows = false;
            this.dgv_report.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_report.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv_report.Location = new System.Drawing.Point(12, 208);
            this.dgv_report.Name = "dgv_report";
            this.dgv_report.RowHeadersWidth = 51;
            this.dgv_report.RowTemplate.Height = 24;
            this.dgv_report.Size = new System.Drawing.Size(1650, 500);
            this.dgv_report.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(408, 116);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 35);
            this.label9.TabIndex = 15;
            this.label9.Text = "Từ ngày";
            // 
            // dtp_tungay
            // 
            this.dtp_tungay.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_tungay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_tungay.Location = new System.Drawing.Point(513, 119);
            this.dtp_tungay.Name = "dtp_tungay";
            this.dtp_tungay.Size = new System.Drawing.Size(136, 22);
            this.dtp_tungay.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(730, 112);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(114, 29);
            this.label10.TabIndex = 18;
            this.label10.Text = "Đến ngày";
            // 
            // dtp_denngay
            // 
            this.dtp_denngay.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_denngay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_denngay.Location = new System.Drawing.Point(884, 117);
            this.dtp_denngay.Name = "dtp_denngay";
            this.dtp_denngay.Size = new System.Drawing.Size(125, 22);
            this.dtp_denngay.TabIndex = 19;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(1082, 112);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(127, 29);
            this.label11.TabIndex = 20;
            this.label11.Text = "Loại Phiếu";
            // 
            // cbx_loai
            // 
            this.cbx_loai.FormattingEnabled = true;
            this.cbx_loai.Location = new System.Drawing.Point(1235, 117);
            this.cbx_loai.Name = "cbx_loai";
            this.cbx_loai.Size = new System.Drawing.Size(194, 24);
            this.cbx_loai.TabIndex = 21;
            // 
            // btn_loc
            // 
            this.btn_loc.Location = new System.Drawing.Point(1460, 112);
            this.btn_loc.Name = "btn_loc";
            this.btn_loc.Size = new System.Drawing.Size(85, 29);
            this.btn_loc.TabIndex = 22;
            this.btn_loc.Text = "Lọc";
            this.btn_loc.UseVisualStyleBackColor = true;
            this.btn_loc.Click += new System.EventHandler(this.btn_loc_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(876, 734);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(133, 43);
            this.button2.TabIndex = 24;
            this.button2.Text = "Thoát";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cbx_chuyenchinhanh
            // 
            this.cbx_chuyenchinhanh.FormattingEnabled = true;
            this.cbx_chuyenchinhanh.Location = new System.Drawing.Point(1235, 167);
            this.cbx_chuyenchinhanh.Name = "cbx_chuyenchinhanh";
            this.cbx_chuyenchinhanh.Size = new System.Drawing.Size(194, 24);
            this.cbx_chuyenchinhanh.TabIndex = 25;
            this.cbx_chuyenchinhanh.DropDownClosed += new System.EventHandler(this.cbx_chuyenchinhanh_DropDownClosed);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1083, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 29);
            this.label3.TabIndex = 26;
            this.label3.Text = "Chi nhánh";
            // 
            // FormReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1557, 814);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbx_chuyenchinhanh);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_loc);
            this.Controls.Add(this.cbx_loai);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dtp_denngay);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dtp_tungay);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dgv_report);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "FormReport";
            this.Load += new System.EventHandler(this.FormReport_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_report)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView dgv_report;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtp_tungay;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtp_denngay;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbx_loai;
        private System.Windows.Forms.Button btn_loc;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cbx_chuyenchinhanh;
        private System.Windows.Forms.Label label3;
    }
}