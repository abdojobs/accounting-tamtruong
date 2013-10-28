using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AccountingSystem.Components;
using DataAccess.Entities;
using DataAccess.Repositories;
using AccountingSystem.Utils;
using Business.Business.ServiceInterfaces;
using Business.Business;
using Common.Exceptions;
using Common.Messages;
using Common.Logs;

namespace AccountingSystem.Controls
{
    public partial class AccountControl : UserControl
    {
        //BaseConnector Connect;
        IAccountBusiness _accountService;
        int indexChangeLevel1 = -1;
        int indexChangeLevel2 = -1;
        IAccountBusiness accountService {
            get {
                if (_accountService == null)
                    _accountService = new AccountService();
                return _accountService;

            }
        }
        public AccountControl()
        {
            InitializeComponent();
            //Connect=new BaseConnector();
            BindingSource dbSource = new BindingSource();
            gridAccount1.SaveChange +=new AutoGrid.SaveChangeHandler(SaveChange);
            gridAccount2.SaveChange += new AutoGrid.SaveChangeHandler(SaveChangeLevel2);
            gridAccount3.SaveChange += new AutoGrid.SaveChangeHandler(SaveChangeLevel3);
            // listen event cellenter gridAccount1 to load gridAccount2
            gridAccount1.CellEnter+=new DataGridViewCellEventHandler(gridAccount1_CellEnter);

            // listen event cellenter gridAccount2 to load gridAccount3
            gridAccount2.CellEnter += new DataGridViewCellEventHandler(gridAccount2_CellEnter);

            dbSource.DataSource = accountService.GetAll().Where(a=>a.Parent==null).ToList();
            gridAccount1.DataSource = dbSource;

            //gridAccount2.DataSource = Connect.Context.Accounts.GetAll().ToList();
            //gridAccount3.DataSource = Connect.Context.Accounts.GetAll().ToList();
            
        }
        
        protected void gridAccount2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            ChangeGridLevel3(e.RowIndex);
            indexChangeLevel2 = e.RowIndex;
        }
        protected void gridAccount1_CellEnter(object sender,DataGridViewCellEventArgs e) {
            ChangeGridLevel2(e.RowIndex);
            indexChangeLevel1 = e.RowIndex;
            indexChangeLevel2 = -1;
            ChangeGridLevel3(0);
        }
        protected void ChangeGridLevel3(int indexlevel2) {
            Account account = gridAccount2.Rows[indexlevel2].DataBoundItem as Account;
            if (indexlevel2 != indexChangeLevel2 && account != null && account.Id != 0)
            {
                BindingSource dbSource = new BindingSource();
                dbSource.DataSource = accountService.GetChildrenByParentId(account.Id).ToList();
                gridAccount3.DataSource = dbSource;
            }
        }
        protected void ChangeGridLevel2(int indexlevel1) {
            Account account = gridAccount1.Rows[indexlevel1].DataBoundItem as Account;
            if (indexlevel1 != indexChangeLevel1 && account != null && account.Id != 0)
            {
                BindingSource dbSource = new BindingSource();
                dbSource.DataSource = accountService.GetChildrenByParentId(account.Id).ToList();
                gridAccount2.DataSource = dbSource;
            }
        }
        public void SaveChange(object sender,int indexRowChange)
        {
            DataGridView grid = sender as DataGridView;
            try
            {
                Account account = (Account)grid.Rows[indexRowChange].DataBoundItem;
                if (account.Id == 0)
                    addNewAccount(account);
                else
                {
                    updateAccount(account);
                }
                grid.Rows[indexRowChange].ErrorText = string.Empty;
            }
            catch (UserException ex)
            {
                WriteLog.Warnning(this.GetType(),ex);
                grid.Rows[indexRowChange].ErrorText = " ";
            }
            catch (Exception ex) {
                MessageBox.Show(ErrorsManager.Error0000);
                WriteLog.Error(this.GetType(),ex);
            }
        }

        public void SaveChangeLevel2(object sender, int indexRowChange)
        {
            DataGridView grid = sender as DataGridView;
            try
            {
                Account account = (Account)grid.Rows[indexRowChange].DataBoundItem;
                Account accountParent=(Account)gridAccount1.Rows[indexChangeLevel1].DataBoundItem;
                if (account.Id == 0)
                {
                    accountService.addAccountLevel2(accountParent, account);
                }
                else
                {
                    accountService.updateAccountLevel2(accountParent, account);
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
                MessageBox.Show(ErrorsManager.Error0000);
                WriteLog.Error(this.GetType(), ex);
            }
        }

        public void SaveChangeLevel3(object sender, int indexRowChange)
        {
            DataGridView grid = sender as DataGridView;
            try
            {
                Account account = (Account)grid.Rows[indexRowChange].DataBoundItem;
                Account accountParent = (Account)gridAccount2.Rows[indexChangeLevel2].DataBoundItem;
                if (account.Id == 0)
                {
                    accountService.addAccountLevel3(accountParent, account);
                }
                else
                {
                    accountService.updateAccountLevel3(accountParent, account);
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
                MessageBox.Show(ErrorsManager.Error0000);
                WriteLog.Error(this.GetType(), ex);
            }
        } 
       
        protected void addNewAccount(Account account) {
            if (account.Id == 0)
            {
                accountService.addAccountLevel1(account);
                //Connect.Context.Accounts.AddSubmit(account);
            }
        }
        protected void updateAccount(Account account) {
            if (account.Id != 0)
            {
                accountService.updateAccountLevel1(account);
                //Connect.Context.Accounts.UpdateSubmit(account);
            }
        }
    }
}
