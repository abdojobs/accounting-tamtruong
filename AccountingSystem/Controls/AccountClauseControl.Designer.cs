using System.Windows.Forms;
using AccountingSystem.Components;
namespace AccountingSystem.Controls
{
    partial class AccountClauseControl
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
            this.spcMain = new System.Windows.Forms.SplitContainer();
            this.gridAccountClause = new AccountingSystem.Components.AccountClauseGrid();
            this.spcAccount = new System.Windows.Forms.SplitContainer();
            this.gridAR = new GridComboBox();
            this.gridAD = new GridComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).BeginInit();
            this.spcMain.Panel1.SuspendLayout();
            this.spcMain.Panel2.SuspendLayout();
            this.spcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAccountClause)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spcAccount)).BeginInit();
            this.spcAccount.Panel1.SuspendLayout();
            this.spcAccount.Panel2.SuspendLayout();
            this.spcAccount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAD)).BeginInit();
            this.SuspendLayout();
            // 
            // spcMain
            // 
            this.spcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcMain.ForeColor = System.Drawing.SystemColors.WindowText;
            this.spcMain.Location = new System.Drawing.Point(0, 0);
            this.spcMain.Name = "spcMain";
            this.spcMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcMain.Panel1
            // 
            this.spcMain.Panel1.Controls.Add(this.gridAccountClause);
            // 
            // spcMain.Panel2
            // 
            this.spcMain.Panel2.Controls.Add(this.spcAccount);
            this.spcMain.Size = new System.Drawing.Size(855, 150);
            this.spcMain.SplitterDistance = 80;
            this.spcMain.TabIndex = 0;
            // 
            // gridAccountClause
            // 
            this.gridAccountClause.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAccountClause.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAccountClause.Location = new System.Drawing.Point(0, 0);
            this.gridAccountClause.Name = "gridAccountClause";
            this.gridAccountClause.Size = new System.Drawing.Size(855, 80);
            this.gridAccountClause.TabIndex = 0;
            // 
            // spcAccount
            // 
            this.spcAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcAccount.Location = new System.Drawing.Point(0, 0);
            this.spcAccount.Name = "spcAccount";
            // 
            // spcAccount.Panel1
            // 
            this.spcAccount.Panel1.Controls.Add(this.gridAR);
            // 
            // spcAccount.Panel2
            // 
            this.spcAccount.Panel2.Controls.Add(this.gridAD);
            this.spcAccount.Size = new System.Drawing.Size(855, 66);
            this.spcAccount.SplitterDistance = 417;
            this.spcAccount.TabIndex = 0;
            // 
            // gridAR
            // 
            this.gridAR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAR.Location = new System.Drawing.Point(0, 0);
            this.gridAR.Name = "gridAR";
            this.gridAR.Size = new System.Drawing.Size(417, 66);
            this.gridAR.TabIndex = 0;
            // 
            // gridAD
            // 
            this.gridAD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAD.Location = new System.Drawing.Point(0, 0);
            this.gridAD.Name = "gridAD";
            this.gridAD.Size = new System.Drawing.Size(434, 66);
            this.gridAD.TabIndex = 0;
            // 
            // AccountClauseControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.spcMain);
            this.Name = "AccountClauseControl";
            this.Size = new System.Drawing.Size(855, 150);
            this.Load += new System.EventHandler(this.AccountClauseControl_Load);
            this.spcMain.Panel1.ResumeLayout(false);
            this.spcMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).EndInit();
            this.spcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAccountClause)).EndInit();
            this.spcAccount.Panel1.ResumeLayout(false);
            this.spcAccount.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcAccount)).EndInit();
            this.spcAccount.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer spcMain;
        private System.Windows.Forms.SplitContainer spcAccount;
        private Components.AccountClauseGrid gridAccountClause;
        private GridComboBox gridAR;
        private GridComboBox gridAD;
    }
}
