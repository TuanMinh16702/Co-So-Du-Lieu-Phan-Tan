namespace WindowsFormsApp1.FormBill
{
    partial class FormRedInvoice
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
            this.dgv_invoice = new System.Windows.Forms.DataGridView();
            this.btn_addinvoice = new System.Windows.Forms.Button();
            this.btn_undo = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.cbx_chuyenchinhanh = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_invoice)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(451, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(605, 100);
            this.label1.TabIndex = 1;
            this.label1.Text = "Danh sách hóa đơn";
            // 
            // dgv_invoice
            // 
            this.dgv_invoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_invoice.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv_invoice.Location = new System.Drawing.Point(12, 166);
            this.dgv_invoice.Name = "dgv_invoice";
            this.dgv_invoice.RowHeadersWidth = 51;
            this.dgv_invoice.RowTemplate.Height = 24;
            this.dgv_invoice.Size = new System.Drawing.Size(1725, 500);
            this.dgv_invoice.TabIndex = 2;
            this.dgv_invoice.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_invoice_CellContentClick);
            // 
            // btn_addinvoice
            // 
            this.btn_addinvoice.Location = new System.Drawing.Point(375, 697);
            this.btn_addinvoice.Name = "btn_addinvoice";
            this.btn_addinvoice.Size = new System.Drawing.Size(142, 45);
            this.btn_addinvoice.TabIndex = 5;
            this.btn_addinvoice.Text = "Tạo Hóa Đơn";
            this.btn_addinvoice.UseVisualStyleBackColor = true;
            this.btn_addinvoice.Click += new System.EventHandler(this.btn_addinvoice_Click);
            // 
            // btn_undo
            // 
            this.btn_undo.Location = new System.Drawing.Point(723, 697);
            this.btn_undo.Name = "btn_undo";
            this.btn_undo.Size = new System.Drawing.Size(142, 45);
            this.btn_undo.TabIndex = 10;
            this.btn_undo.Text = "Hoàn tác";
            this.btn_undo.UseVisualStyleBackColor = true;
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(1080, 697);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(142, 45);
            this.btn_exit.TabIndex = 11;
            this.btn_exit.Text = "Thoát";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // cbx_chuyenchinhanh
            // 
            this.cbx_chuyenchinhanh.FormattingEnabled = true;
            this.cbx_chuyenchinhanh.Location = new System.Drawing.Point(1353, 116);
            this.cbx_chuyenchinhanh.Name = "cbx_chuyenchinhanh";
            this.cbx_chuyenchinhanh.Size = new System.Drawing.Size(179, 24);
            this.cbx_chuyenchinhanh.TabIndex = 15;
            this.cbx_chuyenchinhanh.SelectedIndexChanged += new System.EventHandler(this.cbx_chuyenchinhanh_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1255, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 22);
            this.label2.TabIndex = 16;
            this.label2.Text = "Chi nhánh";
            // 
            // FormRedInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1557, 814);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbx_chuyenchinhanh);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_undo);
            this.Controls.Add(this.btn_addinvoice);
            this.Controls.Add(this.dgv_invoice);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormRedInvoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "FormRedInvoice";
            this.Load += new System.EventHandler(this.FormRedInvoice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_invoice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_invoice;
        private System.Windows.Forms.Button btn_addinvoice;
        private System.Windows.Forms.Button btn_undo;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.ComboBox cbx_chuyenchinhanh;
        private System.Windows.Forms.Label label2;
    }
}