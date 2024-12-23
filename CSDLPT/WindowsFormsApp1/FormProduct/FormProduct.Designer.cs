namespace WindowsFormsApp1
{
    partial class FormProduct
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
            this.tb_find = new System.Windows.Forms.TextBox();
            this.dgv_product = new System.Windows.Forms.DataGridView();
            this.btn_addProduct = new System.Windows.Forms.Button();
            this.btn_deleteProduct = new System.Windows.Forms.Button();
            this.btn_editProduct = new System.Windows.Forms.Button();
            this.btn_undo = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_product)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(555, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(521, 100);
            this.label1.TabIndex = 1;
            this.label1.Text = "Danh mục vật tư";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tìm kiếm";
            // 
            // tb_find
            // 
            this.tb_find.Location = new System.Drawing.Point(118, 118);
            this.tb_find.Name = "tb_find";
            this.tb_find.Size = new System.Drawing.Size(248, 22);
            this.tb_find.TabIndex = 4;
            this.tb_find.TextChanged += new System.EventHandler(this.tb_find_TextChanged);
            // 
            // dgv_product
            // 
            this.dgv_product.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_product.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv_product.Location = new System.Drawing.Point(12, 166);
            this.dgv_product.Name = "dgv_product";
            this.dgv_product.RowHeadersWidth = 51;
            this.dgv_product.RowTemplate.Height = 24;
            this.dgv_product.Size = new System.Drawing.Size(1725, 500);
            this.dgv_product.TabIndex = 5;
            this.dgv_product.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgv_product_CellBeginEdit);
            this.dgv_product.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_product_CellContentClick);
            this.dgv_product.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_product_CellContentClick);
            this.dgv_product.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_product_CellEndEdit);
            this.dgv_product.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_product_KeyDown);
            // 
            // btn_addProduct
            // 
            this.btn_addProduct.Location = new System.Drawing.Point(106, 697);
            this.btn_addProduct.Name = "btn_addProduct";
            this.btn_addProduct.Size = new System.Drawing.Size(142, 45);
            this.btn_addProduct.TabIndex = 6;
            this.btn_addProduct.Text = "Thêm vật tư";
            this.btn_addProduct.UseVisualStyleBackColor = true;
            this.btn_addProduct.Click += new System.EventHandler(this.btn_addProduct_Click);
            // 
            // btn_deleteProduct
            // 
            this.btn_deleteProduct.Location = new System.Drawing.Point(430, 697);
            this.btn_deleteProduct.Name = "btn_deleteProduct";
            this.btn_deleteProduct.Size = new System.Drawing.Size(142, 45);
            this.btn_deleteProduct.TabIndex = 8;
            this.btn_deleteProduct.Text = "Xóa vật tư";
            this.btn_deleteProduct.UseVisualStyleBackColor = true;
            // 
            // btn_editProduct
            // 
            this.btn_editProduct.Location = new System.Drawing.Point(767, 697);
            this.btn_editProduct.Name = "btn_editProduct";
            this.btn_editProduct.Size = new System.Drawing.Size(142, 45);
            this.btn_editProduct.TabIndex = 9;
            this.btn_editProduct.Text = "Sửa vật tư";
            this.btn_editProduct.UseVisualStyleBackColor = true;
            this.btn_editProduct.Click += new System.EventHandler(this.btn_editProduct_Click);
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
            // FormProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1557, 814);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_undo);
            this.Controls.Add(this.btn_editProduct);
            this.Controls.Add(this.btn_deleteProduct);
            this.Controls.Add(this.btn_addProduct);
            this.Controls.Add(this.dgv_product);
            this.Controls.Add(this.tb_find);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "FormProduct";
            this.Load += new System.EventHandler(this.FormProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_product)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_find;
        private System.Windows.Forms.DataGridView dgv_product;
        private System.Windows.Forms.Button btn_addProduct;
        private System.Windows.Forms.Button btn_deleteProduct;
        private System.Windows.Forms.Button btn_editProduct;
        private System.Windows.Forms.Button btn_undo;
        private System.Windows.Forms.Button btn_exit;
    }
}