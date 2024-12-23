namespace WindowsFormsApp1
{
    partial class FormWareHouse
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
            this.dgv_warehouse = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_find = new System.Windows.Forms.TextBox();
            this.btn_addwarehouse = new System.Windows.Forms.Button();
            this.btn_editwarehouse = new System.Windows.Forms.Button();
            this.btn_deletewarehouse = new System.Windows.Forms.Button();
            this.btn_undo = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.tb_nhaptenkho = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbx_chuyenchinhanh = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_warehouse)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(571, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(461, 100);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh mục kho";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dgv_warehouse
            // 
            this.dgv_warehouse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_warehouse.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv_warehouse.Location = new System.Drawing.Point(12, 166);
            this.dgv_warehouse.Name = "dgv_warehouse";
            this.dgv_warehouse.RowHeadersWidth = 51;
            this.dgv_warehouse.RowTemplate.Height = 24;
            this.dgv_warehouse.Size = new System.Drawing.Size(1725, 500);
            this.dgv_warehouse.TabIndex = 1;
            this.dgv_warehouse.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgv_warehouse_CellBeginEdit);
            this.dgv_warehouse.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dgv_warehouse.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvwarehouse_CellEndEdit);
            this.dgv_warehouse.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgv_warehouse_UserAddedRow);
            this.dgv_warehouse.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_warehouse_KeyDown);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tìm kiếm";
            // 
            // tb_find
            // 
            this.tb_find.Location = new System.Drawing.Point(118, 118);
            this.tb_find.Name = "tb_find";
            this.tb_find.Size = new System.Drawing.Size(248, 22);
            this.tb_find.TabIndex = 3;
            this.tb_find.TextChanged += new System.EventHandler(this.tb_find_TextChanged);
            // 
            // btn_addwarehouse
            // 
            this.btn_addwarehouse.Location = new System.Drawing.Point(106, 697);
            this.btn_addwarehouse.Name = "btn_addwarehouse";
            this.btn_addwarehouse.Size = new System.Drawing.Size(142, 45);
            this.btn_addwarehouse.TabIndex = 4;
            this.btn_addwarehouse.Text = "Thêm kho";
            this.btn_addwarehouse.UseVisualStyleBackColor = true;
            this.btn_addwarehouse.Click += new System.EventHandler(this.btn_addwarehouse_Click);
            // 
            // btn_editwarehouse
            // 
            this.btn_editwarehouse.Location = new System.Drawing.Point(767, 697);
            this.btn_editwarehouse.Name = "btn_editwarehouse";
            this.btn_editwarehouse.Size = new System.Drawing.Size(142, 45);
            this.btn_editwarehouse.TabIndex = 6;
            this.btn_editwarehouse.Text = "Sửa kho";
            this.btn_editwarehouse.UseVisualStyleBackColor = true;
            this.btn_editwarehouse.Click += new System.EventHandler(this.btn_editwarehouse_Click);
            // 
            // btn_deletewarehouse
            // 
            this.btn_deletewarehouse.Location = new System.Drawing.Point(430, 697);
            this.btn_deletewarehouse.Name = "btn_deletewarehouse";
            this.btn_deletewarehouse.Size = new System.Drawing.Size(142, 45);
            this.btn_deletewarehouse.TabIndex = 7;
            this.btn_deletewarehouse.Text = "Xóa kho";
            this.btn_deletewarehouse.UseVisualStyleBackColor = true;
            this.btn_deletewarehouse.Click += new System.EventHandler(this.btn_deletewarehouse_Click);
            // 
            // btn_undo
            // 
            this.btn_undo.Location = new System.Drawing.Point(1086, 697);
            this.btn_undo.Name = "btn_undo";
            this.btn_undo.Size = new System.Drawing.Size(142, 45);
            this.btn_undo.TabIndex = 8;
            this.btn_undo.Text = "Hoàn tác";
            this.btn_undo.UseVisualStyleBackColor = true;
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(1388, 697);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(142, 45);
            this.btn_exit.TabIndex = 9;
            this.btn_exit.Text = "Thoát";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // tb_nhaptenkho
            // 
            this.tb_nhaptenkho.Location = new System.Drawing.Point(1287, 118);
            this.tb_nhaptenkho.Name = "tb_nhaptenkho";
            this.tb_nhaptenkho.Size = new System.Drawing.Size(217, 22);
            this.tb_nhaptenkho.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1123, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 22);
            this.label3.TabIndex = 11;
            this.label3.Text = "Nhập Tên Kho";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // cbx_chuyenchinhanh
            // 
            this.cbx_chuyenchinhanh.FormattingEnabled = true;
            this.cbx_chuyenchinhanh.Location = new System.Drawing.Point(767, 120);
            this.cbx_chuyenchinhanh.Name = "cbx_chuyenchinhanh";
            this.cbx_chuyenchinhanh.Size = new System.Drawing.Size(179, 24);
            this.cbx_chuyenchinhanh.TabIndex = 16;
            this.cbx_chuyenchinhanh.SelectedIndexChanged += new System.EventHandler(this.cbx_chuyenchinhanh_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(653, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 22);
            this.label4.TabIndex = 17;
            this.label4.Text = "Chi nhánh";
            // 
            // FormWareHouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1557, 814);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbx_chuyenchinhanh);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_nhaptenkho);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_undo);
            this.Controls.Add(this.btn_deletewarehouse);
            this.Controls.Add(this.btn_editwarehouse);
            this.Controls.Add(this.btn_addwarehouse);
            this.Controls.Add(this.tb_find);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgv_warehouse);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormWareHouse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "FormWareHouse";
            this.Load += new System.EventHandler(this.FormWareHouse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_warehouse)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_warehouse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_find;
        private System.Windows.Forms.Button btn_addwarehouse;
        private System.Windows.Forms.Button btn_editwarehouse;
        private System.Windows.Forms.Button btn_deletewarehouse;
        private System.Windows.Forms.Button btn_undo;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.TextBox tb_nhaptenkho;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbx_chuyenchinhanh;
        private System.Windows.Forms.Label label4;
    }
}