namespace AccountingSystem.Controls
{
    partial class ReceiptControl
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
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtAcLDesription = new System.Windows.Forms.TextBox();
            this.cbbAccountClause = new MultiColumnComboBoxDemo.MultiColumnComboBox();
            this.cbbPersonDelievery = new MultiColumnComboBoxDemo.MultiColumnComboBox();
            this.txtCAddress = new System.Windows.Forms.TextBox();
            this.cbbCName = new MultiColumnComboBoxDemo.MultiColumnComboBox();
            this.cbbCCode = new MultiColumnComboBoxDemo.MultiColumnComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dpCreateDate = new System.Windows.Forms.DateTimePicker();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.gridBalanceAccount = new System.Windows.Forms.DataGridView();
            this.gridBill = new System.Windows.Forms.DataGridView();
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
            ((System.ComponentModel.ISupportInitialize)(this.gridBalanceAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBill)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.gridReceipts);
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
            this.gridReceipts.Size = new System.Drawing.Size(1024, 208);
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
            this.splitContainer2.Panel2.Controls.Add(this.gridBill);
            this.splitContainer2.Size = new System.Drawing.Size(1024, 302);
            this.splitContainer2.SplitterDistance = 106;
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
            this.splitContainer3.Panel1.Controls.Add(this.label6);
            this.splitContainer3.Panel1.Controls.Add(this.label5);
            this.splitContainer3.Panel1.Controls.Add(this.label4);
            this.splitContainer3.Panel1.Controls.Add(this.label3);
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
            this.splitContainer3.Panel2.Controls.Add(this.gridBalanceAccount);
            this.splitContainer3.Size = new System.Drawing.Size(1024, 106);
            this.splitContainer3.SplitterDistance = 770;
            this.splitContainer3.TabIndex = 0;
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
            this.label5.Location = new System.Drawing.Point(18, 68);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Đối tượng thu";
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
            this.txtAcLDesription.Location = new System.Drawing.Point(213, 66);
            this.txtAcLDesription.Name = "txtAcLDesription";
            this.txtAcLDesription.Size = new System.Drawing.Size(290, 20);
            this.txtAcLDesription.TabIndex = 8;
            // 
            // cbbAccountClause
            // 
            this.cbbAccountClause.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbbAccountClause.FormattingEnabled = true;
            this.cbbAccountClause.Location = new System.Drawing.Point(86, 65);
            this.cbbAccountClause.Name = "cbbAccountClause";
            this.cbbAccountClause.Size = new System.Drawing.Size(121, 21);
            this.cbbAccountClause.TabIndex = 7;
            // 
            // cbbPersonDelievery
            // 
            this.cbbPersonDelievery.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbbPersonDelievery.FormattingEnabled = true;
            this.cbbPersonDelievery.Location = new System.Drawing.Point(575, 39);
            this.cbbPersonDelievery.Name = "cbbPersonDelievery";
            this.cbbPersonDelievery.Size = new System.Drawing.Size(190, 21);
            this.cbbPersonDelievery.TabIndex = 6;
            // 
            // txtCAddress
            // 
            this.txtCAddress.Location = new System.Drawing.Point(372, 39);
            this.txtCAddress.Name = "txtCAddress";
            this.txtCAddress.Size = new System.Drawing.Size(131, 20);
            this.txtCAddress.TabIndex = 5;
            // 
            // cbbCName
            // 
            this.cbbCName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbbCName.FormattingEnabled = true;
            this.cbbCName.Location = new System.Drawing.Point(168, 38);
            this.cbbCName.Name = "cbbCName";
            this.cbbCName.Size = new System.Drawing.Size(198, 21);
            this.cbbCName.TabIndex = 4;
            // 
            // cbbCCode
            // 
            this.cbbCCode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbbCCode.FormattingEnabled = true;
            this.cbbCCode.Location = new System.Drawing.Point(86, 38);
            this.cbbCCode.Name = "cbbCCode";
            this.cbbCCode.Size = new System.Drawing.Size(76, 21);
            this.cbbCCode.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(338, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Số phiếu thu";
            // 
            // dpCreateDate
            // 
            this.dpCreateDate.Location = new System.Drawing.Point(575, 13);
            this.dpCreateDate.Name = "dpCreateDate";
            this.dpCreateDate.Size = new System.Drawing.Size(126, 20);
            this.dpCreateDate.TabIndex = 2;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(411, 13);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(92, 20);
            this.txtCode.TabIndex = 1;
            // 
            // gridBalanceAccount
            // 
            this.gridBalanceAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridBalanceAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridBalanceAccount.Location = new System.Drawing.Point(0, 0);
            this.gridBalanceAccount.Name = "gridBalanceAccount";
            this.gridBalanceAccount.Size = new System.Drawing.Size(250, 106);
            this.gridBalanceAccount.TabIndex = 0;
            // 
            // gridBill
            // 
            this.gridBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridBill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridBill.Location = new System.Drawing.Point(0, 0);
            this.gridBill.Name = "gridBill";
            this.gridBill.Size = new System.Drawing.Size(1024, 192);
            this.gridBill.TabIndex = 0;
            // 
            // ReceiptControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ReceiptControl";
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
            ((System.ComponentModel.ISupportInitialize)(this.gridBalanceAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBill)).EndInit();
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
        private MultiColumnComboBoxDemo.MultiColumnComboBox cbbPersonDelievery;
        private System.Windows.Forms.TextBox txtCAddress;
        private MultiColumnComboBoxDemo.MultiColumnComboBox cbbCName;
        private MultiColumnComboBoxDemo.MultiColumnComboBox cbbCCode;
        private System.Windows.Forms.DataGridView gridBalanceAccount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView gridBill;
    }
}
