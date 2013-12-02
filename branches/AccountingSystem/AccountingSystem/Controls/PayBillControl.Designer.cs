using System.Windows.Forms;
namespace AccountingSystem.Controls
{
    partial class PayBillControl
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
            this.gridReceipts = new System.Windows.Forms.DataGridView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.btnSave = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtAcLDesription = new System.Windows.Forms.TextBox();
            this.cbbPersonDelievery = new System.Windows.Forms.ComboBox();
            this.txtCAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dpCreateDate = new System.Windows.Forms.DateTimePicker();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.gridBalanceAccounts = new System.Windows.Forms.DataGridView();
            this.gridInvoices = new System.Windows.Forms.DataGridView();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.dpMonth = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCodeSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.cbbAccountClause = new MultiColumnComboBoxDemo.MultiColumnComboBox();
            this.cbbCName = new MultiColumnComboBoxDemo.MultiColumnComboBox();
            this.cbbCCode = new MultiColumnComboBoxDemo.MultiColumnComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lbDebtAccount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridReceipts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBalanceAccounts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridInvoices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1024, 514);
            this.splitContainer1.SplitterDistance = 208;
            this.splitContainer1.TabIndex = 0;
            // 
            // gridReceipts
            // 
            this.gridReceipts.AllowUserToAddRows = false;
            this.gridReceipts.AllowUserToDeleteRows = false;
            this.gridReceipts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridReceipts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridReceipts.Location = new System.Drawing.Point(0, 0);
            this.gridReceipts.Name = "gridReceipts";
            this.gridReceipts.ReadOnly = true;
            this.gridReceipts.Size = new System.Drawing.Size(891, 208);
            this.gridReceipts.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.gridInvoices);
            this.splitContainer2.Size = new System.Drawing.Size(1024, 302);
            this.splitContainer2.SplitterDistance = 140;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.lbDebtAccount);
            this.splitContainer3.Panel1.Controls.Add(this.label8);
            this.splitContainer3.Panel1.Controls.Add(this.btnSave);
            this.splitContainer3.Panel1.Controls.Add(this.label6);
            this.splitContainer3.Panel1.Controls.Add(this.label5);
            this.splitContainer3.Panel1.Controls.Add(this.label4);
            this.splitContainer3.Panel1.Controls.Add(this.label2);
            this.splitContainer3.Panel1.Controls.Add(this.txtAmount);
            this.splitContainer3.Panel1.Controls.Add(this.txtAcLDesription);
            this.splitContainer3.Panel1.Controls.Add(this.cbbAccountClause);
            this.splitContainer3.Panel1.Controls.Add(this.cbbPersonDelievery);
            this.splitContainer3.Panel1.Controls.Add(this.txtCAddress);
            this.splitContainer3.Panel1.Controls.Add(this.cbbCName);
            this.splitContainer3.Panel1.Controls.Add(this.cbbCCode);
            this.splitContainer3.Panel1.Controls.Add(this.label1);
            this.splitContainer3.Panel1.Controls.Add(this.dpCreateDate);
            this.splitContainer3.Panel1.Controls.Add(this.txtCode);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.gridBalanceAccounts);
            this.splitContainer3.Size = new System.Drawing.Size(1024, 140);
            this.splitContainer3.SplitterDistance = 770;
            this.splitContainer3.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(575, 91);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(126, 43);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Lưu Phiếu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(517, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Tổng tiền";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Nội dung thu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(513, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Người nộp";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(506, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Ngày ghi sổ";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(575, 65);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(126, 20);
            this.txtAmount.TabIndex = 9;
            // 
            // txtAcLDesription
            // 
            this.txtAcLDesription.Location = new System.Drawing.Point(204, 66);
            this.txtAcLDesription.Name = "txtAcLDesription";
            this.txtAcLDesription.Size = new System.Drawing.Size(290, 20);
            this.txtAcLDesription.TabIndex = 8;
            // 
            // cbbPersonDelievery
            // 
            this.cbbPersonDelievery.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbbPersonDelievery.FormattingEnabled = true;
            this.cbbPersonDelievery.Location = new System.Drawing.Point(575, 39);
            this.cbbPersonDelievery.Name = "cbbPersonDelievery";
            this.cbbPersonDelievery.Size = new System.Drawing.Size(177, 21);
            this.cbbPersonDelievery.TabIndex = 6;
            // 
            // txtCAddress
            // 
            this.txtCAddress.Location = new System.Drawing.Point(363, 39);
            this.txtCAddress.Name = "txtCAddress";
            this.txtCAddress.Size = new System.Drawing.Size(132, 20);
            this.txtCAddress.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(329, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Số phiếu thu";
            // 
            // dpCreateDate
            // 
            this.dpCreateDate.CustomFormat = "dd/MM/yyyy";
            this.dpCreateDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpCreateDate.Location = new System.Drawing.Point(575, 13);
            this.dpCreateDate.Name = "dpCreateDate";
            this.dpCreateDate.Size = new System.Drawing.Size(126, 20);
            this.dpCreateDate.TabIndex = 2;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(402, 13);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(92, 20);
            this.txtCode.TabIndex = 1;
            // 
            // gridBalanceAccounts
            // 
            this.gridBalanceAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridBalanceAccounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridBalanceAccounts.Location = new System.Drawing.Point(0, 0);
            this.gridBalanceAccounts.Name = "gridBalanceAccounts";
            this.gridBalanceAccounts.Size = new System.Drawing.Size(250, 140);
            this.gridBalanceAccounts.TabIndex = 0;
            // 
            // gridInvoices
            // 
            this.gridInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridInvoices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridInvoices.Location = new System.Drawing.Point(0, 0);
            this.gridInvoices.Name = "gridInvoices";
            this.gridInvoices.Size = new System.Drawing.Size(1024, 158);
            this.gridInvoices.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.gridReceipts);
            this.splitContainer4.Size = new System.Drawing.Size(1024, 208);
            this.splitContainer4.SplitterDistance = 129;
            this.splitContainer4.TabIndex = 0;
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
            this.groupBox1.Size = new System.Drawing.Size(129, 208);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm Phiếu thu";
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Số phiếu thu";
            // 
            // txtCodeSearch
            // 
            this.txtCodeSearch.Location = new System.Drawing.Point(12, 83);
            this.txtCodeSearch.Name = "txtCodeSearch";
            this.txtCodeSearch.Size = new System.Drawing.Size(111, 20);
            this.txtCodeSearch.TabIndex = 14;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(12, 109);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(111, 44);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Xem";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
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
            // cbbAccountClause
            // 
            this.cbbAccountClause.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbbAccountClause.FormattingEnabled = true;
            this.cbbAccountClause.Location = new System.Drawing.Point(77, 65);
            this.cbbAccountClause.Name = "cbbAccountClause";
            this.cbbAccountClause.Size = new System.Drawing.Size(121, 21);
            this.cbbAccountClause.TabIndex = 7;
            // 
            // cbbCName
            // 
            this.cbbCName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbbCName.FormattingEnabled = true;
            this.cbbCName.Location = new System.Drawing.Point(159, 38);
            this.cbbCName.Name = "cbbCName";
            this.cbbCName.Size = new System.Drawing.Size(198, 21);
            this.cbbCName.TabIndex = 4;
            // 
            // cbbCCode
            // 
            this.cbbCCode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbbCCode.FormattingEnabled = true;
            this.cbbCCode.Location = new System.Drawing.Point(77, 38);
            this.cbbCCode.Name = "cbbCCode";
            this.cbbCCode.Size = new System.Drawing.Size(76, 21);
            this.cbbCCode.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 106);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Tài khoản nợ:";
            // 
            // lbDebtAccount
            // 
            this.lbDebtAccount.AutoSize = true;
            this.lbDebtAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbDebtAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDebtAccount.ForeColor = System.Drawing.Color.OrangeRed;
            this.lbDebtAccount.Location = new System.Drawing.Point(77, 101);
            this.lbDebtAccount.Name = "lbDebtAccount";
            this.lbDebtAccount.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbDebtAccount.Size = new System.Drawing.Size(124, 22);
            this.lbDebtAccount.TabIndex = 17;
            this.lbDebtAccount.Text = "Tài khoản nợ";
            // 
            // ReceiptControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "PayBillControl";
            this.Size = new System.Drawing.Size(1024, 514);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridReceipts)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridBalanceAccounts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridInvoices)).EndInit();
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView gridReceipts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dpCreateDate;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox txtAcLDesription;
        private MultiColumnComboBoxDemo.MultiColumnComboBox cbbAccountClause;
        private ComboBox cbbPersonDelievery;
        private System.Windows.Forms.TextBox txtCAddress;
        private MultiColumnComboBoxDemo.MultiColumnComboBox cbbCName;
        private MultiColumnComboBoxDemo.MultiColumnComboBox cbbCCode;
        private System.Windows.Forms.DataGridView gridBalanceAccounts;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView gridInvoices;
        private Button btnSave;
        private SplitContainer splitContainer4;
        private DateTimePicker dpMonth;
        private GroupBox groupBox1;
        private Button btnPrint;
        private Button btnSearch;
        private TextBox txtCodeSearch;
        private Label label7;
        private Label label3;
        private Label lbDebtAccount;
        private Label label8;
    }
}
