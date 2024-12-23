namespace WindowsFormsApp1
{
    partial class FormStaffList
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
            this.dgv_stafflist = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.btn_addlogin = new System.Windows.Forms.Button();
            this.btn_editstaff = new System.Windows.Forms.Button();
            this.btn_ext = new System.Windows.Forms.Button();
            this.btn_ccn = new System.Windows.Forms.Button();
            this.btn_addstaff = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbx_chuyenchinhanh = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_stafflist)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label1.Location = new System.Drawing.Point(427, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(821, 91);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh Sách Nhân Viên";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dgv_stafflist
            // 
            this.dgv_stafflist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_stafflist.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv_stafflist.Location = new System.Drawing.Point(12, 153);
            this.dgv_stafflist.Name = "dgv_stafflist";
            this.dgv_stafflist.RowHeadersWidth = 51;
            this.dgv_stafflist.RowTemplate.Height = 24;
            this.dgv_stafflist.Size = new System.Drawing.Size(1725, 500);
            this.dgv_stafflist.TabIndex = 1;
            this.dgv_stafflist.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgv_stafflist_CellBeginEdit);
            this.dgv_stafflist.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_stafflist_CellContentClick);
            this.dgv_stafflist.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_stafflist_CellEndEdit);
            this.dgv_stafflist.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_stafflist_KeyDown);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_xoa);
            this.panel1.Controls.Add(this.btn_addlogin);
            this.panel1.Controls.Add(this.btn_editstaff);
            this.panel1.Controls.Add(this.btn_ext);
            this.panel1.Controls.Add(this.btn_ccn);
            this.panel1.Controls.Add(this.btn_addstaff);
            this.panel1.Location = new System.Drawing.Point(12, 659);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1543, 143);
            this.panel1.TabIndex = 7;
            // 
            // btn_xoa
            // 
            this.btn_xoa.Location = new System.Drawing.Point(289, 56);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(142, 45);
            this.btn_xoa.TabIndex = 8;
            this.btn_xoa.Text = "Xóa nhân viên";
            this.btn_xoa.UseVisualStyleBackColor = true;
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // btn_addlogin
            // 
            this.btn_addlogin.Location = new System.Drawing.Point(558, 57);
            this.btn_addlogin.Name = "btn_addlogin";
            this.btn_addlogin.Size = new System.Drawing.Size(142, 45);
            this.btn_addlogin.TabIndex = 7;
            this.btn_addlogin.Text = "Tạo login";
            this.btn_addlogin.UseVisualStyleBackColor = true;
            this.btn_addlogin.Click += new System.EventHandler(this.btn_addlogin_Click);
            // 
            // btn_editstaff
            // 
            this.btn_editstaff.Location = new System.Drawing.Point(826, 57);
            this.btn_editstaff.Name = "btn_editstaff";
            this.btn_editstaff.Size = new System.Drawing.Size(142, 45);
            this.btn_editstaff.TabIndex = 6;
            this.btn_editstaff.Text = "Sửa nhân viên";
            this.btn_editstaff.UseVisualStyleBackColor = true;
            this.btn_editstaff.Click += new System.EventHandler(this.btn_editstaff_Click);
            // 
            // btn_ext
            // 
            this.btn_ext.Location = new System.Drawing.Point(1352, 56);
            this.btn_ext.Name = "btn_ext";
            this.btn_ext.Size = new System.Drawing.Size(142, 45);
            this.btn_ext.TabIndex = 5;
            this.btn_ext.Text = "Thoát";
            this.btn_ext.UseVisualStyleBackColor = true;
            this.btn_ext.Click += new System.EventHandler(this.btn_ext_Click);
            // 
            // btn_ccn
            // 
            this.btn_ccn.Location = new System.Drawing.Point(1094, 57);
            this.btn_ccn.Name = "btn_ccn";
            this.btn_ccn.Size = new System.Drawing.Size(142, 45);
            this.btn_ccn.TabIndex = 4;
            this.btn_ccn.Text = "Chuyển chi nhánh";
            this.btn_ccn.UseVisualStyleBackColor = true;
            this.btn_ccn.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_addstaff
            // 
            this.btn_addstaff.Location = new System.Drawing.Point(44, 57);
            this.btn_addstaff.Name = "btn_addstaff";
            this.btn_addstaff.Size = new System.Drawing.Size(142, 45);
            this.btn_addstaff.TabIndex = 3;
            this.btn_addstaff.Text = "Thêm nhân viên";
            this.btn_addstaff.UseVisualStyleBackColor = true;
            this.btn_addstaff.Click += new System.EventHandler(this.btn_addstaff_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1255, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 22);
            this.label2.TabIndex = 8;
            this.label2.Text = "Chi nhánh";
            // 
            // cbx_chuyenchinhanh
            // 
            this.cbx_chuyenchinhanh.FormattingEnabled = true;
            this.cbx_chuyenchinhanh.Location = new System.Drawing.Point(1353, 116);
            this.cbx_chuyenchinhanh.Name = "cbx_chuyenchinhanh";
            this.cbx_chuyenchinhanh.Size = new System.Drawing.Size(179, 24);
            this.cbx_chuyenchinhanh.TabIndex = 9;
            this.cbx_chuyenchinhanh.SelectedIndexChanged += new System.EventHandler(this.cbx_chuyenchinhanh_SelectedIndexChanged);
            this.cbx_chuyenchinhanh.SelectionChangeCommitted += new System.EventHandler(this.cbx_chuyenchinhanh_SelectionChangeCommitted);
            // 
            // FormStaffList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1557, 814);
            this.Controls.Add(this.cbx_chuyenchinhanh);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgv_stafflist);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormStaffList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "FormStaffList";
            this.Load += new System.EventHandler(this.FormStaffList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_stafflist)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_stafflist;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_addstaff;
        private System.Windows.Forms.Button btn_addlogin;
        private System.Windows.Forms.Button btn_editstaff;
        private System.Windows.Forms.Button btn_ext;
        private System.Windows.Forms.Button btn_ccn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbx_chuyenchinhanh;
        private System.Windows.Forms.Button btn_xoa;
    }
}