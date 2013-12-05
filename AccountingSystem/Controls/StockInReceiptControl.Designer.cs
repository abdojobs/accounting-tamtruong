namespace AccountingSystem.Controls
{
    partial class StockInReceiptControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtCodeSearch = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dpMonth = new System.Windows.Forms.DateTimePicker();
            this.gridSearch = new System.Windows.Forms.DataGridView();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.cbbDiscount = new System.Windows.Forms.ComboBox();
            this.cbbTax = new System.Windows.Forms.ComboBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbAccounts = new System.Windows.Forms.Label();
            this.txtALDesription = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbbDeliveryPerson = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSupplierAddress = new System.Windows.Forms.TextBox();
            this.txtSupplierAccountNo = new System.Windows.Forms.TextBox();
            this.txtSupplierName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtWareHouse = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dpCreateDate = new System.Windows.Forms.DateTimePicker();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.gridStock = new System.Windows.Forms.DataGridView();
            this.cbbVatType = new MultiColumnComboBoxDemo.MultiColumnComboBox();
            this.cbbAccountClause = new MultiColumnComboBoxDemo.MultiColumnComboBox();
            this.cbbSupplier = new MultiColumnComboBoxDemo.MultiColumnComboBox();
            this.cbbWareHouse = new MultiColumnComboBoxDemo.MultiColumnComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridStock)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(1134, 561);
            this.splitContainer1.SplitterDistance = 213;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.gridSearch);
            this.splitContainer2.Size = new System.Drawing.Size(1134, 213);
            this.splitContainer2.SplitterDistance = 208;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPrint);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtCodeSearch);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dpMonth);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 213);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm Phiếu thu";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(12, 158);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(111, 44);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "In";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(12, 109);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(111, 44);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Xem";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // txtCodeSearch
            // 
            this.txtCodeSearch.Location = new System.Drawing.Point(12, 83);
            this.txtCodeSearch.Name = "txtCodeSearch";
            this.txtCodeSearch.Size = new System.Drawing.Size(111, 20);
            this.txtCodeSearch.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Số phiếu nhập kho";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Tháng/Năm";
            // 
            // dpMonth
            // 
            this.dpMonth.CustomFormat = "MM/yyyy";
            this.dpMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpMonth.Location = new System.Drawing.Point(12, 44);
            this.dpMonth.Name = "dpMonth";
            this.dpMonth.Size = new System.Drawing.Size(111, 20);
            this.dpMonth.TabIndex = 0;
            // 
            // gridSearch
            // 
            this.gridSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSearch.Location = new System.Drawing.Point(0, 0);
            this.gridSearch.Name = "gridSearch";
            this.gridSearch.Size = new System.Drawing.Size(922, 213);
            this.gridSearch.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.cbbDiscount);
            this.splitContainer3.Panel1.Controls.Add(this.cbbTax);
            this.splitContainer3.Panel1.Controls.Add(this.txtDescription);
            this.splitContainer3.Panel1.Controls.Add(this.label10);
            this.splitContainer3.Panel1.Controls.Add(this.label13);
            this.splitContainer3.Panel1.Controls.Add(this.label12);
            this.splitContainer3.Panel1.Controls.Add(this.cbbVatType);
            this.splitContainer3.Panel1.Controls.Add(this.label11);
            this.splitContainer3.Panel1.Controls.Add(this.lbAccounts);
            this.splitContainer3.Panel1.Controls.Add(this.txtALDesription);
            this.splitContainer3.Panel1.Controls.Add(this.cbbAccountClause);
            this.splitContainer3.Panel1.Controls.Add(this.label8);
            this.splitContainer3.Panel1.Controls.Add(this.cbbDeliveryPerson);
            this.splitContainer3.Panel1.Controls.Add(this.label6);
            this.splitContainer3.Panel1.Controls.Add(this.txtSupplierAddress);
            this.splitContainer3.Panel1.Controls.Add(this.txtSupplierAccountNo);
            this.splitContainer3.Panel1.Controls.Add(this.txtSupplierName);
            this.splitContainer3.Panel1.Controls.Add(this.cbbSupplier);
            this.splitContainer3.Panel1.Controls.Add(this.label5);
            this.splitContainer3.Panel1.Controls.Add(this.txtWareHouse);
            this.splitContainer3.Panel1.Controls.Add(this.cbbWareHouse);
            this.splitContainer3.Panel1.Controls.Add(this.label4);
            this.splitContainer3.Panel1.Controls.Add(this.label2);
            this.splitContainer3.Panel1.Controls.Add(this.label1);
            this.splitContainer3.Panel1.Controls.Add(this.dpCreateDate);
            this.splitContainer3.Panel1.Controls.Add(this.txtCode);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.gridStock);
            this.splitContainer3.Size = new System.Drawing.Size(1134, 344);
            this.splitContainer3.SplitterDistance = 158;
            this.splitContainer3.TabIndex = 0;
            // 
            // cbbDiscount
            // 
            this.cbbDiscount.FormattingEnabled = true;
            this.cbbDiscount.Location = new System.Drawing.Point(780, 90);
            this.cbbDiscount.Name = "cbbDiscount";
            this.cbbDiscount.Size = new System.Drawing.Size(64, 21);
            this.cbbDiscount.TabIndex = 40;
            // 
            // cbbTax
            // 
            this.cbbTax.FormattingEnabled = true;
            this.cbbTax.Location = new System.Drawing.Point(645, 90);
            this.cbbTax.Name = "cbbTax";
            this.cbbTax.Size = new System.Drawing.Size(65, 21);
            this.cbbTax.TabIndex = 39;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(116, 91);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(299, 20);
            this.txtDescription.TabIndex = 38;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(43, 94);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 13);
            this.label10.TabIndex = 37;
            this.label10.Text = "Lý do";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(716, 93);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(58, 13);
            this.label13.TabIndex = 35;
            this.label13.Text = "Chiết khấu";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(584, 93);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 13);
            this.label12.TabIndex = 33;
            this.label12.Text = "Thuế suất";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(415, 94);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 13);
            this.label11.TabIndex = 31;
            this.label11.Text = "01-02/GTGT";
            // 
            // lbAccounts
            // 
            this.lbAccounts.AutoSize = true;
            this.lbAccounts.Location = new System.Drawing.Point(716, 67);
            this.lbAccounts.Name = "lbAccounts";
            this.lbAccounts.Size = new System.Drawing.Size(101, 13);
            this.lbAccounts.TabIndex = 28;
            this.lbAccounts.Text = "Tài khoản liên quan";
            // 
            // txtALDesription
            // 
            this.txtALDesription.Location = new System.Drawing.Point(524, 64);
            this.txtALDesription.Name = "txtALDesription";
            this.txtALDesription.Size = new System.Drawing.Size(186, 20);
            this.txtALDesription.TabIndex = 27;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(286, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Hình thức NK";
            // 
            // cbbDeliveryPerson
            // 
            this.cbbDeliveryPerson.FormattingEnabled = true;
            this.cbbDeliveryPerson.Location = new System.Drawing.Point(116, 64);
            this.cbbDeliveryPerson.Name = "cbbDeliveryPerson";
            this.cbbDeliveryPerson.Size = new System.Drawing.Size(167, 21);
            this.cbbDeliveryPerson.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Người giao";
            // 
            // txtSupplierAddress
            // 
            this.txtSupplierAddress.Location = new System.Drawing.Point(655, 39);
            this.txtSupplierAddress.Name = "txtSupplierAddress";
            this.txtSupplierAddress.Size = new System.Drawing.Size(189, 20);
            this.txtSupplierAddress.TabIndex = 22;
            // 
            // txtSupplierAccountNo
            // 
            this.txtSupplierAccountNo.Location = new System.Drawing.Point(472, 39);
            this.txtSupplierAccountNo.Name = "txtSupplierAccountNo";
            this.txtSupplierAccountNo.Size = new System.Drawing.Size(177, 20);
            this.txtSupplierAccountNo.TabIndex = 21;
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.Location = new System.Drawing.Point(289, 39);
            this.txtSupplierName.Name = "txtSupplierName";
            this.txtSupplierName.Size = new System.Drawing.Size(177, 20);
            this.txtSupplierName.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Đơn vị giao";
            // 
            // txtWareHouse
            // 
            this.txtWareHouse.Location = new System.Drawing.Point(655, 13);
            this.txtWareHouse.Name = "txtWareHouse";
            this.txtWareHouse.Size = new System.Drawing.Size(189, 20);
            this.txtWareHouse.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(421, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Nhập tại kho";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(220, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Ngày ghi sổ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Số phiếu thu";
            // 
            // dpCreateDate
            // 
            this.dpCreateDate.CustomFormat = "dd/MM/yyyy";
            this.dpCreateDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpCreateDate.Location = new System.Drawing.Point(289, 13);
            this.dpCreateDate.Name = "dpCreateDate";
            this.dpCreateDate.Size = new System.Drawing.Size(126, 20);
            this.dpCreateDate.TabIndex = 13;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(116, 13);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(92, 20);
            this.txtCode.TabIndex = 12;
            // 
            // gridStock
            // 
            this.gridStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridStock.Location = new System.Drawing.Point(0, 0);
            this.gridStock.Name = "gridStock";
            this.gridStock.Size = new System.Drawing.Size(1134, 182);
            this.gridStock.TabIndex = 0;
            // 
            // cbbVatType
            // 
            this.cbbVatType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbbVatType.FormattingEnabled = true;
            this.cbbVatType.Location = new System.Drawing.Point(486, 90);
            this.cbbVatType.Name = "cbbVatType";
            this.cbbVatType.Size = new System.Drawing.Size(92, 21);
            this.cbbVatType.TabIndex = 32;
            // 
            // cbbAccountClause
            // 
            this.cbbAccountClause.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbbAccountClause.FormattingEnabled = true;
            this.cbbAccountClause.Location = new System.Drawing.Point(363, 64);
            this.cbbAccountClause.Name = "cbbAccountClause";
            this.cbbAccountClause.Size = new System.Drawing.Size(155, 21);
            this.cbbAccountClause.TabIndex = 26;
            // 
            // cbbSupplier
            // 
            this.cbbSupplier.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbbSupplier.FormattingEnabled = true;
            this.cbbSupplier.Location = new System.Drawing.Point(116, 39);
            this.cbbSupplier.Name = "cbbSupplier";
            this.cbbSupplier.Size = new System.Drawing.Size(167, 21);
            this.cbbSupplier.TabIndex = 19;
            // 
            // cbbWareHouse
            // 
            this.cbbWareHouse.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbbWareHouse.FormattingEnabled = true;
            this.cbbWareHouse.Location = new System.Drawing.Point(494, 12);
            this.cbbWareHouse.Name = "cbbWareHouse";
            this.cbbWareHouse.Size = new System.Drawing.Size(155, 21);
            this.cbbWareHouse.TabIndex = 16;
            // 
            // StockInReceiptControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "StockInReceiptControl";
            this.Size = new System.Drawing.Size(1134, 561);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSearch)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridStock)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView gridSearch;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtCodeSearch;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dpMonth;
        private System.Windows.Forms.DataGridView gridStock;
        private System.Windows.Forms.TextBox txtWareHouse;
        private MultiColumnComboBoxDemo.MultiColumnComboBox cbbWareHouse;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dpCreateDate;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtSupplierAddress;
        private System.Windows.Forms.TextBox txtSupplierAccountNo;
        private System.Windows.Forms.TextBox txtSupplierName;
        private MultiColumnComboBoxDemo.MultiColumnComboBox cbbSupplier;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbbDeliveryPerson;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private MultiColumnComboBoxDemo.MultiColumnComboBox cbbVatType;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbAccounts;
        private System.Windows.Forms.TextBox txtALDesription;
        private MultiColumnComboBoxDemo.MultiColumnComboBox cbbAccountClause;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbbDiscount;
        private System.Windows.Forms.ComboBox cbbTax;
    }
}
