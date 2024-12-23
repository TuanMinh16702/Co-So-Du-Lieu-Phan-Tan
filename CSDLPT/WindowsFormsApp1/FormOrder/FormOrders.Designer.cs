namespace WindowsFormsApp1
{
    partial class FormOrders
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
            this.dgv_order = new System.Windows.Forms.DataGridView();
            this.btn_addorder = new System.Windows.Forms.Button();
            this.btn_deleteorder = new System.Windows.Forms.Button();
            this.btn_editorder = new System.Windows.Forms.Button();
            this.btn_undo = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbx_chuyenchinhanh = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_order)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(571, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(802, 100);
            this.label1.TabIndex = 1;
            this.label1.Text = "Danh sách đơn đặt hàng";
            // 
            // dgv_order
            // 
            this.dgv_order.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_order.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv_order.Location = new System.Drawing.Point(12, 166);
            this.dgv_order.Name = "dgv_order";
            this.dgv_order.RowHeadersWidth = 51;
            this.dgv_order.RowTemplate.Height = 24;
            this.dgv_order.Size = new System.Drawing.Size(1725, 500);
            this.dgv_order.TabIndex = 2;
            this.dgv_order.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgv_order_CellBeginEdit);
            this.dgv_order.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_order_CellContentClick);
            this.dgv_order.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_order_CellEndEdit);
            this.dgv_order.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_order_KeyDown);
            // 
            // btn_addorder
            // 
            this.btn_addorder.Location = new System.Drawing.Point(106, 697);
            this.btn_addorder.Name = "btn_addorder";
            this.btn_addorder.Size = new System.Drawing.Size(142, 45);
            this.btn_addorder.TabIndex = 5;
            this.btn_addorder.Text = "Tạo đơn đặt hàng";
            this.btn_addorder.UseVisualStyleBackColor = true;
            this.btn_addorder.Click += new System.EventHandler(this.btn_addorder_Click);
            // 
            // btn_deleteorder
            // 
            this.btn_deleteorder.Location = new System.Drawing.Point(430, 697);
            this.btn_deleteorder.Name = "btn_deleteorder";
            this.btn_deleteorder.Size = new System.Drawing.Size(142, 45);
            this.btn_deleteorder.TabIndex = 8;
            this.btn_deleteorder.Text = "Xóa đơn đặt hàng";
            this.btn_deleteorder.UseVisualStyleBackColor = true;
            // 
            // btn_editorder
            // 
            this.btn_editorder.Location = new System.Drawing.Point(767, 697);
            this.btn_editorder.Name = "btn_editorder";
            this.btn_editorder.Size = new System.Drawing.Size(142, 45);
            this.btn_editorder.TabIndex = 9;
            this.btn_editorder.Text = "Sửa đơn đặt hàng";
            this.btn_editorder.UseVisualStyleBackColor = true;
            this.btn_editorder.Click += new System.EventHandler(this.btn_editorder_Click);
            // 
            // btn_undo
            // 
            this.btn_undo.Location = new System.Drawing.Point(1086, 697);
            this.btn_undo.Name = "btn_undo";
            this.btn_undo.Size = new System.Drawing.Size(142, 45);
            this.btn_undo.TabIndex = 10;
            this.btn_undo.Text = "Hoàn tác";
            this.btn_undo.UseVisualStyleBackColor = true;
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(1388, 697);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(142, 45);
            this.btn_exit.TabIndex = 11;
            this.btn_exit.Text = "Thoát";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1255, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 22);
            this.label2.TabIndex = 12;
            this.label2.Text = "Chi nhánh";
            // 
            // cbx_chuyenchinhanh
            // 
            this.cbx_chuyenchinhanh.FormattingEnabled = true;
            this.cbx_chuyenchinhanh.Location = new System.Drawing.Point(1353, 116);
            this.cbx_chuyenchinhanh.Name = "cbx_chuyenchinhanh";
            this.cbx_chuyenchinhanh.Size = new System.Drawing.Size(179, 24);
            this.cbx_chuyenchinhanh.TabIndex = 13;
            this.cbx_chuyenchinhanh.SelectedIndexChanged += new System.EventHandler(this.cbx_chuyenchinhanh_SelectedIndexChanged);
            // 
            // FormOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1557, 814);
            this.Controls.Add(this.cbx_chuyenchinhanh);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_undo);
            this.Controls.Add(this.btn_editorder);
            this.Controls.Add(this.btn_deleteorder);
            this.Controls.Add(this.btn_addorder);
            this.Controls.Add(this.dgv_order);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormOrders";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "FormOrder";
            this.Load += new System.EventHandler(this.FormOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_order)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_order;
        private System.Windows.Forms.Button btn_addorder;
        private System.Windows.Forms.Button btn_deleteorder;
        private System.Windows.Forms.Button btn_editorder;
        private System.Windows.Forms.Button btn_undo;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbx_chuyenchinhanh;
    }
}