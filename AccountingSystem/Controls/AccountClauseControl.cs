﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.Business.ServiceInterfaces;
using Business.Business;
using DataAccess.Entities;
using Common.Messages;
using Common.Logs;
using Common.Exceptions;
using AccountBusiness.Models;
using System.Data.Entity;
using AccountingSystem.Components;

namespace AccountingSystem.Controls
{
    public partial class AccountClauseControl : UserControl
    {
        IAccountClauseBusiness _accountClauseService;
        IAccountClauseBusiness accountClauseService {
            get {
                if (_accountClauseService==null)
                    _accountClauseService = new AccountClauseService();
                return _accountClauseService;
            }
        }
        IAccountBusiness _accountService;
        IAccountBusiness accountService
        {
            get
            {
                if (_accountService == null)
                    _accountService = new AccountService();
                return _accountService;
            }
        }
        BindingSource _proceduceType;
        BindingSource proceduceType
        {
            get {
                if (_proceduceType == null)
                {
                    _proceduceType = new BindingSource();
                    var result = accountClauseService.GetProceduceTypes().ToList();
                    result.Add(new ProceduceType() { Id = 0, Code = string.Empty, Description = string.Empty });
                    _proceduceType.DataSource = result;
                }
                return _proceduceType;
            }
        }
        DataTable _accountList;
        DataTable accountList
        {
            get {
                if (_accountList == null)
                {
                    _accountList = new DataTable();
                    _accountList.Columns.Add("Id");
                    _accountList.Columns.Add("Code");
                    _accountList.Columns.Add("Description");
                    var query = accountService.GetAll();
                    //BindingSource db = new BindingSource();
                    //_accountList = new BindingSource();
                    //db.DataSource = query;
                    //query.Add(new Account() { Id = 0, Description = "[Chọn tài khoản]", Code = "[Chọn tài khoản]" });
                    foreach (var r in query)
                    {
                        _accountList.Rows.Add(new object[] { r.Id, r.Code,r.Description });
                    }
                }
                return _accountList;
            }
        }
        DataTable tbAccountDebts;
        DataTable tbAccountRecs;
        DataTable _accountRList;
        DataTable accountRList
        {
            get
            {
                if (_accountRList == null)
                {
                    _accountRList = new DataTable();
                    _accountRList.Columns.Add("Id");
                    _accountRList.Columns.Add("Code");
                    _accountRList.Columns.Add("Description");
                    var query = accountService.GetAll();
                    foreach (var r in query)
                    {
                        _accountRList.Rows.Add(new object[] { r.Id, r.Code, r.Description });
                    }
                }
                return _accountRList;
            }
        }
        int indexRowChange=-1;
        int indexRowAccount = -1;
        int indexRowAccountR = -1;
        DataGridViewComboBoxColumn columnAD;
        DataGridViewComboBoxColumn columnAR;
        int AccountIdDtChange;
        int AccountIdDtChangeR;
        public AccountClauseControl()
        {
            InitializeComponent();

            BindingSource dbSource = new BindingSource();

            gridAccountClause.ColumnAdded += new DataGridViewColumnEventHandler(gridAccountClause_ColumnAdded);
            gridAccountClause.SaveChange += new Components.AutoGrid.SaveChangeHandler(gridAccountClause_SaveChange);
            gridAccountClause.CellEnter += new DataGridViewCellEventHandler(gridAccountClause_CellEnter);

            DataGridViewComboBoxColumn ColumnProceduceType = new DataGridViewComboBoxColumn();
            ColumnProceduceType.DataPropertyName = "ProceduceType_Id";
            ColumnProceduceType.HeaderText = "Loại Chứng từ";
            ColumnProceduceType.Width = 120;
            ColumnProceduceType.DataSource = proceduceType;
            ColumnProceduceType.ValueMember = "Id";
            ColumnProceduceType.DisplayMember = "Description";
            ColumnProceduceType.Name = "ProceduceType";
            ColumnProceduceType.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            ColumnProceduceType.FlatStyle = FlatStyle.Flat;

            dbSource.DataSource = accountClauseService.GetAllWithAccountClauseModel().ToList();
            gridAccountClause.DataSource = dbSource;

            gridAD.ColumnAdded+=new DataGridViewColumnEventHandler(ColumnAdded);

            tbAccountDebts = new DataTable();
            tbAccountDebts.Columns.Add("Id");
            tbAccountDebts.Columns.Add("Description");
            gridAD.DataSource = tbAccountDebts;
            columnAD = new DataGridViewComboBoxColumn();
            columnAD.DataPropertyName = "Id";
            columnAD.HeaderText = "Tài khoản";
            columnAD.Width = 120;
            columnAD.DataSource = accountList;
            columnAD.ValueMember = "Id";
            columnAD.DisplayMember = "Code";
            columnAD.Name = "ComboAccount";
            columnAD.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            columnAD.FlatStyle = FlatStyle.Flat;
            columnAD.DefaultCellStyle.DataSourceNullValue = -1;
            columnAD.DefaultCellStyle.NullValue = "[Chọn tài khoản]";
            columnAD.ValueType = typeof(int);
            gridAD.AddComboColumn(columnAD);
            columnAD.DisplayIndex = 0;

            gridAD.ComboBoxIndexChanged += new Components.GridComboBox.ComboBoxIndexChangedHandler(gridAD_ComboBoxIndexChanged);
            gridAD.CellEnter+=new DataGridViewCellEventHandler(gridAD_CellEnter);
            gridAD.CellValueChanged+=new DataGridViewCellEventHandler(gridAD_CellValueChanged);

            // init grid accountreceivable gridAR
            gridAR.ColumnAdded += new DataGridViewColumnEventHandler(ColumnAdded);

            tbAccountRecs = new DataTable();
            tbAccountRecs.Columns.Add("Id");
            tbAccountRecs.Columns.Add("Description");
            gridAR.DataSource = tbAccountRecs;
            columnAR = new DataGridViewComboBoxColumn();
            columnAR.DataPropertyName = "Id";
            columnAR.HeaderText = "Tài khoản";
            columnAR.Width = 120;
            columnAR.DataSource = accountList;
            columnAR.ValueMember = "Id";
            columnAR.DisplayMember = "Code";
            columnAR.Name = "ComboAccount";
            columnAR.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            columnAR.FlatStyle = FlatStyle.Flat;
            columnAR.DefaultCellStyle.DataSourceNullValue = -1;
            columnAR.DefaultCellStyle.NullValue = "[Chọn tài khoản]";
            columnAR.ValueType = typeof(int);
            gridAR.AddComboColumn(columnAR);
            columnAR.DisplayIndex = 0;

            gridAR.ComboBoxIndexChanged += new Components.GridComboBox.ComboBoxIndexChangedHandler(gridAR_ComboBoxIndexChanged);
            gridAR.CellEnter += new DataGridViewCellEventHandler(gridAR_CellEnter);
            gridAR.CellValueChanged += new DataGridViewCellEventHandler(gridAR_CellValueChanged);
        }
        void gridAD_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            if (gridAD.GridChangeStyle == GridChangeStyle.ComboBox)
                return;
            gridAD.IsTextChanged = true;
            indexRowAccount = e.RowIndex;
            gridAD.GridChangeStyle = GridChangeStyle.Text;
        }
        void gridAR_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            if (gridAR.GridChangeStyle == GridChangeStyle.ComboBox)
                return;
            gridAR.IsTextChanged = true;
            indexRowAccountR = e.RowIndex;
            gridAR.GridChangeStyle = GridChangeStyle.Text;
        }
        void gridAD_ComboBoxIndexChanged(object sender, EventArgs e) {
            AccountClauseControl_SelectedIndexChanged(sender, e);
        }
        protected void gridAD_CellEnter(object sender, DataGridViewCellEventArgs e) {
            if (indexRowAccount != e.RowIndex && indexRowAccount!=-1)
            {
                if (gridAD.GridChangeStyle == GridChangeStyle.ComboBox)
                {
                    SaveAccountDetail(indexRowAccount, sender as DataGridView,"N");
                }
                else if (gridAD.GridChangeStyle == GridChangeStyle.Text) {
                    UpdateAccountDetail(indexRowAccount, sender as DataGridView);
                }
                gridAD.GridChangeStyle = GridChangeStyle.None;
                AccountIdDtChange = -1;
                indexRowAccount = -1;
            }
        }
        void gridAR_CellEnter(object sender, DataGridViewCellEventArgs e) {
            if (indexRowAccountR != e.RowIndex && indexRowAccountR != -1)
            {
                if (gridAR.GridChangeStyle == GridChangeStyle.ComboBox)
                {
                    SaveAccountDetail(indexRowAccountR, sender as DataGridView,"C");
                }
                else if (gridAR.GridChangeStyle == GridChangeStyle.Text)
                {
                    UpdateAccountDetail(indexRowAccountR, sender as DataGridView);
                }
                gridAR.GridChangeStyle = GridChangeStyle.None;
                AccountIdDtChangeR = -1;
                indexRowAccountR = -1;
            }
        }
        void UpdateAccountDetail(int rowindex,DataGridView grid) {
            int accountid = Convert.ToInt32(((DataGridViewRow)grid.Rows[rowindex]).Cells["Id"].Value);
            string description = Convert.ToString(((DataGridViewRow)grid.Rows[rowindex]).Cells["Description"].Value);
            AccountClauseModel clause = (AccountClauseModel)gridAccountClause.CurrentRow.DataBoundItem;

            accountClauseService.UpdateAccountDetail(accountid, clause.Id, "N", description);

            grid.Rows[rowindex].ErrorText = string.Empty;
        }
        protected void SaveAccountDetail(int rowindex,DataGridView grid,string typeCode) {
            try
            {
                int accountid = Convert.ToInt32(((DataGridViewRow)grid.Rows[rowindex]).Cells["Id"].Value);
                string description = Convert.ToString(((DataGridViewRow)grid.Rows[rowindex]).Cells["Description"].Value);

                AccountType ad = accountClauseService.GetAccountType(typeCode);
                SaveAccountClauseDetail(accountid,description,AccountIdDtChange, ad);

                gridAD.CurrentRow.ErrorText = string.Empty;

            }
            catch (UserException ex)
            {
                MessageBox.Show(ex.Message);
                WriteLog.Warnning(this.GetType(), ex);
                grid.CurrentRow.ErrorText = " ";
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorsManager.Error0000);
                WriteLog.Error(this.GetType(), ex);
                grid.CurrentRow.ErrorText = " ";
            }
            
        }
        
        protected void ColumnAdded(object sender,DataGridViewColumnEventArgs e) {
            if (e.Column.Name == "Description")
            {
                e.Column.HeaderText = "Diễn giải";
            }
            else if (e.Column.Name == "ComboAccount") { }
            else
            {
                e.Column.Visible = false;
            }
            
        }
        protected void gridAccountClause_CellEnter(object sender,DataGridViewCellEventArgs e) {
            ChangeGridAccounts(e.RowIndex);
            indexRowChange = e.RowIndex;
            
        }
        protected void ChangeGridAccounts(int indexrow) {
            AccountClauseModel clause = (AccountClauseModel)gridAccountClause.Rows[indexrow].DataBoundItem;
            if (indexrow != indexRowChange && clause!=null)
            {
                ReloadGridAccount(clause.Id);
            }
        }
        protected void ReloadGridAccount(int clauseId) {
            indexRowAccount = -1;
            tbAccountDebts.Clear();
            var list = accountClauseService.GetDetailWithType(clauseId, "N").Select(a => new AccountCombo
            {
                Id = a.Account_Id,
                Description = a.Description
            }).ToList();

            foreach (var r in list)
            {
                tbAccountDebts.Rows.Add(new object[] { r.Id, r.Description });
            }
            gridAD.DataSource = tbAccountDebts;
            gridAD.Columns["Id"].DefaultCellStyle.NullValue="Chon tai khoan";
            gridAD.Columns["Id"].DefaultCellStyle.DataSourceNullValue=-1;

            gridAD.Columns["Description"].DefaultCellStyle.NullValue = "Chon tai khoan";
            gridAD.Columns["Description"].DefaultCellStyle.DataSourceNullValue = -1;

            // set for grid accountreceivable gridAR
            indexRowAccountR = -1;
            tbAccountRecs.Clear();
            var listR = accountClauseService.GetDetailWithType(clauseId, "C").Select(a => new AccountCombo
            {
                Id = a.Account_Id,
                Description = a.Description
            }).ToList();

            foreach (var r in listR)
            {
                tbAccountRecs.Rows.Add(new object[] { r.Id, r.Description });
            }
            gridAR.DataSource = tbAccountRecs;
            gridAR.Columns["Id"].DefaultCellStyle.NullValue = "Chon tai khoan";
            gridAR.Columns["Id"].DefaultCellStyle.DataSourceNullValue = -1;

            gridAR.Columns["Description"].DefaultCellStyle.NullValue = "Chon tai khoan";
            gridAR.Columns["Description"].DefaultCellStyle.DataSourceNullValue = -1;
            
        }
        protected void AdjustGridAccount(DataGridViewCellEventArgs e)
        { 
             
        }
        protected void Account_EditingControlShowing(object sender,DataGridViewEditingControlShowingEventArgs e) {
            if (e.Control is ComboBox) { 
                //((ComboBox)e.Control).SelectedIndexChanged+=new EventHandler(AccountClauseControl_SelectedIndexChanged);
            }
        }
        
        protected void AccountClauseControl_SelectedIndexChanged(object sender, EventArgs e) {

            try
            {
                ComboBox combo = sender as ComboBox;
                DataRowView row = (DataRowView)combo.SelectedItem;
                if (row == null || row.IsEdit == true || Convert.ToInt32(row["Id"]) == -1)
                {
                    return;
                }
                if (ExistAccountInGrid(gridAD, row["Id"])) {
                    gridAD.CurrentRow.ErrorText = " ";
                    //MessageBox.Show(ErrorsManager.Error0000);
                    //gridAD.CurrentRow.ErrorText = string.Empty;
                    //combo.SelectedIndex = gridAD.SelectedIndexBeforce;
                    //gridAD.CurrentRow.Cells["ComboAccount"].Value = ((DataRowView)combo.Items[gridAD.SelectedIndexBeforce])["Id"];
                    return;
                }
                gridAD.CurrentRow.ErrorText = string.Empty;
                indexRowAccount = gridAD.CurrentRow.Index;
                AccountIdDtChange = gridAD.CurrentRow.Cells["Id"].Value!=DBNull.Value?Convert.ToInt32(gridAD.CurrentRow.Cells["Id"].Value):-1;
                gridAD.CurrentRow.Cells["Description"].Value = row["Description"];
                gridAD.CurrentRow.Cells["Id"].Value = row["Id"];
                gridAD.GridChangeStyle = GridChangeStyle.ComboBox;
                

            }
            catch (UserException ex)
            {
                MessageBox.Show(ErrorsManager.Error0000);
                WriteLog.Warnning(this.GetType(), ex);
                gridAD.CurrentRow.ErrorText = " ";
            }
            catch (Exception ex)
            {
                gridAD.CurrentRow.ErrorText = " ";
                MessageBox.Show(ErrorsManager.Error0000);
                WriteLog.Error(this.GetType(), ex);
            }
            
        }
        void gridAR_ComboBoxIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ComboBox combo = sender as ComboBox;
                DataRowView row = (DataRowView)combo.SelectedItem;
                if (row == null || row.IsEdit == true || Convert.ToInt32(row["Id"]) == -1)
                {
                    return;
                }
                if (ExistAccountInGrid(gridAR, row["Id"]))
                {
                    gridAR.CurrentRow.ErrorText = " ";
                    return;
                }
                gridAR.CurrentRow.ErrorText = string.Empty;
                indexRowAccountR = gridAR.CurrentRow.Index;
                AccountIdDtChangeR = gridAR.CurrentRow.Cells["Id"].Value != DBNull.Value ? Convert.ToInt32(gridAD.CurrentRow.Cells["Id"].Value) : -1;
                gridAR.CurrentRow.Cells["Description"].Value = row["Description"];
                gridAR.CurrentRow.Cells["Id"].Value = row["Id"];
                gridAR.GridChangeStyle = GridChangeStyle.ComboBox;


            }
            catch (UserException ex)
            {
                MessageBox.Show(ErrorsManager.Error0000);
                WriteLog.Warnning(this.GetType(), ex);
                gridAR.CurrentRow.ErrorText = " ";
            }
            catch (Exception ex)
            {
                gridAR.CurrentRow.ErrorText = " ";
                MessageBox.Show(ErrorsManager.Error0000);
                WriteLog.Error(this.GetType(), ex);
            }
        }
        bool ExistAccountInGrid(DataGridView grid,object id) { 
            foreach(DataGridViewRow r in grid.Rows){
                if (id.Equals(r.Cells["Id"].Value))
                    return true;
            }
            return false;
        }
        protected void SaveAccountClauseDetail(int accountid,string description,int accountidchange, AccountType accountType)
        {
            AccountClauseModel clause = (AccountClauseModel)gridAccountClause.CurrentRow.DataBoundItem;
            AccountClauseDetail cdetail = new AccountClauseDetail()
            {
                Account_Id = accountid,
                AccountType = accountType,
                Description = description,
                AccountClause_Id = clause.Id

            };
            // delete account is changed
            accountClauseService.DeleteDetail(accountidchange, clause.Id, accountType.Id);
            // save account current
            accountClauseService.addBalanceAccount(cdetail);
        }
        protected void gridAccountClause_SaveChange(object sender, int indexRowChange)
        {
            DataGridView grid = sender as DataGridView;
            try
            {
                AccountClauseModel accountModel = (AccountClauseModel)grid.Rows[indexRowChange].DataBoundItem;
                accountModel.ProceduceType_Id = (int)grid.Rows[indexRowChange].Cells["ProceduceType"].Value;
                AccountClause account = new AccountClause() { 
                    Id=accountModel.Id,
                    Code=accountModel.Code,
                    Description=accountModel.Description,
                    ProceduceType=accountClauseService.GetProceduceType(accountModel.ProceduceType_Id)
                };

                if (account.Id == 0)
                {
                    accountClauseService.addAccountClause(account,account.ProceduceType.Id);
                    accountModel.Id = account.Id;
                }
                else
                {
                    accountClauseService.updateAccountClause(account);
                }
                grid.Rows[indexRowChange].ErrorText = string.Empty;
            }
            catch (UserException ex)
            {
                WriteLog.Warnning(this.GetType(), ex);
                grid.Rows[indexRowChange].ErrorText = " ";
            }
            catch (Exception ex)
            {
                grid.Rows[indexRowChange].ErrorText = " ";
                MessageBox.Show(ErrorsManager.Error0000);
                WriteLog.Error(this.GetType(), ex);
            }
        }
        protected void gridAccountClause_ColumnAdded(object sender,DataGridViewColumnEventArgs e) {

        }

        private void AccountClauseControl_Load(object sender, EventArgs e)
        {
            
        }
    }
    public class AccountCombo {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
    }
}
