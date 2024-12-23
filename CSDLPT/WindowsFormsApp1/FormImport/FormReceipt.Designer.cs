namespace WindowsFormsApp1.FormImport
{
    partial class FormReceipt
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
            this.dgv_receipt = new System.Windows.Forms.DataGridView();
            this.btn_addreceipt = new System.Windows.Forms.Button();
            this.btn_deletereceipt = new System.Windows.Forms.Button();
            this.btn_editreceipt = new System.Windows.Forms.Button();
            this.btn_undo = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.cbx_chuyenchinhanh = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_receipt)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(557, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(879, 100);
            this.label1.TabIndex = 2;
            this.label1.Text = "Danh sách phiếu nhập";
            // 
            // dgv_receipt
            // 
            this.dgv_receipt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_receipt.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv_receipt.Location = new System.Drawing.Point(12, 166);
            this.dgv_receipt.Name = "dgv_receipt";
            this.dgv_receipt.RowHeadersWidth = 51;
            this.dgv_receipt.RowTemplate.Height = 24;
            this.dgv_receipt.Size = new System.Drawing.Size(1725, 500);
            this.dgv_receipt.TabIndex = 3;
            this.dgv_receipt.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_invoice_CellContentClick);
            this.dgv_receipt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_receipt_KeyDown);
            // 
            // btn_addreceipt
            // 
            this.btn_addreceipt.Location = new System.Drawing.Point(106, 697);
            this.btn_addreceipt.Name = "btn_addreceipt";
            this.btn_addreceipt.Size = new System.Drawing.Size(142, 45);
            this.btn_addreceipt.TabIndex = 6;
            this.btn_addreceipt.Text = "Tạo Phiếu Nhập";
            this.btn_addreceipt.UseVisualStyleBackColor = true;
            this.btn_addreceipt.Click += new System.EventHandler(this.btn_addreceipt_Click);
            // 
            // btn_deletereceipt
            // 
            this.btn_deletereceipt.Location = new System.Drawing.Point(430, 697);
            this.btn_deletereceipt.Name = "btn_deletereceipt";
            this.btn_deletereceipt.Size = new System.Drawing.Size(142, 45);
            this.btn_deletereceipt.TabIndex = 9;
            this.btn_deletereceipt.Text = "Xóa phiếu nhập";
            this.btn_deletereceipt.UseVisualStyleBackColor = true;
            // 
            // btn_editreceipt
            // 
            this.btn_editreceipt.Location = new System.Drawing.Point(767, 697);
            this.btn_editreceipt.Name = "btn_editreceipt";
            this.btn_editreceipt.Size = new System.Drawing.Size(142, 45);
            this.btn_editreceipt.TabIndex = 10;
            this.btn_editreceipt.Text = "Sửa phiếu nhập";
            this.btn_editreceipt.UseVisualStyleBackColor = true;
            this.btn_editreceipt.Click += new System.EventHandler(this.btn_editreceipt_Click);
            // 
            // btn_undo
            // 
            this.btn_undo.Location = new System.Drawing.Point(1086, 697);
            this.btn_undo.Name = "btn_undo";
            this.btn_undo.Size = new System.Drawing.Size(142, 45);
            this.btn_undo.TabIndex = 11;
            this.btn_undo.Text = "Hoàn tác";
            this.btn_undo.UseVisualStyleBackColor = true;
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(1388, 697);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(142, 45);
            this.btn_exit.TabIndex = 12;
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
            this.cbx_chuyenchinhanh.TabIndex = 14;
            this.cbx_chuyenchinhanh.SelectedIndexChanged += new System.EventHandler(this.cbx_chuyenchinhanh_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1255, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 22);
            this.label2.TabIndex = 15;
            this.label2.Text = "Chi nhánh";
            // 
            // FormReceipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1557, 814);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbx_chuyenchinhanh);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_undo);
            this.Controls.Add(this.btn_editreceipt);
            this.Controls.Add(this.btn_deletereceipt);
            this.Controls.Add(this.btn_addreceipt);
            this.Controls.Add(this.dgv_receipt);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormReceipt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "FormReceipt";
            this.Load += new System.EventHandler(this.FormReceipt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_receipt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_receipt;
        private System.Windows.Forms.Button btn_addreceipt;
        private System.Windows.Forms.Button btn_deletereceipt;
        private System.Windows.Forms.Button btn_editreceipt;
        private System.Windows.Forms.Button btn_undo;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.ComboBox cbx_chuyenchinhanh;
        private System.Windows.Forms.Label label2;
    }
}