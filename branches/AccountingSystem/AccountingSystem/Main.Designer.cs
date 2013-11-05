namespace AccountingSystem
{
    partial class Main
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
            this.ptop = new System.Windows.Forms.Panel();
            this.combo = new System.Windows.Forms.ComboBox();
            this.plcontainer = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gridCombobox1 = new AccountingSystem.Components.GridComboBox();
            this.ptop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plcontainer)).BeginInit();
            this.plcontainer.Panel1.SuspendLayout();
            this.plcontainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCombobox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ptop
            // 
            this.ptop.Controls.Add(this.splitContainer1);
            this.ptop.Dock = System.Windows.Forms.DockStyle.Top;
            this.ptop.Location = new System.Drawing.Point(0, 0);
            this.ptop.Name = "ptop";
            this.ptop.Size = new System.Drawing.Size(816, 100);
            this.ptop.TabIndex = 0;
            // 
            // combo
            // 
            this.combo.FormattingEnabled = true;
            this.combo.Location = new System.Drawing.Point(76, 12);
            this.combo.Name = "combo";
            this.combo.Size = new System.Drawing.Size(121, 21);
            this.combo.TabIndex = 1;
            // 
            // plcontainer
            // 
            this.plcontainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plcontainer.Location = new System.Drawing.Point(0, 100);
            this.plcontainer.Name = "plcontainer";
            // 
            // plcontainer.Panel1
            // 
            this.plcontainer.Panel1.Controls.Add(this.dataGridView1);
            this.plcontainer.Size = new System.Drawing.Size(816, 162);
            this.plcontainer.SplitterDistance = 150;
            this.plcontainer.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(150, 162);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.NewRowNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView1_NewRowNeeded);
            this.dataGridView1.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowLeave);
            this.dataGridView1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
            this.dataGridView1.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dataGridView1_RowStateChanged);
            this.dataGridView1.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView1_UserAddedRow);
            this.dataGridView1.Enter += new System.EventHandler(this.dataGridView1_Enter);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.combo);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridCombobox1);
            this.splitContainer1.Size = new System.Drawing.Size(816, 100);
            this.splitContainer1.SplitterDistance = 272;
            this.splitContainer1.TabIndex = 0;
            // 
            // gridCombobox1
            // 
            this.gridCombobox1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCombobox1.comboboxColumn = null;
            this.gridCombobox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCombobox1.Location = new System.Drawing.Point(0, 0);
            this.gridCombobox1.Name = "gridCombobox1";
            this.gridCombobox1.Size = new System.Drawing.Size(540, 100);
            this.gridCombobox1.TabIndex = 2;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 262);
            this.Controls.Add(this.plcontainer);
            this.Controls.Add(this.ptop);
            this.Name = "Main";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ptop.ResumeLayout(false);
            this.plcontainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.plcontainer)).EndInit();
            this.plcontainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCombobox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ptop;
        private System.Windows.Forms.SplitContainer plcontainer;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox combo;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Components.GridComboBox gridCombobox1;

    }
}

