namespace AccountingSystem.Controls
{
    partial class AccountControl
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
            this.gridAccount1 = new AccountingSystem.Components.AccountGrid();
            this.gridAccount2 = new AccountingSystem.Components.AccountGrid();
            this.gridAccount3 = new AccountingSystem.Components.AccountGrid();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAccount1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAccount2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAccount3)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gridAccount1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(788, 316);
            this.splitContainer1.SplitterDistance = 262;
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
            this.splitContainer2.Panel1.Controls.Add(this.gridAccount2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.gridAccount3);
            this.splitContainer2.Size = new System.Drawing.Size(522, 316);
            this.splitContainer2.SplitterDistance = 225;
            this.splitContainer2.TabIndex = 0;
            // 
            // gridAccount1
            // 
            this.gridAccount1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAccount1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAccount1.Location = new System.Drawing.Point(0, 0);
            this.gridAccount1.Name = "gridAccount1";
            this.gridAccount1.Size = new System.Drawing.Size(262, 316);
            this.gridAccount1.TabIndex = 0;
            // 
            // gridAccount2
            // 
            this.gridAccount2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAccount2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAccount2.Location = new System.Drawing.Point(0, 0);
            this.gridAccount2.Name = "gridAccount2";
            this.gridAccount2.Size = new System.Drawing.Size(225, 316);
            this.gridAccount2.TabIndex = 0;
            // 
            // gridAccount3
            // 
            this.gridAccount3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAccount3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAccount3.Location = new System.Drawing.Point(0, 0);
            this.gridAccount3.Name = "gridAccount3";
            this.gridAccount3.Size = new System.Drawing.Size(293, 316);
            this.gridAccount3.TabIndex = 0;
            // 
            // AccountControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "AccountControl";
            this.Size = new System.Drawing.Size(788, 316);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAccount1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAccount2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAccount3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Components.AccountGrid gridAccount2;
        private Components.AccountGrid gridAccount3;
        public Components.AccountGrid gridAccount1;


    }
}
